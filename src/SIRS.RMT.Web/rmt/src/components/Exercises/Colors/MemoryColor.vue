<template>
    <v-app>
        <v-container fluid>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="11" md="11" lg="10">
                    <v-card outlined>
                        <v-card-title>
                            <v-row justify="center" align="center">
                                Запоминание цветов
                            </v-row>
                        </v-card-title>
                        <v-card-subtitle>
                            <v-row justify="center" align="center">
                                СИРС
                            </v-row>
                        </v-card-subtitle>
                        <v-divider />
                        <v-window v-model="menuOption.step" touchless>
                            <v-window-item :value="1">
                                <StartMenu @closeExercise="closeExercises"
                                           @startDiagnostic="startDiagnostic"
                                           @startTraining="startTraining"
                                           @openStatistic="openStatistic" />
                            </v-window-item>
                            <v-window-item :value="2">
                                <SetColors :can-change-level="exercisesPreferences.canChangeLevel"
                                           :set-level-colors="exercisesPreferences.setLevelColors"
                                           @prev="menuOption.step=1"
                                           @startExercise="startExercise" />
                            </v-window-item>
                            <v-window-item :value="3">
                                <Trainer :time-remembering="exercisesPreferences.timeRemembered"
                                         :current-colors="exercisesPreferences.currentColors"
                                         :available-colors="exercisesPreferences.availableColors"
                                         :count-click="exercisesPreferences.countClick"
                                         @iFinished="openResult" />
                            </v-window-item>
                            <v-window-item :value="4">
                                <Result @Runaway="openStartMenu" />
                            </v-window-item>
                            <v-window-item :value="5">
                                <Statistic @close="openStartMenu" />
                            </v-window-item>
                        </v-window>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
        <v-overlay v-model="menuOption.loadingData">
            <v-progress-circular indeterminate size="64"></v-progress-circular>
        </v-overlay>
    </v-app>
</template>

<script>

    import StartMenu from "./MenuItems/StartMenu";
    import SetColors from "./MenuItems/SetColors";
    import Trainer from "./MenuItems/Trainer";
    import Result from "./MenuItems/Result";
    import Statistic from "./MenuItems/Statistic";

    export default {
        data: () => ({
            menuOption: {
                step: 1, /* Для перехода между <v-window-item/> */
                loadingData: true,
            },

            exercisesPreferences: {
                setLevelColors: [], /* Список доступных уровней для пользователя */
                currentUserLevel: 1, /* Текущий уровень пользователя в режиме тренинга */
                canChangeLevel: true, /* Может ли пользователь менять уровень */
                timeRemembered: 10,
                currentColors: {},
                availableColors: {},
                countClick: 0
            },
        }),

        mounted() {
            this.$store.dispatch('setAvailableLevels').then(() => {
                this.exercisesPreferences.setLevelColors = this.$store.getters.getAvailableLevels;
                this.$store.dispatch('getAvailableColors').then(() => {
                    this.exercisesPreferences.availableColors = this.$store.getters.getAvailableColors;
                })
                this.menuOption.loadingData = false;

            }).catch(() => {
                this.$router.push({ name: "Exercises" });
            });
            this.$store.dispatch('setUserCurrentLevel');
            this.exercisesPreferences.currentUserLevel = this.$store.getters.getUserCurrentLevel;
        },

        methods: {
            closeExercises: function () {
                this.$router.push({ name: 'Exercises' })
            },

            openStartMenu: function () {
                this.menuOption.step = 1;
            },

            startDiagnostic: function () {
                let currentDefaultLevel = 10;
                this.$store.dispatch('setCurrentLevel', { level: currentDefaultLevel });
                this.exercisesPreferences.canChangeLevel = false;
                this.menuOption.step = 2
            },

            startTraining: function (currentLevel) {
                if (currentLevel) {
                    this.$store.dispatch('setCurrentLevel', { level: currentLevel });
                }
                this.exercisesPreferences.canChangeLevel = true;
                this.menuOption.step = 2
            },

            openResult: function () {
                this.menuOption.step = 4;
            },
            openStatistic: function () {
                this.menuOption.step = 5;
            },

            startExercise: function () {
                let currentLevel = this.$store.getters.getCurrentLevel
                let levelType = this.$store.getters.getTypeExercise

                if (levelType === 0) {
                    this.$store.dispatch('getDiagnosticExerciseColors').then(() => {
                        this.exercisesPreferences.currentColors = this.$store.getters.getExerciseColors;
                        this.exercisesPreferences.timeRemembered = this.$store.getters.getTimeRemembering;
                        this.exercisesPreferences.countClick++;
                        this.menuOption.step = 3;
                    }).catch(() => {
                        this.$router.push({ name: "Exercises" });
                    });
                }
                if (levelType === 1) {
                    this.$store.dispatch('getTrainingExerciseColors', { count: currentLevel }).then(() => {
                        this.exercisesPreferences.currentColors = this.$store.getters.getExerciseColors;
                        this.exercisesPreferences.timeRemembered = this.$store.getters.getTimeRemembering;
                        this.exercisesPreferences.countClick++;
                        this.menuOption.step = 3;
                    }).catch(() => {
                        this.$router.push({ name: "Exercises" });
                    });
                }
            },
        },
        components: {
            Statistic,
            Result,
            SetColors,
            Trainer,
            StartMenu,
        }
    }
</script>
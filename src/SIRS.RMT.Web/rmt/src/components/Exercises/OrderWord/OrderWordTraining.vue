<template>
    <v-app>
        <v-container fluid>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="11" md="11" lg="10">
                    <v-card outlined>
                        <v-card-title>
                            <v-row justify="center" align="center">
                                Тренинг
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
                                <StartMenu @closeExercise="openResult"
                                           @startExercise="startExercise" />
                            </v-window-item>
                            <v-window-item :value="2">
                                <!--<Trainer @stopExercise="menuOption.step = 3"
                                :click="click" />-->
                                <Trainer @stopExercise="stopExercise"
                                         @openResult="openResult"
                                         :click="click" />
                            </v-window-item>
                            <v-window-item :value="3">
                                <Result @close="menuOption.step=1" />
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
    import StartMenu from "./MenuItemsTraining/StartMenu";
    import Trainer from "./MenuItemsTraining/Trainer";
    import Result from "./MenuItemsTraining/Result";
    export default {
        name: "OrderWordTraining",
        components: {
            Result,
            Trainer,
            StartMenu
        },
        data: () => ({
            menuOption: {
                step: 1, /* Для перехода между <v-window-item/> */
                loadingData: false,
            },
            click: 0
        }),

        methods: {
            startExercise: function (credential) {
                this.$store.dispatch('setPreferences', credential).then(() => {
                    this.$store.dispatch('getExercise', credential.countWords).then(() => {
                        this.click++;
                        this.menuOption.step = 2;
                    }).catch(error => {
                        window.console.error(error)
                    })
                })
            },
            //stopExercise() {
            //    console.log("stopExercise");
            //    // Выполнение необходимых действий при остановке упражнения
            //    //this.$emit('stopExercise'); // Генерация события stopExercise
            //    this.menuOption.step = 3;  // Transition to Results
            //},
            stopExercise() {
                console.log('stopExercise called'); // New log
                this.$emit('openResult');
                this.menuOption.step = 3;
            },
            closeExercises: function () {
                console.log("closeExercises");
                this.$router.push('/memory/orderWords')
            },
            openResult: function () {
                console.log("openResult");
                this.menuOption.step = 3;
                this.$emit('stopExercise');
            }
        }
    }
</script>

<style scoped>
</style>
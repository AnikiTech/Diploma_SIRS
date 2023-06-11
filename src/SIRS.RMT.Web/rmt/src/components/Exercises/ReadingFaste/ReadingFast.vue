<template>
    <v-app>
        <v-container fluid>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="11" md="11" lg="10">
                    <v-card outlined>
                        <v-card-title>
                            <v-row justify="center" align="center">
                                Быстрое чтение
                            </v-row>
                        </v-card-title>
                        <v-divider />
                        <v-window v-model="menuOption.step" touchless>
                            <v-window-item :value="1">
                                <StartMenu
                                        @closeExercise="closeExercises"
                                        @startDiagnostic="startDiagnostic"
                                        @startTraining="startTraining"
                                />
                            </v-window-item>
                            <v-window-item :value="2">
                                <GetTextTraining
                                        @startTrainingReadText="menuOption.step=4"
                                />
                            </v-window-item>
                            <v-window-item :value="3">
                                <GetTextDiagnostic
                                        @startDiagnosticReadText="menuOption.step=5"
                                />
                            </v-window-item>
                            <v-window-item :value="4">
                                <TrainingTrainer
                                        @continueReading="startTraining"
                                        @stopReading="menuOption.step=1"
                                />
                            </v-window-item>
                            <v-window-item :value="5">
                                <DiagnosticTrainer
                                        :click="click"
                                        @stopExerciseQuiz="menuOption.step=1"
                                />
                            </v-window-item>
                            <v-window-item :value="6">
                            </v-window-item>
                        </v-window>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </v-app>
</template>

<script>
    import StartMenu from "../ReadingFaste/MenuItems/StartMenu";
    import GetTextTraining from "./MenuItems/GetTextTraining";
    import TrainingTrainer from "./MenuItems/TrainingTrainer";
    import GetTextDiagnostic from "./MenuItems/GetTextDiagnostic";
    import DiagnosticTrainer from "./MenuItems/DiagnosticTrainer";
    export default {
        name: "ReadingFast",
        components: {DiagnosticTrainer, GetTextDiagnostic, TrainingTrainer, GetTextTraining, StartMenu},
        data: function () {
            return {
                menuOption: {
                    step: 1
                },

                click: 0
            }
        },

        methods: {
            closeExercises: function () {
                this.$router.push({name: 'Exercises'})
            },
            startTraining: function () {
                this.$store.dispatch('setExerciseMode', 1).then(() => {
                    this.$store.dispatch('setExerciseTrainingTexts').then(() => {
                        this.click ++;
                        this.menuOption.step = 2;
                    })
                });
            },
            startDiagnostic: function () {
                this.$store.dispatch('setExerciseMode', 0).then(() => {
                    this.$store.dispatch('setExerciseDiagnosticTexts').then(() => {
                        this.click ++;
                        this.menuOption.step = 3;
                    })
                });
            }
        }
    }
</script>

<style scoped>

</style>
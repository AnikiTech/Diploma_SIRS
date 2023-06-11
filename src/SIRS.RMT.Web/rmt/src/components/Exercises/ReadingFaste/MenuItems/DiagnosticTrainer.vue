<template>
    <div>
        <v-card-actions>
            <v-row justify="center" align="center">
                <v-icon>mdi-timer-outline</v-icon>{{formatTimer(pageOption.timeReading)}}
            </v-row>
        </v-card-actions>
        <v-divider></v-divider>
        <v-window touchless v-model="menuOption.step">
            <v-window-item :value="1">
                <v-card-actions>
                    <v-row justify="center" align="center">
                        <v-col cols="12" sm="11" md="11" lg="10">
                            <div>
                                {{getExerciseDiagnosticText.text}}
                            </div>
                        </v-col>
                    </v-row>
                </v-card-actions>
                <v-divider></v-divider>
                <v-card-actions>
                    <v-row justify="center" align="center">
                        <v-col cols="12" sm="11" md="11" lg="10">
                            <v-btn block outlined color="primary" @click="showMessage = !showMessage">Закончить</v-btn>
                        </v-col>
                    </v-row>
                </v-card-actions>
            </v-window-item>
            <v-window-item :value="2">
                <v-card-actions>
                    <v-row justify="center" align="center">
                        <v-col cols="12" sm="10" md="10" lg="10">
                            <!--<v-card outlined>
                                <v-card-actions>
                                    <v-row justify="center" align="center">
                                        Количество верных ответов: {{ countAnswersIsValid }}
                                    </v-row>
                                </v-card-actions>
                            </v-card>-->
                            <v-window touchless
                                      v-model="answerStep"
                                      vertical
                            >
                                <v-window-item
                                        v-for="(question, index) of getExerciseDiagnosticText.questions" :key="index"
                                        :value="index"
                                >
                                    <v-card outlined>
                                        <v-card-actions>
                                            <v-row justify="center" align="center">
                                                <p>{{ question.text }}</p>
                                            </v-row>
                                        </v-card-actions>
                                        <v-card-actions>
                                            <v-row justify="center" align="center">
                                                <v-col cols="12" sm="12"
                                                       v-for="(answer) in question.answers " :key="answer.id"
                                                >
                                                    <v-btn block outlined color="primary" @click="checkAnswer(answer.isTrue)">{{ answer.text }}</v-btn>
                                                </v-col>
                                            </v-row>
                                        </v-card-actions>
                                    </v-card>
                                </v-window-item>
                                <v-window-item :value="10">
                                    <v-card outlined>
                                        <v-card-actions>
                                            <v-row justify="center" align="center">
                                                <v-col cols="12" sm="8">
                                                    <v-simple-table>
                                                        <thead>
                                                        <tr>
                                                        </tr>
                                                        </thead>
                                                        <tbody>
                                                        <tr>
                                                            <td>Коэффициент понимания</td>
                                                            <td>
                                                                {{ countAnswersIsValid }}
                                                                ({{ getPercent(countAnswersIsValid, 10) }}%)
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Скорость чтения (слов / мин)</td>
                                                            <td>{{ readingSpeed(getExerciseDiagnosticText.countWord) }}</td>
                                                        </tr>

                                                        </tbody>
                                                    </v-simple-table>
                                                </v-col>
                                            </v-row>
                                        </v-card-actions>
                                        <v-card-actions>
                                            <v-row justify="center" align="center">
                                                <v-col cols="12" sm="8">
                                                    <v-btn outlined block color="primary" @click="stopExerciseQuiz">Закончить</v-btn>
                                                </v-col>
                                            </v-row>
                                        </v-card-actions>
                                    </v-card>
                                </v-window-item>
                            </v-window>
                        </v-col>
                    </v-row>
                </v-card-actions>
            </v-window-item>
        </v-window>
        <v-dialog v-model="showMessage" max-width="500">
            <v-card>
                <v-card-title>Внимание</v-card-title>
                <v-card-text>Вы хотите закончить чтение?</v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn text color="primary" @click="showMessage = false">Нет</v-btn>
                    <v-btn text color="primary" @click="startQuiz">Да</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>
    import {mapGetters} from "vuex";

    export default {
        name: "DiagnosticTrainer",

        data: () => ({
            showMessage: false,
            answerStep: 0,
            countAnswersIsValid: 0,
            menuOption: {
                step: 1,
            },
            pageOption: {
                timeReading: 0,
                timer: null,
            }
        }),

        computed: {
            ...mapGetters(['getExerciseDiagnosticText'])
        },

        watch: {

            click() {
                this.answerStep = 0;
                this.countAnswersIsValid = 0;
                this.menuOption.step = 1;
                this.pageOption.timeReading = 0
                this.startTimer()
            }
        },

        mounted() {
            this.answerStep = 0;
            this.countAnswersIsValid = 0;
            this.menuOption.step = 1;
            this.pageOption.timeReading = 0
            this.startTimer()
        },

        methods: {
            readingSpeed: function (countWord) {
                return ( countWord / ( this.pageOption.timeReading / 60) ) * this.countAnswersIsValid / 10
            },
            startQuiz: function () {
                this.showMessage = false;
                this.menuOption.step = 2;
                this.stopTimer();
            },

            stopExerciseQuiz: function () {
                this.$emit("stopExerciseQuiz")
            },

            checkAnswer: function (answer) {
                this.answerStep++;
                if (answer) {
                    this.countAnswersIsValid++;
                }
            },
            startTimer() {
                this.pageOption.timer = setInterval(() => {
                    this.pageOption.timeReading++;
                }, 1000);
            },
            stopTimer(){
                clearTimeout(this.pageOption.timer);
            },

            formatTimer: function (times) {
                let sec_num = parseInt(times, 10);
                let hours = Math.floor(sec_num / 3600);
                let minutes = Math.floor((sec_num - (hours * 3600)) / 60);
                let seconds = sec_num - (hours * 3600) - (minutes * 60);

                if (minutes < 10) { minutes = "0" + minutes; }
                if (seconds < 10) { seconds = "0" + seconds; }
                return minutes + ':' + seconds;
            },

            getPercent: function (num1, num2) {
                return num1 / num2 * 100;
            }
        },

        props: {
            click: {}
        }
    }
</script>

<style scoped>

</style>
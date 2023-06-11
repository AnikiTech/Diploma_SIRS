<template>
    <div>
        <template v-if="pageOption.showWord">
            <v-card-actions>
                <v-row justify="center" align="center" style="margin-top: 3px; margin-bottom: 3px">
                    <v-icon>mdi-timer-outline</v-icon>{{formatTimer(exercise.timeRemembering)}}
                </v-row>
            </v-card-actions>
            <v-divider />
            <v-card-actions>
                <v-row justify="center" align="center" style="margin-top: 3px; margin-bottom: 3px">
                    Запомните эти слова
                </v-row>
            </v-card-actions>
            <v-divider />
            <v-card-actions>
                <v-container grid-list-md text-xs-center>
                    <v-row justify="center" align="center">
                        <v-col cols="12" sm="6" md="6" wrap>
                            <v-row justify="center"
                                   align="center"
                                   dense
                                   v-for="(word) of exercise.words" :key="word">
                                <v-col cols="12" sm="12">
                                    <v-card outlined>
                                        <v-card-title>
                                            <v-row justify="center" align="center" style="margin: fill">
                                                {{ word }}
                                            </v-row>
                                        </v-card-title>
                                    </v-card>
                                </v-col>
                                <v-spacer />
                            </v-row>
                        </v-col>
                    </v-row>
                </v-container>
            </v-card-actions>
            <v-divider />
            <v-card-actions>
                <v-row justify="center" align="center">
                    <v-col cols="12" sm="6" md="6" wrap>
                        <v-btn outlined
                               block
                               color="primary"
                               @click="startTraining">
                            Начать
                        </v-btn>
                    </v-col>
                </v-row>
            </v-card-actions>
        </template>

        <template v-else>
            <v-card-actions>
                <v-row justify="center" align="center" style="margin-top: 3px; margin-bottom: 3px">
                    Заполните слова
                </v-row>
            </v-card-actions>
            <v-divider />
            <v-card-actions>
                <v-row>
                    <v-col cols="6" sm="6">
                        <v-card outlined>
                            <v-card-title>
                                <v-row justify="center" align="center">
                                    Перенесите слова отсюда
                                </v-row>
                            </v-card-title>
                            <v-divider />
                            <v-card-actions>
                                <v-container grid-list-md text-xs-center>
                                    <v-row justify="center" align="center">
                                        <v-col cols="12" sm="6" md="6" wrap>
                                            <draggable v-model="exercise.answerWords" group="word">
                                                <v-row justify="center"
                                                       align="center"
                                                       dense
                                                       v-for="(word) of exercise.answerWords" :key="word">
                                                    <v-col cols="12" sm="12">
                                                        <v-card outlined>
                                                            <v-card-title>
                                                                <v-row justify="center" align="center" style="margin: fill">
                                                                    {{ word }}
                                                                </v-row>
                                                            </v-card-title>
                                                        </v-card>
                                                    </v-col>
                                                    <v-spacer />
                                                </v-row>
                                            </draggable>
                                        </v-col>
                                    </v-row>
                                </v-container>
                            </v-card-actions>
                        </v-card>
                    </v-col>
                    <v-spacer></v-spacer>
                    <v-col cols="6" sm="6">
                        <v-card outlined>
                            <v-card-title>
                                <v-row justify="center" align="center">
                                    Перенесите слова сюда
                                </v-row>
                            </v-card-title>
                            <v-divider />
                            <v-card-actions>
                                <v-container grid-list-md text-xs-center>
                                    <v-row justify="center" align="center">
                                        <v-col cols="12" sm="6" md="6" wrap>
                                            <draggable v-model="userAnswer" group="word">
                                                <v-row justify="center"
                                                       align="center"
                                                       dense
                                                       v-for="(word, index) of userAnswer" :key="word">
                                                    <v-col cols="12" sm="12">
                                                        <v-card outlined>
                                                            <v-card-title>
                                                                <v-row justify="center" align="center" style="margin: fill">
                                                                    {{index = index + 1}} - {{word}}
                                                                </v-row>
                                                            </v-card-title>
                                                        </v-card>
                                                    </v-col>
                                                    <v-spacer />
                                                </v-row>
                                            </draggable>
                                        </v-col>
                                    </v-row>
                                </v-container>
                            </v-card-actions>
                        </v-card>
                    </v-col>
                </v-row>
            </v-card-actions>
            <v-divider />
            <v-card-actions>
                <v-row justify="center" align="center">
                    <v-col cols="12" sm="6" md="6" wrap>
                        <v-btn outlined
                               block
                               color="primary"
                               @click="closeExercise">
                            Закончить
                        </v-btn>
                    </v-col>
                </v-row>
            </v-card-actions>
        </template>
    </div>
</template>

<script>

    import draggable from 'vuedraggable';
    import { sendStatistic } from "../../../../api/wordExercise/statistic";

    export default {
        name: "Trainer",
        components: {
            draggable
        },
        data: () => ({
            exercise: {
                timeRemembering: {},
                words: {},
                answerWords: {},
            },
            userAnswer: [],

            pageOption: {
                timer: null,
                showWord: true
            }
        }),
        watch: {
            'exercise.timeRemembering': function (time) {
                if (time === 0) {
                    this.stopTimer();
                }
            },
            click() {
                this.userAnswer = [];
                this.pageOption.showWord = true
                this.exercise = this.$store.getters.getExercise;
                this.startTimer()
            }
        },
        mounted() {
            this.userAnswers = []
            this.pageOption.showWords = true
            this.exercise = this.$store.getters.getExercise;
            this.startTimer()
        },
        methods: {
            startTimer() {
                this.pageOption.timer = setInterval(() => {
                    this.exercise.timeRemembering--;
                }, 1000);
            },
            stopTimer() {
                clearTimeout(this.pageOption.timer);
                this.pageOption.showWord = false
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
          closeExercise: function () {
            console.log('closeExercise started'); // New log
            this.$store.dispatch('sendExercise', {
              words: this.exercise.words,
              userAnswer: this.userAnswer,
            }).then(() => {
              console.log('sendExercise dispatched'); // New log
              this.$store.dispatch('setUserAnswer', {
                    userAnswer: this.userAnswer,
                    words: this.exercise.words
                  },
                  sendStatistic({
                    correctAnswersCount: this.getUserAnswersWords,
                    time: 10//this.$store.getters.getTypeExercise ? 60 : 10
                    //ExerciseType: this.$store.getters.getTypeExercise
                  })

              ).then(() => {
                console.log('setUserAnswer dispatched'); // New log
                this.$emit('openResult')
              })
            })
          },

            startTraining: function () {
                this.pageOption.showWord = false
                this.stopTimer();
            }
        },
        props: {
            click: {}
        }
    }
</script>

<style scoped>
</style>
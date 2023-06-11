<template>
    <div>
        <v-card-actions>
            <v-row justify="center" align="center" style="margin-top: 3px; margin-bottom: 3px">
                Количество правильных ответов: {{getResult.points}}
            </v-row>
        </v-card-actions>
        <v-divider />
        <v-card-actions>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="10">
                    <v-row>
                        <v-col cols="6" sm="6">
                            <v-card outlined>
                                <v-card-title>
                                    <v-row justify="center" align="center">
                                        Изначальный порядок
                                    </v-row>
                                </v-card-title>
                                <v-divider />
                                <v-card-actions>
                                    <v-container grid-list-md text-xs-center>
                                        <v-row justify="center" align="center">
                                            <v-col cols="12" sm="6" md="6" wrap>
                                                <v-row justify="center"
                                                       align="center"
                                                       dense
                                                       v-for="(word) of getExerciseData.words" :key="word">
                                                    <v-col cols="12" sm="12">
                                                        <v-card outlined>
                                                            <v-card-title>
                                                                <v-row justify="center" align="center">
                                                                    {{word}}
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
                            </v-card>
                        </v-col>
                        <v-spacer></v-spacer>
                        <v-col cols="6" sm="6">
                            <v-card outlined>
                                <v-card-title>
                                    <v-row justify="center" align="center">
                                        Ваш ответ
                                    </v-row>
                                </v-card-title>
                                <v-divider />
                                <v-card-actions>
                                    <v-container grid-list-md text-xs-center>
                                        <v-row justify="center" align="center">
                                            <v-col cols="12" sm="6" md="6" wrap>
                                                <v-row justify="center"
                                                       align="center"
                                                       dense
                                                       v-for="(word, index) of getExerciseData.answerWords" :key="word">
                                                    <v-col cols="12" sm="12">
                                                        <v-card outlined
                                                                :color="getColor(getResult.markTrueAnswers[index])">
                                                            <v-card-title>
                                                                <v-row justify="center" align="center">
                                                                    {{index = index + 1}} - {{word}}
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
                            </v-card>
                        </v-col>
                    </v-row>
                </v-col>
                <v-col cols="12" sm="10">
                    <v-card-actions outlined>
                        <v-btn outlined block large color="primary" @click="Runaway(); close();">Закончить</v-btn>
                    </v-card-actions>
                </v-col>
            </v-row>
        </v-card-actions>
    </div>
</template>

<script>
    import { mapGetters } from "vuex";
    import { sendStatistic } from "../../../../api/wordExercise/statistic";

    export default {
        name: "Result",

        computed: {
            ...mapGetters(['getResult', 'getExerciseData'])
        },

        methods: {
            //Runaway: function () {
            //    sendStatistic({
            //      questionsCount: this.$store.getters.getExerciseData.words.length,
            //      correctAnswerCount: this.$store.getters.getExerciseData.answerWords,
            //  })
            //  this.$emit('Runaway');
            //},
            Runaway: function () {
                sendStatistic({
                    questionsCount: this.$store.getters.getExerciseData.words.length,
                    correctAnswerCount: this.$store.getters.getExerciseData.answerWords,
                    type: 0
                    //time:,
                    //date:,
                })
                this.$emit('Runaway');
            },
            getColor: function (flag) {
                if (flag) {
                    return "#3ddc84"
                }
                return 'red';
            },
            close: function () {
                //this.$emit('close')
                this.$router.push('/memory/orderWords')
            }
        }
    }
</script>

<style scoped>
</style>
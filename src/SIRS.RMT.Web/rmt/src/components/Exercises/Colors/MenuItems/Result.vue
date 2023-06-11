<template>
    <v-card-actions>
        <v-row justify="center" align="center">
            <v-col cols="12" sm="8">
                <v-simple-table v-if="getUserAnswers">
                    <thead>
                        <tr>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Количество верных ответов</td>
                            <td>
                                {{ getUserAnswers.countValidAnswer }}
                                ({{ getPercent(getUserAnswers.countValidAnswer, this.$store.getters.getCurrentLevel).toFixed() }}%)
                            </td>
                        </tr>
                        <tr>
                            <td>Количество неправильных ответов</td>
                            <td>{{ getUserAnswers.countInvalidAnswer }}</td>
                        </tr>

                    </tbody>
                </v-simple-table>
                <v-card-actions v-else>
                    <v-card-text>
                        Вы видимо еще не прошли упражнение!
                    </v-card-text>
                </v-card-actions>
                <v-card-actions>
                    <v-btn block outlined color="primary" @click="Runaway">Вернуться в главное меню</v-btn>
                </v-card-actions>
            </v-col>
        </v-row>
    </v-card-actions>
</template>

<script>
    import { mapGetters } from "vuex";
    import { sendStatistic } from "../../../../api/colorsExercise/statistic";

    export default {
        name: "Result",

        data: () => ({
            resultData: {}
        }),

        computed: {
            ...mapGetters(['getUserAnswers'])
        },

        methods: {
            // Colors
            Runaway: function () {
                sendStatistic({
                    ColorsSet: this.$store.getters.getCurrentLevel,
                    TrueAnswers: this.getUserAnswers.countValidAnswer,
                    TimeSeconds: this.$store.getters.getTypeExercise ? 60 : 10,
                    ExerciseType: this.$store.getters.getTypeExercise
                })
                this.$emit('Runaway');
            },

            getPercent: function (num1, num2) {
                return num1 / num2 * 100;
            }
        }
    }
</script>

<style scoped>
</style>
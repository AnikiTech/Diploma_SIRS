<template>
    <v-app>
        <v-container fluid>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="11" md="11" lg="10">
                    <v-card outlined>
                        <v-card-title>
                            <v-row justify="center" align="center">
                                Порядок слов
                            </v-row>
                        </v-card-title>
                        <v-card-subtitle>
                            <v-row justify="center" align="center">
                                СИРС
                            </v-row>
                        </v-card-subtitle>
                        <v-divider />
                        <v-card-actions>
                            <v-row justify="center" align="center">
                                <v-col cols="12" sm="8">
                                    <v-btn outlined block large color="primary" @click="openDiagnostic">Диагностика</v-btn>
                                </v-col>
                                <v-col cols="12" sm="8">
                                    <v-btn outlined block large color="primary" @click="openTraining">Тренинг</v-btn>
                                </v-col>
                                <v-col cols="12" sm="8">
                                    <v-btn outlined block large color="primary" @click="openStatistic">Статистика</v-btn>
                                </v-col>
                                <v-col cols="12" sm="8">
                                    <v-btn outlined block large color="primary" @click="close">Выход</v-btn>
                                </v-col>
                            </v-row>
                        </v-card-actions>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </v-app>
</template>

<script>
    export default {
        name: "WordsMenu",
        data: () => ({
        }),

        methods: {
            close: function () {
                this.$router.push('/exercises')
            },
            openDiagnostic: function () {
                this.$router.push('/memory/orderWords/diagnostic')
            },
            openTraining: function () {
                this.$router.push('/memory/orderWords/training')
            },
            openStatistic: function () {
                this.$router.push('/memory/orderWords/statistic')
            }
        }
    }
</script>

<style scoped>

</style>
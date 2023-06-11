<template>
    <div>
        <v-card-actions>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="10">
                    <v-data-table
                            :headers="headers"
                            :items="getColorStatistic"
                            class="elevation-1"
                    >
                        <template v-slot:item.exerciseType="{ item }">
                            {{getTypeExercise(item.exerciseType)}}
                        </template>
                        <template v-slot:item.date="{ item }">
                            {{new Date(item.date).toLocaleString("ru-RU", {timeZone: 'Asia/Novosibirsk'})}}
                        </template>
                        <template v-slot:item.rawPercent="{ item }">
                            <v-chip :color="getColor(item.rawPercent)" dark>{{ item.rawPercent.toFixed() }}</v-chip>
                        </template>
                    </v-data-table>
                </v-col>
            </v-row>
        </v-card-actions>
        <v-card-actions>
            <v-row>
                <v-col cols="6" sm="6">
                    <v-btn outlined block large color="primary" @click="showDialog = !showDialog">Экспорт данных</v-btn>
                </v-col>
                <v-spacer></v-spacer>
                <v-col cols="6" sm="6">
                    <v-btn outlined block large color="primary" @click="close">Выход</v-btn>
                </v-col>
            </v-row>
            <v-dialog v-model="showDialog" scrollable max-width="500">
                <v-card outlined>
                    <v-card-title>Экспорт данных</v-card-title>
                    <v-card-text>Выберите, в какой формат экспортировать данные</v-card-text>
                    <v-card-actions>
                        <JsonExcel
                                :data="getColorStatistic"
                                :fields="fields"
                                worksheet="Статистика"
                                name="Data Export.xls"
                        >
                            <v-btn outlined block large color="primary">Экспорт в Excel</v-btn>
                        </JsonExcel>
                        <v-spacer/>
                        <JsonExcel
                                :data="getColorStatistic"
                                :meta="json_meta"
                                :fields="fields"
                                type="csv"
                                name="filename.xls"
                        >
                            <v-btn outlined block large color="primary">Экспорт в CSV</v-btn>
                        </JsonExcel>
                    </v-card-actions>
                    <v-divider></v-divider>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn outlined color="primary" @click="showDialog = false">OK</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-card-actions>
    </div>
</template>

<script>

    import JsonExcel from 'vue-json-excel'

    import {mapGetters} from "vuex";

    export default {
        name: "Statistic",
        mounted() {
            // Вызовите действие getWordStatistic из хранилища Vuex
            this.$store.dispatch("getColorStatistic");
        },
        data () {
            return {
                showDialog: false,
                headers: [
                    {text: 'Дата и время прохождения', value: 'date'},
                    { text: 'Тип упражнения', value: 'exerciseType' },
                    { text: 'Время запоминания', value: 'totalTimeStr' },
                    { text: 'Количество цветов', value: 'colorsSet' },
                    { text: 'Правильных ответов', value: 'correctAnswersCount' },
                    { text: 'Оценка', value: 'mark' },
                    { text: 'Имя пользователя', value: 'userLogin' },
                    { text: 'Процент правильных ответов (%)', value: 'rawPercent' },
                    { text: 'Коффицент правильных ответов (%)', value: 'coffPercent' }
                ],
                fields: {
                    "Дата и время прохождения": {
                        field: 'date',
                        callback: (value) => {
                            return new Date(value).toLocaleString("ru-RU", {timeZone: 'Asia/Novosibirsk'});
                        }
                    },
                    "Тип упражнения": {
                        field: 'exerciseType',
                        callback: (value) => {
                            return value ? "Тренинг" : "Диагностика";
                        }
                    },
                    "Время запоминания": 'totalTimeStr',
                    "Количество цветов": 'colorsSet',
                    "Правильных ответов": 'correctAnswersCount',
                    "Оценка": 'mark',
                    "Имя пользователя": 'userLogin',
                    "Процент правильных ответов (%)": {
                        field: 'rawPercent',
                        callback: (value) => { return value.toFixed(3);}
                    },
                },
                json_meta: [
                    [
                        {
                            'key': 'charset',
                            'value': 'cp1251'
                        }
                    ]
                ],
            }
        },

        computed: {
            ...mapGetters(['getColorStatistic'])
        },

        methods: {
            close: function () {
                this.$emit("close")
            },
            getTypeExercise(type) {
                if (type == 0) {
                    return "Диагностика"
                }
                return "Тренинг"
            },
            getColor(percent) {
                if (percent <= 25) {
                    return 'red';
                }
                else if (percent > 25 && percent <= 50) {
                    return 'orange';
                }
                else if (percent > 50) {
                    return 'green';
                }
            },
        },

        components: {
            JsonExcel
        }
    }
</script>

<style scoped>

</style>
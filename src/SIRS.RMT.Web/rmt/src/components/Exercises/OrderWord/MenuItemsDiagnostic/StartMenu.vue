<template>
    <v-card-actions>
        <v-row justify="center" align="center">
            <v-col cols="12" sm="8">
                <v-card outlined>
                    <v-card-actions>
                        <v-select outlined
                                  label="Уровень сложности"
                                  :items="countWords"/>
                                  <!--v-model="defaultCountWord"-->
                    </v-card-actions>
                    <v-divider/>
                    <v-card-actions>
                        <v-list-item>
                            <v-list-item-content>
                                Слов для ответа
                            </v-list-item-content>
                            <v-list-item-action>
                                {{ defaultCountAnswerWord }}
                            </v-list-item-action>
                        </v-list-item>
                    </v-card-actions>
                    <v-divider/>
                    <v-card-actions>
                            <!--<v-list-item disabled>
                                <v-list-item-content>
                                    Произвольное расположение
                                </v-list-item-content>
                                <v-list-item-action>
                                    <v-checkbox hide-details
                                                v-model="randomPosition"
                                    />
                                </v-list-item-action>
                            </v-list-item>-->
                    </v-card-actions>
                    <v-divider/>
                    <v-card-actions>
                        <v-select outlined
                                   label="Время для запоминания (секунды)"
                                   :items="timeValues"
                                   v-model="time"
                        />
                    </v-card-actions>
                </v-card>
            </v-col>
            <v-col cols="12" sm="8">
                <v-card outlined>
                    <v-card-actions>
                        <v-row>
                            <v-col cols="6" sm="6">
                                <v-btn outlined block large color="primary" @click="start">Начать</v-btn>
                            </v-col>
                            <v-spacer></v-spacer>
                            <v-col cols="6" sm="6">
                                <v-btn outlined block large color="primary" @click="close">Выход</v-btn>
                            </v-col>
                        </v-row>
                    </v-card-actions>
                </v-card>
            </v-col>
        </v-row>
    </v-card-actions>
</template>

<script>
    export default {
        name: "StartMenu",

        data: () => ({
            defaultCountWord: 10,
            defaultCountAnswerWord: 12,
            randomPosition: false,
            time: 30,
            countWords: [1,2,3,4,5,6,7,8,9,10],
            timeValues: [30, 50, 60, 80,100, 130, 150, 180, 200, 230, 250, 280,300]
        }),

        /*computed: {
            defaultCountAnswerWord: function () {
                return this.defaultCountWord + 2;
            }
        },*/
        methods: {
            close: function () {
                this.$emit('closeExercise')
            },
            start: function () {
                this.$emit('startExercise',
                    {
                        countWords: this.defaultCountWord,
                        countAnswerWords: this.defaultCountAnswerWord,
                        timeRemembering: this.time
                    }
                )
            }
        }
    }
</script>

<style scoped>

</style>
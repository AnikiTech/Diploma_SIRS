<template>
    <v-app>
        <v-container grid-list-xl>
            <v-layout>
                <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6>
                    <v-card max-width="750" class="mx-auto" outlined>
                        <v-img
                                src="https://sun4-16.userapi.com/rdG6WEO--snH5vySQyZOeJ6iXzVUJ3YtKdzYlg/0l0VfIJ7Bn8.jpg"
                                height="194"
                        />
                        <v-divider/>
                        <v-card-title>Запоминание цветов</v-card-title>
                        <v-card-subtitle>Навыки интенсивного обучения</v-card-subtitle>
                        <v-card-text>Отлично помогает для запоминания больших объемов информации за счет развития кратковременнной зрительной памяти.</v-card-text>
                        <v-divider/>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn outlined color="primary" @click="startColorExercises">Начать упражнение</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-flex>
            </v-layout>
            <v-layout>
                <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6>
                    <v-card max-width="750" class="mx-auto" outlined>
                        <v-img
                                src="https://sun4-16.userapi.com/rdG6WEO--snH5vySQyZOeJ6iXzVUJ3YtKdzYlg/0l0VfIJ7Bn8.jpg"
                                height="194"
                        />
                        <v-divider/>
                        <v-card-title>Порядок слов</v-card-title>
                        <v-card-subtitle>Развитие памяти</v-card-subtitle>

                        <v-card-text>Отлично подходит для повышения зрительной памяти</v-card-text>
                        <v-divider/>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn outlined color="primary" @click="startOrderWordExercises">Начать упражнение</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-flex>
            </v-layout>
            <v-layout>
                <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6>
                    <v-card max-width="750" class="mx-auto" outlined>
                        <v-img
                                src="https://sun4-16.userapi.com/rdG6WEO--snH5vySQyZOeJ6iXzVUJ3YtKdzYlg/0l0VfIJ7Bn8.jpg"
                                height="194"
                        />
                        <v-divider/>
                        <v-card-title>Быстрое чтение</v-card-title>
                        <v-card-subtitle>Навыки интенсивного обучения</v-card-subtitle>

                        <v-card-text>Отлично подходит для повышения скорости чтения</v-card-text>
                        <v-divider/>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn outlined color="primary" @click="startReadingFast">Начать упражнение</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-flex>
            </v-layout>
            <v-layout>
                <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6>
                    <v-card max-width="750" class="mx-auto" outlined>
                        <v-img
                            src="https://sun4-16.userapi.com/rdG6WEO--snH5vySQyZOeJ6iXzVUJ3YtKdzYlg/0l0VfIJ7Bn8.jpg"
                            height="194"
                        />
                        <v-divider/>
                        <v-card-title>Запоминание лиц</v-card-title>
                        <v-card-subtitle>Развитие памяти</v-card-subtitle>
                        <v-card-text>Отлично подходит для повышения зрительной памяти</v-card-text>
                        <v-divider/>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn outlined color="primary" @click="startFacesExercises">Начать упражнение</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
    </v-app>
</template>

<script>
    export default {
        name: "Exercises",
        methods: {
            startColorExercises: function () {
                this.$router.push({path:'/memory/colors'})
            },
            startOrderWordExercises: function () {
                this.$router.push({path:'/memory/orderWords'})
            },
            startReadingFast: function () {
                this.$router.push({path: '/memory/fastReading'})
            },
            startFacesExercises: function () {
                this.$router.push({path: '/memory/faces'})
            }
        }
    }
</script>

<style scoped>

</style>
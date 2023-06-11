<template>
    <v-app>
        <v-container grid-list-md text-xs-center >
            <v-layout >
                <v-flex >
                    <v-card outlined class="mx-auto" max-width="600px">
                        <v-card-title> Результаты </v-card-title>
                    </v-card>
                </v-flex>
            </v-layout>
            <v-layout>
                <v-flex>
                    <v-card outlined class="mx-auto" max-width="600px">
                        
                        <v-card-title primary-title>Лица: диагностика
                        </v-card-title>
                        <v-divider/>
                        <v-row justify="center">
                            <v-card-title>
                                <div class="font-weight-bold ml-8 mb-2">
                                    13.06.22
                                </div>
                                <v-list>
                                    <v-list-item>
                                        <v-list-item-avatar>
                                        </v-list-item-avatar>
                                        <div>
                                            <div class="font-weight-normal">
                                                <strong>Время выполнения</strong>
                                            </div> 
                                            <div>01:24</div>
                                            <div class="font-weight-normal">
                                                <strong>Верных ответов</strong>
                                            </div>
                                            <div>2/2</div>
                                                <div class="font-weight-normal">
                                                <strong>Оценка</strong>
                                            </div>
                                            <div>5</div>
                                        </div>
                                    </v-list-item>
                                </v-list>
                                <v-list></v-list>
                                
                            </v-card-title>
                        </v-row>
                        <v-divider/>
                        <v-row justify="center">
                            <v-card-title>
                                <div class="font-weight-bold ml-8 mb-2">
                                    10.06.22
                                </div>
                                <v-list>
                                    <v-list-item>
                                        <v-list-item-avatar>
                                        </v-list-item-avatar>
                                        <div>
                                            <div class="font-weight-normal">
                                                <strong>Время выполнения</strong>
                                            </div> 
                                            <div>05:12</div>
                                            <div class="font-weight-normal">
                                                <strong>Верных ответов</strong>
                                            </div>
                                            <div>1/2</div>
                                                <div class="font-weight-normal">
                                                <strong>Оценка</strong>
                                            </div>
                                            <div>3</div>
                                        </div>
                                    </v-list-item>
                                </v-list>
                                
                                <v-list></v-list>
                                
                            </v-card-title>
                        </v-row>
                    </v-card>
                    
                </v-flex>
            </v-layout >
        </v-container>
        <v-row justify="center" >
            <v-btn  v-bind="attrs" v-on="on" outlined color="primary" @click="$router.push('/')">Назад</v-btn>
        </v-row>
    </v-app>              
</template>

                        
<script>
export default {}
</script>
                        
<style>
                       
</style>
<template>
    <v-app>

        <v-container grid-list-xl>
        <v-layout >
        <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6 >
          <v-card style="top:5%" max-width="750" class="mx-auto" outlined>
            
            <v-card-title v-bind:style="styleObject">ТЕСТ №2.  Лица</v-card-title>
            
            <v-card-text v-bind:style="styleObject">Посмотрите на портреты людей. Рассматривать их вы можете не более 4 минут. Затем будут даны теже портреты уже без ФИО. Посторайтесь запомнить имена изображенных людей.</v-card-text>
            <v-divider/>
            <v-card-actions>
              <v-spacer></v-spacer>

                <v-dialog 
                v-model="dialog"
                class="mx-auto" max-width="300">

                <template v-slot:activator="{ on, attrs }" >

                <v-btn  v-bind="attrs" 
                        v-on="on" outlined color="primary" >Начать упражнение</v-btn>
                </template></v-dialog>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout></v-container>

        <div class="text-center">    
     
            <v-dialog
                v-model="dialog"
                class="mx-auto" max-width="810">

                

                <v-card>
                        <v-row dense class="mx-auto">
                            <v-col>
                                <v-card>
                                    <v-img src="..\..\..\картинки\35367.jpg" aspect-ratio="1"
                                        class="grey lighten-2">
                                    </v-img>
                                    <v-card-title>
                                        Семёнова Аврора Владимировна
                                    </v-card-title>
                            
                                </v-card>
                            </v-col>
                            <v-col>
                                <v-card>
                                    <v-img src="..\..\..\картинки\35368.png" aspect-ratio="1"
                                        class="grey lighten-2"></v-img>
                                    <v-card-title>
                                        Белов Владимир Дмитриевич
                                    </v-card-title>
                                </v-card>
                            </v-col>
                        </v-row>


                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn
                            color="primary"
                            text
                            @click="$router.push({name: 'fullname'})">
                            Запомнил(а)
                        </v-btn>
                    </v-card-actions>
                </v-card>
                
            </v-dialog>
        </div> 
    </v-app>
</template>

<script>

export default {
    data: () => ({
        dialog: false,
        styleObject: {

            fontSize: '28px'
        },
        selectedItem: 1,
        
    }),
}


</script>
<style scoped></style>
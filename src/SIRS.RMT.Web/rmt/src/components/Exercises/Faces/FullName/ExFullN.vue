<template>
  <v-app>
    <v-container grid-list-xl>
      <v-layout >
        <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6 >
          <v-card style="top:5%" max-width="750" class="mx-auto" outlined>

            <v-card-title v-bind:style="styleObject">ТЕСТ №3.  Фамилия-имя-отчество</v-card-title>

            <v-card-text v-bind:style="styleObject">Посмотрите на портреты людей. Постарайтесь запомнить ФИО и лица изображенных людей. Затем будут даны те же портреты уже без ФИО.</v-card-text>
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
          class="mx-auto" max-width="2000">



        <v-card>
          <v-row dense class="mx-auto">
            <v-col>
              <v-card>
                <v-img src="..\..\..\..\pictures\5.jpg" aspect-ratio="1"
                       class="grey lighten-2">
                </v-img>
                <v-card-title>
                  Мельников Иосиф Георгиевич
                </v-card-title>

              </v-card>
            </v-col>
            <v-col>
              <v-card>
                <v-img src="..\..\..\..\pictures\4.jpg" aspect-ratio="1"
                       class="grey lighten-2"></v-img>
                <v-card-title>
                  Дроздова Рита Григорьевна
                </v-card-title>
              </v-card>
            </v-col>
            <v-col>
              <v-card>
                <v-img src="..\..\..\..\pictures\35368.png" aspect-ratio="1"
                       class="grey lighten-2"></v-img>
                <v-card-title>
                  Иванов Владимир Дмитриевич
                </v-card-title>
              </v-card>
            </v-col>
            <v-col>
              <v-card>
                <v-img src="..\..\..\..\pictures\kirill.jpg" aspect-ratio="1"
                       class="grey lighten-2"></v-img>
                <v-card-title>
                  Шумаков Кирилл Изотович
                </v-card-title>
              </v-card>
            </v-col>
            <v-col>
              <v-card>
                <v-img src="..\..\..\..\pictures\9.jpg" aspect-ratio="1"
                       class="grey lighten-2"></v-img>
                <v-card-title>
                  Кузнецов Иван Сергеевич
                </v-card-title>
              </v-card>
            </v-col>
          </v-row>


          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
                color="primary"
                text
                @click="$router.push({name: 'FullNameEx'})">
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

      fontSize: '26px'
    },
    selectedItem: 1,

  }),
}


</script>
<style scoped></style>
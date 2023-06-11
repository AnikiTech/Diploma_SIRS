<template >
  <v-app >
    <v-container grid-list-xl>
      <v-layout>
        <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6 >
          <v-card style="top:5%" max-width="750" class="mx-auto" outlined>
            <v-card-text v-bind:style="styleObject">На рабочем экране появился список имён. Нужно перетащить имя под соответствующую фотографию. Запомните, под ОДНОЙ фотографией должно стоять только ОДНО имя.</v-card-text>

            <v-row class="text-center" justify="center">
              <div v-bind:style="styleObject" class="col-3">
                <div style=" display: flex"><v-icon>mdi-timer-outline</v-icon>{{formatTimer(pageOption.timeReading)}}</div></div></v-row>
            <v-card-actions>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout></v-container>

    <v-container fluid v-bind:style="styleObject" >

      <v-row justify="center">
        <v-col class="d-flex child-flex" >
          <v-card>

            <v-img src="..\..\..\..\pictures\7.jpg" aspect-ratio="1"
                   class="grey lighten-2"></v-img>
            <draggable class="list-group" :list="listFirstAnswer" group="people" @change="log">
              <div
                  style="border-radius: 10px; text-align: center"
                  class="list-group-item"
                  v-for="(element) in listFirstAnswer"
                  :key="element.name">
                <strong style="font-size: 30px; ">{{ element.name }}</strong>
              </div>
            </draggable>
          </v-card>
        </v-col>
        <v-col class="d-flex child-flex ">
          <v-card >
            <v-img src="..\..\..\..\pictures\1.jpg" aspect-ratio="1"
                   class="grey lighten-2"></v-img>
            <draggable class="list-group" :list="listSecondAnswer" group="people" @change="log">
              <div
                  style="border-radius: 10px; text-align: center"
                  class="list-group-item"
                  v-for="(element) in listSecondAnswer"
                  :key="element.name">
                <strong style="font-size: 30px; ">{{ element.name }}</strong>
              </div>
            </draggable>
          </v-card>

        </v-col>
        <v-col class="d-flex child-flex">
          <v-card>

            <v-img src="..\..\..\..\pictures\3.jpg" aspect-ratio="1"
                   class="grey lighten-2"></v-img>
            <draggable class="list-group" :list="listThirdAnswer" group="people" @change="log">
              <div
                  style="border-radius: 10px; text-align: center"
                  class="list-group-item"
                  v-for="(element) in listThirdAnswer"
                  :key="element.name">
                <strong style="font-size: 30px; ">{{ element.name }}</strong>
              </div>
            </draggable>
          </v-card>
        </v-col>
        <v-col class="d-flex child-flex">
          <v-card>

            <v-img src="..\..\..\..\pictures\5.jpg" aspect-ratio="1"
                   class="grey lighten-2"></v-img>
            <draggable class="list-group" :list="listFourAnswer" group="people" @change="log">
              <div
                  style="border-radius: 10px; text-align: center"
                  class="list-group-item"
                  v-for="(element) in listFourAnswer"
                  :key="element.name">
                <strong style="font-size: 30px; ">{{ element.name }}</strong>
              </div>
            </draggable>
          </v-card>
        </v-col>
        <v-col class="d-flex child-flex">
          <v-card>

            <v-img src="..\..\..\..\pictures\8.jpg" aspect-ratio="1"
                   class="grey lighten-2"></v-img>
            <draggable class="list-group" :list="listFiveAnswer" group="people" @change="log">
              <div
                  style="border-radius: 10px; text-align: center"
                  class="list-group-item"
                  v-for="(element) in listFiveAnswer"
                  :key="element.name">
                <strong style="font-size: 30px; ">{{ element.name }}</strong>
              </div>
            </draggable>
          </v-card>
        </v-col>
      </v-row>
      <div class="row" style="align-content: center;align-items: center;justify-content: center">
        <div class="col-3" style="">
          <v-row class="text-center" justify="center"><div style="justify-content: space-between;align-items: center; width: 100%">
            <h3>Варианты</h3>
          </div></v-row>
          <v-card-actions>
            <v-spacer></v-spacer>
          </v-card-actions>
          <draggable class="list-group" :list="listTask" group="people" @change="log">
            <div style="border-radius: 10px; background:#FFDEAD; text-align: center; margin-top: 5px"
                 class="list-group-item"
                 v-for="(element) in listTask"
                 :key="element.name">
              <strong style="font-size: 30px; ">{{ element.name }}</strong>
            </div>
          </draggable>
        </div>

      </div>
      <v-row justify="center">
        <v-dialog
            v-model="dialog"
            persistent
            max-width="600px"
        >
          <template v-slot:activator="{ on, attrs }">
            <v-btn
                large
                color="primary"
                dark
                v-bind="attrs"
                v-on="on"
                @click="stopTimer(); scoreCalculate()"
            >
              <strong style="font-size: 18px; ">проверить</strong>
            </v-btn
            >

          </template>
          <v-card>
            <v-card-title class="text-h5 grey lighten-2">
              <span class="text-h5">Результаты тренинга</span>
            </v-card-title>
            <v-card-text>
              <v-container>
                <v-row style="justify-content: center">
                  <v-list-item style="display: inline-block">
                    <v-list-item style="display: flex; align-content: center; justify-content: center">
                      <v-list-item-title v-bind:style="styleObject">Время выполнения:  {{formatTimer(pageOption.timeReading)}}
                      </v-list-item-title>
                    </v-list-item>
                    <v-list-item>
                      <v-list-item-title v-bind:style="styleObject">Результат: {{result}}/5</v-list-item-title>
                    </v-list-item>
                  </v-list-item>
                  <v-btn
                      outlined
                      color="primary"
                      @click="dialog = false; $router.push({name: 'Faces'})">
                    Выход
                  </v-btn>

                </v-row>
              </v-container>
            </v-card-text>
          </v-card>
        </v-dialog></v-row>

    </v-container>
  </v-app>
</template>

<script>
import draggable from "vuedraggable";// без @
export default {
  name: "two-lists",
  display: "Two Lists",
  order: 1,
  data: () => ({
    dialog: false,
    pageOption: {
      timeReading: 0,
      timer: null,
    },
    styleObject: {
      fontSize: '23px'
    },
    dateStartLesson:new Date(),
    timeSecondsForLesson: 0,
    listTask: [
      { name: "Аврора", id: 1},
      { name: "Людмила", id: 2 },
      { name: "Владимир", id: 3 },
      { name: "Кирилл", id: 4 },
      { name: "Маргарита", id: 5 },
      { name: "Оливер", id: 6},
      { name: "Анастасия", id: 8 },
      { name: "Максим", id: 7 },
      { name: "Иосиф", id: 10 },
      { name: "Агата", id: 9 }
    ],
    listFirstAnswer: [],
    listSecondAnswer: [],
    listThirdAnswer: [],
    listFourAnswer: [],
    listFiveAnswer: [],
    TrueAnswer: [
      { name: "Маргарита", id: 5},
      { name: "Людмила", id: 2},
      { name: "Оливер", id: 6},
      { name: "Максим", id: 7},
      { name: "Анастасия", id: 8},
    ],
    result: 0,
  }),
  components: {
    draggable
  },
  mounted() {
    this.startTimer()
  },
  methods: {
    scoreCalculate(){
      if (this.listFirstAnswer[0].id === this.TrueAnswer[0].id){
        this.result++;
      }
      if (this.listSecondAnswer[0].id === this.TrueAnswer[1].id){
        this.result++;
      }
      if (this.listThirdAnswer[0].id === this.TrueAnswer[2].id){
        this.result++;
      }
      if (this.listFourAnswer[0].id === this.TrueAnswer[3].id){
        this.result++;
      }
      if (this.listFiveAnswer[0].id === this.TrueAnswer[4].id){
        this.result++;
      }
    },
    add: function() {
      this.list.push({ name: "Nina" });
    },
    replace: function() {
      this.list = [{ name: "Reyana" }];
    },
    clone: function(el) {
      return {
        name: el.name + " cloned"
      };
    },

    log: function(evt) {
      window.console.log(evt);
    },

    getImage () {
      const min = 550
      const max = 560

      return Math.floor(Math.random() * (max - min + 1)) + min
    },

    startTimer() {
      this.pageOption.timer = setInterval(() => {
        this.pageOption.timeReading++;
      }, 1000);
    },
    stopTimer(){
      clearTimeout(this.pageOption.timer);
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
  },


}
</script>

<style scoped>

</style>
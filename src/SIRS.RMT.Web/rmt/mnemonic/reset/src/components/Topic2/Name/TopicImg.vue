<template >
    <v-app >

        <v-container fluid v-bind:style="styleObject" >
           
            <v-row justify="center">
                <v-col class="d-flex child-flex"
                cols="3" >
                    <v-card>
                        
                        <v-img src="..\..\..\картинки\35367.jpg" aspect-ratio="1"
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
                <v-col class="d-flex child-flex "
                cols="3">
                    <v-card >
                        <v-img src="..\..\..\картинки\35368.png" aspect-ratio="1"
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
            </v-row>
          <div class="row" style="align-content: center;align-items: center;justify-content: center">
            <div class="col-3" style="">
              <div style="justify-content: space-between;align-items: center;display: flex; width: 100%">
              <h3 style="display: flex">Варианты</h3>
                <div style=" display: flex"><v-icon>mdi-timer-outline</v-icon>{{formatTimer(pageOption.timeReading)}}</div>
              </div>
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
            <strong>далее</strong>
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
                      <v-list-item-title>Время выполнения:  {{formatTimer(pageOption.timeReading)}}
                       </v-list-item-title>
                    </v-list-item>
                  <v-list-item>
                    <v-list-item-title>Результат: {{result}}/2</v-list-item-title>
                  </v-list-item>
                  </v-list-item>
                    <v-btn
                        outlined
                        color="primary"
                        @click="dialog = false; $router.push({path: '/'})">
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
      { name: "Иосиф", id: 2 },
      { name: "Владимир", id: 3 },
      { name: "Кирилл", id: 4 },
      { name: "Маргарита", id: 5 }
    ],
    listFirstAnswer: [],
    listSecondAnswer: [],
    TrueAnswer: [
      { name: "Аврора", id: 1},
      { name: "Владимир", id: 3 },
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
      console.log(this.listFirstAnswer[0].id)
      console.log(this.TrueAnswer[0].id)
      if (this.listFirstAnswer[0].id === this.TrueAnswer[0].id){
        this.result++;
      }
      if (this.listSecondAnswer[0].id === this.TrueAnswer[1].id){
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

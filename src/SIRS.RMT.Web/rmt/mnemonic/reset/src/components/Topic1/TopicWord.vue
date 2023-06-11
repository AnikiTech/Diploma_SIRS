<template>
    <v-app>
        <v-container grid-list-xl v-bind:style="styleObject">
      <v-layout >
        <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6 >
          <v-card style="top:5%" max-width="750" class="mx-auto"  outlined>

           <v-row class="text-center" justify="center">
            <div class="col-3"><div style=" display: flex"><v-icon>mdi-timer-outline</v-icon>{{formatTimer(pageOption.timeReading)}}</div></div>
                <div class="col-3">
                  
                    <h3>Варианты</h3>
                    <draggable class="list-group" :list="list1" group="people" @change="log">
                      <div style="border-radius: 10px; background:#FFDEAD; text-align: center; margin-top: 5px"
                           class="list-group-item"
                           v-for="(element) in list1"
                           :key="element.name">
                        <strong style="font-size: 30px; ">{{ element.name }}</strong>
                      </div>
                    </draggable>
                </div>
                <div class="col-3">
                    
                    <h3>Ответ</h3>
                    
                    <draggable class="list-group" :list="list2" group="people" @change="log">
                      <div style="border-radius: 10px; background:#FFDEAD; text-align: center; margin-top: 5px"
                           class="list-group-item"
                           v-for="(element) in list2"
                           :key="element.name">
                        <strong style="font-size: 30px; ">{{ element.name }}</strong>
                      </div>
                    </draggable>
                </div>
            </v-row><v-divider/>
           <v-card-actions>
              <v-spacer></v-spacer>
               <!--<v-btn outlined color="primary" @click="ComparingArrays()">Проверить</v-btn>
            </v-card-actions>-->
           
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
            <strong>проверить</strong>
          </v-btn
          >

      </template>
      <v-card>
        <v-card-title class="text-h5 grey lighten-2">
            <span class="text-h5">Результат:</span>
        </v-card-title>
        <v-card-text>
            <v-container>
                <v-row style="justify-content: center">
                  <v-list-item style="display: inline-block">
                    <v-list-item style="display: flex; align-content: center; justify-content: center">
                      <v-list-item-title>Время выполнения:  {{formatTimer(pageOption.timeReading)}}
                       </v-list-item-title>
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
    </v-dialog>
           </v-card-actions></v-card></v-flex></v-layout></v-container>
            
           <!--</div>-->
    </v-app>
</template>

<script>
import draggable from "vuedraggable";
export default {
  data: () => ({
    dialog: false,
    pageOption: {
      timeReading: 0,
      timer: null,
    },
    styleObject: {
      fontSize: '20px'
    },
    selectedItem: 1,
    TrueAnswer: [],
    list1: [],
    list2: [],
    shuffleList: [],
    result: 0,
  }),
  name: "two-lists",
  display: "Two Lists",
  order: 1,
  components: {
    draggable
  },
  mounted() {
    this.ShuffleWords();
    this.TrueAnswer = this.getArrayForWord;
    this.startTimer()
  },

  computed: {
    getArrayForWord(){
      return this.$store.getters.getArrayForWord;
    },
  },
  methods: {
    ShuffleWords(){
      this.shuffleList = this.getArrayForWord;
      this.shuffleList.sort(() => Math.random() - 0.5)
      this.list1 = this.shuffleList;
      },
    ComparingArrays(){
      for(let i = 0; i < this.getArrayForWord.length; i++){
        if(this.getArrayForWord[i] === this.list2[i]){
          this.result++;
        }
      }
    },
    log: function(evt) {
      window.console.log(evt);
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
<style scoped></style>
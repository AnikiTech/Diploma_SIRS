<template>
    <v-app>
        <v-container grid-list-xl>
        <v-layout>
        <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6 >
          <v-card style="top:5%" max-width="750" class="mx-auto" outlined>
                   
            <v-card-title v-bind:style="styleObject">ТЕСТ №1.  Слова</v-card-title>
            
            <v-card-text v-bind:style="styleObject">Прочитайте список слов и изучите его в течении полутора минут.</v-card-text>
            <v-divider/>
            <v-card-actions>
              <v-spacer></v-spacer>

                <v-dialog 
                v-model="dialog"
                class="mx-auto" max-width="300">

                <template v-slot:activator="{ on, attrs }" >
                  <v-btn  v-bind="attrs"
                          v-on="on" outlined color="primary" @click="$router.push('/')">Назад</v-btn>
              <v-btn style=""  v-bind="attrs"
                        v-on="on" outlined color="primary" @click="$router.push('/topic1'); pushArrayForWord()">
                Начать упражнение</v-btn>
                </template></v-dialog>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout></v-container>

        
        <div class="text-center">      
            <v-dialog 
                v-model="dialog"
                class="mx-auto" max-width="300">
                <v-card >
                        <v-row dense class="mx-auto" justify="center">
                            <v-list>
                                <v-list-item v-for="(item, i) in items"
                                :key="i">
                                    <v-list-item-title v-bind:style="styleObject" v-text="item.text">
                                        </v-list-item-title>
                                </v-list-item>
                            </v-list>
                        </v-row>
                    <v-sheet 
                        height="10"
                        class="overflow-hidden">
                    </v-sheet>
                    <v-divider></v-divider>

                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn
                            color="primary"
                            text
                            @click="$router.push({name: 'words'})">
                            Запомнил(а)
                        </v-btn>
                    </v-card-actions>
                </v-card>

            </v-dialog></div>
    </v-app>
</template>

<script>

export default {
    
    data: () => ({
        dialog: false,
        styleObject: {
            
            fontSize: '25px'
        },
        selectedItem: 1,
        items: 
        [
            { text: 'мышка'},
            { text: 'краска'},
            { text: 'стена'},
            { text: 'воробей'},
            { text: 'флаг'},
            { text: 'заря'},
            { text: 'свеча'},
            { text: 'банк'},
            { text: 'лесник'},
            { text: 'парус'}
        ],
    }),
  computed:{
    getArrayForWord(){
      return this.$store.getters.getArrayForWord;
    },
  },
  methods: {
      pushArrayForWord(){
        //this.items = this.getArrayForWord;
        return this.items(response => {
          this.$store.dispatch('getArrayForWord',response.data);
        });
      }
  }
}
</script>
<style scoped></style>
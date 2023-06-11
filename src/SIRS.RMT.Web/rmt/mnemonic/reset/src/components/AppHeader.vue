<template>
  <v-app>

    <v-container grid-list-xl>
      <v-layout >
        <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6 >
          <v-card style="top:3%" max-width="750" class="mx-auto" outlined>
                          
            <v-img
            src="..\картинки\words2.jpg"
            height="194"/>
            <v-divider/>
                          
            <v-card-title v-bind:style="styleObject">Слова</v-card-title>
            <v-card-subtitle v-bind:style="styleObject">Развитие мнемонической памяти</v-card-subtitle>
            <v-card-text v-bind:style="styleObject">Это упражнение на запоминание последовательности не связанных между собой слов. Его выполнение основывается на методе ассоциаций.</v-card-text>
            <v-divider/>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn outlined color="primary" @click="$router.push({name: 'instruction'})">Начать упражнение</v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
      <v-layout >
        <v-flex xs12 sm10 md8 offset-sm2 offset-md-4 offset-xs-6 >
          <v-card style="top:5%" max-width="750" class="mx-auto" outlined >
                          
            <v-img
            src="..\картинки\fraud.webp"
            height="194"/>
            <v-divider/>
                          
            <v-card-title v-bind:style="styleObject">Лица</v-card-title>
            <v-card-subtitle v-bind:style="styleObject">Развитие памяти, внимания и воображения.</v-card-subtitle>
            <v-card-text v-bind:style="styleObject">Наблюдайте и анализируйте различия в той или иной черте лица. Фамилии преобразуйте в образы, методом наводящих ассоциаций.</v-card-text>
            <v-divider/>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn outlined color="primary" @click="$router.push({name: 'faces-level'})">Начать упражнение</v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>

  </v-app>
  
</template>

<script>


    export default {
    
    data: () => ({
      
      drawer: false,
      group: null,
      styleObject: {
            fontSize: '20px',
            fontWeight: 'bold',
            fontFamily: 'Roboto, sans-serif'
        },
    })
  }
</script>
<style scoped>
</style>

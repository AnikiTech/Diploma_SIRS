<template>
<v-app>
    <div class="v-toolbar__content orange" 
            style="height: 64px;" >

            <v-btn icon @click="$router.push('/')" >
                <v-icon >mdi-arrow-left</v-icon>
            </v-btn>

            <div v-bind:style="styleObject" class="v-toolbar__title">Слова: диагностика </div>
        
        <!--<v-menu
              bottom
              right
              offset-y>
              <template v-slot:activator="{ on, attrs }">
                <v-btn
                  icon
                  v-bind="attrs"
                  v-on="on"
                >
                  <v-icon>mdi-dots-vertical</v-icon>
                </v-btn>
              </template>
              
        </v-menu>-->
        </div>


        <router-view></router-view>
        
</v-app>
</template>
<script>

    export default {
    data: () => ({
      styleObject: {
            fontSize: '23px'
        },
    }),
  }
</script>
<!--<template>
    <div class="layout">
        <app-header/>
        <router-view></router-view>
    </div>
</template>

<script>
import AppHeader from '../components/AppHeader.vue'

export default {
    components: {
        AppHeader
    },
}
</script>-->

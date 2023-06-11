<template>
<v-app>
    <div class="v-toolbar__content orange" 
            style="height: 64px;" >

            <v-btn icon @click="$router.push('/')" >
                <v-icon >mdi-arrow-left</v-icon>
            </v-btn>

            <div v-bind:style="styleObject" class="v-toolbar__title">Лица: диагностика </div>
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


<template>
    <v-app>
        <v-container fluid>
            <v-row justify="center">
                <v-col cols="12" sm="11" md="11" lg="10">
                     <v-card style="top:15%" max-width="750" class="mx-auto" outlined>
        
                        <v-card-title v-bind:style="styleObject" outlined color="primary" >
                            <v-row justify="center">
                                Лица
                            </v-row>
                        </v-card-title>
                        <v-card-actions>
                        <v-row justify="center" align="center">
                                <v-col cols="12" sm="8">
                                    <v-btn outlined block large color="primary" @click="$router.push({name: 'name'})">Имя</v-btn>
                                </v-col>
                                <v-col cols="12" sm="8">
                                    <v-btn outlined block large color="primary" @click="$router.push({name: 'exerciseNP'})">Имя–отчество</v-btn>
                                </v-col>
                                <v-col cols="12" sm="8">
                                    <v-btn outlined block large color="primary" @click="$router.push({name: 'exerciseFull'})">ФИО</v-btn>
                                </v-col>
                                <v-col cols="12" sm="8">
                                    <v-btn outlined block large color="primary" @click="$router.push({name: 'level'})">Выход</v-btn>
                                </v-col>
                            </v-row>
                        </v-card-actions>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
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
<style scoped>
</style>
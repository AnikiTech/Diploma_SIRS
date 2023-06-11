<template>
        <v-card-actions>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="8">
                    <v-btn outlined block large color="primary" @click="startDiagnostic">Диагностика</v-btn>
                </v-col>
                <v-col cols="12" sm="8">
                    <v-btn outlined block large color="primary" @click="startTraining">Тренинг</v-btn>
                </v-col>
                <v-col cols="12" sm="8">
                    <v-btn outlined block large color="primary" @click="openStatistic">Статистика</v-btn>
                </v-col>
                <v-col cols="12" sm="8">
                    <v-btn outlined block large color="primary" @click="close">Выход</v-btn>
                </v-col>
            </v-row>
        </v-card-actions>
</template>

<script>
    export default {
        name: "StartMenu",
        data: () => ({
        }),

        methods: {
            close: function () {
                this.$emit('closeExercise')
            },

            startDiagnostic: function () {
                this.$store.dispatch('setTypeExercise', {type: 0});
                this.$emit('startDiagnostic')
            },

            startTraining: function () {
                this.$store.dispatch('setTypeExercise', {type: 1});
                this.$emit('startTraining')
            },
            openResult: function () {
                this.$emit("openResult")
            },
            openStatistic: function () {
                this.$store.dispatch('getColorStatistic').then(() =>{
                    this.$emit("openStatistic")
                }).catch(()=>{
                    
                })
            }
        }
    }
</script>

<style scoped>

</style>
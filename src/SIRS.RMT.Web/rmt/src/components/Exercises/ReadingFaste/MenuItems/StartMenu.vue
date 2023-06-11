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
                <v-btn outlined block large color="primary" @click="close">Выход</v-btn>
            </v-col>
        </v-row>
    </v-card-actions>
</template>

<script>
    export default {
        name: "StartMenu",

        methods: {
            close: function () {
                this.$emit('closeExercise')
            },
            startDiagnostic: function () {
                this.$emit('startDiagnostic');
            },
            startTraining: function () {
                this.$emit('startTraining');
            }
        }
    }
</script>

<style scoped>

</style>
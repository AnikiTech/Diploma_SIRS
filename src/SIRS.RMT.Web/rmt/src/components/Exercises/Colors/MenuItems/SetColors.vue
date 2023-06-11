<template>
    <v-card-actions>
        <v-row justify="center" align="center" wrap>
            <v-col cols="12" sm="8">
                <v-select
                        outlined
                        :disabled=!canChangeLevel
                        :items="setLevelColors"
                        v-model="currentLevel"
                        @change="changeCurrentLevel"
                ></v-select>
                <v-btn outlined block large color="primary" @click="startExercise">Продолжить</v-btn>
            </v-col>
            <v-col cols="12" sm="8">
                <v-btn outlined block large color="primary" @click="prev">Назад</v-btn>
            </v-col>
        </v-row>
    </v-card-actions>
</template>

<script>

    export default {
        name: "setColors",

        data: () => ({
            currentLevel: 1,
            typeExercises: String,
        }),

        mounted() {
            this.currentLevel = this.$store.getters.getCurrentLevel
        },

        beforeUpdate() {
            this.currentLevel = this.$store.getters.getCurrentLevel;
        },

        methods: {
            changeCurrentLevel: function (value) {
                if (value) {
                    this.currentLevel = value;
                }
                else {
                    this.currentLevel = this.$store.getters.getCurrentLevel;
                }

                this.$store.dispatch('setCurrentLevel', {level: this.currentLevel});
            },
            prev: function () {
                this.$emit("prev");
            },

            startExercise: function () {
                this.$store.dispatch('setCurrentLevel', {level: this.currentLevel});
                this.$emit("startExercise", this.currentLevel);
            }
        },
        props: {
            setLevelColors: {},
            canChangeLevel: {}
        }
    }
</script>

<style scoped>

</style>
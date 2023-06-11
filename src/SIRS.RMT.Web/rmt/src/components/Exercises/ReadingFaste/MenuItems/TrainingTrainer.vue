<template>
    <div>
        <v-card-actions>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="11" md="11" lg="10">
                    <div>
                        {{getExerciseTrainingText.text}}
                    </div>
                </v-col>
            </v-row>
        </v-card-actions>
        <v-divider></v-divider>
        <v-card-actions>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="11" md="11" lg="10">
                    <v-btn block outlined color="primary" @click="showMessage = !showMessage">Закончить</v-btn>
                </v-col>
            </v-row>
        </v-card-actions>
        <v-dialog v-model="showMessage" max-width="500">
            <v-card>
                <v-card-title>Внимание</v-card-title>
                <v-card-text>Хотите прочитать еще один текст?</v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn text color="primary" @click="stopReading">Я не хочу читать</v-btn>
                    <v-btn text color="primary" @click="continueReading">Да</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>
    import {mapGetters} from "vuex";

    export default {
        name: "TrainingTrainer",

        data: () => ({
            showMessage: false,
        }),

        computed: {
            ...mapGetters(['getExerciseTrainingText'])
        },

        methods: {
            continueReading: function () {
                this.showMessage = false;
                this.$emit('continueReading')
            },
            stopReading: function () {
                this.showMessage = false;
                this.$emit('stopReading')
            }
        }
    }
</script>

<style scoped>

</style>
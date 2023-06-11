<template>
    <div>
        <template v-if="showColors">
            <v-card-actions>
                <div class="row wrap align-center justify-center sortable-list">
                    <v-icon>mdi-timer-outline</v-icon> {{formatTimer(currentTime)}}
                </div>
            </v-card-actions>
            <v-divider />
            <v-card-actions>
                <v-container fluid>
                    <v-row justify="center" align="center">
                        <v-col cols="12" sm="8" md="8" wrap>
                            <div class="row wrap align-center justify-center sortable-list">
                                <v-card outlined
                                        tile
                                        width="100"
                                        height="100"
                                        v-for="color of currentColors"
                                        :key=color
                                        :color="color">
                                </v-card>
                            </div>
                        </v-col>
                    </v-row>
                </v-container>
            </v-card-actions>
        </template>

        <template v-else>
            <v-card-actions>
                <v-container fluid>
                    <v-row justify="center" align="center">
                        <v-col cols="12" sm="8" md="8" wrap>
                            <draggable class="row wrap align-center justify-center sortable-list" group="colors" v-model="userColorAnswers">
                                <v-card outlined
                                        tile
                                        width="100"
                                        height="100"
                                        v-for="color of userColorAnswers"
                                        :key=color
                                        :color="color">
                                </v-card>
                            </draggable>
                        </v-col>
                    </v-row>
                </v-container>
            </v-card-actions>
            <v-divider />
            <v-card-actions>
                <v-container fluid>
                    <v-row justify="center" align="center">
                        <v-col cols="12" sm="8" md="8" wrap>
                            <draggable group="colors" v-model="currentAvailableColors" class="row wrap align-center justify-center sortable-list">
                                <v-card outlined
                                        tile
                                        width="55"
                                        height="55"
                                        v-for="color of currentAvailableColors"
                                        :key=color
                                        :color="color">
                                </v-card>
                            </draggable>
                        </v-col>
                    </v-row>
                </v-container>
            </v-card-actions>
        </template>
        <v-divider />
        <v-card-actions>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="10" v-if="showColors">
                    <v-btn outlined block large color="primary" @click="iRemembered">Начать</v-btn>
                </v-col>
                <v-col cols="12" sm="10" v-else>
                    <v-btn outlined block large color="primary" @click="iFinished">Закончить</v-btn>
                </v-col>
            </v-row>
        </v-card-actions>
    </div>
</template>
<!--Colors-->
<script>

    import draggable from 'vuedraggable'
    import { userAnswer } from "../../../../api/colorsExercise/color-exercises";

    export default {
        data: () => ({
            showColors: true,
            userColorAnswers: [], /* Список цветов ответа пользователя*/
            currentAvailableColors: {},
            currentTime: null,
            timer: null
        }),

        name: "Trainer",

        mounted() {
            this.currentTime = this.timeRemembering;
            this.currentAvailableColors = this.availableColors;
            this.startTimer();
        },

        methods: {
            startTimer() {
                this.timer = setInterval(() => {
                    this.currentTime--;
                }, 1000);
            },
            stopTimer() {
                clearTimeout(this.timer);
                this.showColors = false;
            },
            formatTimer: function (times) {
                let sec_num = parseInt(times, 10); // don't forget the second param
                let hours = Math.floor(sec_num / 3600);
                let minutes = Math.floor((sec_num - (hours * 3600)) / 60);
                let seconds = sec_num - (hours * 3600) - (minutes * 60);

                if (minutes < 10) { minutes = "0" + minutes; }
                if (seconds < 10) { seconds = "0" + seconds; }
                return minutes + ':' + seconds;
            },
            iRemembered: function () {
                this.currentTime = 0;
                this.stopTimer();
            },
            iFinished: function () {
                userAnswer({
                    ExerciseType: this.$store.getters.getTypeExercise,
                    Colors: this.currentColors,
                    UserColors: this.userColorAnswers
                }).then(r => {
                    this.$store.dispatch('setUserAnswers', { answers: r });
                    this.showColors = true;
                    this.$emit('iFinished');
                }).catch(() => {
                    this.$router.push({ name: 'Exercises' })
                });
            },
        },

        watch: {
            currentTime(time) {
                if (time === 0) {
                    this.stopTimer();
                }
            },

            countClick() {
                this.currentTime = this.$store.getters.getTimeRemembering;
                this.currentAvailableColors = this.availableColors;
                this.userColorAnswers = [];
                this.startTimer();
            }
        },

        beforeDestroy() {
            this.stopTimer();
        },

        components: {
            draggable
        },

        props: {
            timeRemembering: {},
            currentColors: {},
            availableColors: {},
            countClick: {}
        }
    }
</script>

<style scoped>
</style>
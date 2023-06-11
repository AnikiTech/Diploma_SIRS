import { getAvailableLevels, getDiagnosticExerciseColors, getTrainingExerciseColors }
    from "../../../../api/colorsExercise/color-exercises";
import { getAvailableColors }
    from "../../../../api/colorsExercise/colors";
import { getColorStatistic }
    from "../../../../api/colorsExercise/statistic";

export default {
    state: {
        exercisesPreferences: {
            availableLevels: [],
            currentLevel: 1,
            typeExercises: {},
            timeRemembering: 60,
            userAnswers: null
        },
        colorsPreferences: {
            availableColors: [],
            exerciseColors: []
        },
        userPreferences: {
            currentLevel: 8
        },
        colorStatistic: {}
    },

    getters: {
        getColorStatistic(state) {
            return state.colorStatistic;
        },
        getAvailableLevels(state) {
            return state.exercisesPreferences.availableLevels
        },
        getAvailableColors(state) {
            return state.colorsPreferences.availableColors
        },
        getTypeExercise(state) {
            return state.exercisesPreferences.typeExercises
        },
        getTimeRemembering(state) {
            return state.exercisesPreferences.timeRemembering
        },
        getExerciseColors(state) {
            return state.colorsPreferences.exerciseColors
        },
        getUserAnswers(state) {
            return state.exercisesPreferences.userAnswers
        },
        getUserCurrentLevel(state) {
            return state.userPreferences.currentLevel
        },
        getCurrentLevel(state) {
            return state.exercisesPreferences.currentLevel
        }
    },

    mutations: {
        setColorsStatistic(state, colorStatistic) {
            console.log("COLOR_setStatistic");
            state.colorStatistic = colorStatistic;
        },
        setAvailableLevels(state, listColors) {
            state.exercisesPreferences.availableLevels = listColors;
        },
        setTypeExercise(state, type) {
            state.exercisesPreferences.typeExercises = type;
        },
        setTimeRemembering(state, time) {
            state.exercisesPreferences.timeRemembering = time;
        },
        setUserAnswers(state, answers) {
            state.exercisesPreferences.userAnswers = answers;
        },
        setCurrentLevel(state, level) {
            state.exercisesPreferences.currentLevel = level;
        },
        setUserCurrentLevel(state, currentLevel) {
            state.userPreferences.currentLevel = currentLevel;
        },
        setExerciseColors(state, colors) {
            state.colorsPreferences.exerciseColors = colors;
        },
        setAvailableColors(state, colors) {
            state.colorsPreferences.availableColors = colors;
        }
    },

    actions: {
        getColorStatistic({ commit }) {
            return new Promise((resolve, reject) => {
                getColorStatistic().then(stat => {
                    //window.console.info(stat);
                    console.log(stat);
                    commit('setColorsStatistic', stat);
                    resolve(stat)
                }).catch(error => {
                    reject(error)
                })
            });
        },
        setAvailableLevels({ commit }) {
            return new Promise((resolve, reject) => {
                getAvailableLevels().then(response => {
                    commit('setAvailableLevels', response);
                    resolve(response)
                }).catch(error => {
                    reject(error)
                })
            });
        },

        setTypeExercise({ commit }, credential) {
            commit('setTypeExercise', credential.type)
        },
        setUserAnswers({ commit }, credential) {
            commit('setUserAnswers', credential.answers)
        },
        setCurrentLevel({ commit }, credential) {
            commit('setCurrentLevel', credential.level)
        },
        setUserCurrentLevel({ commit }) {
            // И текущий уровень тоже будет получен через API
            let currentLevel = 8;
            commit('setUserCurrentLevel', currentLevel)
        },
        getDiagnosticExerciseColors({ commit }) {
            return new Promise((resolve, reject) => {
                getDiagnosticExerciseColors().then(r => {
                    commit('setExerciseColors', r.colors);
                    commit('setTimeRemembering', r.timeRemembering)
                    resolve(r)
                }).catch(error => {
                    reject(error);
                });
            });
        },
        getTrainingExerciseColors({ commit }, credential) {
            return new Promise((resolve, reject) => {
                getTrainingExerciseColors(credential.count).then(r => {
                    commit('setExerciseColors', r.colors);
                    commit('setTimeRemembering', r.timeRemembering)
                    resolve(r)
                }).catch(error => {
                    reject(error);
                });
            });
        },
        getAvailableColors({ commit }) {
            return new Promise((resolve, reject) => {
                getAvailableColors().then(r => {
                    commit('setAvailableColors', r.colors);
                    resolve(r)
                }).catch(error => {
                    reject(error);
                });
            });
        }
    }
}
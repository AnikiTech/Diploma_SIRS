import {
    getDiagnosticText,
    getDiagnosticTexts,
    getTrainingText,
    getTrainingTexts
} from "../../../../api/readingFast/readingFast";


export default {
    state: {
        exercise: {
            mode: {},
            textsInfo: {}
        },
        exerciseTraining: {
            text: {},
        },
        exerciseDiagnostic: {
            text: {},
            questions: {}
        }
    },

    getters: {
        getExerciseTrainingTexts(state) {
            return state.exercise.textsInfo;
        },
        getExerciseDiagnosticTexts(state) {
            return state.exercise.textsInfo;
        },
        getExerciseTrainingText(state){
            return state.exerciseTraining.text;
        },
        getExerciseDiagnosticText(state){
            return state.exerciseDiagnostic.text;
        }
    },

    mutations: {
        setExerciseMode(state, mode) {
            state.exercise.mode = mode;
        },

        setExerciseTrainingTexts(state, texts) {
            state.exercise.textsInfo = texts;
        },
        setExerciseTrainingText(state, text) {
            state.exerciseTraining.text = text;
        },
        setExerciseDiagnosticTexts(state, texts) {
            state.exercise.textsInfo = texts;
        },
        setExerciseDiagnosticText(state, text) {
            state.exerciseDiagnostic.text = text;
        }
    },

    actions: {
        setExerciseMode({commit}, mode) {
            // Тренинг = 1, Диагноситка = 0
            return new Promise((resolve) => {
                commit('setExerciseMode', mode)
                resolve()
            })
        },

        setExerciseTrainingTexts({commit}) {
            return new Promise((resolve, reject) => {
                getTrainingTexts().then(response => {
                    commit('setExerciseTrainingTexts', response);
                    resolve(response)

                }).catch(error => {
                    reject(error)
                })
            })
        },

        setExerciseDiagnosticTexts({commit}) {
            return new Promise((resolve, reject) => {
                getDiagnosticTexts().then(response => {
                    commit('setExerciseDiagnosticTexts', response);
                    resolve(response)

                }).catch(error => {
                    reject(error)
                })
            })
        },

        setExerciseTrainingText({commit}, id) {
            return new Promise((resolve, reject) => {
                getTrainingText(id).then(response => {
                    commit('setExerciseTrainingText', response);
                    resolve(response)

                }).catch(error => {
                    reject(error)
                })
            })
        },

        setExerciseDiagnosticText({commit}, id) {
            return new Promise((resolve, reject) => {
                getDiagnosticText(id).then(response => {
                    commit('setExerciseDiagnosticText', response);
                    resolve(response)

                }).catch(error => {
                    reject(error)
                })
            })
        }
    }
}
import { getWords, userAnswers }
    from "../../../../api/wordExercise/words";
import { getWordStatistic }
    from "../../../../api/wordExercise/statistic";

export default {
    state: {
        wordPreferences: {
            countWords: 1,
            countAnswerWords: 1,
            timeRemembering: 30
        },
        exerciseWord: {
            words: [],
            answerWords: []
        },
        words: [],
        userAnswer: [],
        exerciseResult: {
            markTrueAnswers: [],
            Points: {}
        },
        wordStatistic: []
    },
    getters: {
        getUserAnswersWords(state) {
            return state.wordPreferences.countAnswerWords;
        },
        getPreferences(state) {
            return state.wordPreferences;
        },
        getExercise(state) {
            return {
                countWords: state.wordPreferences.countWords,
                timeRemembering: state.wordPreferences.timeRemembering,
                words: state.exerciseWord.words,
                answerWords: state.exerciseWord.answerWords
            }
        },
        getExerciseData(state) {
            return {
                words: state.exerciseWord.words,
                answerWords: state.userAnswer,
                date: null,
                points: state.exerciseResult.Points,
                time: state.wordPreferences.timeRemembering
            }
        },
        getResult(state) {
            return state.exerciseResult;
        },
        getWordStatistic(state) {
            return state.wordStatistic;
        }
    },
    mutations: {
        setWordsStatistic(state, wordStatistic) {
            console.log("WORD_setStatistic");
            state.wordStatistic = wordStatistic;
        },
        setPreferences(state, credential) {
            state.wordPreferences = credential;
        },
        getExercise(state, credential) {

            state.exerciseWord = credential;
        },
        setUserAnswer(state, answer) {
            state.userAnswer = answer.userAnswer;
            state.words = answer.words;
        },
        setResult(state, result) {
            state.exerciseResult = result;
        }
    },
    actions: {
        getWordStatistic({ commit }) {
            return new Promise((resolve, reject) => {
                getWordStatistic().then(stat => {
                    window.console.info(stat)
                    commit('setWordsStatistic', stat);
                    resolve(stat)
                }).catch(error => {
                    reject(error)
                })
            });
        },
        setPreferences({ commit }, credential) {
            return new Promise((resolve) => {
                commit('setPreferences', credential)
                resolve()
            })
        },

        getExercise({ commit }, count) {
            return new Promise((resolve, reject) => {
                getWords(count).then(response => {
                    commit('getExercise', response);
                    resolve(response)

                }).catch(error => {
                    reject(error)
                })
            })
        },
        setUserAnswer({ commit }, answer) {
            return new Promise((resolve) => {
                commit('setUserAnswer', answer)
                resolve()
            })
        },

        sendExercise({ commit }, exerciseResult) {
            return new Promise((resolve, reject) => {
                userAnswers(exerciseResult).then(response => {
                    commit('setResult', response);
                    resolve(response)

                }).catch(error => {
                    reject(error)
                })
            })
        }
    }
}
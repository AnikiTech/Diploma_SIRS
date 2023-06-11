import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state:{
    ArrayForWord: [
      { name: 'мышка', id: 1},
      { name: 'краска', id: 2},
      { name: 'стена', id: 3},
      { name: 'воробей', id: 4},
      { name: 'флаг', id: 5},
      { name: 'заря', id: 6},
      { name: 'свеча', id: 7},
      { name: 'банк', id: 8},
      { name: 'лесник', id: 9},
      { name: 'парус', id: 10},
    ],
    ArrayForImg: {},
  },
  getters:{
    getArrayForWord: state => state.ArrayForWord,
    getArrayForImg: state => state.ArrayForImg,
  },
  mutations:{
    getArrayForWord(state, word) {
      state.ArrayForWord = word;
    },
    getArrayForImg(state, img) {
      state.ArrayForImg = img;
    },
  },
  actions:{
    getArrayForWord({commit}, word){
      commit('getArrayForWord', word);
    },
    getArrayForImg({commit}, img){
      commit('getArrayForImg', img);
    },
  }
})

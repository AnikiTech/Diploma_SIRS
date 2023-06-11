import Vue from 'vue'
import Vuex from 'vuex'

import auth from "./modules/auth";
import settings from "./modules/settings";
import colors from "./modules/exercises/MemoryColor/colors";
import words from "./modules/exercises/OrderWord/words";
import readingFast from "./modules/exercises/ReadingFast/readingFast";
import faces from "./modules/exercises/Faces/faces";

import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex);

export default new Vuex.Store({
  plugins: [
      createPersistedState({
          key: 'vuex-state',
          paths: ['settings']
      })
  ],
  modules: {
      auth,
      settings,
      colors,
      words,
      readingFast,
      faces
  }
})

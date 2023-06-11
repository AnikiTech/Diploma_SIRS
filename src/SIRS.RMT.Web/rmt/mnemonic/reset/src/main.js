import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'

import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css' // Ensure you are using css-loader
import VueRouter from 'vue-router'

Vue.use(VueRouter)
Vue.use(Vuetify)

//Vue.config.productionTip = false//

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App),
  el: '#app'
})
  //.$mount('#app')

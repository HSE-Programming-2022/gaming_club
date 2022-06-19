import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import AOS from 'aos'
import 'aos/dist/aos.css'

Vue.config.productionTip = false

Vue.prototype.$backend_url = 'http://127.0.0.1:8080'
if (process.env.BACKEND_URL) {
  Vue.prototype.$backend_url = process.env.BACKEND_URL
}

new Vue({
  vuetify,
  router,
  render: h => h(App),
  mounted() {
    AOS.init()
  }
}).$mount('#app')

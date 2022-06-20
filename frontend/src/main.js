import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import AOS from 'aos'
import 'aos/dist/aos.css'

Vue.config.productionTip = false

Vue.prototype.$backend_url = 'http://127.0.0.1:8080'
if (process.env.NODE_ENV === 'production') {
  Vue.prototype.$backend_url = 'http://mdpashedko.ru:8080'
}

console.log(Vue.prototype.$backend_url)

new Vue({
  vuetify,
  router,
  render: h => h(App),
  mounted() {
    AOS.init()
  }
}).$mount('#app')

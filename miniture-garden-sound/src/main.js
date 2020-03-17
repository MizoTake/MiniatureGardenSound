import Vue from 'vue'
import App from './App.vue'
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import {vueAccordion} from 'vue-accordion'

Vue.config.productionTip = false
Vue.use(VueMaterial)
Vue.component('vue-accordion', vueAccordion)

new Vue({
  render: h => h(App)
}).$mount('#app')

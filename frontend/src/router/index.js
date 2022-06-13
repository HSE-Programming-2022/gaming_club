import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ContactsView from "@/views/ContactsView"
import PriceView from "@/views/PriceView"
<<<<<<< Updated upstream
import NewsView from "@/views/NewsView"
=======
import SignUpView from "@/views/SignUpView";
import LoginView from "@/views/LoginView";
>>>>>>> Stashed changes

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/contacts',
    name: 'Contacts',
    component: ContactsView
  },
  {
    path: '/prices',
    name: 'Prices',
    component: PriceView
  },
  {

    path: '/news',
    name: 'News',
    component: NewsView
  },
  {
    path: '/signup',
    name: 'Sign Up',
    component: SignUpView
  },
  {
    path: '/login',
    name: 'Login',
    component: LoginView
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router

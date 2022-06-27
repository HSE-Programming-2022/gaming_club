import Vue from 'vue';
import VueRouter from 'vue-router';
import HomeView from '../views/HomeView.vue';
import ContactsView from "@/views/ContactsView";
import PriceView from "@/views/PriceView";
import NewsView from "@/views/NewsView";
import SignUpView from "@/views/SignUpView";
import LoginView from "@/views/LoginView";
import BookingView from "@/views/BookingView";
import ProfileView from "@/views/ProfileView";
import PayView from "@/views/PayView";


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
  {
    path: '/booking',
    name: 'Booking',
    component: BookingView
  },
  {
    path: '/profile',
    name: 'Profile',
    component: ProfileView
  },
  {
    path: '/pay',
    name: 'Pay',
    component: PayView
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router

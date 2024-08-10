import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import PersonalArea from '../views/PersonalArea.vue'
import RegistrationView from '../views/RegistrationView.vue'
import LoginView from '../views/LoginView.vue'
import NewAchievement from "@/views/NewAchievement.vue";
import EditProfile from "@/views/EditProfile.vue";
import CurrentEvents from "@/views/CurrentEvents.vue";
import FutureEvents from "@/views/FutureEvents.vue";
import Requests from "@/views/Requests.vue";
import AdminDashboard from "@/views/AdminDashboard.vue";


const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/PersonalArea',
    name: 'PersonalArea',
    component: PersonalArea
  },
  {
    path: '/Registration',
    name: 'Registration',
    component: RegistrationView
  },
  {
    path: '/Login',
    name: 'Login',
    component: LoginView
  },
  {
    path: '/NewAchievement',
    name: 'NewAchievement',
    component: NewAchievement
  },
  {
    path: '/EditProfile',
    name: 'EditProfile',
    component: EditProfile
  },
  {
    path: '/CurrentEvents',
    name: 'CurrentEvents',
    component: CurrentEvents
  },
  {
    path: '/FutureEvents',
    name: 'FutureEvents',
    component: FutureEvents
  },
  {
    path: '/Requests',
    name: 'Requests',
    component: Requests
  },
  {
    path: '/AdminDashboard',
    name: 'AdminDashboard',
    component: AdminDashboard
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router

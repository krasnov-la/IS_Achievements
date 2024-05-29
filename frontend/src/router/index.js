import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import PersonalArea from '../views/PersonalArea.vue'
import RegistrationView from '../views/RegistrationView.vue'


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
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router

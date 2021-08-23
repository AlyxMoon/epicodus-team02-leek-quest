import { createWebHistory, createRouter } from 'vue-router'

import Game from './pages/Game'
import Home from './pages/Home'
import Login from './pages/Login'
import Register from './pages/Register'

const routes = [
  {
    path: '/',
    component: Home,
  },
  {
    path: '/login',
    component: Login,
  },
  {
    path: '/register',
    component: Register,
  },
  {
    path: '/game',
    component: Game,
  },
]

const router = createRouter({
  routes,
  history: createWebHistory(),
})

export default router

import { createWebHistory, createRouter } from 'vue-router'

import store from '@/store'

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
    beforeEnter: (to, from, next) => {
      if (!store.getters.isLoggedIn) {
        return next('/login')
      }

      next()
    }
  },
]

const router = createRouter({
  routes,
  history: createWebHistory(),
})

export default router

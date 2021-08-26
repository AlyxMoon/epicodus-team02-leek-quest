import { createStore } from 'vuex'
import { 
  loginUser as apiLoginUser,
  getTokenAuthData as apiGetTokenAuthData,
  updateUserPosition as apiUpdateUserPosition,
} from '@/lib/api'

const state = {
  user: {},
  token: '',
}

const getters = {
  isLoggedIn (state) {
    return !!(state.user && state.user.id)
  },
}

const actions = {
  async getTokenAuthData (context) {
    try {
      const token = window.localStorage.getItem('token')
      if (!token) return

      const response = await apiGetTokenAuthData(token)

      context.dispatch('updateToken', token)
      context.commit('setUser', response)
    } catch (error) {
      console.error('getTokenAuthData error', error)
      context.dispatch('updateToken', '')
    }
  },

  async loginUser (context, userData) {
    try {
      const response = await apiLoginUser(userData.username, userData.password)

      if (response.result.succeeded) {
        context.commit('setUser', response.user)
        context.dispatch('updateToken', response.token)
      } else {
        context.commit('setUser', {})
        context.dispatch('updateToken', '')
      }

      return response
    } catch (error) {
      console.error(error)
    }
  },

  async updateToken (context, token) {
    if (token) {
      window.localStorage.setItem('token', token)
      context.commit('setToken', token)
    } else {
      window.localStorage.removeItem('token')
      context.commit('setToken', '')
    }
  },

  async updateUserPosition (context, direction) {
    try {
      const response = await apiUpdateUserPosition({ 
        userId: context.state.user.id,
        token: context.state.token,
        direction,
      })
  
      context.commit('setUser', {
        ...context.state.user,
        positionX: response.positionX,
        positionY: response.positionY,
      })
    } catch (error) {
      console.error('error updateUserPosition: ', error)
    }
  },
}

const mutations = {
  setToken (state, token) {
    state.token = token
  },

  setUser (state, user) {
    state.user = user
  },
}

const store = createStore({
  state,
  getters,
  actions,
  mutations,
})

export default store

// state
// the basic data, nothing else
// state = {
//   hello: 'world',
//   something: 42,
// }

// mutations
// functions that are allowed to edit the state
// function updateSomething (state, newVal) {
//   state.something = newVal
// }

// actions
// any "thing" you need to do that will end up updating state or not, whatever, it's freeballing
// function login (context, userdata) {
  // call the api with userData
  // context.dispatch('updateSomething', newVal)
// }

// getters
// function addToHello (state) => {
//   return state.hello + 'and everyone else'
// }

import { createStore } from 'vuex'
import { loginUser as apiLoginUser } from '@/lib/api'

const state = {
  user: {},
  token: '',
}

const actions = {
  async loginUser (context, userData) {
    try {
      const response = await apiLoginUser(userData.username, userData.password)

      if (response.result.succeeded) {
        context.commit('setUser', response.user)
      } else {
        context.commit('setUser', {})
      }

      return response
    } catch (error) {
      console.error(error)
    }
  },
}

const mutations = {
  setUser (state, user) {
    state.user = user
  },
}

const store = createStore({
  state,
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

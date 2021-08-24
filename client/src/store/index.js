import { createStore } from 'vuex'

const state = {
  user: null,
  token: '',
}

const mutations = {
  setUser (state, user) {
    state.user = user
  },
}

const store = createStore({
  state,
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

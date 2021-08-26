<template>
  <h1>Application</h1>

  <nav>
    <router-link to="/">Home</router-link>
    <router-link to="/game">Game</router-link>
    <router-link to="/register">Register</router-link>
    <router-link to="/login">Log In</router-link>

    <span>{{ user && user.userName }}</span>
  </nav>
  
  <router-view />
</template>

<script>
import { mapActions, mapState } from 'vuex'

export default {
  name: 'App',
  computed: {
    ...mapState({
      user: 'user',
      userList: 'userList',
    }),
  },

  created () {
    this.getTokenAuthData()
  },

  methods: {
    ...mapActions(['getTokenAuthData']),
  },
}
</script>

<style>
a {
  margin-right: 15px;
}
</style>

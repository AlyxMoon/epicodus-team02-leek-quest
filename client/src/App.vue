r<template>
  <h1>Application</h1>

  <nav>
    <router-link to="/">Home</router-link>
    <router-link to="/game">Game</router-link>
    <router-link to="/register">Register</router-link>
    <router-link to="/login">Log In</router-link>

    {{ user.username }}
  </nav>
  
  <router-view />
</template>

<script>
import { mapState } from 'vuex'

export default {
  name: 'App',
  computed: {
    ...mapState({
      user: 'user',
    }),
  },
}
</script>

<style>
a {
  margin-right: 15px;
}
</style>

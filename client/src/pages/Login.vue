<template>
  <h1>Log in Page!</h1>
  <p>Log in to join our leek quest</p>

  <form @submit.prevent="handleFormSubmit">
    <label>username</label>
    <input type="text" v-model="username" />
    <label>password</label>
    <input type"text" v-model="password" />
  </form>
</template>

<script>
import { applicationUser } from '../lib/api'

export default {
  name: 'LoginPage',
  data: () => ({
    username: '',
    password: '',
  }),
  methods: {

    handleFormSubmit () {
      this.applicationUser(username, password) {
        if (response['result'] === 'success') {
          return blah; 
        },
      },
    },
  },
}
</script>

<style scoped>

</style>
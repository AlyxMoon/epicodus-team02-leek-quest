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
    email: '',
  }),
  methods: {
    handleFormSubmit () {
      this.username
      this.password
      this.email
      this.applicationUser()
    },
  },
}
</script>

<style scoped>

</style>
<template>
  <h1>Register Page!</h1>
  <p>New user, Welcome!</p>

  <form @submit.prevent="handleFormSubmit">
    <label>email</label>
    <input type="text" v-model="email" />
    <label>username</label>
    <input type="text" v-model="username" />
    <label>password</label>
    <input type"text" v-model="password" />
  </form>
</template>

<script>
import { registerUser } from '../lib/api'

export default {
  name: 'RegisterPage',
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
      this.registerUser()
    },
  },
}
</script>

<style scoped>

</style>
<template>
  <h1>Register Page!</h1>
  <p>New user, Welcome!</p>

  <form @submit.prevent="handleFormSubmit">
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
  }),
  methods: {

    handleFormSubmit () {
      this.registerUser(username, password) {
        if (response['result'] === 'success') {
          this.$router.push('/login')
        } else if (response['result'] === 'error') {
          console.log(`There was an error: ${response['error']}`);
        } else {
          console.log(`There was an error: Invalid Input`);
      },
    },
  },
}
</script>

<style scoped>

</style>
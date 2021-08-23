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
      this.loginUser(username, password) {
        if (response['result'] === 'success') {
          this.$router.push('/game')
        } else if (response['result'] === 'error') {
          console.log(`There was an error: ${response['error']}`);
        } else {
          console.log(`There was an error: Invalid Input`);
        },
      },
    },
  },
}
</script>

<style scoped>

</style>
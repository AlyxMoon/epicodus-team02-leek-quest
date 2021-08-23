<template>
  <h1>Log in Page!</h1>
  <p>Log in to join our leek quest</p>

  <form @submit.prevent="handleFormSubmit">
    <label>username</label>
    <input type="text" v-model="username" />
    <label>password</label>
    <input type="text" v-model="password" />
    <button type="submit" class="btn">Log In</button>
  </form>
</template>

<script>
import { loginUser } from '../lib/api'

export default {
  name: 'LoginPage',
  data: () => ({
    username: '',
    password: '',
  }),
  methods: {
    async handleFormSubmit () {
      let response = await loginUser(this.username, this.password);
      console.log(response)
      console.log('hello- are we leeking?');
      if (response['success']) {
        this.$router.push('/game')
      } else {
        console.log(`There was an error: Invalid Input`);
      }
    },
  },
}
</script>

<style scoped>

</style>
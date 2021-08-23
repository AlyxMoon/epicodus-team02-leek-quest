<template>
  <h1>Register Page!</h1>
  <p>New user, Welcome!</p>

  <form @submit.prevent="handleFormSubmit">
    <label>username</label>
    <input type="text" class="margin" v-model="username" />
    <label>password</label>
    <input type="text" class="margin" v-model="password" />
    <button type="submit" class="btn">Register!</button>
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

    async handleFormSubmit () {
      let response = await registerUser(this.username, this.password);
      if (response['success']) {
        this.$router.push('/login')
      } else {
        console.log(`There was an error: Invalid Input`);
      }
    },
  },
}
</script>

<style scoped>
.margin {
  margin: 0 8px;
}
</style>
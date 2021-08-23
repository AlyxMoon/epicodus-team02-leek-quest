<template>
  <h1>Register Page!</h1>
  <p>New user, Welcome!</p>

  <form @submit.prevent="handleFormSubmit">
    <label>username</label>
    <input type="text" v-model="username" />
  </form>
</template>

<script>
// import { registerUser } from '../lib/api'

export default {
  name: 'RegisterPage',
  data: () => ({
    username: '',
  }),
  methods: {
    handleFormSubmit () {
      // this.username
      this.registerUser()
    },
  },
}
</script>

<style scoped>

</style>
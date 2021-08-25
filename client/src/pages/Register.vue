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
  <ul>
    <li 
      v-for="error of errors"
      :key="error.code"
    >
      {{ error.description }}
    </li>
  </ul>
</template>

<script>
import { registerUser } from '../lib/api'

export default {
  name: 'RegisterPage',
  data: () => ({
    username: '',
    password: '',
    errors: [],
  }),
  methods: {

    async handleFormSubmit () {
      const response = await registerUser(this.username, this.password);

      if (response.result.succeeded) {
        this.$router.push('/login')
      } else {
        this.errors = response.result.errors
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
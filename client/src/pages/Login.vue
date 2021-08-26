<template>
  <h1>Log in Page!</h1>
  <p>Log in to join our leek quest</p>

  <form @submit.prevent="handleFormSubmit">
    <label>username</label>
    <input type="text" class="margin" v-model="username" />
    <label>password</label>
    <input type="password" class="margin" v-model="password" />
    <button type="submit" class="btn">Log In</button>
  </form>
    <div class="showErrors">{{ error }}</div>
</template>

<script>
import { mapActions, mapState, mapMutations } from 'vuex'

export default {
  name: 'LoginPage',
  data: () => ({
    username: '',
    password: '',
    error: '',
  }),
  computed: {
    ...mapState({
      user: 'user',
    }),
  },
  methods: {
    ...mapActions(['loginUser']),
    ...mapMutations(['setUser']),

    async handleFormSubmit () {
      const response = await this.loginUser({
        username: this.username,
        password: this.password,
      })

      if (response.result.succeeded) {
        this.$router.push('/game')
      }
      else {
        this.error = "failed to log in; please try again"
      }
    }
  }
}
</script>

<style scoped>
.margin {
  margin: 0 8px;
}
</style>
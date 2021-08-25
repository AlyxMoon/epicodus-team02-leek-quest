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
    <div class="showErrors"></div>
</template>

<script>
import { mapState, mapMutations } from 'vuex'
import { loginUser } from '../lib/api'

export default {
  name: 'LoginPage',
  data: () => ({
    username: '',
    password: '',
  }),
  computed: {
    ...mapState({
      user: 'user',
    }),
  },
  methods: {
    ...mapMutations(['setUser']),

    clearFields() {
      ('.showErrors').text('');
    },

    async handleFormSubmit () {
      let response = await loginUser(this.username, this.password)

      if (response.result.succeeded) {
        this.setUser({ username: this.username })
        this.$router.push('/game')
      }
      if (!response.ok) {
        const error = "failed to log in; please try again"
        return ('.showErrors').text(Promise.reject(error));

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
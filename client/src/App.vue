<template>
  <Navbar />

  <router-view />
</template>

<script>
import { mapActions, mapState } from "vuex";
import Navbar from "./components/Navbar.vue";

export default {
  name: "App",
  components: {
    Navbar,
  },
  computed: {
    ...mapState({
      user: "user",
      userList: "userList",
    }),
  },

  created() {
    this.getTokenAuthData();
  },

  methods: {
    ...mapActions(["getTokenAuthData"]),
  },
};
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Josefin+Slab:wght@455&display=swap');
body {
  font-family: 'Josefin Slab', serif;

  text-align: center;
  background-repeat: no-repeat;
  background: radial-gradient(
    circle,
    rgba(124, 219, 116, 0.936) 31%,
    rgba(41, 210, 52, 0.8748541652989321) 100%
  );
}
li {
  list-style-type: none;
}
p{
  font-size: 1.2rem;
}
a {
  margin-right: 15px;
}
h2, h3{
  font-weight:600;
}
h1 {
  padding-top: 50px;
  font-weight: bold;
}
.btn {
  background: rgb(0, 119, 255);
}
.btn:hover {
  background: rgb(111, 0, 255);
}
</style>

<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <a class="navbar-brand" href="#">LEEKQUEST</a>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarNav"
      aria-controls="navbarNav"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
        <li class="nav-item active">
          <router-link to="/">Home</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/game">Game</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/register">Register</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/login">Log In</router-link>
        </li>
        <li class="nav-item">
          <span>{{ user && user.userName }}</span>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
export default {
  name: "Navbar",
};
</script>

<style scoped>
nav {
  opacity: 0.6;
  padding: 0 2%;
}
.navbar-brand {
  padding-left: 50px;
}
.navbar-brand:hover {
  padding-left: 50px;
  font-style: bolder;
  color: cyan;
  text-shadow: 2px 2px red;
}
.nav-item:hover {
  font-style: bolder;
  color: cyan;
  text-shadow: 1px 1px red;
}

/* unvisited link */
a:link {
  color: rgb(68, 68, 68);
  text-decoration: none;
}

/* visited link */
a:visited {
  color: rgb(68, 68, 68);
  text-decoration: none;
}

/* mouse over link */
a:hover {
  color: white;
}

/* selected link */
a:active {
  color: rgb(68, 68, 68);
}
</style>

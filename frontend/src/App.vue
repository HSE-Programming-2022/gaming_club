<template>
  <div id="app">
    <nav>
      <router-link to="/">Home</router-link> |
      <router-link to="/contacts">Contacts</router-link>
    </nav>
    <router-view/>


    <HereMap
      appId="APP-ID-HERE"
      appCode="APP-CODE-HERE"
      lat="37.7397"
      lng="-121.4252"
      width="100%"
      height="835px" />
  </div>
</template>

<script>
import HereMap from "./components/ClubMap.vue"

export default {
  name: 'app',
  components: {
    HereMap
  }
}
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>

<template>
  <v-app>
    <v-sheet
        id="scrolling-techniques-6"
        class="overflow-y-auto"
    >
        <v-content>
          <router-view>
          </router-view>
        </v-content>
    </v-sheet>
  </v-app>
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  background-color: aqua;
}

@font-face {
    font-family: "our_font";
    src: local("our_font"),
     url("@/assets/9331.ttf") format("truetype");
  }
</style>
<script>

export default {
}
</script>
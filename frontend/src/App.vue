<template>
  <v-app>
    <NavigationBar>
    </NavigationBar>
    <v-sheet
        id="scrolling-techniques-6"
    >
        <v-content style="height: 3000px; margin-top: 5px;">
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
}
</style>
<script>

import NavigationBar from "@/components/NavigationBar";

export default {
  components: {
    NavigationBar,
  },
  data: () => ({
    collapseOnScroll: true,
  }),
}
</script>
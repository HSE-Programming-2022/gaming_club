<template>
  <div class="home">
    <v-parallax
        height="500"
        src="@/assets/background.jpeg">
    </v-parallax>
    <HelloWorld />
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'HomeView',
  components: {
    HelloWorld
  },
}
</script>

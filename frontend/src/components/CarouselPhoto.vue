<template>
  <v-carousel class="Car">
    <v-carousel-item
        v-for="(item,i) in items"
        :key="i"
        :src="require('@/assets/contacts/'+item.src)"
        reverse-transition="fade-transition"
        transition="fade-transition"
    ></v-carousel-item>
  </v-carousel>
</template>


<script>
export default {
  data () {
    return {
      items: [
        {
          src: "ClubMap.png",
        },
        {
          src: "2.png",
        },
        {
          src: "3D.png",
        },
        {
          src: "4.png",
        },
        {
          src: "5.png",
        },
      ],
    }
  },
}
</script>


<style scoped>
.Car {
  width: 800px;
  margin: auto;
}
</style>
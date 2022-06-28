<template>
  <v-card
      class="mx-auto btn-gradient-2"
      max-width="500"
      :id="`trigger-${index+1}`"
      :data-aos-anchor="`#trigger-${index}`"
      :data-aos="`fade-${side}`"
      data-aos-delay="300"
      data-aos-anchor-placement="top-center"
      data-aos-duration="1000"
      style="margin-top: 5em;"
  >
    <v-card-text>
      <p class="computer_font text-h4 text--primary">
        {{ title }}
      </p>
      <div class="text--primary">
        {{ subtitle }}
      </div>
    </v-card-text>
    <v-card-actions>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: "AdvCard",
  props: {
    index: Object,
    title: Object,
    subtitle: Object,
    side: Object
  }
}
</script>

<style scoped>
  .computer_font {
    font-family: "our_font" !important;
  }
  .btn-gradient-2 {
    background:
        linear-gradient(rgb(20, 20, 20), rgb(28, 28, 28)) padding-box,
        linear-gradient(to right, rgb(134, 44, 130), rgb(201, 120, 60)) border-box;

    border-radius: 30px;
    border: 2px solid transparent;
  }
</style>
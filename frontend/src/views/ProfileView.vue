<template>
  <v-card
      class="mx-auto"
      max-width="344"
  >
    <v-card-text>
      <div>Word of the Day</div>
      <p class="text-h4 text--primary">
        el·ee·mos·y·nar·y
      </p>
      <p>adjective</p>
      <div class="text--primary">
        relating to or dependent on charity; charitable.<br>
        "an eleemosynary educational institution."
      </div>
    </v-card-text>
    <v-card-actions>
      <v-btn
          text
          color="teal accent-4"
          @click="reveal = true"
      >
        Learn More
      </v-btn>
    </v-card-actions>

    <v-expand-transition>
      <BalanceCard />
    </v-expand-transition>
  </v-card>
</template>

<script>
export default {
  name: "ProfileView"
}
</script>

<style scoped>

</style>
<template>
  <v-card
        class="mx-auto"
        max-width="450"
    >
      <v-card-text>

        <p class="text-h4 text--primary">
          Адрес клуба:                              Телефон:                          Почта:
        </p>
        <p>adjective</p>
        <div class="text--primary">
          г.Самара ул.Молодогвардейская д.180        +7(937)073-8220                  У них её нет, сорямба
        </div>
      </v-card-text>
      <v-card-actions>
        <v-btn
            text
            color="teal accent-4"
            @click="reveal = true"
        >
        </v-btn>
      </v-card-actions>

      <v-expand-transition>
        <v-card
            v-if="reveal"
            class="transition-fast-in-fast-out v-card--reveal"
            style="height: 100%;"
        >
        </v-card>
      </v-expand-transition>
    </v-card>
</template>

<script>
export default {
  data: () => ({
    reveal: false,
  }),
}
</script>

<style>
.v-card--reveal {
bottom: 0;
opacity: 1 !important;
position: absolute;
width: 100%;
}
</style>
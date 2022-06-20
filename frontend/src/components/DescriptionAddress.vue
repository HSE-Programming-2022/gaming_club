<template>
  <v-card
      class="mx-auto"
      max-width="500"
  >
    <v-card-text>
      <div class="pp"> Как пройти к нашему клубу?</div>
      <p class="text-h4">

      </p>
      <div class="text--primary">
      <p>Вход находится со стороны улицы Молодогвардейская</p>
        за рестораном "Чипоаучо".<br>
        Дверь находится правее двери салона красоты (см фото 4). <br>
        При входе висит белая вывеска с названием клуба "REBORN"
      </div>
    </v-card-text>
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
}
.mx-auto {
  width: 200%;
  margin: auto;
}
.pp {
  font-size: 15px;
}
.text--primary{
  font-size: 16px;
}
</style>
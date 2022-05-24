<template>
  <v-card
      class="mx-auto"
      max-width="450"
  >
    <v-card-text>
      <template v-slot:default>
        <thead>
        <tr>
          <th class="text-left">
            Samara
          </th>
          <th class="text-left">
            Telephone
          </th>
        </tr>
        </thead>
        <tbody>
        <tr
            v-for="item in Samara"
            :key="item.name"
        >
          <td>{{ item.name }}</td>
          <td>{{ item.number }}</td>
        </tr>
        </tbody>
      </template>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  name: "BestComponent.vue",
  data: () => ({
    reveal: false,
  }),
    Samara: [
      {
        name: ' г.Самара ул.Молодогвардейская д.180',
        number: '7(937)073-82-20',
      }
    ],
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
<template>
  <v-simple-table>
    <template v-slot:default>
      <thead>
      <tr>
        <th class="text-left">
          Адрес клуба:
        </th>
        <th class="text-left">
          Телефон:
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
  </v-simple-table>
</template>

<script>
export default {
  data () {
    return {
      Samara: [
        {
          name: ' г.Самара ул.Молодогвардейская д.180',
          number: '+7(937)073-82-20',
        }
      ],
    }
  },
}
</script>

<style scoped>

</style>
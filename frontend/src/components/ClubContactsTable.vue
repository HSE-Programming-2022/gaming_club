<template>
  <v-simple-table class="stable">
    <template v-slot:default>
      <thead>
      <tr style="background: transparent;">
        <th class="text-left">
          Адрес клуба:
        </th>
        <th class="text-left">
          Телефон:
        </th>
      </tr>
      </thead>
      <tbody >
      <tr
          v-for="item in Samara"
          :key="item.name"
      >
        <td class="abcd text-left">{{ item.name }}</td>
        <td class="ef text-left">{{ item.number }}</td>
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

<style scoped lang="scss">
th.text-left {
  font-size: 25px !important;
}
.abcd {
  font-size: 20px !important;
}
.ef {
  font-size: 20px !important;
}
.stable {
  width: 600px !important;
  text-align: center;
  background: #fc0;
  margin: auto;
  border: transparent;
  opacity: 1;
}

tbody {
  tr:hover {
    background-color: transparent !important;
  }
}
</style>
<template>
<div>
    <h1 class="computer_font display-2 font-weight-bold mb-3">бронирование мест</h1>
    <v-row justify="center" style="margin-top:30px">
        <div>
        <v-date-picker
            v-model="picker"
            show-adjacent-months
            :show-current="false"
            locale="ru"
            style="font-family: our_font; margin-right: 100px; margin-top: 14px;"
            width="400"
            color="purple"
            header-color="default"
        ></v-date-picker>
        <v-time-picker style="font-family: our_font;"
            ampm-in-title
            :allowed-minutes="allowedMinutes"
            format="24hr"
            scrollable
            color="orange"
            header-color="default"
        ></v-time-picker>
        <v-time-picker style="font-family: our_font; margin-left: 10px;"
            ampm-in-title
            format="24hr"
            scrollable
            :allowed-minutes="allowedMinutes"
            color="orange"
            header-color="default"
        ></v-time-picker>
        </div>
    </v-row>
    <div style="margin-top:30px;">
      <v-row v-for="row in 2" :key="row"> 
      <v-img v-for="seat in seats.slice(10*(row-1), 10*(row))" :key="seat.Id"
            :src="require('@/assets/fractured_picture/'+ seat.Number + '.svg')"
            
      ></v-img></v-row>
      <v-img
            :src="require('@/assets/fractured_picture/line.svg')"
      ></v-img>
      <v-row v-for="row in [3, 4]" :key="row"> 
      <v-img v-for="seat in seats.slice(10*(row-1), 10*(row))" :key="seat.Id"
            :src="require('@/assets/fractured_picture/'+ seat.Number + '.svg')"
      ></v-img></v-row>
    </div>
    <v-btn style="margin-top:30px" v-if="true">Забронировать</v-btn>
</div>
</template>

<script>
import seats from "@/assets/seats.json"
  export default {
    data: () => ({
    show: false,
    overlay: false,
    seats: seats.seats,
    picker: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)
    }),

    methods: {
      allowedMinutes: m => m % 5 === 0,
    },
  }
</script>

<style scoped>
  .computer_font {
    font-family: "our_font" !important;
  }
  
</style>
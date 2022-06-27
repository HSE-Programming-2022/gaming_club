<template>
<div>
    <h1 class="computer_font display-2 font-weight-bold mb-3">бронирование мест</h1>
    <v-row justify="center" style="margin-top:30px">
        <div>
        <v-date-picker
            v-model="res_date"
            show-adjacent-months
            :show-current="false"
            locale="ru"
            style="font-family: our_font; margin-right: 100px; margin-top: 14px;"
            width="400"
            color="purple"
            header-color="default"
            :min="getneededDate(new Date())"
            @click="$refs.menu.save(new Date(res_date))"
        ></v-date-picker>
        <v-time-picker style="font-family: our_font;"
            v-model="time1"
            ampm-in-title
            :allowed-minutes="allowedMinutes"
            :min="minHours(res_date)"
            format="24hr"
            scrollable
            color="orange"
            header-color="default"
            @click:minute="$refs.menu.save(time1)"
        ></v-time-picker>
        </div>
    </v-row>
  <div style="display:flex; flex-direction:column; align-items:center">
    <div style="margin-top:30px; display:flex; align-items: center;">
      <v-img v-if="hours > 0"
      :src="require('@/assets/arrows/left.svg')"
      style="max-width:48px; max-height:86px; margin-right:15px"
      v-on:click="hours -= 1"
      ></v-img>
      <v-img v-else
      :src="require('@/assets/arrows/left_disabled.svg')"
      style="max-width:48px; max-height:86px; margin-right:15px"
      ></v-img>
      <div style="font-family: our_font; font-size:100px;">{{hours}}</div>
      <v-img 
      :src="require('@/assets/arrows/right.svg')"
      style="max-width:48px; max-height:86px; margin-left:15px"
      v-on:click="hours += 1"
      ></v-img>
      </div>
    </div>
    <div style="margin-top:30px; background-color:#252525;">
      <v-row v-for="row in 2" :key="row"> 
      <v-img v-for="seat in seats.slice(10*(row-1), 10*(row))" :key="seat.Id"
            :src="require('@/assets/fractured_picture/'+ seat.Number + '.svg')"
            :style="{'visibility' : backfunc(new Date(res_date + ' ' + time1 + ':00'), new Date((new Date(res_date + ' ' + time1 + ':00').getTime()+hours*60*60*1000)), seat.Number) ? 'hidden' : 'visible', 'opacity' : seat.Number == chosen_seat || seat.Number == watched_seat ? 1 : 0.5 }" 
            @click="chosen_seat = seatChoose(seat.Number, chosen_seat)" 
            @mouseover="watched_seat=seatWatch(seat.Number, watched_seat)"
            @mouseleave="watched_seat=null"
      ></v-img></v-row>
      <v-img
            :src="require('@/assets/fractured_picture/line.svg')"
      ></v-img>
      <v-row v-for="row in [3, 4]" :key="row"> 
      <v-img v-for="seat in seats.slice(10*(row-1), 10*(row))" :key="seat.Id"
            :src="require('@/assets/fractured_picture/'+ seat.Number + '.svg')"
            :style="{'visibility' : backfunc(new Date(res_date + ' ' + time1 + ':00'), new Date((new Date(res_date + ' ' + time1 + ':00').getTime()+hours*60*60*1000)), seat.Number) ? 'hidden' : 'visible', 'opacity' : seat.Number == chosen_seat || seat.Number == watched_seat ? 1 : 0.5 }" 
            @click="chosen_seat = seatChoose(seat.Number, chosen_seat)"
            @mouseover="watched_seat=seatWatch(seat.Number, watched_seat)"
            @mouseleave="watched_seat=null"
      ></v-img></v-row>
    </div>
    <v-btn style="margin-top:30px" v-if="true">Забронировать</v-btn>
    <div v-if="time1">{{time1}}</div>
    <div>{{min_reservation_date}}</div>
    <div>{{new Date((new Date(res_date + ' 00:00:00').getTime()+hours*60*60*1000))}}</div>
</div>
</template>

//{{(new Date("01-01-2000 " + time2) - new Date("01-01-2000 " + time1))/(1000*60)-Math.floor((new Date("01-01-2000 " + time2) - new Date("01-01-2000 " + time1))/(1000*60*60))*60}}
//(new Date("01-01-2000 " + time1))/(1000*60*60)

<script>
import seats from "@/assets/seats.json"
  export default {
    data: () => ({
    show: false,
    overlay: false,
    seats: seats.seats,
    time1: null,
    hours: 0,
    res_date: null,
    chosen_seat: null,
    watched_seat: null
    }),

    methods: {
      allowedMinutes: m => m % 5 === 0,
      minHours(res_date) {
        if (new Date(res_date).getDate() == new Date().getDate())
        {
          return (new Date().getHours().toString()+':'+new Date().getMinutes().toString())
        }
        else
        {
          return '00:00'
        }
      },

      seatChoose(Number, chosen_seat) {
        if (chosen_seat != Number)
        {
          chosen_seat = Number
        }
        else
        {
          chosen_seat = null
        }
        return chosen_seat
      },

      seatWatch(Number, watched_seat) {
        if (watched_seat != Number)
        {
          watched_seat = Number
        }
        else
        {
          watched_seat = null
        }
        return watched_seat
      },

//      async get_reservations(res_datetime_start, res_datetime_end) {
//      let reservations = new Array()
//      await axios.get(this.$backend_url + "/reservations")

//      },
      backfunc(date, date1, number) {
        if(date && date1 && number)
        {
          return false
        }
        else
        {
          return false
        }
      },

      getneededDate(today) {
        var dd = today.getDate();
        var mm = today.getMonth()+1; 
        var yyyy = today.getFullYear();
        
        if(dd<10) 
        {
          dd='0'+dd;
        } 

        if(mm<10) 
        {
          mm='0'+mm;
        } 

        return today = yyyy+'-'+mm+'-'+dd;
      }
          },
        }
</script>

<style scoped>
  .computer_font {
    font-family: "our_font" !important;
  }
  
</style>
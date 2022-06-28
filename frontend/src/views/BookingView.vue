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
<div>
   <div style="margin-top:30px; background-color:#252525;">
      <v-row v-for="row in 2" :key="row"> 
      <v-img v-for="seat in seats.slice(10*(row-1), 10*(row))" :key="seat"
            :src="require('@/assets/fractured_picture/'+ seat.number + '.svg')"
            :style="{'visibility' : backfunc(new Date(res_date + ' ' + time1 + ':00'), new Date((new Date(res_date + ' ' + time1 + ':00').getTime()+hours*60*60*1000)), seat.id) ? 'hidden' : 'visible', 'opacity' : seat.id == chosen_seat || seat.id == watched_seat ? 1 : 0.5 }" 
            @click="chosen_seat = seatChoose(seat.id, chosen_seat)" 
            @mouseover="watched_seat=seatWatch(seat.id, watched_seat)"
            @mouseleave="watched_seat=null"
      ></v-img></v-row>
      <v-img
            :src="require('@/assets/fractured_picture/line.svg')"
      ></v-img>
      <v-row v-for="row in [3, 4]" :key="row"> 
      <v-img v-for="seat in seats.slice(10*(row-1), 10*(row))" :key="seat"
            :src="require('@/assets/fractured_picture/'+ seat.number + '.svg')"
            :style="{'visibility' : backfunc(new Date(res_date + ' ' + time1 + ':00'), new Date((new Date(res_date + ' ' + time1 + ':00').getTime()+hours*60*60*1000)), seat.id) ? 'hidden' : 'visible', 'opacity' : seat.id == chosen_seat || seat.id == watched_seat ? 1 : 0.5 }" 
            @click="chosen_seat = seatChoose(seat.id, chosen_seat)"
            @mouseover="watched_seat=seatWatch(seat.id, watched_seat)"
            @mouseleave="watched_seat=null"
      ></v-img></v-row>
    </div>
    <v-btn style="margin-top:30px" @click="submit" v-if="true">Забронировать</v-btn>
</div>
</div>
</template>

//{{(new Date("01-01-2000 " + time2) - new Date("01-01-2000 " + time1))/(1000*60)-Math.floor((new Date("01-01-2000 " + time2) - new Date("01-01-2000 " + time1))/(1000*60*60))*60}}
//(new Date("01-01-2000 " + time1))/(1000*60*60)

<script>
import axios from "axios"
  export default {
    data: () => ({
    show: false,
    overlay: false,
    seats: null,
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

      seatChoose(id, chosen_seat) {
        if (chosen_seat != id)
        {
          chosen_seat = id
        }
        else
        {
          chosen_seat = null
        }
        return chosen_seat
      },

      seatWatch(id, watched_seat) {
        if (watched_seat != id)
        {
          watched_seat = id
        }
        else
        {
          watched_seat = null
        }
        return watched_seat
      },

      async getSeats() {
        let seats = new Array()
        await axios.get(this.$backend_url + "/places")
        .then(function(response) {
          for (let i = 0; i < response.data.length; i++) {
            seats.push(response.data[i])
          }
        })
        this.seats = seats
        },

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
      },
      padTo2Digits(num) {
        return num.toString().padStart(2, '0');
      },
      formatDate(date) {
          return (
            [
              date.getFullYear(),
              this.padTo2Digits(date.getMonth() + 1),
              this.padTo2Digits(date.getDate()),
            ].join('-') +
            ' ' +
            [
              this.padTo2Digits(date.getHours()),
              this.padTo2Digits(date.getMinutes()),
              this.padTo2Digits(date.getSeconds()),
            ].join(':')
          );
        },
       async submit () {
          console.log(this.chosen_seat)
          console.log(this.res_date + ' ' + this.time1 + ':00')
          console.log(this.formatDate(new Date((new Date(this.res_date + ' ' + this.time1 + ':00').getTime()+this.hours*60*60*1000))))
          console.log(this.userId)
          await axios.post(this.$backend_url + "/reservations", {
           userId: this.userId,
           placeId: this.chosen_seat,
           startTime: this.res_date + ' ' + this.time1 + ':00',
           finishTime: this.formatDate(new Date((new Date(this.res_date + ' ' + this.time1 + ':00').getTime()+this.hours*60*60*1000)))
          })
              .then(function (response) {
                console.log(response.status)
                if (response.status === 201) {
                  console.log("заебись")
                }
              })
              .catch(function (error) {
                console.log(error)
              });
        }
  },
    mounted()
  {
    let user = localStorage.getItem('user-info')
    console.log(user)
    if (!user)
    {
      this.$router.push({name: "Login"})
    }
    user = JSON.parse(user)
    this.userId = user['id']
    this.getSeats()
  },
        }
</script>

<style scoped>
  .computer_font {
    font-family: "our_font" !important;
  }
  
</style>
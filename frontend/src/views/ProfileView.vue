<template>
<div>
  <h1 class="description" align="left" style="margin-left: 790px; margin-bottom: 40px; font-size: 30px; color: #D3D3D3; position: fixed">
      Профиль пользователя
  </h1>
  <v-row style="align: left">
    <h2 align="left" style="margin-left: 140px; font-size: 20px; font-size: 23px; color: #D3D3D3"> 
    <div style="margin-top: 10px; margin-bottom: 10px;">
    Ты провел в клубе: {{ Math.floor(total_time / 3600000) }} ч {{ Math.floor((total_time / 3600000 - Math.floor(total_time / 3600000)) * 60)}} минут </div> <hr>
    <div style="margin-top: 10px; color: purple">
    Текущие брони:  
    </div>
    <div v-if="current_res.length == 0">
      Пока броней нет - самое время поиграть!
    </div>
    <div v-else>
      <div v-for="(item) in current_res" :key="item">
        <div style="margin-left: 10px; margin-bottom: 5px; margin-top: 10px; font-size: 18px"> {{ item['startTime'] }} - {{ item['finishTime'] }} </div>
        <div style="margin-left: 10px; margin-bottom: 10px; font-size: 12px"> ряд: {{ item['placeRow'] }} место: {{ item['placeNumber'] }}</div> <hr>
      </div>
    </div> 
    <div style="margin-top: 10px; color: #808080">
    Прошедшие брони:
    </div>
    <div v-if="past_res.length == 0">
      Пока броней не было - самое время поиграть!
    </div>
    <div v-else>
      <div v-for="(item, index) in past_res" :key="item">
        <div style="margin-left: 10px; margin-bottom: 5px; margin-top: 10px; font-size: 18px"> {{ item['startTime'] }} - {{ item['finishTime'] }} </div> 
        <div style="margin-left: 10px; margin-bottom: 10px; font-size: 12px"> ряд: {{ item['placeRow'] }} место: {{ item['placeNumber'] }} </div>
        <div v-if="index != past_res.length - 1">
          <hr>
        </div>
      </div>
    </div>
  </h2>
  <ProfileCard align="left" style="margin-left: 55%; margin-top: 70px; position: fixed" :Name=this.name :Surname=this.surname :Email=this.email :Balance=this.balance :PictureNumber=this.random_number />
   </v-row>
</div>
</template>



<script>
import ProfileCard from "@/components/ProfileCard.vue"
import axios from "axios";
export default {
  methods: { 
    getRandomNumber(min, max) {
      return Math.floor(Math.random() * (max - min) + min);
    },
    async get_reservations () {
      var time = 0
      let res_current = new Array()
      let res_past = new Array()
      await axios.get(this.$backend_url + "/reservations")
      .then(function(response) {
        for (let i = 0; i < response.data.length; i++) {
          if (new Date(response.data[i]['startTime']) > new Date()){
            res_current.push(response.data[i])
            res_current[res_current.length - 1]['startTime'] = res_current[res_current.length - 1]['startTime'].replace('T', ' ')
            res_current[res_current.length - 1]['startTime'] = res_current[res_current.length - 1]['startTime'].replace('Z', ' ')
            res_current[res_current.length - 1]['finishTime'] = res_current[res_current.length - 1]['finishTime'].replace('T', ' ')
            res_current[res_current.length - 1]['finishTime'] = res_current[res_current.length - 1]['finishTime'].replace('Z', ' ')
          }
          else {
            var f = new Date(response.data[i]['finishTime']);
            var s = new Date(response.data[i]['startTime']);
            f -= s 
            time += f
            res_past.push(response.data[i])
            res_past[res_past.length - 1]['startTime'] = res_past[res_past.length - 1]['startTime'].replace('T', ' ')
            res_past[res_past.length - 1]['startTime'] = res_past[res_past.length - 1]['startTime'].replace('Z', ' ')
            res_past[res_past.length - 1]['finishTime'] = res_past[res_past.length - 1]['finishTime'].replace('T', ' ')
            res_past[res_past.length - 1]['finishTime'] = res_past[res_past.length - 1]['finishTime'].replace('Z', ' ')
          }
        }
      })
      this.total_time = time
      this.current_res = res_current
      this.past_res = res_past
    }
   }, 
    data () {
    return {
      name: '',
      surname: '',
      email: '',
      balance: 0,
      random_number: 0,
      total_time: 0,
      current_res: '',
      past_res: '',
    }}
  ,
  mounted()
  {
    let user = localStorage.getItem('user-info')
    console.log(user)
    if (!user)
    {
      this.$router.push({name: "Login"})
    }
    user = JSON.parse(user)
    this.name = user['name']
    this.surname = user['surname']
    this.email = user['email']
    this.balance = user['balance']
    this.random_number = this.getRandomNumber (1, 8) 
    this.get_reservations()
  },
  name: 'ProfileView', 
  components: {
    ProfileCard
  },
}
</script>

<style>
  .description{
     font-family: "our_font";
     font-size: 20px;
  }
   hr {
        height: 2px;
        background-color: #4c4c4c;
        border: none;
      }
</style>
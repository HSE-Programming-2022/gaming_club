<template>
<div>
  <h1 class="description" align="left" style="margin-left: 130px; margin-bottom: 40px; font-size: 30px">
      Профиль пользователя
  </h1>
  <v-row style="align: left">
  <ProfileCard align="left" style="margin-left: 130px" :Name=this.name :Surname=this.surname :Email=this.email :Balance=this.balance :PictureNumber=this.random_number />
  <ProfileCard2 align="left" />
  </v-row>
</div>
</template>



<script>
import ProfileCard from "@/components/ProfileCard.vue"
import ProfileCard2 from "@/components/ProfileCard2.vue"
export default {
  methods: { 
    getRandomNumber(min, max) {
      return Math.floor(Math.random() * (max - min) + min);
    }
   }, 
    data () {
    return {
      name: '',
      surname: '',
      email: '',
      balance: 0,
      random_number: 0
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
  },
  name: 'ProfileView', 
  components: {
    ProfileCard,
    ProfileCard2
  },
}
</script>

<style>
  .description{
     font-family: "our_font";
     font-size: 20px;
  }
</style>
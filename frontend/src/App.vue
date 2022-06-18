<template>
  <div>
    <v-app>
      <div v-if="this.loadedUserInfo">
        <NavigationBar :userLoggedInProp=this.userLoggedIn>
        </NavigationBar>
        <v-sheet
            id="scrolling-techniques-6"
        >
          <v-content style="height: 3000px; padding-top: 6em;">
            <router-view>
            </router-view>
          </v-content>
        </v-sheet>
      </div>
      <div v-else class="loading">
        <div class="logo"><b>R<span>E</span>B<span>O</span><span>R</span>N</b></div>
      </div>
    </v-app>
  </div>
</template>

<style lang="scss">
@import url(//fonts.googleapis.com/css?family=Vibur);
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}

@font-face {
  font-family: "our_font";
  src: local("our_font"),
  url("@/assets/9331.ttf") format("truetype");
}

.loading {
  height:100%;
  background: #112 url("@/assets/loadingbackground.gif") center no-repeat;
  background-size: auto;
}
.logo {
  text-align: center;
  width: 65%;
  height: 250px;
  margin: auto;
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 22em;
  user-select: none;
}

.logo b{
  font: 400 7vh "our_font";
  color: #fee;
  text-shadow: 0 -40px 100px, 0 0 2px, 0 0 1em #ff4444, 0 0 0.5em #ff4444, 0 0 0.1em #ff4444, 0 10px 3px #000;
  margin-right: 7em;
}
.logo b span{
  animation: blink linear infinite 2s;
}
.logo b span:nth-of-type(2){
  animation: blink linear infinite 3s;
}
@keyframes blink {
  78% {
    color: inherit;
    text-shadow: inherit;
  }
  79%{
    color: #333;
  }
  80% {

    text-shadow: none;
  }
  81% {
    color: inherit;
    text-shadow: inherit;
  }
  82% {
    color: #333;
    text-shadow: none;
  }
  83% {
    color: inherit;
    text-shadow: inherit;
  }
  92% {
    color: #333;
    text-shadow: none;
  }
  92.5% {
    color: inherit;
    text-shadow: inherit;
  }
}


/* follow me @nodws */
#btn-twtr{
  clear:both;
  color:#fff;
  border:2px solid;
  border-radius:3px;
  text-align:center;
  text-decoration:none;
  display:block;
  font-family:sans-serif;
  font-size:14px;
  width:13em;
  padding:5px 10px;
  font-weight:600;
  position:absolute;
  bottom:20px;
  left:0;
  right:0;
  margin:0 auto;
  background:rgba(0,0,0,0.2);
  box-shadow:0 0 0px 3px rgba(0,0,0,0.2);
  opacity:0.4
}#btn-twtr:hover{color:#fff;opacity:1}
</style>
<script>

import NavigationBar from "@/components/NavigationBar";
import axios from "axios";

export default {
  components: {
    NavigationBar,
  },
  data() {
    return {
      collapseOnScroll: true,
      userLoggedIn: false,
      loadedUserInfo: false,
    }
  },
  watch: {
    '$route' () {
      window.scrollTo(0,0);
      let user = localStorage.getItem('user-info')
      if (user) {
        if (!this.userLoggedIn) {
          location.reload()
        }
      } else {
        this.loadedUserInfo = true
        this.userLoggedIn = false
      }
    }
  },
  methods: {
    async preload_data(){
      let userLogged = false
      if (!this.loadedUserInfo) {
        let user = localStorage.getItem('user-info')
        let user_found = true
        if (user)
        {
          let userJson = JSON.parse(user)
          await axios.post("http://127.0.0.1:8080/users/verify", {
            email: userJson.email,
            password: userJson.password,
          })
              .then(function (response) {

                if (response.status === 200) {
                  userLogged = true
                }
              })
              .catch(function (error) {
                if (error.response) {
                  user_found = false
                }
              });
          if (!user_found) {
            localStorage.removeItem('user-info')
            this.userLoggedIn = false
          }
        }
      }
      this.userLoggedIn = userLogged
      this.loadedUserInfo = true
    }
  },
  mounted() {
    this.preload_data();
  },
}
</style>

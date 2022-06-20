<template>
  <nav>
    <v-app-bar
    :collapse="!collapseOnScroll"
    :collapse-on-scroll="collapseOnScroll"
    fixed
    dark
    scroll-target="#scrolling-techniques-6"
    >
    <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    <v-toolbar-title>
      REBORN компьютерный клуб
    </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-checkbox
        v-model="collapseOnScroll"
        color="white"
        hide-details
        :on-icon="'mdi-arrow-left-bold'" :off-icon="'mdi-arrow-right-bold'"
    ></v-checkbox>
    </v-app-bar>

    <v-navigation-drawer
        v-model="drawer"
        fixed
        temporary
    >
      <v-list
          nav
          dense
      >
        <v-list-item-group
            v-model="group"
            active-class="deep-purple--text text--accent-4"
        >
          <v-list-item to="/">
            <v-list-item-icon>
              <v-icon>mdi-home</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              Домашняя страница
            </v-list-item-title>
          </v-list-item>

          <v-list-item to="/contacts">
            <v-list-item-icon>
              <v-icon>mdi-card-account-phone-outline</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              Контакты
            </v-list-item-title>
          </v-list-item>

          <v-list-item to="/prices">
            <v-list-item-icon>
              <v-icon>mdi-cash-multiple</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              Цены
            </v-list-item-title>
          </v-list-item>

          <v-list-item to="/news">
            <v-list-item-icon>
              <v-icon>mdi-newspaper</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              Новости
            </v-list-item-title>
          </v-list-item>

          <v-list-item to="/signup" v-if="!this.userLoggedIn">
            <v-list-item-icon>
              <v-icon>mdi-login</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              Регистрация
            </v-list-item-title>
          </v-list-item>

          <v-list-item to="/login" v-if="!this.userLoggedInProp">
            <v-list-item-icon>
              <v-icon>mdi-account</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              Логин
            </v-list-item-title>
          </v-list-item>
          <v-list-item to="/profile" v-if="this.userLoggedIn">
            <v-list-item-icon>
              <v-icon>mdi-account</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              Профиль
            </v-list-item-title>
            </v-list-item>
          <v-list-item @click="logout" v-if="this.userLoggedIn">
            <v-list-item-icon>
              <v-icon>mdi-arrow-left</v-icon>
            </v-list-item-icon>
            <v-list-item-title>
              Выйти
            </v-list-item-title>
          </v-list-item>
           
        </v-list-item-group>

      </v-list>
    </v-navigation-drawer>
  </nav>
</template>
<script>
export default {
  data: () => ({
    drawer: false,
    group: null,
    collapseOnScroll: true,
    hide: false,
  }),
  methods: {
    logout() {
      localStorage.removeItem('user-info')
      location.reload()
    }
  },
  props: {
    userLoggedInProp: Boolean
  }
}
</script>
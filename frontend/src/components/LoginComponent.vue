<template>
  <div>
    <h1>Логин</h1>
    <v-alert
        v-if=user_not_found
        shaped
        dense
        dark
        outlined
        type="warning"
    >
      Неверный логин или пароль
    </v-alert>
    <validation-observer
        ref="observer"
        v-slot="{ invalid }"
    >
      <form @submit.prevent="submit">
        <validation-provider
            v-slot="{ errors }"
            name="email"
            rules="required|email"
        >
          <v-text-field
              v-model="email"
              :error-messages="errors"
              label="E-mail"
              required
          ></v-text-field>
        </validation-provider>
        <validation-provider
            v-slot="{ errors }"
            name="password"
            rules="required|password"
        >
          <v-text-field
              v-model="password"
              :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
              :type="show ? 'text' : 'password'"
              :error-messages="errors"
              name="input-10-2"
              label="Пароль"
              hint="At least 8 characters"
              class="input-group--focused"
              @click:append="show = !show"
          ></v-text-field>
        </validation-provider>
        <v-btn
            class="mr-4"
            type="submit"
            :disabled="invalid"
        >
          submit
        </v-btn>
        <v-btn @click="clear">
          clear
        </v-btn>
      </form>
    </validation-observer>
  </div>
</template>

<script>

import { required, digits, email, max, regex } from 'vee-validate/dist/rules'
import { extend, ValidationObserver, ValidationProvider, setInteractionMode } from 'vee-validate'
import axios from "axios";

setInteractionMode('eager')

extend('digits', {
  ...digits,
  message: '{_field_} needs to be {length} digits. ({_value_})',
})

extend('required', {
  ...required,
  message: '{_field_} can not be empty',
})

extend('max', {
  ...max,
  message: '{_field_} may not be greater than {length} characters',
})

extend('regex', {
  ...regex,
  message: '{_field_} {_value_} does not match {regex}',
})

extend('email', {
  ...email,
  message: 'Email must be valid',
})

export default {
  name: "LoginComponent",
  components: {
    ValidationProvider,
    ValidationObserver,
  },
  data: () => ({
    email: '',
    password: '',
    show: false,
    user_not_found: false
  }),
  mounted()
  {
    let user = localStorage.getItem('user-info')
    if (user)
    {
      this.$router.push({name: "home"})
    }
  },
  methods: {
    async submit () {
      this.$refs.observer.validate()
      let user_found = true
      await axios.post(this.$backend_url + "/users/login", {
        email: this.email,
        password: this.password,
      })
          .then(function (response) {
            console.log(response.status)
            if (response.status === 201) {
              localStorage.setItem('user-info', JSON.stringify(response.data))
            }
          })
          .catch(function (error) {
            if (error.response) {
                user_found = false
            }
          });
      this.user_not_found = !user_found
      if (user_found) {
        await this.$router.push({name: "home"})
      }
    },
    clear () {
      this.email = ''
      this.password = ''
      this.$refs.observer.reset()
    },
  },
}

</script>

<style scoped>

</style>
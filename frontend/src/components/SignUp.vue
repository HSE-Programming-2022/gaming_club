<template>
  <div>
    <h1>Регистрация</h1>
    <v-alert
        v-if=user_exists
        shaped
        dense
        dark
        outlined
        type="warning"
    >
      Данный email уже занят
    </v-alert>
    <validation-observer
        ref="observer"
        v-slot="{ invalid }"
    >
      <form @submit.prevent="submit">
        <validation-provider
            v-slot="{ errors }"
            name="Name"
            rules="required|max:15"
        >
          <v-text-field
              v-model="name"
              :counter="15"
              :error-messages="errors"
              label="Имя"
              required
          ></v-text-field>
        </validation-provider>
        <validation-provider
            v-slot="{ errors }"
            name="surname"
            rules="required|max:15"
        >
          <v-text-field
              v-model="surname"
              :counter="15"
              :error-messages="errors"
              label="Фамилия"
              required
          ></v-text-field>
        </validation-provider>
        <validation-provider
            v-slot="{ errors }"
            name="phoneNumber"
            :rules="{
          required: true,
          digits: 11,
          regex: '^(79|89)\\d{9}$'
        }"
        >
          <v-text-field
              v-model="phoneNumber"
              :counter="11"
              :error-messages="errors"
              label="Телефон"
              required
          ></v-text-field>
        </validation-provider>
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
import axios from 'axios'

export default {
  name: "SignUp",
  components: {
    ValidationProvider,
    ValidationObserver,
  },
  data: () => ({
    name: '',
    surname: '',
    phoneNumber: '',
    email: '',
    password: '',
    select: null,
    checkbox: null,
    show: false,
    user_exists: false
  }),

  methods: {
    async submit () {
      this.$refs.observer.validate()
      let user_exists = false
      await axios.post("http://127.0.0.1:8080/users/", {
        email: this.email,
        phoneNumber : this.phoneNumber,
        name: this.name,
        surname: this.surname,
        password: this.password,
      })
        .then(function (response) {
          if (response.status === 201) {
            localStorage.setItem('user-info', JSON.stringify(response.data))
          }
        })
        .catch(function (error) {
          if (error.response) {
            user_exists = true
          }
        });
      this.user_exists = user_exists
      if (!user_exists) {
          this.$router.push({name: "home"})
      }
    },
    clear () {
      this.name = ''
      this.phoneNumber = ''
      this.email = ''
      this.select = null
      this.checkbox = null
      this.password = ''
      this.$refs.observer.reset()
    }
  },
  mounted()
  {
    let user = localStorage.getItem('user-info')
    if (user)
    {
      this.$router.push({name: "home"})
    }
  },
}

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

extend('password', {
  ...required,
  message: 'Enter password',
})
</script>

<style scoped>

</style>
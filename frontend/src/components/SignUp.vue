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
        bails="false"
    >
      <form @submit.prevent="submit">
        <validation-provider
            v-slot="{ errors }"
            name="Имя"
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
            name="Фамилия"
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
            name="телефонный номер"
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
            name="Пароль"
            rules="password"
        >
        <v-text-field
            v-model="password"
            :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
            :type="show ? 'text' : 'password'"
            :error-messages="errors"
            name="input-10-2"
            label="Пароль"
            hint="Как минимум 8 символов"
            class="input-group--focused"
            @click:append="show = !show"
            :rules="passwordRules"
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
    user_exists: false,
    passwordRules: [
      v => ( v && v.length >= 8 ) || "Пароль должен содержать хотя бы 8 символов",
      v => ( v && v.length <= 100 ) || "Вы превысили лимит в 100 символов в пароле, это уж слишком!",
    ]
  }),

  methods: {
    async submit () {
      this.$refs.observer.validate()
      let user_exists = false
      await axios.post(this.$backend_url + "/users/", {
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
  message: '{_field_} должен содержать {length} цифр и начинаться с 79 / 89. ({_value_})',
})

extend('required', {
  ...required,
  message: 'Поле "{_field_}" не может быть пустым',
})

extend('max', {
  ...max,
  message: '{_field_} не может содержать больше {length} символов',
})

extend('regex', {
  ...regex,
  message: '{_field_} {_value_} не соотвествует {regex}',
})

extend('email', {
  ...email,
  message: 'Введите валидный email',
})

extend('password', {
  ...required,
  message: 'Не забудьте пароль!',
})
</script>

<style scoped>

</style>
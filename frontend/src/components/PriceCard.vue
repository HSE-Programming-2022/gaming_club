<template>
    <div>
        <v-card
            class="mx-auto"
            max-width="344"
            color="#150726"
        >
           
            <v-img
            :src="require('@/assets/' + img + '')"
            height="200px"
            ></v-img>

            <v-card-title class="description">
            {{ Title }}
            </v-card-title>

            <v-card-subtitle>
            {{ Subtitle }}
            </v-card-subtitle>

            <v-card-actions>
            <v-btn
                color="deep-purple lighten-5"
                text
                @click="overlay = true"
                class="description"
            >
                ПОСМОТРЕТЬ ЦЕНЫ
            </v-btn>

            <v-spacer></v-spacer>

            
            </v-card-actions>

            <v-expand-transition>
            <div v-show="show">
                <v-divider></v-divider>
                <v-card-text>
                </v-card-text>
            </div>
            </v-expand-transition>
        </v-card>
    <v-overlay
      :z-index="zIndex"
      :value="overlay"
    >
    <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-left description">
            ОСНОВНОЙ ЗАЛ
          </th>
          <th v-if="(time !='night') & (time != 'rent')" class="text-left description">
            ПРЕМИУМ ЗАЛ
          </th>
        </tr>
      </thead>
      <tbody v-if="time=='main'">
        
        <tr
          v-for="item in time_price.middle"
          :key="item.main"
        >
        <td>
            <v-row>
            {{ item.main.time }}
            {{ item.main.price }}
            </v-row>
        </td>
        <td>
            <v-row justify="space-between" align-content="space-between">
                {{item.premium.time}}
                {{item.premium.price}}
            </v-row>
        </td>
        </tr>
      </tbody>
      <tbody v-if="time=='morning'">
        <tr
          v-for="item in time_price.morning"
          :key="item.main"
        >
        <td>
            <v-row>
            {{ item.main.time }}
            {{ item.main.price }}
            </v-row>
        </td>
        <td>
            <v-row justify="space-between" align-content="space-between">
                {{item.premium.time}}
                {{item.premium.price}}
            </v-row>
        </td>
        </tr>
      </tbody>
      <tbody v-if="time=='night'">
        <tr
          v-for="item in time_price.night"
          :key="item.main"
        >
        <td>
            <v-row>
            {{ item.main.time }}
            {{ item.main.price }}
            </v-row>
        </td>
        </tr>
      </tbody>
      <tbody v-if="time=='rent'">
        <tr
          v-for="item in time_price.rent"
          :key="item.main"
        >
        <td>
            <v-row>
            {{ item.main.time }}
            {{ item.main.price }}
            </v-row>
        </td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
  <v-btn
    style="margin-top: 10px;"
    class="white--text description"
    color="deep-purple lighten-4"
    @click="overlay = false"
  >
        ЗАКРЫТЬ
      </v-btn>
    </v-overlay>
  </div>
</template>

<script>
import time_price from "@/assets/prices.json"
export default {
      data: () => ({
      show: false,
      overlay: false,
      time_price: time_price.time_price
    }),
  name: 'PriceView',

  props: ['Title', 'Subtitle', 'img', 'time']
}
</script>
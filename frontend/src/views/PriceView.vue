<template>
<div>
  <v-row justify='space-around' style="margin-top: 50px;">
    <PriceCard Title="УТРО" style="text-align:left" Subtitle="08:00 – 11:00" img="morning.jpg" time="morning"/>
    <PriceCard Title="ОСНОВНОЕ ВРЕМЯ" style="text-align:left" Subtitle="11:00 – 08:00" img="day.jpg" time="main"/>
    <PriceCard Title="НОЧЬ" style="text-align:left" Subtitle="22:00 – 24:00 (время для покупки)" img="night.webp" time="night"/>
  </v-row>
    <PriceCard Title="АРЕНДА ДЕВАЙСОВ" Subtitle="" img="rent.jpg" time="rent" style="margin-top: 50px; margin-bottom: 50px;" />
</div>
</template>

<script>
import PriceCard from "@/components/PriceCard.vue"
export default {
  name: 'PriceView',
  components: {
    PriceCard
  }
}
</script>

<style>
  .description{
     font-family: "our_font";
     font-size: 20px;
  }
</style>

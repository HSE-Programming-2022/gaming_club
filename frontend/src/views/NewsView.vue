<template>
<div>
  <h1 class="computer_font display-2 font-weight-bold mb-3">новости</h1>
<v-row justify = "space-around" style="margin-top: 50px;">
    <div v-for="item in news" :key="item.id">
<NewsCard :Title="item.title" :Img="item.img" :Text="item.text" :Datetime="item.datetime"  style="margin: 10px;"/>
</div>
</v-row>
</div>
</template>

<script>
import NewsCard from "@/components/NewsCard.vue"
import news from "@/assets/news.json"
export default {
    data: () => ({
    show: false,
    overlay: false,
    news: news.news
    }),
  name: 'NewsView',
  components: {
    NewsCard
  },
  props: ['Title', 'Text', 'Img', 'Datetime']
}
</script>

<style scoped>
  .computer_font {
    font-family: "our_font" !important;
  }
  
</style>
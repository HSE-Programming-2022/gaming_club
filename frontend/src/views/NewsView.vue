<template>
<v-row justify = "space-around" style="margin-top: 50px;">
    <div v-for="item in news" :key="item.id">
<NewsCard :Title="item.title" :Img="item.img" :Text="item.text" :Datetime="item.datetime"  style="margin: 10px;"/>
</div>
</v-row>
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
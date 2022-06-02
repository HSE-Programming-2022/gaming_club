<template>
<div>

    <v-card max-width="450">
        
        <v-card-title class="description justify-center">{{Title}}</v-card-title>

        <v-img
            :src="require('@/assets/news_icons/' + Img + '')"
            max-width="450"
            ></v-img>

        <v-card-subtitle>
            {{Text}}
        </v-card-subtitle>

        <div align="right" class="description" style="margin-right: 10px;">
            {{Datetime}}
        </div>
    
    </v-card>
</div>
</template>

<script>
export default {
      data: () => ({
      show: false,
      overlay: false
    }),
  name: 'NewsView',

  props: ['Title', 'Text', 'Img', 'Datetime']
}
</script>
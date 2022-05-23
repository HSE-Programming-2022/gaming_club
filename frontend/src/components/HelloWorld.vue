<template>
  <v-container>
    <v-row class="text-center">
      <v-col cols="12">
      </v-col>

      <v-col class="mb-4">
        <h1 class="display-2 font-weight-bold mb-3">
          Компьютерный клуб <a class="gradient_text">REBORN</a>
        </h1>

        <p class="subheading font-weight-regular">
          Приветствуем вас на странице самого крупного и современного компьютерного развлекательного центра Самары!
        </p>
        <v-card
            class="mx-auto btn-gradient-2"
            max-width="500"
            id="trigger-0"
            data-aos="fade-right"
            :style="`margin-top: 5em;`"
            data-aos-delay="300"
            data-aos-anchor-placement="top-center"
            data-aos-duration="1000"
            style="margin-top: 5em;"
        >
          <v-card-text>
            <p class="text-h4 text--primary">
              Сразись с лучшими!
            </p>
            <div class="text--primary">
              Регулярно проводим турниры и игровые трансляции!
            </div>
          </v-card-text>
          <v-card-actions>
          </v-card-actions>
        </v-card>
        <div v-for="(adv, index) in advantages" :key="index">
          <div v-if="index % 2 === 1">
            <AdvCard
                :index="index"
                :title="adv.title"
                :subtitle="adv.subtitle"
                :side="'right'">
            </AdvCard>
          </div>
          <div v-else>
            <AdvCard
                :index="index"
                :title="adv.title"
                :subtitle="adv.subtitle"
                :side="'left'">
            </AdvCard>
          </div>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>
<style scoped>
</style>
<script>
import cards from '@/assets/advantages.json'
import AdvCard from "@/components/AdvCard";
import 'aos/dist/aos.css';
export default {
  name: 'HelloWorld',
  components: {AdvCard},
  data() {
    return {
      advantages: cards.cards
    }
  }
}
</script>

<style scoped>
  .btn-gradient-2 {
    background:
        linear-gradient(rgb(20, 20, 20), rgb(28, 28, 28)) padding-box,
        linear-gradient(to right, rgb(134, 44, 130), rgb(201, 120, 60)) border-box;

    border-radius: 30px;
    border: 4px solid transparent;
  }
  .gradient_text {
    background-image: linear-gradient(60deg, #512889, #ED872D);
    background-clip: text;
    color: transparent;
  }
</style>

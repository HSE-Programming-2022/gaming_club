<template>
  <div id="контакты">
    <h1> Контакты </h1>
    <hr>
    <ClubContactsTable />
    <CarouselPhoto />
    <DescriptionAddress />
    <!--
    <h1 class="title">{{ title }}</h1>
    <div class="прямоугольник">
      <p>{{ Adress_ }}</p>
      <input v-model="Adress" type="text" placeholder="Адрес клуба" />

      <input v-model="Telephone" type="text" placeholder="Телефон" />
      <input v-model="Email" type="text" placeholder="Почта" />
      <p>{{ Adress_ }}</p>
    </div>
    -->

    </div>
</template>



<script>
import ClubContactsTable from "@/components/ClubContactsTable";
import CarouselPhoto from "@/components/CarouselPhoto";
import DescriptionAddress from "@/components/DescriptionAddress";
export default {
  components: {
    DescriptionAddress,
    CarouselPhoto,
    ClubContactsTable,
  },

};
</script>



<style scoped>
img {
  width: auto
}
</style>


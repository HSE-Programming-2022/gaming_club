<template>
  <div id="контакты">
    <h1> Контакты </h1>
    <hr>
    <img alt="Club map" src="../assets/ClubMap.png/">
      <ClubMap />
    <ClubContactsTable />
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
import ClubMap from "@/components/ClubMap";
import ClubContactsTable from "@/components/ClubContactsTable";
export default {
  components: {
    ClubContactsTable,
    ClubMap
  },
  data() {
    return {
      title: "Контакты",
      Adress_: "г. Самара"

    };
  },
};
</script>
<style scoped>
</style>


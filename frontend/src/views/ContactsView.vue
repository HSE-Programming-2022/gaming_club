<template>
  <div id="контакты">
    <h1> Контакты </h1>
    <hr>
    <ClubContactsTable />
    <CarouselPhoto />
    <DescriptionAddress />
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


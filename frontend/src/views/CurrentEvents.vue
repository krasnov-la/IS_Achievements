<template>
  <Header />
  <div
      style="
      width: 100%;
      height: 100%;
      background-color: #1c1e1f;
    "
  >
    <div
        style="
      margin-left: 260px;
      width: calc(100% - 260px);
      height: fit-content;
      background-color: #1c1e1f;
      display: flex;
      align-items: center;
      justify-content: center;
      padding: 12.5vh 4.5vh 5vh 4.5vh;
    "
    >
    <SideBar />
    <div style="width: 100%; height: 100%; display: flex; justify-content: center;">
      <div class="container" style="width: 100%;">
        <EventCard/>
        <EventCard/>
        <EventCard/>
        <EventCard/>
      </div>
    </div>
  </div>
  </div>
</template>

<script setup>
import Header from "@/components/Header.vue";
import SideBar from "@/components/SideBar.vue";
import EventCard from "@/components/EventCard.vue";
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");



.container {
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
}
</style>

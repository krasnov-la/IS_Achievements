<template>
  <div class="wrapper">
    <side-bar />
    <div class="main">
      <header>Главная страница</header>
      <div class="widgets">
        <scoreboard />
        <events-list :events="events" v-if="events.length > 0" />
        <future-events-list />
      </div>
    </div>
  </div>
</template>

<script setup>
import SideBar from "../components/SideBar.vue";
import EventsList from "../components/EventsList.vue";
import FutureEventsList from "../components/FutureEventsList.vue";
import Scoreboard from "../components/Scoreboard.vue";
import axios from "axios";
import { onMounted, ref } from "vue";

const events = ref([]);

const fetchCTFEvents = async () => {
  try {
    const response = await axios.get(
      process.env.VUE_APP_CTF_API + "events/?limit=5"
    );
    events.value = response.data;
  } catch (error) {
    console.error("Error fetching CTF events:", error);
  }
};

onMounted(fetchCTFEvents);
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

.wrapper {
  height: 100%;
  display: flex;
}
.main {
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  background: #1c1e1f;
}
header {
  /* position: absolute; */
  width: 100%;
  background: #232627;
  /* height: 50px; */
  padding: 10px 10px;
  border: 1px solid #35373a;
  font-family: Inter;
  font-style: normal;
  font-weight: 600;
  font-size: 33px;
  line-height: 40px;
  color: #e3e4e4;
}

.widget_item {
  background: #232627;
  border: 1px solid #35373a;
  border-radius: 18px;
  background: #232627;
  border-radius: 20px;
  padding: 0 10px 10px 10px;
}
h2 {
  /* Scoreboard */

  font-family: Inter;
  font-style: normal;
  font-weight: 600;
  font-size: 30px;
  line-height: 36px;

  color: #e3e4e4;
}
.widgets {
  overflow-x: hidden;
  /* height: 100%; */
  padding: 2%;
  display: grid;
  /* grid-template-columns: 10fr 1fr 1fr; */
  gap: 2%;
  justify-items: start;
  align-items: start;
  grid-template-areas:
    "a a a b"
    "a a a c";
}
@media screen and (min-width: 150px) {
  .widgets {
    display: flex;
    flex-direction: column;
  }
  .scoreboard {
    min-width: 100% !important;
  }
}
.scoreboard {
  min-width: 40vw;
  grid-area: a;
}
.event-list {
  grid-area: b;
}
.future-event-list {
  grid-area: c;
}
</style>

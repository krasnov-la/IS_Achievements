<template>
  <div class="wrapper">
    <side-bar />
    <div class="main">
      <header>Главная страница</header>
      <div class="widgets">
        <scoreboard />
        <div v-if="loading" class="loading-indicator">Loading events...</div>
        <div v-else>
          <events-list :currentEvents="currentEvents" />
          <future-events-list :upcomingEvents="upcomingEvents" />
        </div>
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

const currentEvents = ref([]);
const upcomingEvents = ref([]);
const loading = ref(true);

const fetchCTFEvents = async () => {
  const currentTimestamp = Math.floor(Date.now() / 1000); // Current time in seconds
  const pastTimestamp = currentTimestamp - 60 * 60 * 24 * 14; // 14 days ago in seconds
  const futureTimestamp = currentTimestamp + 60 * 60 * 24 * 30; // 30 days from now in seconds

  try {
    // Fetch events from the API
    const response = await axios.get(
      `${process.env.VUE_APP_CTF_API}events/?limit=100&start=${pastTimestamp}&finish=${futureTimestamp}`
    );

    const allEvents = response.data;
    // Filter current events (must not include ended events)
    currentEvents.value = allEvents.filter((event) => {
      const eventEndTime = new Date(event.finish).getTime();
      return eventEndTime > Date.now(); // Event is still ongoing
    });
    currentEvents.value = currentEvents.value.slice(0, 5);

    // Filter upcoming events
    upcomingEvents.value = allEvents.filter((event) => {
      const eventStartTime = new Date(event.start).getTime();
      return eventStartTime > Date.now(); // Event is in the future
    });
    upcomingEvents.value = upcomingEvents.value.slice(0, 5);
  } catch (error) {
    console.error("Error fetching CTF events:", error);
  } finally {
    loading.value = false;
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

.loading-indicator {
  font-family: Inter;
  font-style: normal;
  font-weight: 600;
  font-size: 30px;
  color: #e3e4e4;
  text-align: center;
  margin: 20px;
  font-size: 1.5em;
}

.loading-indicator::after {
  content: "";
  display: inline-block;
  width: 20px;
  height: 20px;
  margin-left: 10px;
  border: 2px solid currentColor;
  border-radius: 50%;
  border-top-color: transparent;
  animation: spin 1s linear infinite;
}

@keyframes spin {
  to {
    transform: rotate(360deg);
  }
}
</style>

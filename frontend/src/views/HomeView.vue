<template>
  <Header />
  <div style="width: 100%; height: 100%; background-color: #1c1e1f">
    <div
      style="
        margin-left: 260px;
        width: calc(100% - 260px);
        height: fit-content;
        background-color: #1c1e1f;
        display: flex;
        flex-wrap: wrap;
      "
    >
      <SideBar />
      <div style="width: 100%; margin-top: 7.5vh">
        <div class="widgets" style="display: flex; align-items: flex-start">
          <scoreboard :scoreboardData="scoreboardData" class="widget_item" />
          <div
            class="events-container"
            style="display: flex; flex-direction: column; flex-grow: 1"
          >
            <events-list
              :loadingEvents="loadingEvents"
              :currentEvents="currentEvents"
              class="widget_item"
            />
            <future-events-list
              :loadingEvents="loadingEvents"
              :upcomingEvents="upcomingEvents"
              class="widget_item"
            />
          </div>
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
import Header from "@/components/Header.vue";
import { useStore } from "vuex";

const currentEvents = ref([]);
const upcomingEvents = ref([]);
const scoreboardData = ref([]);
const loadingEvents = ref(true);
const store = useStore();

const getScoreboard = async () => {
  try {
    const count = 10;
    const offset = 0;

    const response = await axios.get(
      `${process.env.VUE_APP_API_URL}Scoreboard/GetData/${count}/${offset}`
    );

    scoreboardData.value = response.data;
  } catch (error) {
    console.error("Error fetching scoreboard data:", error);
  }
};

const fetchCTFEvents = async () => {
  const currentTimestamp = Math.floor(Date.now() / 1000); // Current time in seconds
  const pastTimestamp = currentTimestamp - 60 * 60 * 24 * 14; // 14 days ago in seconds
  const futureTimestamp = currentTimestamp + 60 * 60 * 24 * 30; // 30 days from now in seconds

  try {
    // Fetch events from the CTF API
    const response = await axios.get(
      `http://localhost:8080/events/?limit=100&start=${pastTimestamp}&finish=${futureTimestamp}`,
      {
        headers: { "Content-Type": "application/json" },
      }
    );

    const allEvents = response.data;
    // Filter current events (must not include ended events)
    currentEvents.value = allEvents.filter((event) => {
      const eventEndTime = new Date(event.finish).getTime();
      const eventStartTime = new Date(event.start).getTime();
      return eventEndTime > Date.now() && eventStartTime < Date.now(); // Event is still ongoing
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
    loadingEvents.value = false;
  }
};

const getStudentInfo = async () => {
  try {
    const userResponse = await axios.get(
      `${process.env.VUE_APP_API_URL}Student/GetInfo`,
      {
        withCredentials: true,
        headers: { "Content-Type": "application/json" },
      }
    );
    const user = await userResponse.data;
    store.dispatch("setUser", user);
  } catch (error) {
    console.log(`error with userResponse ${error}`);
  }
};

onMounted(fetchCTFEvents);
onMounted(getScoreboard);
onMounted(getStudentInfo);
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

body {
  overflow-y: hidden; /* Скрывает вертикальную полосу прокрутки */
}

.wrapper {
  height: 100%;
  display: flex;
}
.main {
  width: 100%;
  height: 100%;
  display: flex;
  background: #1c1e1f;
}
header {
  width: 100%;
  background: #232627;
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
  border-radius: 13px;
  margin: 2%;
  flex: 1;
}
h2 {
  font-family: Inter;
  font-style: normal;
  font-weight: 600;
  font-size: 30px;
  line-height: 36px;
  color: #e3e4e4;
}
.widgets {
  overflow-x: hidden;
  padding: 1% 0.8%;
  align-items: flex-start;
}
@media screen and (min-width: 150px) {
  .widgets {
    display: flex;
    flex-direction: row;
  }
  .scoreboard {
    min-width: 52% !important;
  }
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

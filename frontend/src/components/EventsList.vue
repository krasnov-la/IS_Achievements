<template>
  <div
    class="widget_item event-list"
    style="margin: 4.5% 0 0 -0.2%; width: 95.8%"
  >
    <h2>Ивенты сейчас</h2>
    <div class="list_events">
      <div v-if="props.loadingEvents" class="loading-indicator"></div>
      <div v-else>
        <div v-if="currentEvents.length === 0" class="no-events">
          Нет текущих мероприятий
        </div>
        <div v-else>
          <div
            class="event-item"
            v-for="event in currentEvents"
            :key="event.title"
          >
            <div class="img-container">
              <img :src="event.logo" alt="" class="img" />
            </div>
            <a
              :href="`${event.ctftime_url}`"
              target="_blank"
              rel="noreferrer"
              class="event-text"
            >
              <h4>{{ event.title }}</h4>
            </a>
            <div style="display: flex; align-items: end">
              <button
                class="link-full-info"
                @click="openInNewTab(`${event.ctftime_url}`)"
              ></button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  loadingEvents: {
    type: Boolean,
    default: () => true,
  },
  currentEvents: {
    type: Array,
    default: () => [],
  },
});

const openInNewTab = (url) => {
  window.open(url, "_blank", "noreferrer");
};
</script>

<style scoped>
a {
  text-decoration: none;
}
.event-item {
  display: flex;
  align-items: center;
  background: #343839;
  border-radius: 15px;
  margin: 3.4%;
  padding: 8px;
  height: auto;
}

h2 {
  font-family: "Inter";
  font-weight: 550;
  font-size: 23.5px;
  line-height: 36px;
  margin: 3.5% 2% 4.6% 3.8%;
  color: #e3e4e4;
}

.img-container {
  width: 80px;
  height: 60px;
  overflow: hidden;
  margin-right: 4%;
}

img {
  width: 80px;
  height: 60px;
  max-width: 100px;
  object-fit: cover;
  border-radius: 8px;
  background: #a69ae8;
}

h4 {
  margin: 0 0 5px 0;
  font-family: "Inter";
  font-weight: 600;
  font-size: 17.5px;
  color: #e3e4e4;
}

.event-text {
  position: relative;
  width: 60%;
  height: 20%;
}

p {
  font-family: "Inter";
  font-weight: 300;
  font-size: 10px; /* Измените это на 10px и добавьте line-height */
  line-height: 1.5; /* Добавьте явную высоту строки */
  overflow: hidden;
  display: -webkit-box;
  -webkit-box-orient: vertical;
  -webkit-line-clamp: 2;
  line-clamp: 2;
  color: #ffffff;
  margin: 8px 0 0 0;
}

.link-full-info {
  background: none;
  border: none;
  width: 15px;
  height: 15px;
  border-top: 2px solid white;
  border-left: 2px solid white;
  transform: rotate(135deg);
  cursor: pointer;
  transition: 0.3s;
  margin: 0 0 0 55px;
}

.link-full-info:hover {
  transform: translateX(6px) rotate(135deg);
}

.no-events {
  text-align: center;
  font-family: "Inter";
  font-size: 18px;
  color: #e3e4e4;
  padding: 20px;
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

<template>
  <div class="widget_item event-list" style="margin: 6% 0 0 3%; width: 123.5%">
    <h2>Будущие ивенты</h2>
    <div class="list_events">
      <div
        class="event-item"
        v-for="event in props.upcomingEvents"
        :key="event.title"
      >
        <div class="img-container">
          <img :src="event.logo" alt="" class="img" />
        </div>
        <div class="event-text">
          <h4>{{ event.title }}</h4>
          <div style="width: 119%; height: 28px">
            <p>{{ event.url }}</p>
          </div>
        </div>
        <div style="display: flex; align-items: end">
          <button class="link-full-info"></button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  upcomingEvents: {
    type: Array,
    default: () => [],
  },
});
</script>

<style scoped>

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

</style>

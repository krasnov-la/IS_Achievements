<template>
  <div class="widget_item event-list" style="margin: -39% 0 0 -8%; width: 45%">
    <h2>Ивенты сейчас</h2>
    <div class="list_events">
      <div
        class="event-item"
        v-for="event in props.currentEvents"
        :key="event.title"
      >
        <div class="img-container">
          <img :src="event.logo" alt="" class="img" />
        </div>
        <div class="event-text">
          <h4>{{ event.title }}</h4>
          <p>
            {{ event.url }}
          </p>
        </div>
        <button class="link-full-info"></button>
      </div>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  currentEvents: {
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
  margin: 3.5%;
  padding: 10px;
  height: 3%;
}
h2 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 23.5px;
  line-height: 36px;
  margin: 3% 2% 4% 3.8%;

  color: #e3e4e4;
}
.img-container {
  width: 75px;  /* Фиксированная ширина контейнера */
  height: 65px; /* Фиксированная высота контейнера */
  overflow: hidden;
  margin-right: 4%;
}
img {
  width: 75px;  /* Либо фиксированная ширина */
  height: 65px;/* Height will adjust proportionally */
  max-width: 100px; /* Limit the maximum width */
  object-fit: cover;
  border-radius: 8px;
  background: #A69AE8;
}
h4 {
  margin: 2% 0 6% 0;
  font-family: "Inter";
  font-style: normal;
  font-weight: 600;
  font-size: 17.5px;
  line-height: 0px;
  /* identical to box height */

  color: #e3e4e4;
}
.event-text{
  position: relative;
  width: 68%;
  height: 20%;
}
p {
  font-family: "Inter";
  font-style: normal;
  font-weight: 300;
  font-size: 15px;
  line-height: 10px;

  overflow: hidden; /* Скрывает переполняющий текст */
  display: -webkit-box; /* Flexbox для создания текстового контейнера */
  -webkit-box-orient: vertical; /* Вертикальная ориентация контейнера */
  -webkit-line-clamp: 1; /* Количество видимых строк */
  line-clamp: 2; /* Совместимость с другими браузерами */

  color: #ffffff;
}
.link-full-info {
  background: none;
  border: none;
  display: block;
  /* margin: 30px auto; */
  width: 25px;
  height: 25px;
  border-top: 3px solid white;
  border-left: 3px solid white;
  transform: rotate(135deg);
  cursor: pointer;
  transition: 0.3s;
  margin: 0 15px;
}
.link-full-info:hover {
  transform: translateX(6px) rotate(135deg);
}
</style>

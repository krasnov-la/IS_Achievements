<template>
  <div class="widget_item future-event-list">
    <h2>Будущие ивенты</h2>
    <div class="list_events">
      <div
        class="event-item"
        v-for="event in props.upcomingEvents"
        :key="event.title"
      >
        <img :src="event.logo" alt="" class="img" />
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
  margin: 15px 0;
  padding: 10px;
}
h2 {
  margin: 15px 0;
  font-family: "Inter";
  font-style: normal;
  font-weight: 600;
  font-size: 30px;
  line-height: 36px;
  color: #e3e4e4;
}
h4 {
  margin: 20px 0;
  font-family: "Inter";
  font-style: normal;
  font-weight: 600;
  font-size: 22px;
  line-height: 0px;
  /* identical to box height */

  color: #e3e4e4;
}
img {
  width: 20vw; /* 20% of the viewport width */
  height: auto; /* Height will adjust proportionally */
  max-width: 100px; /* Limit the maximum width */
  object-fit: cover;
  border-radius: 5px;
  margin: 0 15px 0 0;
  background: #8057f2;
}
p {
  font-family: "Inter";
  font-style: normal;
  font-weight: 300;
  font-size: 15px;
  line-height: 15px;
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

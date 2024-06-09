<template>
  <div class="widget_item scoreboard">
    <div class="scoreboard-header">
      <h2>Scoreboard</h2>
      <div class="dots"/>
    </div>

    <div class="table">
      <div class="table-header">
        <p class="number1">Номер позиции</p>
        <p class="name1">Имя / никнэйм</p>
        <p class="score1">Количество баллов</p>
      </div>
      <div class="table-item" v-for="player in players" :key="player.id">
        <p class="number">#{{ player.id }}</p>
        <img class="profile-img" src="" alt="" />
        <p class="name">{{ player.name }}</p>
        <p class="score">{{ player.score.toLocaleString("ru") }} баллов</p>
      </div>
    </div>
  </div>
</template>
<script setup>
import { ref, createApp } from "vue";
const sortIndex = ref(0);
const players = ref([
  { name: "John", score: 100245, id: 1234 },
  { name: "Jane", score: 93998, id: 1235 },
  { name: "Bob", score: 86277, id: 1236 },
  { name: "John", score: 100245, id: 1234 },
  { name: "Jane", score: 93998, id: 1235 },
  { name: "Bob", score: 86277, id: 1236 },
]);

function sortPlayers() {
  sortIndex.value++; // Переход к следующему полю для сортировки
  let fields = ["name", "score"]; // Массив полей для сортировки
  if (sortIndex.value >= fields.length) {
    sortIndex.value = 0; // Сброс индекса, если все поля были пройдены
  }
  players.value.sort((a, b) => {
    switch (fields[sortIndex.value]) {
      case "name":
        return String(a[fields[sortIndex.value]]).localeCompare(
          String(b[fields[sortIndex.value]])
        );
      case "score":
        return a[fields[sortIndex.value]] - b[fields[sortIndex.value]];
      default:
        return 0;
    }
  });
  const sortedPlayers = computed(() => players.value.slice()); // Копируем массив для отображения
}
</script>
<style scoped>
h2 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 23.5px;
  line-height: 36px;
  margin: 3% 2% 4% 3.8%;

  color: #e3e4e4;
}
.widget_item {
  background: #232627;
  background: #35373a;
  border-radius: 20px;
}
.scoreboard-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.sort {
  width: 6px;
  height: 28px;
  cursor: pointer;
}
.table {
  /* height: 100%; */
  padding-bottom: 4%;
}

.table-header {
  position: relative;

  font-family: "Inter";
  font-style: normal;
  font-weight: 500;
  font-size: 15px;
  line-height: 10px;
  background: #343839;
  color: #ffffff;
  min-height: 35px;
  width: 100%;
}
.table-item {
  /* doppio23s */
  width: 100%;
  /* justify-content: space-around;
display: flex; */
  position: relative;
  font-family: "Inter";
  font-style: normal;
  font-weight: 300;
  font-size: 15px;
  line-height: 18px;
  display: flex;
  align-items: center;

  color: #ffffff;
  min-height: 55px;
}
/* .table-item:nth-child(2n) {
    background: #35373A;
} */
.table-item:nth-child(2n + 1) {
  background: #343839;
}
.profile-img {
  width: 35px;
  height: 35px;
  background: #a69ae8;
  border-radius: 50%;
  position: absolute;
  left: 31%;
}
.number1 {
  position: absolute;
  font-weight: 500;
  color: #f1f1f1;
  font-size: 9pt;
  min-width: 80pt;
  left: 4.5%;
}
.number {
  position: absolute;
  font-weight: 340;
  color: #e3e4e4;
  font-size: 9pt;
  min-width: 80pt;
  left: 4.6%;
}
.name1 {
  position: absolute;
  font-weight: 500;
  color: #f1f1f1;
  font-size: 9pt;
  min-width: 80pt;
  left: 31%;
}
.name {
  position: absolute;
  font-weight: 340;
  color: #e3e4e4;
  font-size: 9pt;
  min-width: 80pt;
  left: 38.5%;
}
.score1 {
  position: absolute;
  font-weight: 500;
  color: #f1f1f1;
  font-size: 9pt;
  min-width: 80pt;
  left: 73%;
}
.score {
  position: absolute;
  font-weight: 340;
  color: #e3e4e4;
  font-size: 9pt;
  min-width: 80pt;
  left: 73.1%;
}
.dots {
  content: url("../assets/ico/dots.svg");
  padding: 5pt;
  right: 0;
  width: 37pt;
  height: 37pt;
  margin: -2% 0 0 0;
}
</style>

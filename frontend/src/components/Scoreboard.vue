<template>
  <div class="widget_item scoreboard">
    <div class="scoreboard-header">
      <h2>Scoreboard</h2>
      <div class="dots" />
    </div>

    <div class="table">
      <div class="table-header">
        <p class="number1">Номер позиции</p>
        <p class="name1">Имя / никнэйм</p>
        <p class="score1">Количество баллов</p>
      </div>
      <div v-if="isScoreboardEmpty" class="loading-animation">
        <div class="loading-spinner"></div>
        Loading scoreboard...
      </div>
      <div v-else>
        <div
          class="table-item"
          v-for="player in props.scoreboardData"
          :key="player.id"
        >
          <p class="number">#{{ player.place }}</p>
          <img class="profile-img" src="" alt="" />
          <p class="name">{{ player.nick }}</p>
          <p class="score">{{ player.score.toLocaleString("ru") }} баллов</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed } from "vue";
const isScoreboardEmpty = computed(() => {
  return props.scoreboardData.length === 0;
});
const props = defineProps({
  scoreboardData: {
    type: Array,
    default: () => [],
  },
});
</script>
<style scoped>
h2 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 23.5px;
  line-height: 36px;
  margin: 2.5% 2% 4% 3%;

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
.loading-animation {
  text-align: center;
  padding: 20px;
  font-size: 1.2em;
  color: #e3e4e4;
}

.loading-spinner {
  display: inline-block;
  width: 40px;
  height: 40px;
  border: 4px solid rgba(255, 255, 255, 0.3);
  border-radius: 50%;
  border-top-color: #e3e4e4;
  animation: spin 1s ease-in-out infinite;
}

@keyframes spin {
  to {
    transform: rotate(360deg);
  }
}
</style>

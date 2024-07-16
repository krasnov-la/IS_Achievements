<template>
  <div class="widget_item scoreboard">
    <div class="scoreboard-header">
      <h2>Scoreboard</h2>
      <div class="dots" />
    </div>

    <div class="table">
      <div class="table-header">
        <p class="number1">Номер позиции</p>
        <p class="name1">Никнейм</p>
        <p class="score1">Количество баллов</p>
      </div>
      <div v-if="isScoreboardEmpty" class="loading-indicator">
        <div class="loading-spinner"></div>
      </div>
      <div v-else>
        <div
          class="table-item"
          v-for="student in props.scoreboardData"
          :key="student.id"
        >
          <p class="number">#{{ student.place }}</p>
          <img class="profile-img" src="" alt="" />
          <p class="name">{{ student.nick }}</p>
          <p class="score">{{ student.score.toLocaleString("ru") }} баллов</p>
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
  width: 100%;
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

.table-item:nth-child(odd) {
  background: #232627;
}

.table-item:nth-child(even) {
  background: #35373a;
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

.loading-indicator {
  font-family: Inter;
  font-style: normal;
  font-weight: 550;
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

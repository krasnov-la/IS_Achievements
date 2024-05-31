<template>
  <div class="widget_item scoreboard">
    <div class="scoreboard-header" >
  <h2>Scoreboard</h2>
    
    <img class="sort" @click="sortPlayers" src="../assets/Group 2.png" alt="">
    </div>

    <div class="table">
      <div class="table-header">
        <p class="number">Номер позиции</p>
        <p class="name">Имя / никнэйм</p>
        <p class="score">Количество баллов</p>
      </div>
      <div class="table-item" v-for="player in players" :key="player.id">
        <p class="number">#{{ player.id }}</p>
        <p class="name">{{ player.name }}</p>
        <p class="score">{{ player.score.toLocaleString("ru") }} баллов</p>
      </div>
    </div>
  </div>
</template>
<script setup >
import { ref, createApp, } from 'vue'
const sortIndex = ref(0)
    const players = ref([
      { name: 'John', score: 100245, id: 1234 },
      { name: 'Jane', score: 93998, id: 1235 },
      { name: 'Bob', score: 86277, id: 1236 },
      { name: 'John', score: 100245, id: 1234 },
      { name: 'Jane', score: 93998, id: 1235 },
      { name: 'Bob', score: 86277, id: 1236 },
    ])

function sortPlayers() {
  sortIndex.value++; // Переход к следующему полю для сортировки
  let fields = ['name', 'score']; // Массив полей для сортировки
  if (sortIndex.value >= fields.length) {
    sortIndex.value = 0; // Сброс индекса, если все поля были пройдены
  }
  players.value.sort((a, b) => {
    switch (fields[sortIndex.value]) {
      case 'name':
        return String(a[fields[sortIndex.value]]).localeCompare(String(b[fields[sortIndex.value]]));
      case 'score':
        return a[fields[sortIndex.value]] - b[fields[sortIndex.value]];
      default:
        return 0;
    }
  });
const sortedPlayers = computed(() => players.value.slice()); // Копируем массив для отображения


}
const app = createApp({})

// Регистрация компонента
</script>
<style scoped>
h2 {
    /* Scoreboard */



font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 30px;
line-height: 36px;

color: #E3E4E4;


}
.widget_item {
background: #232627;
    background: #35373A;
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
}

.table-header {
position: relative;

font-family: 'Inter';
font-style: normal;
font-weight: 500;
font-size: 15px;
line-height: 18px;
    background: #343839;
color: #FFFFFF;
min-height: 50px;
}
.table-item {
    /* doppio23s */
    width: 100%;
    /* justify-content: space-around;
display: flex; */
position: relative;
font-family: 'Inter';
font-style: normal;
font-weight: 300;
font-size: 15px;
line-height: 18px;

color: #FFFFFF;
min-height: 50px;
}
/* .table-item:nth-child(2n) {
    background: #35373A;
} */
.table-item:nth-child(2n+1) {
    background: #343839;
}
.number {
    position: absolute;
    left: 5%;
}
.name {
    position: absolute;
    left: 45%;
}
.score { 
    position: absolute;
    left: 75%;
}
</style>
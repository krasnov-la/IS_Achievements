<template>
  <div class="widget_item scoreboard">
    <h2>Scoreboard</h2>
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
<script>
import { ref, createApp } from 'vue'

export default {
  setup() {
    const players = ref([
      { name: 'John', score: 100245, id: 1234 },
      { name: 'Jane', score: 93998, id: 1235 },
      { name: 'Bob', score: 86277, id: 1236 },
      { name: 'John', score: 100245, id: 1234 },
      { name: 'Jane', score: 93998, id: 1235 },
      { name: 'Bob', score: 86277, id: 1236 },
    ])
    return { players }
  }
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
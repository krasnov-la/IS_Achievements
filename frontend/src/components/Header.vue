<script setup></script>

<template>
  <div class="header">
    <div class="h1">Личный кабинет</div>
    <div class="notif"></div>
  </div>
</template>

<style scoped>
.notif {
  content: url("../assets/ico/bell.svg");
  padding: 5pt;
  position: absolute;
  right: 0;
  border-radius: 100%;
  width: 28pt;
  height: 28pt;
  background-color: #343839;
  margin-right: 30pt;
}
.h1 {
  top: 10pt;
  color: #e3e4e4;
  margin-left: 23.1%;
  font-size: 17pt;
  -webkit-text-stroke: 0.4px #e3e4e4;
  transform: scaleX(1.05);
}

.header {
  background-color: #232627;
  width: 100%;
  height: 7.5vh;
  border-bottom: 1pt solid #35373a;
  font-family: Inter;
  align-items: center;
  display: flex;
}

.h2 {
  color: #e3e4e4;
  margin-left: 22%;
  -webkit-text-stroke: 0.5px #9ba1a8;
  font-size: 10pt;
  transform: scaleX(1.1);
}
</style>

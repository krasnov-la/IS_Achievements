<template>
  <div class="side-bar">
    <div class="side-bar_header">
      <img class="logo" src="../assets/logo.svg" alt="" />
      <h1>.NET Creations</h1>
    </div>
    <a href="">Главная страница</a>
    <a href="">Текущие ивенты</a>
    <a href="">Будущие ивенты</a>
  </div>
</template>

<style scoped>
.side-bar_header {
  display: flex;
}

h1 {
  margin: 0 0% 0 5%;

  font-family: "Inter";
  font-style: normal;
  font-weight: 700;
  font-size: 33px;
  line-height: 40px;

  color: #e3e4e4;
}
.side-bar {
  padding: 2.5%;
  height: 100vh;
  width: 20%;
  background: #232627;
  min-width: 350px;
  display: flex;
  flex-direction: column;
}
a {
  margin: 5% 0;
  display: block;

  font-family: "Inter";
  font-style: normal;
  font-weight: 500;
  font-size: 15.7143px;
  line-height: 19px;

  color: #bfbfbf;
  text-decoration: none;

  border: 1px solid #797979;
  border-radius: 9.42857px;
  padding: 5%;
  display: flex;
  align-items: center;
}

a:nth-child(2)::before {
  content: url('../assets/ico/home.svg');
  margin: 0 7px 0 0;
}
a:nth-child(3)::before {
  content: url('../assets/ico/events.svg');
  margin: 0 7px 0 0;
}
a:nth-child(4)::before {
  content: url('../assets/ico/time.svg');
  margin: 0 7px 0 0;
}

.active {
    background: #8057F2;
}
</style>
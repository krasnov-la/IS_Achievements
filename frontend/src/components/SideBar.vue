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
@import url('https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap');

.side-bar {
  position: fixed;
  top: 0;
  left: 0;
  padding: 1.5% 1.8% 0 1.9%;
  height: 100%;
  width: 20%;
  background: #232627;
  min-width: 300px;
  display: flex;
  flex-direction: column;
  float: left;
  border-right: 1pt solid #35373A;
}
.side-bar_header {
  display: flex;
  margin: -5pt 0 0 0;
}

h1 {
  margin: 0 0% 0 5%;

  font-family: "Inter";
  font-style: normal;
  font-weight: 700;
  font-size: 30px;
  line-height: 40px;

  color: #e3e4e4;
}

img{
  margin: 0 -5pt 0 -5pt;
}

a {
  margin: 4% -2% 4% 0;
  display: block;

  font-family: "Inter";
  font-style: normal;
  font-weight: 500;
  font-size: 13.5px;
  line-height: 19px;

  color: #bfbfbf;
  text-decoration: none;

  border: 1.3px solid #797979;
  border-radius: 9.42857px;
  padding: 4%;
  display: flex;
  align-items: center;
}

a:nth-child(2)::before {
  content: url('../assets/ico/home.svg');
  margin: 2px 15px 0 3px;
}
a:nth-child(3)::before {
  content: url('../assets/ico/events.svg');
  margin: 2.5px 12px -0.5px 0;
}
a:nth-child(4)::before {
  content: url('../assets/ico/time.svg');
  margin: 0 12px -2px 0;
}

.active {
    background: #8057F2;
}
</style>
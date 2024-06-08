<template>
  <div class="side-bar">
    <div class="wrapper">
      <div class="side-bar_header">
        <img class="logo" src="../assets/logo.svg" alt="" />
        <h1>.NET Creations</h1>
      </div>
      <router-link to="/">Главная страница</router-link>
      <a href="">Текущие ивенты</a>
      <a href="">Будущие ивенты</a>
      <router-link to="/PersonalArea" class="profile">
        <img class="profile-img" src="" alt="" />
        <div>
          <h6 class="profile-name">User228</h6>
          <p class="profile-score">Баллы: 12 333</p>
        </div>
      </router-link>
    </div>
  </div>
</template>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

.side-bar {
  border: 1px solid #35373a;
  padding: 2.5%;
  height: 100%;
  width: 20%;
  background: #232627;
  min-width: 300px;
  display: flex;
  flex-direction: column;
  /* float: left; */
}
.wrapper {
  width: 100%;
  height: 100%;
  position: relative;
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

img {
  margin: 0 -5pt 0 -5pt;
}

a {
  margin: 4% 0 4% 0;
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
  content: url("../assets/ico/home.svg");
  margin: 2px 15px 0 3px;
}
a:nth-child(3)::before {
  content: url("../assets/ico/events.svg");
  margin: 2.5px 12px -0.5px 0;
}
a:nth-child(4)::before {
  content: url("../assets/ico/time.svg");
  margin: 0 12px -2px 0;
}

.active {
  background: #8057f2;
}

.profile {
  width: 100%;
  position: absolute;
  bottom: 0;
  left: 0%;
  margin: 0;
  padding: 10px;
}
.profile-img {
  width: 44px;
  height: 44px;
  background: #a69ae8;
  border-radius: 50%;
  margin: 0 5% 0 0;
}
.profile-score {
  font-family: "Inter";
  font-style: normal;
  font-weight: 300;
  font-size: 12px;
  line-height: 15px;

  color: #e3e4e4;
}
.profile-name {
  margin: 0;

  font-family: "Inter";
  font-style: normal;
  font-weight: 500;
  font-size: 15.7143px;
  line-height: 19px;
  /* identical to box height */

  color: #e3e4e4;
}
</style>

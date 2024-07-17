<template>
  <div class="side-bar">
    <div class="wrapper">
      <div class="side-bar_header">
        <img class="logo" src="../assets/logo.svg" alt="" />
        <h1>.NET Creations</h1>
      </div>
      <router-link
        to="/"
        :class="{ active: isActive('/') }"
        @click.native="
          () => {
            setActive('/');
            changeText('Главная страница');
          }
        "
      >
        <div class="stripe" :class="{ active: isActive('/') }"></div>
        Главная страница
      </router-link>
      <a
        href="/CurrentEvents"
        :class="{ active: isActive('/events') }"
        @click="
          () => {
            setActive('/events');
            changeText('Текущие ивенты');
          }
        "
      >
        <div class="stripe" :class="{ active: isActive('/events') }"></div>
        Текущие ивенты
      </a>
      <a
        href="/FutureEvents"
        :class="{ active: isActive('/future-events') }"
        @click="
          () => {
            setActive('/future-events');
            changeText('Будущие ивенты');
          }
        "
      >
        <div
          class="stripe"
          :class="{ active: isActive('/future-events') }"
        ></div>
        Будущие ивенты
      </a>

      <template v-if="isAuthenticated">
        <router-link
          to="/PersonalArea"
          @click="changeText('Личный кабинет')"
          class="profile"
        >
          <img class="profile-img" :src="user?.profileImage || ''" alt="" />
          <div>
            <h6 class="profile-name">{{ user?.nickname || "User" }}</h6>
            <p class="profile-score">Баллы: {{ user?.score || 0 }}</p>
          </div>
        </router-link>
      </template>

      <template v-else>
        <div class="log-reg">
          <router-link to="/login" class="auth-link border1">
            <div style="margin-left: 15%">Вход</div>
          </router-link>
          <div
            style="
              width: 0.8pt;
              height: 20pt;
              background-color: #6b6b6b;
              margin: 3.5% 0 3.5% -25%;
            "
          />
          <router-link to="/Registration" class="auth-link border2">
            <div style="margin-left: 15%">Регистрация</div>
          </router-link>
        </div>
      </template>
    </div>
  </div>
</template>

<script setup>
import { ref, computed } from "vue";
import { useStore } from "vuex";

const store = useStore();

const activePath = ref("/");

const changeText = (newText) => {
  store.dispatch("updateText", newText);
};

const isAuthenticated = computed(() => store.getters.isAuthenticated);
const user = computed(() => store.getters.user);

const setActive = (path) => {
  activePath.value = path;
};

const isActive = (path) => activePath.value === path;
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

.side-bar {
  position: fixed;
  top: 0;
  left: 0;
  border: 1px solid #35373a;
  padding: 0.1% 1.5% 0 1.5%;
  height: 100%;
  width: 10%;
  background: #232627;
  min-width: 260px;
  display: flex;
  z-index: 1000;
  flex-direction: column;
}

.wrapper {
  width: 100%;
  height: 100%;
  position: relative;
}

.side-bar_header {
  display: flex;
  margin: 0 10pt 0 -5pt;
}

h1 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 680;
  font-size: 27px;
  line-height: 32px;
  margin-left: 1pt;
  color: #e3e4e4;
}

.log-reg a:nth-child(2)::before {
  content: none;
}
.log-reg a:nth-child(3)::before {
  content: none;
}

a:nth-child(2)::before {
  content: url("../assets/ico/home.svg");
  margin: 1.9% 5% -1% 1.5%;
}

a:nth-child(3)::before {
  content: url("../assets/ico/events.svg");
  margin: 2.1% 6% -1.2% 2.2%;
}

a:nth-child(4)::before {
  content: url("../assets/ico/time.svg");
  margin: 1.8% 5% -0.9% 2.2%;
}

.stripe {
  width: 2%;
  height: 32pt;
  position: relative;
  left: -68px;
  top: 0;
}

.stripe.active {
  background: #1F7BD4;
}

.active {
  background: #1F7BD4;
  color: #e3e4e4;
}

.profile {
  width: 104%;
  position: absolute;
  bottom: 0;
  left: 0%;
  margin: 0 0 10% 0;
  padding: 0 0 -15% 10px;
  background-color: #35373a;
  border: #35373a;
}

.profile-img {
  width: 35px;
  height: 35px;
  background: #2b8be8;
  border-radius: 50%;
  margin: 0 5% 0 0;
}

.profile-score {
  margin: 13% 0 13% 0;
  font-family: "Inter";
  font-style: normal;
  font-weight: 300;
  font-size: 10px;
  line-height: 10px;
  color: #e3e4e4;
}

.profile-name {
  margin: 10% 0 0 0;
  font-family: "Inter";
  font-style: normal;
  font-weight: 500;
  font-size: 13px;
  line-height: 14px;
  color: #e3e4e4;
}

a {
  margin: 1% -4% 7% 0%;
  align-items: center;
  font-family: "Inter";
  font-style: normal;
  font-weight: 450;
  font-size: 12.5px;
  line-height: 20px;
  color: #bfbfbf;
  text-decoration: none;
  border: 0.9px solid #6b6b6b;
  border-radius: 8px;
  padding: 0 4%;
  display: flex;
}

.log-reg {
  width: 104%;
  position: absolute;
  bottom: 0;
  left: 0%;
  margin: 0 0 10% 0;
  background-color: #35373a;
  border: #35373a;
  border-radius: 8px;
  line-height: 20px;
  display: flex;
}

.auth-link {
  flex: 1;
  margin: 0 0;
  text-align: center;
  border: transparent;
  background-color: #35373a;
  color: #dadada;
  font-family: "Inter";
  font-style: normal;
  font-weight: 450;
  font-size: 12.5px;
  line-height: 20px;
  text-decoration: none;
}
.border1 {
  border-radius: 8px 0 0 8px;
}
.border2 {
  border-radius: 0 8px 8px 0;
}

a:hover {
  background: #1365b4;
  color: #e3e4e4;
}

a.active {
  background: #1F7BD4;
  color: #e3e4e4;
}

a:not(.active):hover {
  background: #1365b4;
  color: #e3e4e4;
}
</style>

<template>
  <div class="side-bar">
    <div class="wrapper">
      <div class="side-bar_header">
        <img class="logo" src="../assets/logo.svg" alt="" />
        <h1>.NET Creations</h1>
      </div>
      <router-link
        to="/PersonalArea"
        :class="{ active: isActive('/') }"
        @click.native="
          () => {
            setActive('/');
            changeText('Личный кабинет');
          }
        "
      >
        <div class="stripe" :class="{ active: isActive('/') }"></div>
        Личный кабинет
      </router-link>

      <router-link
        to="/NewAchievement"
        :class="{ active: isActive('/NewAchievement') }"
        @click="
          () => {
            setActive('/NewAchievement');
            changeText('Добавить достижение');
          }
        "
      >
        <div
          class="stripe"
          :class="{ active: isActive('/NewAchievement') }"
        ></div>
        Добавить достижение
      </router-link>

      <router-link
        to="/Requests"
        :class="{ active: isActive('/Requests') }"
        @click="
          () => {
            setActive('/Requests');
            changeText('Отправленные заявки');
          }
        "
      >
        <div class="stripe" :class="{ active: isActive('/Requests') }"></div>
        Отправленные заявки
      </router-link>

      <router-link
        to="/EditProfile"
        :class="{ active: isActive('/EditProfile') }"
        @click="
          () => {
            setActive('/EditProfile');
            changeText('Редактировать профиль');
          }
        "
      >
        <div class="stripe" :class="{ active: isActive('/EditProfile') }"></div>
        Редактировать профиль
      </router-link>

      <router-link
        to="/"
        :class="{ active: isActive('/future') }"
        @click="
          () => {
            setActive('/');
            logout();
          }
        "
      >
        <div class="stripe" :class="{ active: isActive('/future') }"></div>
        Выйти из аккаунта
      </router-link>

      <router-link
        to="/"
        class="profile"
        style="height: 32pt"
        @click="
          () => {
            setActive('/');
            changeText('Главная страница');
          }
        "
      >
        На главную страницу
      </router-link>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import { computed } from "vue";
import { useStore } from "vuex";
import { useRouter } from "vue-router";

const store = useStore();
const router = useRouter();

const isAuthenticated = computed(() => store.getters.isAuthenticated);
const user = computed(() => store.getters.user);
const activePath = computed(() => store.getters.activePath);

const changeText = (newText) => {
  store.dispatch("updateText", newText);
};

const setActive = (path) => {
  store.dispatch("updateActivePath", path);
};

const isActive = (path) => activePath.value === path;

const logout = async () => {
  store.dispatch("setAuth", false);
  store.dispatch("setUser", {
    emailAddress: "",
    nickname: "",
    score: "",
    place: "0",
  });
  changeText("Главная страница");
};
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

a:nth-child(2)::before {
  content: url("../assets/ico/user.svg");
  margin: 1.9% 4% -1% 1%;
}

a:nth-child(3)::before {
  content: url("../assets/ico/add.svg");
  margin: 2.1% 4% -1.2% 2%;
}

a:nth-child(4)::before {
  content: url("../assets/ico/letter.svg");
  margin: 1.8% 4.2% -0.9% 2.2%;
}

a:nth-child(5)::before {
  content: url("../assets/ico/edit.svg");
  margin: 1.8% 6% -0.9% 2.2%;
}

a:nth-child(6)::before {
  content: url("../assets/ico/exit.svg");
  margin: 1.8% 3% -0.9% 2.2%;
}

a:nth-child(7)::before {
  content: url("../assets/ico/left.svg");
  margin: 1.8% 4% -0.9% 2.2%;
}

.stripe {
  width: 2%;
  height: 32pt;
  position: relative;
  left: -68px;
  top: 0;
}

.stripe.active {
  background: #1f7bd4;
}

.active {
  background: #1f7bd4;
  color: #ebedee;
  border: 0.9px solid #1f7bd4;
}

.profile {
  width: 104%;
  position: absolute;
  bottom: 0;
  left: 0%;
  margin: 0 0 10% 0;
  padding: 0 0 -15% 10px;
  background-color: #35373a;
  border: 0.9px solid #35373a;
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
  cursor: pointer;
  transition: border 0.4s, background-color 0.4s, transform 0.4s;
}

a:hover {
  background: rgba(31, 123, 212, 0.5);
  color: #e3e4e4;
  border: 0.9px solid rgb(40, 87, 132);
}

a.active {
  background: #1f7bd4;
  color: #e3e4e4;
}

a:not(.active):hover {
  background: rgba(31, 123, 212, 0.5);
  color: #e3e4e4;
}
</style>

<template>
  <div class="bg">
    <div class="card1">
      <form @submit.prevent="submit">
        <div style="display: grid; place-items: center">
          <div class="h11">Вход в аккаунт</div>
          <div class="separatorr" />
        </div>

        <div style="margin: 2.2vh 0 3vh 0">
          <div class="h22">Логин</div>
          <input placeholder="Введите Логин" v-model="data.login" />
        </div>

        <div style="margin: 2.2vh 0 3vh 0">
          <div style="display: flex; justify-content: space-between">
            <div class="h22">Пароль</div>
            <router-link to="" style="margin: 1.2vh 1.5vh 0 0" class="link"
              >Забыли пароль?</router-link
            >
          </div>
          <input placeholder="Введите пароль" v-model="data.password" />
        </div>

        <div style="display: flex">
          <label class="checkbox-container">
            <input type="checkbox" />
            <span class="checkmark"></span>
          </label>
          <div style="margin: -0.55vh 0 0 3.5vh" class="h3">Запомнить меня</div>
        </div>

        <div style="display: grid; place-items: center; margin-top: 3vh">
          <div class="separatorr" />
          <button class="button" type="submit">Войти</button>

          <div style="display: flex; margin-bottom: 0.8vh">
            <div class="h3">У вас еще нет аккаунта?</div>
            <router-link
              to="/Registration"
              class="link"
              style="margin-left: 2.5vh"
            >
              Зарегистрироваться
            </router-link>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import { reactive } from "vue";
import { useRouter } from "vue-router";
import { useStore } from "vuex";
const data = reactive({
  login: "",
  password: "",
});

const router = useRouter();
const store = useStore();

const submit = async () => {
  try {
    const response = await axios.post(
      `${process.env.VUE_APP_API_URL}Auth/login`,
      {
        login: data.login,
        password: data.password,
      },
      {
        withCredentials: true,
        headers: { "Content-Type": "application/json" },
      }
    );

    if (response.status == 200) {
      store.dispatch("setAuth", true);
    }
  } catch (error) {
    if (error.response.data == "User not found")
      alert(`${error.response.data}`);
    else alert(`Неверное имя пользователя или пароль`);
  }
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

.bg {
  width: 100%;
  height: 100%;
  background-color: #1c1e1f;
  display: grid;
  place-items: center;
}

.card1 {
  font-family: "Inter";
  position: relative;
  padding: 2.6vh 4.7vh;
  width: 66vh;
  height: fit-content;
  background-color: #232627;

  border-radius: 10pt;
  border: 0.8px solid #35373a;
}

.h11 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 22.5px;
  line-height: 30px;

  color: #e3e4e4;
}

.separatorr {
  width: 100%;
  height: 0.7px;
  background-color: #35373a;
  margin: 2.7vh 0 2.7vh 0;
}

.h22 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 16.2px;
  line-height: 30px;
  margin: 0 0 0.5vh 0.9vh;

  color: #e3e4e4;
}

input {
  background-color: #35373a;
  border: 0.8px solid #45484c;
  border-radius: 9px;
  width: 100%;
  height: 5.2vh;
  padding-left: 2vh;
  color: #a9aaaf;
  transition: border-color 0.2s ease-in-out;
}

input::placeholder {
  color: #72787d;
  font-size: 9.8pt;
}

input:focus {
  border-color: #80c0fd;
  color: #a9aaaf;
  outline: none;
  font-size: 9.8pt;
}

.link {
  font-size: 9pt;
  font-weight: lighter;
  -webkit-text-stroke: 0.5px #8abefc;
  transform: scaleX(1.1);
  margin: 0 0 0.5vh 0.9vh;
  text-decoration: none;

  color: #8abefc;
}

.h3 {
  font-family: "Inter";
  font-size: 9pt;
  font-weight: lighter;
  -webkit-text-stroke: 0.5px #72787d;
  transform: scaleX(1.1);
  margin: 0 0 0.5vh 0.9vh;
  text-decoration: none;

  color: #72787d;
}

.button {
  width: 100%;
  height: 6vh;
  background-color: #1F7BD4;
  display: grid;
  place-items: center;
  border-radius: 15px;
  font-size: 13.3pt;
  color: #e3e4e4;
  font-weight: 570;
  margin: 0.5vh 0 3vh 0;
  border: none;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.2s;
}

.checkbox-container {
  display: inline-block;
  position: relative;
  cursor: pointer;
  font-size: 22px;
  user-select: none;
  margin: -1vh 0.9vh;
}

.checkbox-container input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
}

.checkmark {
  position: absolute;
  top: 0;
  left: 0;
  height: 20px;
  width: 20px;
  background-color: #35373a;
  border-radius: 4px;
}

.checkbox-container input:checked ~ .checkmark {
  background-color: #35373a;
}

.checkmark:after {
  content: "";
  position: absolute;
  display: none;
}

.checkbox-container input:checked ~ .checkmark:after {
  display: block;
}

.checkbox-container .checkmark:after {
  left: 6.5px;
  top: 1.5px;
  width: 5px;
  height: 10px;
  border: solid white;
  border-width: 0 3px 3px 0;
  transform: rotate(45deg);
  background-color: transparent; /* чтобы галочка была только из границ */
  border-color: #1F7BD4; /* фиолетовая галочка */
}

.button:hover {
  background-color: #2081de;
}

.button:active {
  background-color: #1e74c7;
  transform: scale(0.98);
}
</style>

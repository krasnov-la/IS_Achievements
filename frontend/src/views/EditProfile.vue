<template>
  <Header />
  <div
      style="
      margin-left: 260px;
      width: calc(100% - 260px);
      height: fit-content;
      background-color: #1c1e1f;
      display: flex;
      align-items: center;
      justify-content: center;
      padding: 12.5vh 17.5vh 5vh 9.5vh;
    "
  >
    <SideBarPersonal />
    <div style="width: 100%; height: 100%; display: flex; justify-content: center;">
      <div class="container" style="width: 100%;">
        <div class="card">

          <div style="display: flex; justify-content: space-between;">
            <div class="h1">Фото профиля</div>
            <div class="separator" style="flex: 1;"/>
          </div>

          <div style="display: flex; justify-content: start;align-items: center; ">
            <div class="pfp"/>
            <div class="button1" @click="uploadPhoto" style="align-items: center; display: flex">
              <div style="margin-right: 1vh">Загрузить фото</div>
              <img src="../assets/ico/download.svg"/>
            </div>
          </div>

          <div style="display: flex; justify-content: space-between;">
            <div class="h1">Личная информация</div>
            <div class="separator" style="flex: 1;"/>
          </div>

          <div style="display: flex; justify-content: start;align-items: center; ">

            <div class="h2" style="margin: 3vh 0 0 -0.5vh; flex: 1; padding-right: 5.5vh; ">
              <div style="margin-left: 1.4vh ">Имя пользователя</div>
              <input type="text" placeholder="User228" />
            </div>

            <div class="h2" style="margin: 3vh 0 0 -0.5vh; flex: 1;">
              <div style="margin-left: 1.4vh ">Электронная почта</div>
              <input type="text" placeholder="ivanivan@mail.ru" />
            </div>

          </div>

          <div style="display: flex; justify-content: start;align-items: center; ">

            <div class="h2" style="margin: 2vh 0 0 -0.5vh; flex: 1; padding-right: 5.5vh; ">
              <div style="margin-left: 1.4vh ">Имя</div>
              <input type="text" placeholder="Иван" />
            </div>

            <div class="h2" style="margin: 2vh 0 0 -0.5vh; flex: 1;">
              <div style="margin-left: 1.4vh ">Фамилия</div>
              <input type="text" placeholder="Иванов" />
            </div>

          </div>

          <div style="display: flex; justify-content: start;align-items: center; ">
            <div class="h2" style="margin: 2vh 0 0 -0.5vh; flex: 1; padding-right: 5.5vh; ">
              <div style="margin-left: 1.4vh ">Отчетсво</div>
              <input type="text" placeholder="Иванович" />
            </div>
            <div class="h2" style="margin: 2vh 0 0 -0.5vh; flex: 1;"/>
          </div>

          <div style="display: flex; justify-content: space-between; margin-top: 5vh">
            <div class="h1">Образование</div>
            <div class="separator" style="flex: 1;"/>
          </div>

          <div style="display: flex; justify-content: start;align-items: center; ">

            <div class="h2" style="margin: 3vh 0 0 -0.5vh; flex: 1; padding-right: 5.5vh; ">
              <div style="margin-left: 1.4vh ">Направление обучения</div>

              <div style="display: flex; position: relative">
                <select class="dropdown">
                  <option>Информационная / Компьютерная безопасность</option>
                  <option>Программирование</option>
                  <option>Анализ данных</option>
                  <option>Сетевые технологии</option>
                </select>
                <img class="dropdown-arrow" src="../assets/ico/down.svg"/>
              </div>

            </div>

            <div class="h2" style="margin: 3vh 0 0 -0.5vh; flex: 1; ">
              <div style="margin-left: 1.4vh ">Курс</div>

              <div style="display: flex; position: relative">
                <select class="dropdown">
                  <option>1 курс</option>
                  <option>2 курс</option>
                  <option>3 курс</option>
                  <option>4 курс</option>
                </select>
                <img class="dropdown-arrow" src="../assets/ico/down.svg"/>
              </div>

            </div>
          </div>

          <div style="display: flex; justify-content: space-between; margin-top: 4vh">
            <div class="separator" style="flex: 1; margin-left: 0"/>
          </div>

          <div style="display: flex; justify-content: center;align-items: center; ">
            <div class="button2" @click="uploadPhoto" style="align-items: center; display: flex">
              <div style="margin-right: 1vh; font-size: 16px">Сохранить изменения</div>
            </div>
          </div>

        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import SideBarPersonal from "@/components/SideBarPersonal.vue";
import Header from "@/components/Header.vue";
import { useStore } from "vuex";
import { computed } from "vue";

const store = useStore();
const user = computed(() => store.getters.user);

const uploadPhoto = () => {
  console.log("Загрузить фото");
  // код для обработки клика
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

.card {
  position: relative;
  font-family: Inter;
  padding: 4.5vh 6vh;
  width: 100%;
  height: fit-content;
  background-color: #232627;
  border-radius: 12pt;
  border: 1px solid #35373a;
}

.container {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
}

.h1{
  color: #5F6567;
  font-weight: 400;
  font-size: 12px;
  line-height: 0px;
}

.h2{
  color: #E3E4E4;
  font-size: 13.5px;
  font-weight: 280;
}

.separator{
  height: 1px;
  width: 100%;
  background-color: #35373A;
  margin: 0 0 0 3vh;
}

.pfp {
  background-color: #35373a;
  border: 1px solid #72787d;
  border-radius: 100%;
  width: 94pt;
  height: 94pt;
  margin: 4vh 0;
}

.button1{
  border-radius: 20px;
  height: fit-content;
  margin-left: 4.5vh;
  background-color: #464A4B;
  border: none;
  color: #E3E4E4;
  font-size: 14px;
  font-weight: 300;
  padding: 1.1vh 3.5vh;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.2s;
}

.button2{
  border-radius: 18px;
  height: fit-content;
  margin-top: 4.5vh;
  background-color: #1F7BD4;
  border: none;
  color: #E3E4E4;
  font-size: 14px;
  font-weight: 520;
  padding: 1.5vh 4vh;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.2s;
}

.button1:hover {
  background-color: #565a5b;
}

.button1:active {
  background-color: #3b3e3f;
  transform: scale(0.98);
}

.button2:hover {
  background-color: #2081de;
}

.button2:active {
  background-color: #1e74c7;
  transform: scale(0.98);
}

input[type="text"] {
  background-color: #343839;
  border: 1px solid #45484c;
  border-radius: 12px;
  color: #cdcece;
  font-family: "Inter";
  font-size: 13.5px;
  font-weight: 300;
  padding: 0 12px;
  width: 100%;
  height: 4.7vh;
  transition: border-color 0.2s ease-in-out;
}

input[type="text"]::placeholder {
  color: #cdcece;
  font-size: 13.5px;
}

input:focus {
  border-color: #585b60; /* Цвет рамки при фокусе */
}

.dropdown {
  background-color: #343839;
  border: 1px solid #45484c;
  border-radius: 12px;
  color: #cdcece;
  font-family: "Inter";
  font-size: 13.5px;
  font-weight: 300;
  padding: 0 12px;
  width: 100%;
  height: 4.7vh;
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
  outline: none;
}
.dropdown-arrow {
  margin-left: -30px;
  pointer-events: none;
  position: absolute;
  right: 5px;
}
</style>

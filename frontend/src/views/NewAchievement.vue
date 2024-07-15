<template>
  <Header />
  <div
      style="
      width: 100%;
      height: 100%;
      background-color: #1c1e1f;
    "
  >
  <div
      style="
      margin-left: 260px;
      width: calc(100% - 260px);
      height: fit-content;
      background-color: #1c1e1f;
      display: flex;
      align-items: center;
      justify-content: center;
      padding: 12.5vh 35.5vh 5vh 25.5vh;
    "
  >
    <SideBarPersonal />
    <div style="width: 100%; height: 100%; display: flex; justify-content: center;">
      <div class="container" style="width: 100%;">
        <div class="card">

          <div class="h1">
            Создание нового достижения
          </div>

          <div class="separator" style="flex: 1; margin-top: 6vh"/>

          <div class="h2" style="margin: 3vh 0 0 -0.5vh; flex: 1;">
            <div style="margin: 0 0 2px 1.4vh ">Название достижения</div>
            <input type="text" placeholder="Напишите название" />
          </div>

          <div class="h2" style="margin: 2.5vh 0 0 -0.5vh; flex: 1;">
            <div style="margin: 0 0 2px 1.4vh ">Описание достижения</div>
            <input type="text" placeholder="Напишите описание" />
          </div>

          <div style="display: flex; justify-content: start;align-items: center; margin: 3vh 0">
            <div class="button1" @click="uploadPhoto" style="align-items: center; display: flex">
              <img src="../assets/ico/file.svg"/>
            </div>
            <div class="h2" style="margin-left: 2vh">Сертификат_1.pdf</div>
          </div>

          <div style="display: flex; justify-content: start;align-items: center; margin: 3vh 0">
            <div class="button1" @click="uploadPhoto" style="align-items: center; display: flex">
              <img src="../assets/ico/file.svg"/>
            </div>
            <div class="h2" style="margin-left: 2vh">Сертификат_2.pdf</div>
          </div>

          <div style="display: flex; justify-content: center;align-items: center; ">
            <div class="pfp"/>
            <div class="button2" @click="uploadPhoto" style="align-items: center; display: flex">
              <div style="margin-right: 1vh">Добавить файлы</div>
              <img src="../assets/ico/download.svg"/>
            </div>
          </div>

          <div style="display: flex; justify-content: space-between; margin-top: 4vh">
            <div class="separator" style="flex: 1; margin-bottom: 4vh"/>
          </div>

          <div style="display: flex; justify-content: center;align-items: center; ">
            <div class="button3" @click="uploadPhoto" style="align-items: center; display: flex; flex: 1; justify-content: center;">
              <div style="margin-right: 1vh; font-size: 17px">Отправить</div>
            </div>
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
  padding: 5.5vh 6vh;
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
  color: #E3E4E4;
  font-weight: 450;
  font-size: 22px;
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
  margin: 0;
}

.button1{
  border-radius: 16px;
  height: fit-content;
  background-color: #464A4B;
  border: none;
  color: #E3E4E4;
  font-size: 14px;
  font-weight: 300;
  padding: 1.3vh 1.3vh;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.2s;
}

.button2{
  border-radius: 20px;
  height: fit-content;
  background-color: #464A4B;
  border: none;
  color: #E3E4E4;
  font-size: 14px;
  font-weight: 300;
  padding: 1.1vh 3.5vh;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.2s;
}

.button3{
  border-radius: 18px;
  height: fit-content;
  background-color: #1F7BD4;
  border: none;
  color: #E3E4E4;
  font-size: 16px;
  font-weight: 520;
  padding: 1.6vh 4vh;
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
  background-color: #565a5b;
}

.button2:active {
  background-color: #3b3e3f;
  transform: scale(0.98);
}

.button3:hover {
  background-color: #2081de;
}

.button3:active {
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

</style>

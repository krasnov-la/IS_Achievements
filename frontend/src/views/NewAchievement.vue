<template>
  <Header />
  <div
      style="
      margin-left: 260px;
      width: calc(100% - 260px);
      height: 100%;
      background-color: #1c1e1f;
      display: flex;
      flex-wrap: wrap;
    "
  >
    <SideBarPersonal />
    <div style="width: 100%; margin-top: 10vh">
      <div class="container" style="margin-left: 1.5vh; margin-right: 1.5vh">
        <div class="card">
          <div class="pfp" />
          <div style="margin-left: 38%">
            <div
                style="
                color: #e3e4e4;
                font-size: 15pt;
                -webkit-text-stroke: 0.5px #e3e4e4;
                margin-bottom: 6pt;
              "
            >
              {{ user?.nickname || "User" }}
            </div>
            <div style="margin-left: 2.2%">
              <div class="h5">Иванов Иван Иванович</div>
              <div class="h5">ivanivan@mail.ru</div>
            </div>
          </div>

          <div class="h6" style="display: flex">
            <div class="h5">Информационная/Компьютерная безопасность</div>
            <div
                style="
                width: 0.8pt;
                height: 25pt;
                background-color: #343839;
                margin-left: 5%;
              "
            />
            <div style="margin: 0 3% 0 7%" class="h5">2 курс обучения</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import SideBar from "@/components/SideBar.vue";
import Header from "@/components/Header.vue";
import { useStore } from "vuex";
import { computed } from "vue";
import SideBarPersonal from "@/components/SideBarPersonal.vue";
const store = useStore();
const user = computed(() => store.getters.user);
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

.table {
  width: 93%;
  margin: 2.5% 0 0 5%;
  padding-bottom: 2%;
  position: relative;
  height: fit-content;
  background-color: #232627;
  font-family: Inter;

  border-radius: 12pt;
  border: 1px solid #35373a;
}
.row {
  width: 100%;
  height: 4.5vh;
  padding: 0.7% 3.5% 1% 3.1%;
  background-color: #343839;
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-wrap: wrap;
}

.row1 {
  width: 100%;
  height: 10vh;
  padding: 2% 3.5% 2% 3.1%;
  background-color: #343839;
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
}

.row2 {
  width: 100%;
  height: fit-content;
  padding: 2% 3.5% 2% 3.1%;
  background-color: #232627;
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
}

.card .pic1 {
  position: absolute;
  top: 0;
  right: 0;
  width: 25%;
  height: 50%;
  margin: 3% 3% 0 0;
  background-image: url("../assets/ico/medal.svg");
  background-repeat: no-repeat;
  background-size: contain;
}
.card .pic2 {
  position: absolute;
  top: 0;
  right: 0;
  width: 25%;
  height: 50%;
  margin: 3% 3% 0 0;
  background-image: url("../assets/ico/coins.svg");
  background-repeat: no-repeat;
  background-size: contain;
}

.pfp {
  background-color: #35373a;
  border: 1px solid #72787d;
  border-radius: 100%;
  width: 85pt;
  height: 85pt;
  position: absolute;
  top: 0;
  left: 0;
  margin: 5% 0 0 5%;
}
.h8 {
  font-weight: lighter;
  color: #e3e4e4;
  font-weight: 340;
  font-size: 9pt;
  margin: 0 0 0pt -0.5vh;
  min-width: 80pt;
}
.h7 {
  font-weight: 490;
  color: #ffffff;
  font-size: 9pt;
  min-width: 80pt;
  margin: 0 0 0pt -0.5vh;
}

.h6 {
  position: absolute;
  bottom: 0;
  margin: 0 0 5% 0;
  justify-content: space-between;
}

.h5 {
  font-weight: lighter;
  color: #9ba1a8;
  -webkit-text-stroke: 0.4px #9ba1a8;
  font-size: 9pt;
  transform: scaleX(1.05);
  margin: 0 0 1pt 0;
  min-width: 80pt;
}
.h4 {
  font-weight: lighter;
  color: #9ba1a8;
  -webkit-text-stroke: 0.5px #9ba1a8;
  font-size: 10pt;
  transform: scaleX(1.1);
  margin: 8.5pt 0 0 5%;
}
.h3 {
  color: #e3e4e4;
  font-weight: bold;
  font-size: 38pt;
}
.h2 {
  color: #9ba1a8;
  font-size: 15pt;
  margin-bottom: 33.5pt;
}
.h1 {
  color: #e3e4e4;
  margin: 3vh 0 4vh 4vh;
  font-size: 18pt;
  font-weight: 550;
}
.card {
  position: relative;
  font-family: Inter;
  padding: 1.5% 0 0 2%;
  width: calc(80% / 2.56);
  height: 150pt;
  background-color: #232627;

  border-radius: 12pt;
  border: 1px solid #35373a;
}

.container {
  margin: 2.5% 0 0 2.5%;
  display: flex;
  justify-content: space-between;
  padding: 0 2.5%;
  flex-wrap: wrap;
}
.dots {
  content: url("../assets/ico/dots.svg");
  padding: 5pt;
  position: absolute;
  right: 0;
  width: 35pt;
  height: 35pt;
  margin: 10pt 4pt 0 0;
}
</style>

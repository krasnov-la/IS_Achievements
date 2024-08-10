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
      <div class="table" style="margin-left: 6vh">
        <div class="dots"></div>
        <div class="h1">Мои заявки</div>
        <div class="row">
          <div class="h7" style="flex: 1">Название достижения</div>
          <div class="h7" style="flex: 3; margin-left: 5%">Описание</div>
          <div class="h7" style="flex: 1">Дата заявления</div>
          <div class="h7" style="flex: 1">Статус</div>
        </div>
        <div
          v-for="(request, index) in requests"
          :key="request.id"
          @click="openModal(request)"
        >
          <div :class="[{ row2: index % 2 === 0 }, { row1: index % 2 === 1 }]">
            <div class="h8" style="flex: 1">{{ request.eventName }}</div>
            <div class="h8" style="flex: 3; margin-left: 5%">
              {{ request.description }}
            </div>
            <div class="h8" style="flex: 1">
              {{
                `${String(new Date(request.dateTime).getDate()).padStart(
                  2,
                  "0"
                )}.${String(new Date(request.dateTime).getMonth() + 1).padStart(
                  2,
                  "0"
                )}.${new Date(request.dateTime).getFullYear()}`
              }}
            </div>
            <div class="h8" style="flex: 1">{{ request.status }}</div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <AchievementModal
    :achievement="selectedRequest"
    :visible="isModalVisible"
    @close="closeModal"
  />
</template>

<script setup>
import Header from "@/components/Header.vue";
import axios from "axios";
import { useStore } from "vuex";
import { onMounted, ref } from "vue";
import SideBarPersonal from "@/components/SideBarPersonal.vue";
import AchievementModal from "@/components/AchievementInfo.vue";

const store = useStore();
const requests = ref([]);
const selectedRequest = ref(null);
const isModalVisible = ref(false);

const getStudentRequests = async () => {
  try {
    const achievementsData = await axios.get(
      `${process.env.VUE_APP_API_URL}Requests/self`,
      {
        withCredentials: true,
        headers: { "Content-Type": "application/json" },
      }
    );
    requests.value = achievementsData.data;
  } catch (error) {
    console.log(error);
  }
};

const openModal = (achievement) => {
  selectedRequest.value = achievement;
  isModalVisible.value = true;
};

const closeModal = () => {
  isModalVisible.value = false;
  selectedRequest.value = null;
};

onMounted(getStudentRequests);
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
.row,
.row1,
.row2 {
  width: 100%;
  padding: 0.8% 3.5% 1% 3.5%;
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-wrap: wrap;
}

.row {
  height: 4.5vh;
  background-color: #343839;
}

.row1 {
  padding: 2% 3.5%;
  cursor: pointer;
  height: fit-content;
  background-color: #343839;
  transition: background-color 0.2s, transform 0.2s;
}

.row2 {
  padding: 2% 3.5%;
  cursor: pointer;
  height: fit-content;
  background-color: #232627;
  transition: background-color 0.2s, transform 0.2s;
}

.row1:hover {
  background-color: rgba(52, 56, 57, 0.85);
}

.row1:active {
  background-color: #343839;
  transform: scale(0.995);
}

.row2:hover {
  background-color: rgba(52, 56, 57, 0.15);
}

.row2:active {
  background-color: #232627;
  transform: scale(0.995);
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
  margin-left: 12px;
}
.h2 {
  color: #9ba1a8;
  font-size: 15pt;
  margin-bottom: 33.5pt;
  margin-top: 0;
}
.h1 {
  color: #e3e4e4;
  margin: 30px 30px;
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
  margin: 8px 10px;
}
</style>

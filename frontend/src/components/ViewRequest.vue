<template>
  <div class="container">
    <div class="request-details">
      <h2>{{ requestData.title }}</h2>
      <p>{{ requestData.description }}</p>

      <div class="images">
        <img v-for="image in requestData.images" :src="image" :alt="requestData.title" />
      </div>

      <div class="score-input">
        <p for="score">Введите баллы:</p>
        <input type="number" id="score" v-model="score" />
      </div>

      <div class="actions">
        <button @click="approveRequest">Принять</button>
        <div style="width: 20px"/>
        <button @click="rejectRequest">Отклонить</button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import { useRouter } from "vue-router";

const requestData = {
  title: "Sample Event 4",
  description: "Это пример описания мероприятия.",
  images: [
    "/path/to/image1.jpg",
    "/path/to/image2.jpg",
    "/path/to/image3.jpg",
  ],
};

const score = ref(0);
const router = useRouter();

const approveRequest = () => {
  alert(`Заявка принята с баллами: ${score.value}`);
  router.push("/AdminDashboard");
};

const rejectRequest = () => {
  alert("Заявка отклонена");
  router.push("/AdminDashboard");
};
</script>

<style scoped>
/* Контейнер для центрирования */
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh; /* Высота экрана */
  background-color: #1f2125;
  font-family: Inter;
  font-size: 14px;
  color: #d0d0d0;
}

.request-details {
  padding: 20px;
  background-color: #282f38;
  border-radius: 12px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  width: 80%;
  max-width: 600px;
}

h2 {
  font-family: "Inter";
  font-weight: 550;
  font-size: 23.5px;
  margin: 0 0 20px 0;
  color: #e3e4e4;
}

.request-details p {
  margin-bottom: 20px;
}

.request-details .images img {
  max-width: 200px;
  margin: 10px;
  border-radius: 5px;
}

.score-input {
  margin-bottom: 20px;
}

input {
  background-color: #1f2125;
  border: 1px solid #38404b;
  padding: 12px;
  color: #d0d0d0;
  border-radius: 5px;
}

.actions {
  display: flex;
  justify-content: space-between;
}

.actions button {
  padding: 10px 15px;
  background-color: #3d79cd;
  color: #fff;
  border: none;
  cursor: pointer;
  border-radius: 17px;
  flex: 1;
}

.actions button:hover {
  background-color: #4685dc;
}
</style>

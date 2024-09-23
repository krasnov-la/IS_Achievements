<template>
  <div class="request-table">
    <h2>Открытые заявки</h2>
    <table>
      <thead>
        <tr>
          <th>№</th>
          <th>Названия мероприятия</th>
          <th>Пользователь</th>
          <th>Дата подачи</th>
          <th>Действия</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(request, index) in requests" :key="request.id">
          <td>{{ index + 1 }}</td>
          <td>{{ request.eventName }}</td>
          <td>{{ request.ownerLogin }}</td>
          <td>
            {{
              `${String(new Date(request.dateTime).getDate()).padStart(
                2,
                "0"
              )}.${String(new Date(request.dateTime).getMonth() + 1).padStart(
                2,
                "0"
              )}.${new Date(request.dateTime).getFullYear()}`
            }}
          </td>
          <td>
            <button class="watch-request-button" @click="openRequest(request.id)">Просмотреть</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";
import router from "@/router";

const requests = ref([]);

const openRequest = (id) => {
  router.push(`/request/${id}`);
};

const getRequests = async () => {
  try {
    const requestsResponse = await axios.get(
      `${process.env.VUE_APP_API_URL}Requests/open`,
      {
        withCredentials: true,
        headers: { "Content-Type": "application/json" },
      }
    );
    requests.value = await requestsResponse.data;
  } catch (error) {
    console.log(error);
  }
};

onMounted(getRequests);
</script>

<style scoped>

.watch-request-button{
  border-radius: 15px;
  background-color: #3b4c5d;
  border: 1px solid #3b4c5d;
  color: #d0d0d0;
  padding: 5px 7px;
}

h2 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 23.5px;
  line-height: 36px;
  margin: 0 0 20px 0;
  color: #e3e4e4;
}

.request-table table {
  width: 100%;
  border-collapse: collapse;
  color: #d0d0d0;
}

.request-table th,
.request-table td {
  border: 1.2px solid #3b4c5d;
  padding: 8px;
}

.request-table th {
  background-color: #3d79cd;
  color: white;
}
</style>

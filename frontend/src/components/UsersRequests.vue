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
            <button @click="openRequest(request.id)">Просмотреть</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";

const requests = ref([]);

const openRequest = (id) => {
  // Implement edit user logic
  console.log("Open Request:", id);
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
.request-table table {
  width: 100%;
  border-collapse: collapse;
}

.request-table th,
.request-table td {
  border: 1px solid #ddd;
  padding: 8px;
}

.request-table th {
  background-color: #2980b9;
  color: white;
}
</style>

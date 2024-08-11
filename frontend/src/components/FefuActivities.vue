<template>
  <div class="activities-table">
    <!-- TODO: Кнопка добавить мероприятие -->
    <h2>Мероприятия ЦИБ</h2>
    <table>
      <thead>
        <tr>
          <th>№</th>
          <th>Названия мероприятия</th>
          <th>Создатель</th>
          <th>Ссылка на мероприятие</th>
          <th>Действия</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(activity, index) in activities" :key="activity.id">
          <td>{{ index + 1 }}</td>
          <td>{{ activity.name }}</td>
          <td>{{ activity.adminLogin }}</td>
          <td>{{ activity.link }}</td>
          <td>
            <button @click="changeActivity(activity.id)">Изменить</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";

const activities = ref([]);

const changeActivity = (id) => {
  // Implement edit user logic
  console.log("Open Request:", id);
};

const getActivities = async () => {
  try {
    const activitiesResponse = await axios.get(
      `${process.env.VUE_APP_API_URL}Activities`,
      {
        withCredentials: true,
        headers: { "Content-Type": "application/json" },
      }
    );
    activities.value = await activitiesResponse.data;
    console.log(activities.value);
  } catch (error) {
    console.log(error);
  }
};

onMounted(getActivities);
</script>

<style scoped>
.activities-table table {
  width: 100%;
  border-collapse: collapse;
}

.activities-table th,
.activities-table td {
  border: 1px solid #ddd;
  padding: 8px;
}

.activities-table th {
  background-color: #2980b9;
  color: white;
}
</style>

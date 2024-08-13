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
            <button class="edit-event-button" @click="changeActivity(activity.id)">Изменить</button>
          </td>
        </tr>
      </tbody>
    </table>
    <button class="add-event-button" @click="changeActivity(activity.id)">Добавить мероприятие</button>
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

.edit-event-button{
  border-radius: 15px;
  background-color: #3b4c5d;
  border: 1px solid #3b4c5d;
  color: #d0d0d0;
  padding: 5px 7px;
}

.add-event-button{
  border-radius: 15px;
  background-color: #3b4c5d;
  border: 1px solid #3b4c5d;
  color: #d0d0d0;
  padding: 8px 10px;
  margin-top: 20px;
  font-size: 15px;
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

.activities-table table {
  width: 100%;
  border-collapse: collapse;
  color: #d0d0d0;
}

.activities-table th,
.activities-table td {
  border: 1.2px solid #3b4c5d;
  padding: 8px;
}

.activities-table th {
  background-color: #3d79cd;
  color: white;
}
</style>

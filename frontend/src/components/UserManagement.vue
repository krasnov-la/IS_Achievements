<!-- UserManagement.vue -->
<template>
  <div class="user-management">
    <h2>Управление пользователями</h2>
    <table>
      <thead>
        <tr>
          <th>№</th>
          <th>Логин</th>
          <th>Email</th>
          <th>Действия</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(student, index) in students" :key="student.id">
          <td>{{ index + 1 }}</td>
          <td>{{ student.login }}</td>
          <td>example@mail.com</td>
          <td>
            <button class="edit-user-button" @click="editUser(student.id)">Изменить</button>
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

const students = ref([]);

const editUser = (id) => {
  router.push(`/student/${id}`);
};

const getStudents = async () => {
  try {
    const studentsResponse = await axios.get(
      `${process.env.VUE_APP_API_URL}Users/students`,
      {
        withCredentials: true,
        headers: { "Content-Type": "application/json" },
      }
    );
    students.value = await studentsResponse.data;
  } catch (error) {
    console.log(error);
  }
};

onMounted(getStudents);
</script>

<style scoped>

.edit-user-button{
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

.user-management table {
  width: 100%;
  border-collapse: collapse;
  color: #d0d0d0;
}

.user-management th,
.user-management td {
  border: 1.2px solid #3b4c5d;
  padding: 8px;
}

.user-management th {
  background-color: #3d79cd;
  color: white;
}
</style>

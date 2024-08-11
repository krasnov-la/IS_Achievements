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
            <button @click="editUser(student.id)">Изменить</button>
            <button @click="deleteUser(student.id)">Удалить</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";

const students = ref([]);

const editUser = (id) => {
  // Implement edit user logic
  console.log("Edit user with ID:", id);
};
const deleteUser = (id) => {
  // Implement delete user logic
  console.log("Delete user with ID:", id);
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
.user-management table {
  width: 100%;
  border-collapse: collapse;
}

.user-management th,
.user-management td {
  border: 1px solid #ddd;
  padding: 8px;
}

.user-management th {
  background-color: #2980b9;
  color: white;
}
</style>

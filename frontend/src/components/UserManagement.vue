<!-- UserManagement.vue -->
<template>
  <div class="user-management">
    <h2>User Management</h2>
    <table>
      <thead>
      <tr>
        <th>ID</th>
        <th>Имя</th>
        <th>Email</th>
        <th>Действия</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="user in users" :key="user.id">
        <td>{{ user.id }}</td>
        <td>{{ user.name }}</td>
        <td>{{ user.email }}</td>
        <td>
          <button @click="editUser(user.id)">Изменить</button>
          <button @click="deleteUser(user.id)">Удалить</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      users: [
        { id: 1, name: 'John Doe', email: 'john@example.com' },
        { id: 2, name: 'Jane Smith', email: 'jane@example.com' },
        // Add more users as needed
      ],
    };
  },
  methods: {
    editUser(id) {
      // Implement edit user logic
      console.log('Edit user with ID:', id);
    },
    deleteUser(id) {
      // Implement delete user logic
      console.log('Delete user with ID:', id);
    },
  },
};
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

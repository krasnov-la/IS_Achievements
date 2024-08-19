<template>
  <div class="admin-container">
    <!-- Sidebar -->
    <div class="sidebar">
      <h2>Панель администратора</h2>
      <ul>
        <li>
          <a href="#" @click="setActiveSection('requests')">Заявки</a>
        </li>
        <li>
          <a href="#" @click="setActiveSection('usersManagement')"
            >Управление пользователями</a
          >
        </li>
        <li>
          <a href="#" @click="setActiveSection('activities')"
            >Мероприятия ЦИБ</a
          >
        </li>
        <li>
          <a href="#" @click="setActiveSection('settings')">Настройки</a>
        </li>
        <li>
          <a href="/PersonalArea" @click="setActiveSection('logout')">Выйти</a>
        </li>
      </ul>
    </div>

    <!-- Main Content -->
    <div class="main-content">
      <header>
        <h1 style="color: #e3e4e4;">Добро пожаловать, Админ</h1>
      </header>

      <section v-if="activeSection === 'requests'" class="content-section">
        <UsersRequests />
      </section>

      <section
        v-if="activeSection === 'usersManagement'"
        class="content-section"
      >
        <UserManagement />
      </section>

      <section v-if="activeSection === 'activities'" class="content-section">
        <FefuActivities />
      </section>

      <section v-if="activeSection === 'settings'" class="content-section">
        <h2>Настройки</h2>
        <p>Настройте параметры вашей админ-панели.</p>
      </section>
    </div>
  </div>
</template>

<script setup>
import FefuActivities from "@/components/FefuActivities.vue";
import UserManagement from "@/components/UserManagement.vue";
import UsersRequests from "@/components/UsersRequests.vue";
import { ref } from "vue";

const activeSection = ref("requests"); // Раздел по умолчанию

const setActiveSection = (section) => {
  activeSection.value = section;
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

body {
  margin: 0;
  background-color: #1c1e1f;
}

.admin-container {
  display: flex;
  height: 100vh;
}

/* Sidebar */
.sidebar {
  width: 250px;
  background-color: rgb(40, 47, 56);
  color: #ecf0f1;
  padding: 20px;
  box-sizing: border-box;
}

.sidebar h2 {
  margin: 0 0 20px 0;
  font-size: 24px;
  text-align: center;
  font-family: Inter;
  font-weight: 600;
}

.sidebar ul {
  list-style: none;
  padding: 0;
}

.sidebar ul li {
  margin: 15px 0;
  border: 1.2px solid #3b4c5d;
  border-radius: 15px;
  font-family: Inter;
  font-size: 15px;
}

.sidebar ul li a {
  font-family: Inter;
  font-size: 15px;
  color: #d9e4e7;
  text-decoration: none;
  display: block;
  padding: 10px;
  border-radius: 15px;
  transition: background-color 0.3s;
}

.sidebar ul li a:hover {
  background-color: #34495e;
  border-radius: 15px;
}

/* Main Content */
.main-content {
  flex-grow: 1;
  padding: 20px;
  box-sizing: border-box;
  background-color: #1e2125;
}

.main-content header {
  background-color: #3d79cd;
  color: #fff;
  padding: 20px;
  border-radius: 12px;
  margin-bottom: 20px;
  font-family: Inter;
}

.main-content .content-section {
  background-color: rgba(42, 54, 68, 0.65);
  padding: 20px;
  border-radius: 12px;
  margin-bottom: 20px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  font-family: Inter;
  font-weight: 400;
}
</style>

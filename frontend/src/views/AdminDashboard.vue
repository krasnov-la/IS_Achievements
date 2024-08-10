<template>
  <div class="admin-container">
    <!-- Sidebar -->
    <div class="sidebar">
      <h2>Панель администратора</h2>
      <ul>
        <li>
          <a href="#" @click="setActiveSection('dashboard')">Панель управления</a>
        </li>
        <li>
          <a href="#" @click="setActiveSection('users')">Управление пользователями</a>
        </li>
        <li>
          <a href="#" @click="setActiveSection('settings')">Настройки</a>
        </li>
        <li>
          <a href="#" @click="setActiveSection('reports')">Отчеты</a>
        </li>
        <li>
          <a href="#" @click="setActiveSection('logout')">Выйти</a>
        </li>
      </ul>
    </div>

    <!-- Main Content -->
    <div class="main-content">
      <header>
        <h1>Добро пожаловать, Админ</h1>
      </header>

      <section v-if="activeSection === 'dashboard'" class="content-section">
        <h2>Панель управления</h2>
        <p>Здесь отображаются все важные метрики.</p>
      </section>

      <section v-if="activeSection === 'users'" class="content-section">
        <UserManagement />
      </section>

      <section v-if="activeSection === 'settings'" class="content-section">
        <h2>Настройки</h2>
        <p>Настройте параметры вашей админ-панели.</p>
      </section>

      <section v-if="activeSection === 'reports'" class="content-section">
        <h2>Отчеты</h2>
        <p>Просмотр отчетов и аналитики.</p>
      </section>
    </div>
  </div>
</template>

<script>
import UserManagement from "@/components/UserManagement.vue";

export default {
  components: {
    UserManagement,
  },
  data() {
    return {
      activeSection: 'dashboard', // Раздел по умолчанию
    };
  },
  methods: {
    setActiveSection(section) {
      this.activeSection = section;
    },
  },
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

body {
  margin: 0;
  background-color: #f4f4f4;

}

.admin-container {
  display: flex;
  height: 100vh;
}

/* Sidebar */
.sidebar {
  width: 250px;
  background-color: #2c3e50;
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
  border: 1px solid #45607a;
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
}

.main-content header {
  background-color: #2980b9;
  color: #fff;
  padding: 20px;
  border-radius: 8px;
  margin-bottom: 20px;
  font-family: Inter;


}

.main-content .content-section {
  background-color: #fff;
  padding: 20px;
  border-radius: 8px;
  margin-bottom: 20px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  font-family: Inter;
  font-weight: 400;
}
</style>

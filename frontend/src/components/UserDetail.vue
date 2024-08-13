<template>
  <div class="container">
  <div class="user-detail-container">
    <h2>Информация о пользователе</h2>

    <div class="user-info">
      <p><strong>Имя пользователя:</strong> {{ user.name }}</p>
      <p><strong>ФИО:</strong> {{ user.name }}</p>
      <p><strong>Логин:</strong> {{ user.login }}</p>
      <p><strong>Email:</strong> {{ user.email }}</p>
      <p><strong>Роль:</strong>
        <select style="width: 215px" v-model="user.role">
          <option value="user">Пользователь</option>
          <option value="admin">Администратор</option>
        </select>
      </p>
      <p><strong>Статус:</strong>
        <select style="width: 200px" v-model="user.status">
          <option value="active">Активен</option>
          <option value="banned">Забанен</option>
        </select>
      </p>
    </div>

    <div class="actions">
      <button @click="saveChanges">Сохранить изменения</button>
      <div style="width: 20px"/>
      <button @click="cancelChanges">Отмена</button>
    </div>
  </div>
  </div>
</template>

<script setup>
import { ref, watch, reactive } from 'vue';
import { useRouter } from 'vue-router';

const props = defineProps({
  initialUser: {
    type: Object,
    required: true
  }
});

const router = useRouter();

const user = reactive({ ...props.initialUser }); // Создание реактивной копии объекта пользователя

// Сохранение изменений пользователя
const saveChanges = () => {
  // Здесь вы можете добавить логику для сохранения данных на сервере
  // Например, через API-запрос
  console.log("Сохранение изменений:", user);
  router.push('/admin-dashboard'); // Возврат на главную страницу панели администратора
};

// Отмена изменений
const cancelChanges = () => {
  router.push('/admin-dashboard'); // Возврат на главную страницу панели администратора без сохранения
};
</script>

<style scoped>

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

.user-detail-container {
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

.user-info p {
  margin-bottom: 20px;
}

.user-info select {
  font-size: 14px;
  padding: 5px;
  margin-left: 14px;
  background-color: #1f2125;
  border: 1px solid #38404b;
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

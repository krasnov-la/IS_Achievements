<template>
  <div v-if="visible" class="modal-overlay" @click.self="closeModal">
    <div class="modal-content">

      <div style="display: flex; justify-content: space-between; align-items: center; margin: 0 0 10px 0">
        <div class="h1">{{ achievement.eventName }}</div>
        <div style="cursor: pointer;"  @click="closeModal">
          <img style="margin-right: -10px" src="../assets/ico/cross.svg" />
        </div>
      </div>

      <div class="separator"/>

      <div style="margin: 25px 10px 15px 10px">
        <div class="h21" style="margin: 0 0 55px 0">{{ achievement.description }}</div>
        <div style="display: flex; justify-content: space-between; align-items: center;">
          <div class="h31">Полученно баллов: {{ achievement.score }}</div>
          <div class="h21">Дата прохождения: </div>
        </div>
      </div>

      <div class="separator"/>

      <div style="display: flex; justify-content: space-between; align-items: center;">

        <div
            class="button3"
            @click=""
            style="align-items: center;"
        >
          Сертификат
        </div>

        <div
            class="button4"
            @click=""
            style="align-items: center;"
        >
          <img src="../assets/ico/download.svg" />
        </div>

      </div>

    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';

const props = defineProps({
  achievement: Object,
  visible: Boolean
});

const emit = defineEmits(['close']);

const closeModal = () => {
  emit('close');
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

.separator {
  height: 1px;
  width: 100%;
  background-color: #35373a;
}


.h1 {
  color: #e3e4e4;
  font-weight: 600;
  font-size: 14.5pt;
  font-family: Inter;
  line-height: 18px;
}

.h21 {
  font-family: Inter;
  color: #e3e4e4;
  font-weight: 250;
  font-size: 9.8pt;
  margin: 0 0 0pt -0.5vh;
  min-width: 80pt;
}

.h31 {
  color: #e3e4e4;
  font-weight: 580;
  font-size: 12pt;
  font-family: Inter;
  line-height: 18px;
}

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
}

.modal-content {
  background-color: #232627;
  border: 1px solid #36393a;
  padding: 12px 35px 25px 35px;
  border-radius: 12px;
  max-width: 600px;
  width: 100%;
  color: #e3e4e4;
}

.button3, .button4 {
  font-family: Inter;
  border-radius: 13px;
  display: flex; /* Добавлено */
  justify-content: center; /* Добавлено */
  align-items: center; /* Добавлено */
  height: fit-content;
  margin-top: 25px;
  background-color: #1f7bd4;
  border: none;
  color: #e3e4e4;
  font-size: 16px;
  font-weight: 480;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.2s;
}

.button3 {
  width: calc(100% - 68px);
  padding: 1.5vh 4vh;
}

.button4 {
  padding: 1.5vh 1.6vh;
}

.button3:hover {
  background-color: #2081de;
}

.button3:active {
  background-color: #1e74c7;
  transform: scale(0.98);
}

.button4:hover {
  background-color: #2081de;
}

.button4:active {
  background-color: #1e74c7;
  transform: scale(0.98);
}
</style>

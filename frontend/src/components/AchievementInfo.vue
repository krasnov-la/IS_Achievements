<template>
  <div v-if="visible" class="modal-overlay" @click.self="closeModal">
    <div class="modal-content">
      <h2>{{ achievement.eventName }}</h2>
      <p>{{ achievement.description }}</p>
      <p>Сертификаты: {{ achievement.certificates }}</p>
      <p>Баллы: {{ achievement.score }}</p>
      <button @click="closeModal">Закрыть</button>
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
  padding: 20px;
  border-radius: 12px;
  max-width: 600px;
  width: 100%;
  color: #e3e4e4;
}
</style>

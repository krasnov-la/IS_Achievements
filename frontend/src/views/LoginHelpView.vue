<template>
  <div></div>
</template>

<script setup>
import { onMounted } from "vue";
import { useStore } from "vuex";

const store = useStore();

onMounted(() => {
  window.YaSendSuggestToken(`${process.env.VUE_APP_HOST_URL}login`, {
    flag: true,
  });
});
</script>

<style scoped>
html,
body {
  background: #eee;
}
</style>

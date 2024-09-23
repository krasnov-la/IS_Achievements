<template>
  <div></div>
</template>

<script setup>
import { onMounted } from "vue";
import { useStore } from "vuex";

const store = useStore();

onMounted(() => {
  window.YaSendSuggestToken("http://localhost:4000/login", {
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

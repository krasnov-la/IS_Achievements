<template>
  <div class="header">
    <div class="h1">{{ text }}</div>
    <div class="notif"></div>
  </div>
</template>

<script>
import { computed } from 'vue';
import { useStore } from 'vuex';

export default {
  name: 'Header',
  setup() {
    const store = useStore();
    const text = computed(() => store.state.text);

    return { text };
  }
}
</script>

<style scoped>
.notif {
  content: url("../assets/ico/bell.svg");
  padding: 5pt;
  position: fixed;
  right: 0;
  border-radius: 100%;
  width: 28pt;
  height: 28pt;
  background-color: #343839;
  margin-right: 30pt;
}
.h1 {
  top: 10pt;
  color: #e3e4e4;
  margin-left: 3%;
  font-size: 18pt;
  font-weight: 450;
  -webkit-text-stroke: 0.4px #e3e4e4;
  transform: scaleX(1.05);
}

.header {
  position: fixed;
  background-color: #232627;
  width: 90%;
  margin-left: 260px;
  height: 8vh;
  border-bottom: 1pt solid #35373a;
  font-family: Inter;
  align-items: center;
  display: flex;
  z-index: 1000;
}

.h2 {
  color: #e3e4e4;
  margin-left: 22%;
  -webkit-text-stroke: 0.5px #9ba1a8;
  font-size: 10pt;
  transform: scaleX(1.1);
}
</style>

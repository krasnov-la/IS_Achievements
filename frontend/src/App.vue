<template>
    <router-view/>
</template>

<script setup>
import { createApp } from 'vue'
import App from './App.vue'

const app = createApp(App)
</script>

<style>
html, body {
  height: 100vh;
  margin: 0;
}
* {
  box-sizing: border-box;
}
.main{
  display: flex;
}
#app {
  height: 100%;
}
</style>

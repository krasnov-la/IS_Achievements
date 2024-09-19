<template>
  <div></div>
</template>

<script setup>
import { onMounted, ref } from "vue";

onMounted(() => {
  // // Extract the token from the URL fragment (hash part)
  // const hash = window.location.hash;

  // if (hash) {
  //   const params = new URLSearchParams(hash.substring(1)); // Remove the '#' and parse the parameters
  //   const token = params.get("access_token"); // Get the access token

  //   if (token) {
  //     test.value = token;
  //   }
  // }
  // This will run when the component is mounted
  window.YaSendSuggestToken("http://localhost:8080/login", {
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

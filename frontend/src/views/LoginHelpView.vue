<template>
  <div></div>
</template>

<script setup>
import { onMounted } from "vue";
import axios from "axios";
import { useStore } from "vuex";

const store = useStore();

const getYandexInfo = async (token) => {
  const OAuthToken = token;

  try {
    const response = await axios.get("https://login.yandex.ru/info", {
      params: {
        format: "json",
      },
      headers: {
        Authorization: `OAuth ${OAuthToken}`,
      },
    });

    const userInfo = response.data;
    const user = { email: userInfo["login"] };
    store.dispatch("setUser", user);
  } catch (error) {
    console.error("Error fetching Yandex info:", error);
    userInfo.value = { error: "Failed to fetch data" };
  }
};

onMounted(() => {
  // Extract the token from the URL fragment (hash part)
  const hash = window.location.hash;
  if (hash) {
    const params = new URLSearchParams(hash.substring(1)); // Remove the '#' and parse the parameters
    const token = params.get("access_token"); // Get the access token
    if (token) {
      getYandexInfo(token);
    }
  }
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

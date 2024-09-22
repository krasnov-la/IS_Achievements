<template>
  <!-- <div id="container"></div> -->
  <div class="bg">
    <div class="card1">
      <form id="form" @submit.prevent="submit">
        <div style="display: grid; place-items: center">
          <div class="h11">Вход в аккаунт</div>
          <div class="separatorr" />
        </div>
        <div id="buttonContainerId"></div>
      </form>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import { onMounted } from "vue";
import { useStore } from "vuex";
import { useRouter } from "vue-router";

const router = useRouter();
const store = useStore();

const changeText = async (newText) => {
  store.dispatch("updateText", newText);
};

const setActive = async (path) => {
  store.dispatch("updateActivePath", path);
};

onMounted(() => {
  // Assuming that YaAuthSuggest is already available globally
  if (window.YaAuthSuggest) {
    window.YaAuthSuggest.init(
      {
        client_id: "d09e490d8e604eed9475097b0ccde511",
        response_type: "token",
        redirect_uri: "http://localhost:4000/loginhelp",
      },
      "http://localhost:4000/loginhelp",
      //указывать текущий порт приложения
      // "http://localhost:{your_port}/loginhelp",
      {
        view: "button",
        parentId: "buttonContainerId",
        buttonSize: "m",
        buttonView: "main",
        buttonTheme: "dark",
        buttonBorderRadius: "8",
        buttonIcon: "ya",
      }
    )
      .then(function (result) {
        return result.handler();
      })
      .then(function (data) {
        authorize(data["access_token"]);
      })
      .catch(function (error) {
        console.log("Что-то пошло не так: ", error);
      });
  } else {
    console.error("YaAuthSuggest is undefined.");
  }
});

const authorize = async (token) => {
  try {
    const response = await axios.get(
      `${process.env.VUE_APP_API_URL}auth/login/${token}`,
      {},
      {
        withCredentials: true,
        headers: { "Content-Type": "application/json" },
      }
    );
    if (response.status === 200) {
      const user = {
        emailAddress: response.data.email,
        nickname: "",
        score: "",
        place: "0",
      };

      await store.dispatch("setUser", user);
      await store.dispatch("setToken", response.data.accessToken);
      await store.dispatch("setAuth", true);

      setActive("/");
      changeText("Главная страница");
      router.push("/");
    }
  } catch (error) {
    alert(`${error}`);
  }
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

.bg {
  width: 100%;
  height: 100%;
  background-color: #1c1e1f;
  display: grid;
  place-items: center;
}

.card1 {
  font-family: "Inter";
  position: relative;
  padding: 2.6vh 4.7vh;
  width: 66vh;
  height: fit-content;
  background-color: #232627;

  border-radius: 10pt;
  border: 0.8px solid #35373a;
}

.h11 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 22.5px;
  line-height: 30px;

  color: #e3e4e4;
}

.separatorr {
  width: 100%;
  height: 0.7px;
  background-color: #35373a;
  margin: 2.7vh 0 2.7vh 0;
}

.h22 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 16.2px;
  line-height: 30px;
  margin: 0 0 0.5vh 0.9vh;

  color: #e3e4e4;
}

input {
  background-color: #35373a;
  border: 0.8px solid #45484c;
  border-radius: 9px;
  width: 100%;
  height: 5.2vh;
  padding-left: 2vh;
  color: #a9aaaf;
  transition: border-color 0.2s ease-in-out;
}

input::placeholder {
  color: #72787d;
  font-size: 9.8pt;
}

input:focus {
  border-color: #80c0fd;
  color: #a9aaaf;
  outline: none;
  font-size: 9.8pt;
}

.link {
  font-size: 9pt;
  font-weight: lighter;
  -webkit-text-stroke: 0.5px #8abefc;
  transform: scaleX(1.1);
  margin: 0 0 0.5vh 0.9vh;
  text-decoration: none;

  color: #8abefc;
}

.h3 {
  font-family: "Inter";
  font-size: 9pt;
  font-weight: lighter;
  -webkit-text-stroke: 0.5px #72787d;
  transform: scaleX(1.1);
  margin: 0 0 0.5vh 0.9vh;
  text-decoration: none;

  color: #72787d;
}

.button {
  width: 100%;
  height: 6vh;
  background-color: #1f7bd4;
  display: grid;
  place-items: center;
  border-radius: 15px;
  font-size: 13.3pt;
  color: #e3e4e4;
  font-weight: 570;
  margin: 0.5vh 0 3vh 0;
  border: none;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.2s;
}

.checkbox-container {
  display: inline-block;
  position: relative;
  cursor: pointer;
  font-size: 22px;
  user-select: none;
  margin: -1vh 0.9vh;
}

.checkbox-container input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
}

.checkmark {
  position: absolute;
  top: 0;
  left: 0;
  height: 20px;
  width: 20px;
  background-color: #35373a;
  border-radius: 4px;
}

.checkbox-container input:checked ~ .checkmark {
  background-color: #35373a;
}

.checkmark:after {
  content: "";
  position: absolute;
  display: none;
}

.checkbox-container input:checked ~ .checkmark:after {
  display: block;
}

.checkbox-container .checkmark:after {
  left: 6.5px;
  top: 1.5px;
  width: 5px;
  height: 10px;
  border: solid white;
  border-width: 0 3px 3px 0;
  transform: rotate(45deg);
  background-color: transparent; /* чтобы галочка была только из границ */
  border-color: #1f7bd4; /* фиолетовая галочка */
}

.button:hover {
  background-color: #2081de;
}

.button:active {
  background-color: #1e74c7;
  transform: scale(0.98);
}

input:-webkit-autofill {
  -webkit-box-shadow: 0 0 0px 1000px #35373a inset !important;
  -webkit-text-fill-color: #a9aaaf !important; /* Цвет текста */
}

html,
body {
  background: #eee;
}
</style>

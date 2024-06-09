<template>
  <div class="side-bar">
    <div class="wrapper">
      <div class="side-bar_header">
        <img class="logo" src="../assets/logo.svg" alt="" />
        <h1>.NET Creations</h1>
      </div>
      <router-link to="/"  :class="{ active: isActive('/') }" @click.native="() => { setActive('/'); changeText('Главная страница'); }">
        <div class="stripe" :class="{ active: isActive('/') }"></div>
        Главная страница
      </router-link>
      <a href="" :class="{ active: isActive('/events') }" @click="() => { setActive('/events'); changeText('Текущие ивенты'); }">
        <div class="stripe" :class="{ active: isActive('/events') }"></div>
        Текущие ивенты
      </a>
      <a href=""  :class="{ active: isActive('/future-events') }" @click="() => { setActive('/future-events'); changeText('Будущие ивенты'); }" >
        <div class="stripe" :class="{ active: isActive('/future-events') }"></div>
        Будущие ивенты
      </a>
      <router-link to="/PersonalArea" @click="changeText('Личный кабинет')" class="profile" >
        <img class="profile-img" src="" alt="" />
        <div>
          <h6 class="profile-name">User228</h6>
          <p class="profile-score">Баллы: 12 333</p>
        </div>
      </router-link>
    </div>
  </div>
</template>


<script>
import { useStore } from 'vuex';
export default {
  name: 'SideBar',
  setup() {
    const store = useStore();

    const changeText = (newText) => {
      store.dispatch('updateText', newText);
    };

    return { changeText };
  },
  data() {
    return {
      activePath: '/'
    };
  },
  methods: {
    setActive(path) {
      this.activePath = path;
    },
    isActive(path) {
      return this.activePath === path;
    }
  }
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap");

.side-bar {
  border: 1px solid #35373a;
  padding: 0.1% 1.5% 0 1.5%;
  height: 100%;
  width: 10%;
  background: #232627;
  min-width: 260px;
  display: flex;
  flex-direction: column;
  /* float: left; */
}
.wrapper {
  width: 100%;
  height: 100%;
  position: relative;
}
.side-bar_header {
  display: flex;
  margin: 0 10pt 0 -5pt;
}

h1 {
  font-family: "Inter";
  font-style: normal;
  font-weight: 680;
  font-size: 27px;
  line-height: 32px;
  margin-left: 1pt;

  color: #e3e4e4;
}

a {
  margin: 1% -4% 7% 0%;
  display: block;

  align-items: center;
  font-family: "Inter";
  font-style: normal;
  font-weight: 450;
  font-size: 12.5px;
  line-height: 20px;

  color: #BFBFBF;
  text-decoration: none;

  border: 0.9px solid #6b6b6b;
  border-radius: 8px;
  padding:  0 4% 0 4%;
  display: flex;
  align-items: center;
}

a:nth-child(2)::before {
  content: url("../assets/ico/home.svg");
  margin: 1.9% 5% -1% 1.5%;
}
a:nth-child(3)::before {
  content: url("../assets/ico/events.svg");
  margin: 2.1% 5% -1.2% 2.2%;
}
a:nth-child(4)::before {
  content: url("../assets/ico/time.svg");
  margin: 1.8% 5% -0.9% 2.2%;
}

.stripe {
  width: 2%;
  height: 32pt;
  position: relative;
  left: -68px;
  top: 0;
}

.stripe.active {
  background: #8057f2;
}

.active {
  background: #8057f2;
  color: #E3E4E4;
}

.profile {
  width: 104%;
  position: absolute;
  bottom: 0;
  left: 0%;
  margin: 0 0 10% 0;
  padding: 0 0 -15% 10px;
  background-color: #35373A;
  border: #35373A;
}
.profile-img {
  width: 35px;
  height: 35px;
  background: #a69ae8;
  border-radius: 50%;
  margin: 0 5% 0 0;
}
.profile-score {
  margin: 13% 0 13% 0;
  font-family: "Inter";
  font-style: normal;
  font-weight: 300;
  font-size: 10px;
  line-height: 10px;

  color: #e3e4e4;
}
.profile-name {
  margin: 10% 0 0 0;

  font-family: "Inter";
  font-style: normal;
  font-weight: 500;
  font-size: 13px;
  line-height: 14px;
  position: relative;
  /* identical to box height */

  color: #e3e4e4;
}
</style>

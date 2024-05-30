<template>
  <!-- <div class="main" >
    <side-bar />


  </div> -->
    <router-view/>
</template>

<script>
import SideBar from "./components/SideBar";
export default {
  components: {
    SideBar
  }
}
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

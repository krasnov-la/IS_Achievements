<template>
  <div>
    <side-bar />
  <router-view/>

  </div>
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
  height: 100%;
  margin: 0;
}
* {
  box-sizing: border-box;
}
</style>

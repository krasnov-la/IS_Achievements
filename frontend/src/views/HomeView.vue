<template>
<div class="wrapper">
   <side-bar />
    <div class="main" >
        
        <header>Главная страница</header>
        <div class="widgets" >
            <scoreboard  />
            <events-list />
            <future-events-list />

        </div>
    </div>
</div>
 


</template>

<script>
import { ref, createApp } from 'vue'
import SideBar from '../components/SideBar.vue'
import EventsList from '../components/EventsList.vue'
import FutureEventsList from '../components/FutureEventsList.vue'

import Scoreboard from '../components/Scoreboard.vue'

export default {
  components: { SideBar, EventsList, Scoreboard, FutureEventsList },

}
const app = createApp({})

// Регистрация компонента
app.component('side-bar', SideBar)
</script>

<style scoped>
.wrapper {
    height: 100%;
    display: flex;
}
.main {
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    background: #1c1e1f;
}
header {
    /* position: absolute; */
    width: 100%;
    background: #232627;
    /* height: 50px; */
    padding: 10px 10px;
    border: 1px solid #35373A;
font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 33px;
line-height: 40px;
color: #E3E4E4;
}

.widget_item {
background: #232627;
border: 1px solid #35373A;
border-radius: 18px;
    background: #232627;
    border-radius: 20px;
    padding: 0 10px 10px 10px;
}
h2 {
    /* Scoreboard */



font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 30px;
line-height: 36px;

color: #E3E4E4;


}
.widgets {
    overflow-x: hidden;
    /* height: 100%; */
    padding: 2%;
      display: grid;
      /* grid-template-columns: 10fr 1fr 1fr; */
      gap: 2%;
      justify-items: start;
      align-items: start;
        grid-template-areas: "a a a b" 
                             "a a a c"
                        
;
}
@media screen and (min-width: 150px) {
.widgets {
    display: flex;
    flex-direction: column;
}
.scoreboard  {
    min-width: 100% !important;
}
}
.scoreboard {
    min-width: 40vw;
    grid-area: a;
}
.event-list {
grid-area: b;
}
.future-event-list {
grid-area: c;
}

</style>
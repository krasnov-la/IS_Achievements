<template>
<div class="widget_item future-event-list " > 
    <h2>Будущие ивенты</h2>
 <div class=" list_events">
    <div class="event-item" v-for="event in events" :key="event.title">
      <img :src="event.img" alt="" />
      <div class="event-text">
        <h4>{{event.title}}</h4>
        <p>
          {{event.description}}
        </p>
      </div>
      <button class="link-full-info" ></button>
    </div>

  </div>
</div>
 
</template>

<script setup>
import { ref } from 'vue';


const events = ref([
  {img: "", title: "CTF-Хакатон", description: "Примите вызов на этом захватывающем CTF-хакатоне, где вы сможете продемонстрировать свои навыки в области кибербезопасности."},
  {img: "", title: "CTF-Хакатон", description: "Примите вызов на этом захватывающем CTF-хакатоне, где вы сможете продемонстрировать свои навыки в области кибербезопасности."},
])

</script>




<style scoped>
.widget_item {
    background: #232627;
    border-radius: 20px;
    padding:  0 10px 10px 10px 10px;
}
.event-item {
display: flex;
align-items: center;

background: #343839;
border-radius: 15px;
margin: 15px 0;
padding: 10px;

}
h2 {
margin: 15px 0;
font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 30px;
line-height: 36px;

color: #E3E4E4;


}
img {
    min-width: 100px;
    min-height: 70px;
    margin: 0 15px 0 0;
    background: #8057F2;
}
h4 {
margin: 20px 0;
font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 22px;
line-height: 0px;
/* identical to box height */

color: #E3E4E4;


}
p {


font-family: 'Inter';
font-style: normal;
font-weight: 300;
font-size: 15px;
line-height: 15px;

color: #FFFFFF;


}
.link-full-info {
    background: none;
    border: none;
  display: block;
  /* margin: 30px auto; */
  width: 25px;
  height: 25px;
  border-top: 3px solid  white;
  border-left: 3px solid  white;
   transform: rotate(135deg);
   cursor: pointer;
   transition: 0.3s;
   margin: 0 15px ;
   
}
.link-full-info:hover {
    transform: translateX(6px) rotate(135deg);
}
</style>
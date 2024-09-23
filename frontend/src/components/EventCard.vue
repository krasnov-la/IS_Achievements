<template>
  <div class="card">
    <div class="pfp" />

    <div style="display: flex; justify-content: space-between">
      <div style="display: flex">
        <img style="margin: -2vh 0.7vh -2vh 0" src="../assets/ico/clock.svg" />
        <div class="h1">2 дня 3ч</div>
      </div>

      <div style="display: flex">
        <img
          style="margin: -2vh 0.7vh -2vh 0"
          src="../assets/ico/calendar.svg"
        />
        <div class="h1">7 сентября - 11 сентября</div>
      </div>
    </div>

    <div class="h2">CTF-Хакатон</div>

    <div class="separator" />

    <div
      style="display: flex; justify-content: space-between; margin: 2vh 0 0 0"
    >
      <div style="display: flex; align-items: center">
        <img style="margin-right: 0.5vh" src="../assets/ico/location.svg" />
        <div class="h33">A корпус, 9 этаж</div>
      </div>

      <div style="display: flex">
        <div class="circle"></div>
        <div class="circle lm"></div>
        <div class="circle lm"></div>
        <div
          class="circle lm"
          style="
            display: flex;
            align-items: center;
            justify-content: center;
            background-color: #464a4b;
          "
        >
          <div class="h34">02+</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script></script>

<style>
.card {
  position: relative;
  font-family: Inter;
  padding: 2.9vh 2.9vh 2.3vh 2.9vh;
  width: 51.8vh;
  height: fit-content;
  background-color: #232627;
  border-radius: 12pt;
  border: 1px solid #35373a;
  margin-bottom: 3vh;
}

.pfp {
  flex: 1;
  width: 100%;
  background-color: #1e74c7;
  height: 35vh;
  border-radius: 8px;
  margin-bottom: 3vh;
}

.h1 {
  color: #9fa6ad;
  font-weight: 380;
  font-size: 12px;
  line-height: 13px;
}

.h2 {
  color: #e3e4e4;
  font-size: 19px;
  margin: 3.3vh 0 2.7vh 0;
  font-weight: 550;
}

.h33 {
  color: #9fa6ad;
  font-weight: 400;
  font-size: 13.2px;
  width: 150px;
}

.h34 {
  color: #a9b0b7;
  font-weight: 400;
  font-size: 12.8px;
}

.separator {
  height: 1.2px;
  width: 100%;
  background-color: #35373a;
  margin: 0;
  flex: 1;
}

.circle {
  width: 32px;
  height: 32px;
  border-radius: 50%;
  background-color: #1e74c7;
  border: 1.5px solid #232627;
}

.lm {
  margin-left: -12px;
}
</style>

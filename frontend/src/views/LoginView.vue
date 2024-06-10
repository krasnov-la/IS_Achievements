<template>
  <div class="bg">
    <div class="card">

      <div style="display: grid; place-items: center;">
        <div class="h1">Вход в аккаунт</div>
        <div class="separator" />
      </div>

      <div style="margin: 2.2vh 0 3vh 0">
        <div class="h2">Логин</div>
        <input placeholder="Введите Логин"/>
      </div>

      <div style="margin: 2.2vh 0 3vh 0">
        <div style="display: flex; justify-content: space-between">
          <div class="h2">Пароль</div>
          <router-link to="" style="margin: 1.2vh 1.5vh 0 0" class="link">Забыли пароль?</router-link>
        </div>
        <input placeholder="Введите пароль"/>
      </div>

      <div style="display: flex;">
        <label class="checkbox-container">
          <input type="checkbox">
          <span class="checkmark"></span>
        </label>
        <div style="margin: -0.55vh 0 0 3.5vh;" class="h3">Запомнить меня</div>
      </div>

      <div style="display: grid; place-items: center; margin-top: 3vh;">
        <div class="separator" />
        <div class="button">
          Войти
        </div>

        <div style="display: flex; margin-bottom: 0.8vh">
          <div class="h3">У вас еще нет аккаунта?</div>
          <div class="link" style="margin-left: 2.5vh ">Зарегистрироваться</div>
          </div>
      </div>
    </div>
  </div>
</template>

<style>

.bg{
  width: 100%;
  height: 100%;
  background-color: #1C1E1F;
  display: grid;
  place-items: center;
}

.card {
  position: relative;
  font-family: Inter;
  padding: 2.6vh 4.7vh;
  width: 66vh;
  height: fit-content;
  background-color: #232627;

  border-radius: 10pt;
  border: 0.8px solid #35373A;
}

.h1{
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 22.5px;
  line-height: 30px;

  color: #e3e4e4;
}

.separator{
  width: 100%;
  height: 0.7px;
  background-color: #35373a;
  margin: 2.7vh 0 2.7vh 0;

}

.h2{
  font-family: "Inter";
  font-style: normal;
  font-weight: 550;
  font-size: 16.2px;
  line-height: 30px;
  margin: 0 0 0.5vh 0.9vh;

  color: #e3e4e4;
}

input{
  background-color: #35373A;
  border: 0.8px solid #45484C;
  border-radius: 9px;
  width: 100%;
  height: 5.2vh;
  padding-left: 3.2vh ;
}

input::placeholder{
  color: #72787D;
  font-size: 9.8pt;
  transform: scaleX(1.05);

}

.link{
  font-size: 9pt;
  font-weight: lighter;
  -webkit-text-stroke: 0.5px #A69AE8;
  transform: scaleX(1.1);
  margin: 0 0 0.5vh 0.9vh;
  text-decoration: none;

  color: #A69AE8;
}

.h3{
  font-size: 9pt;
  font-weight: lighter;
  -webkit-text-stroke: 0.5px #72787D;
  transform: scaleX(1.1);
  margin: 0 0 0.5vh 0.9vh;
  text-decoration: none;

  color: #72787D;;
}

.button{
  width: 100%;
  height: 6vh;
  background-color: #8057f2;
  display: grid;
  place-items: center;
  border-radius: 15px;
  font-size: 13.3pt;
  color: #e3e4e4;
  font-weight: 570;
  margin: 0.5vh 0 3vh 0;

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
  background-color: #35373A;
  border-radius: 4px;
}

.checkbox-container input:checked ~ .checkmark {
  background-color: #35373A;
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
  border-color: #8a2be2; /* фиолетовая галочка */
}

</style>
<script setup>
</script>
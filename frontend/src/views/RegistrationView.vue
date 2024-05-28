<template>
    <div class="registration" >
        <div class="registration_inner" >
        <h2>Регистрация</h2>
        <span  class="line-translation" ></span>
        <div class="registration_content" >
            <div class="registration_item" >
                <h3 class="item_title" >Имя пользователя</h3>
                <input type="text"  v-model="inputLogin"  placeholder="Введите имя пользователя" class="item_input" >
                <p class="item_error" :class="{ 'visible': inputLogin.length < 3 }">Имя пользователя должно содержать минимум 3 символа</p>

            </div>
            <div class="registration_item" >
                <h3 class="item_title" >Логин</h3>
                <input type="text"  placeholder="Введите Логин" class="item_input" >
                <p class="item_error" >Введите действительный Логин</p>
            </div>
            <div class="registration_item" >
                <h3 class="item_title" >Пароль</h3>
                <input type="text" placeholder="Введите пароль" class="item_input" >
                <p class="item_error" ></p>
            </div>
        </div>
        <span class="line-translation" ></span>
        <button>Зарегистрироваться</button>
        <p class="have-account" >  У вас уже есть аккаунт? <span class="have-account-link" >Войти</span></p>
    </div>
        </div>

</template>
<script>
import { ref } from 'vue'

export default {
  setup() {
    const inputLogin = ref('')
    return { inputLogin }
  }
}
</script>
<style scoped  lang="scss"  >

.registration {
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    background: #232627;
}

h2 { 

text-align: center;
font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 35px;
line-height: 42px;

color: #E3E4E4;

}
.line-translation {
    /* Line 3 */
    display: block;
width: 100%;
height: 1px;
border: 1px solid #35373A;
/* background: #35373A */
;
}
.item_title {


font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 25px;
line-height: 30px;
margin: 20px 0;

color: #E3E4E4;
}

.item_input {
    /* Rectangle 11 */

box-sizing: border-box;


background: #35373A;
border: 1px solid #45484C;
border-radius: 13px;
padding: 5px;
width: 100%;
height: 60px;
}


.item_error  {
font-family: 'Inter';
font-style: normal;
font-weight: 300;
font-size: 20px;
line-height: 24px;
color: #A2411E;
transition: 0.2s;
opacity: 0;
}

.item_input:focus + .item_error{
    opacity: 0 !important;
}

.item_error.visible {
    opacity: 1;
}
button {

width: 100%;
height: 70px;
background: #8057F2;
border: 1px solid #45484C;
border-radius: 20px;
padding: 5px;
/* Frame 29 */

/* Зарегистрироваться */



font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 27px;
line-height: 33px;

color: #E3E4E4;

cursor: pointer;
transition: 0.2s;
margin: 5% 0 0 0;
}
button:hover {
    background: #6d3fee;
}
.have-account {
text-align: center;

font-family: 'Inter';
font-style: normal;
font-weight: 300;
font-size: 20px;
line-height: 24px;

color: #828282;


}
.have-account-link {


font-family: 'Inter';
font-style: normal;
font-weight: 300;
font-size: 20px;
line-height: 24px;

color: #A69AE8;
cursor: pointer;

}

</style>
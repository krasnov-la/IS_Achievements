import { createStore } from 'vuex';

export default createStore({
  state: {
    text: 'Главная страница'
  },
  mutations: {
    setText(state, newText) {
      state.text = newText;
    }
  },
  actions: {
    updateText({ commit }, newText) {
      commit('setText', newText);
    }
  }
});
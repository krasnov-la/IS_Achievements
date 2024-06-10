import { createStore } from 'vuex';

export default createStore({
  state: {
    text: 'Главная страница',
    isAuthenticated: false,
    user: null,
  },
  mutations: {
    setText(state, newText) {
      state.text = newText;
    },
    setAuthentication(state, payload) {
      state.isAuthenticated = payload.isAuthenticated;
      state.user = payload.user;
    }
  },
  actions: {
    updateText({ commit }, newText) {
      commit('setText', newText);
    },
    login({ commit }, user) {
      commit('setAuthentication', { isAuthenticated: true, user: user });
    },
    logout({ commit }) {
      commit('setAuthentication', { isAuthenticated: false, user: null });
    }
  },
  getters: {
    isAuthenticated: (state) => state.isAuthenticated,
    user: (state) => state.user,
  }
});
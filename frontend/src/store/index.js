import { createStore } from 'vuex';
import createPersistedState from 'vuex-plugin-persistedstate'

export default createStore({
  plugins: [createPersistedState()],
  state: {
    activePath: '/',
    text: 'Главная страница',
    authenticated: false,
    user: {
      nickname: "",
      score: "",
      place: "0"
    },
  },
  mutations: {
    SET_ACTIVE_PATH: (state, newPath) => state.activePath = newPath,
    SET_TEXT: (state, newText) => state.text = newText,
    SET_AUTH: (state, auth) => state.authenticated = auth,
    SET_USER: (state, user) => state.user = user,
  },
  actions: {
    updateActivePath: ({commit}, newPath) => commit('SET_ACTIVE_PATH', newPath),
    updateText: ({ commit }, newText) => commit('SET_TEXT', newText),
    setAuth: ({commit}, auth) => commit('SET_AUTH', auth),
    setUser: ({commit}, user) => commit('SET_USER', user),
    },
  getters: {
    activePath: state => state.activePath,
    text: state => state.text,
    isAuthenticated: (state) => state.authenticated,
    user: (state) => state.user,
  }
});
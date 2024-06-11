import { createStore } from 'vuex';
import createPersistedState from 'vuex-plugin-persistedstate'

export default createStore({
  plugins: [createPersistedState()],
  state: {
    text: 'Главная страница',
    authenticated: false,
    user: null,
  },
  mutations: {
    SET_TEXT: (state, newText) => state.text = newText,
    SET_AUTH: (state, auth) => state.authenticated = auth,
    SET_USER: (state, user) => state.user = user,
  },
  actions: {
    updateText: ({ commit }, newText) => commit('SET_TEXT', newText),
    setAuth: ({commit}, auth) => commit('SET_AUTH', auth),
    setUser: ({commit}, user) => commit('SET_USER', user),
    },
  getters: {
    isAuthenticated: (state) => state.authenticated,
    user: (state) => state.user,
  }
});
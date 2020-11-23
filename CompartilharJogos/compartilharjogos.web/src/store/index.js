import Vue from 'vue'
import Vuex from 'vuex'

import {
  state as stateAutenticacaoStore,
  mutations as mutationsAutenticacaoStore,
  actions as actionsAutenticacaoStore
} from './AutenticacaoStore'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    ...stateAutenticacaoStore,
  },
  mutations: {
    ...mutationsAutenticacaoStore,
  },
  actions: {
    ...actionsAutenticacaoStore,
  },
  modules: {
  }
})

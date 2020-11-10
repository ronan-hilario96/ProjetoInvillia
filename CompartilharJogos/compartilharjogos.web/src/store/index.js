import Vue from 'vue'
import Vuex from 'vuex'

import {
  state as stateAutenticacaoStore,
  mutations as mutationsAutenticacaoStore,
  actions as actionsAutenticacaoStore
} from './AutenticacaoStore'


import {
  state as stateAmigo,
  mutations as mutationsAmigo,
  actions as actionsAmigo
} from './Amigo'

import {
  state as stateJogo,
  mutations as mutationsJogo,
  actions as actionsJogo
} from './Jogo'


import {
  state as stateCompartilharJogo,
  mutations as mutationsCompartilharJogo,
  actions as actionsCompartilharJogo
} from './CompartilharJogo'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    ...stateAutenticacaoStore,
    ...stateCompartilharJogo,
    ...stateAmigo,
    ...stateJogo
  },
  mutations: {
    ...mutationsAutenticacaoStore,
    ...mutationsCompartilharJogo,
    ...mutationsAmigo,
    ...mutationsJogo
  },
  actions: {
    ...actionsAutenticacaoStore,
    ...actionsCompartilharJogo,
    ...actionsAmigo,
    ...actionsJogo
  },
  modules: {
  }
})

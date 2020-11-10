import axios from "axios";

export const state = {
    JogosCompartilhados: null,
    ErroRequisicaoCompartilharJogos: null
}

export const mutations = {
    setJogosCompartilhados(state, dado) {
        state.JogosCompartilhados = dado
    },

    setErroRequisicaoCompartilharJogos(state, erro) {
        state.ErroRequisicaoCompartilharJogos = erro
    },
}

export const actions = {
    async Compartilhar({ commit }, dados) {
        try {
            await axios.post('/compartilharjogo', dados)
        } catch (e) {
            commit("setErroRequisicaoCompartilharJogos", e)
            console.error(e)
        }
    },
    async JogosCompartilhados({ commit }) {
        try {
            const resposta = await axios.get('/compartilharjogo')
            commit("setJogosCompartilhados", resposta)
        } catch (e) {
            console.error(e)
            commit("setErroRequisicaoCompartilharJogos", e)
        }
    }
}
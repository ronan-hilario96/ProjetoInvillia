import axios from "axios";

export const state = {
    Amigos: null,
    ErroRequisicaoAmigos: null
}

export const mutations = {
    setAmigos(state, dado) {
        state.Amigos = dado
    },

    setErroRequisicaoAmigos(state, erro) {
        state.ErroRequisicaoAmigos = erro
    },
}

export const actions = {
    async CadastrarAmigo({ commit }, dados) {
        try {
            await axios.post('/Amigos', dados)
        } catch (e) {
            commit("setErroRequisicaoAmigos", e)
            console.error(e)
        }
    },
    async ListaAmigos({ commit }) {
        try {
            const resposta = await axios.get('/Amigos')
            commit("setAmigos", resposta)
        } catch (e) {
            console.error(e)
            commit("setErroRequisicaoAmigos", e)
        }
    }
}
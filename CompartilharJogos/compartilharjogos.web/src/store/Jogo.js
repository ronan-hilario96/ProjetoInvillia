import axios from "axios";

export const state = {
    Jogos: null,
    ErroRequisicaoJogo: null
}

export const mutations = {
    setJogos(state, dado) {
        state.Jogos =  dado
    },

    setErroRequisicaoJogo(state, erro) {
        state.ErroRequisicaoJogo = erro
    },
}

export const actions = {
    async CadastrarJogo({commit}, dados) {
        try {
            await axios.post('/jogo', dados) 
        } catch (e) {
            commit("setErroRequisicaoJogo", e)
            console.error(e)
        }
    },
    async Jogos({commit}) {
        try {
            const resposta = await axios.get('/jogo')
            commit("setJogos", resposta)
        } catch (e) {
            console.error(e)
            commit("setErroRequisicaoJogo", e)
        }
    }
}
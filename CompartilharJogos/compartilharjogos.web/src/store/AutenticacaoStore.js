export const state = {
    autenticacao: null,
}

export const mutations = {
    setAutenticacao(state, tolken) {
        state.autenticacao = tolken
    },
}

export const actions = {
    async Autenticar({ commit }, data) {
        try {
            commit("setAutenticacao", data)
        } catch (e) {
            console.error(e)
        }
    },
}
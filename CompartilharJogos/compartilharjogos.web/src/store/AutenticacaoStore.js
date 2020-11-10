import axios from "axios";

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
            axios.defaults.baseURL = `${process.env.VUE_APP_BASE_URL}`;
            // axios.defaults.headers['Content-Type'] = 'application/json';

            const resposta = await axios.get("/user/login", data)

            axios.defaults.headers.common['Authorization'] = resposta;

            commit("setAutenticacao", resposta)
        } catch (e) {
            console.error(e)
        }
    },
    async Cadastrar({ commit }, data)
    {
        try {
            axios.defaults.baseURL = `${process.env.VUE_APP_BASE_URL}`;
            // axios.defaults.headers['Content-Type'] = 'application/json';

            const resposta = await axios.get("/user/login", data)

            axios.defaults.headers.common['Authorization'] = resposta;

            commit("setAutenticacao", resposta)
        } catch (e) {
            console.error(e)
        }
    }
}
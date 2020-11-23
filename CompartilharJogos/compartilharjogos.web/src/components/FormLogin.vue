<template>
  <v-form v-model="validar">
    <v-container>
      <v-row>
        <v-col cols="12" md="12">
          <v-text-field v-model="login" label="Login" required />
        </v-col>

        <v-col cols="12" md="12">
          <v-text-field
            v-model="senha"
            :append-icon="exibirsenha ? 'mdi-eye' : 'mdi-eye-off'"
            :type="exibirsenha ? 'text' : 'password'"
            name="input-10-1"
            label="Senha"
            @click:append="exibirsenha = !exibirsenha"
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="6">
          <v-btn elevation="2" @click="entrar">Login</v-btn>
        </v-col>

        <v-col cols="12" md="6">
          <v-btn elevation="2" @click="cadastro">Criar conta</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
</template>

<script>
import { mapState } from "vuex";
import vue from "vue";

export default {
  name: "FormLogin",
  data: () => ({
    login: null,
    senha: null,
    validar: false,
    exibirsenha: false
  }),
  computed: {
    ...mapState(["autenticacao"]),
  },
  methods: {
    entrar: async function() {
      if(this.validar){
        try {
          const response = await vue.axios.get(`user/login?username=${this.login}&password=${this.senha}`)

          localStorage.setItem('user',JSON.stringify(response.data.user))
          localStorage.setItem('jwt',response.data.token)

          vue.axios.defaults.headers.common['Authorization'] = `Bearer ${response.data.token}`

          const dataLogin = {
            jwt: response.data.token, 
            user: JSON.stringify(response.data.user)
          }

          this.$store.commit("setAutenticacao", dataLogin)
          this.$router.push("/");
        } catch(e) {
          console.error(e)
        }
      }
    },
    cadastro() {
      this.$router.push("/cadastrar_usuario");
    },
  },
};
</script>

<style>
</style>
<template>
  <v-form v-model="validar">
    <v-alert
      border="top"
      :color="setColor"
      dark
      v-if="erro"
    >
      {{erro}}
    </v-alert>

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
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="6">
            <v-btn elevation="2" @click="cadastrar" >Cadastrar</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
</template>

<script>
import { mapState } from "vuex"
import vue from "vue"

export default {
  name: "FormCadastroUsuario",
  data: () => ({
    login: null,
    senha: null,
    validar: false,
    exibirsenha: false,
    erro: null,
    color: ["green lighten-2", "red lighten-2"],
    setColor: "green lighten-2"
  }),
  computed: {
    ...mapState(["autenticacao"]),
  },
  watch: {
    autenticacao: function(val) {
      this.teste = val
    }
  },
  methods: {
    cadastrar: async function(){
      if(this.validar)
      {
        const body = {
          Username: this.login,
          Password: this.senha,
          Role: "User"
        }
        try{
          await vue.axios.post("user/create-account", body);
          this.setColor = this.color[1]

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
          this.setColor = this.color[0]
          this.erro = "Não foi posivel cadastrar"
          console.warn(e)
        }
        setTimeout(() => {this.erro = null}, 1000)
      }
    }
  }
};
</script>

<style>
</style>
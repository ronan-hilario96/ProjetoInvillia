<template>
  <div id="app">
    <v-app id="inspire">
      <v-navigation-drawer v-model="drawer" app v-if="login">
        <v-list nav dense>
          <v-list-item-group active-class="deep-purple--text text--accent-4">
            <v-list-item @click="sair">
              <v-list-item-icon>
                <v-icon>fas fa-sign-out-alt</v-icon>
              </v-list-item-icon>

              <v-list-item-content>
                <v-list-item-title>Sair</v-list-item-title>
              </v-list-item-content>
              
            </v-list-item>
          </v-list-item-group>
        </v-list>
      </v-navigation-drawer>

      <v-app-bar app>
        <v-app-bar-nav-icon @click="drawer = !drawer" v-if="login"></v-app-bar-nav-icon>

        <v-toolbar-title>Emprestimo de Jogos</v-toolbar-title>
      </v-app-bar>

      <v-main>
        <router-view />
      </v-main>
    </v-app>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  data: () => ({
    drawer: null,
    login: false,
  }),
  computed: {
    ...mapState(["autenticacao"])
  },
  watch: {
    autenticacao(val) {
      this.login = Boolean(val)
    },
  },
  methods: {
    sair() {
      localStorage.clear()
      this.$store.commit("setAutenticacao", null)
      this.$router.push("/login")
    },
  },
  beforeMount() {
    const dataSend = {
      user: localStorage.getItem('user'),
      jwt: localStorage.getItem('jwt')
    }
    if(dataSend.jwt)
      this.$store.commit("setAutenticacao", dataSend)
  }
};
</script>


<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>

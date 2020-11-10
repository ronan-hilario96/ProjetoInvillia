<template>
  <v-form v-model="validar">
    <v-alert border="top" :color="setColor" dark v-if="erro">
      {{ erro }}
    </v-alert>

    <v-container>
      <v-row>
        <v-col cols="12" md="12">
          <v-text-field v-model="gameName" label="Login" required />
        </v-col>

        <v-col cols="12" md="6">
          <v-btn elevation="2" @click="cadastrar">Cadastrar</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
</template>

<script>
import vue from "vue";
export default {
  name: "FormGame",
  data: () => ({
    gameName: null,
    validar: false,
    erro: null,
    color: ["green lighten-2", "red lighten-2"],
    setColor: "green lighten-2",
  }),
  computed: {},
  methods: {
    cadastrar: async function () {
      if (this.validar) {
        const body = {
          Name: this.gameName,
        };
        try {
          await vue.axios.post("game/", body);
          this.setColor = this.color[1];
          this.$router.push("/");
        } catch (e) {
          this.setColor = this.color[0];
          this.erro = "Não foi posivel cadastrar";
          console.warn(e);
        }
        setTimeout(() => {
          this.erro = null;
        }, 1000);
      }
    },
  },
};
</script>

<style>
</style>
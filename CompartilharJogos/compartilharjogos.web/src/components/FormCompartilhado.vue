<template>
  <v-form v-model="validar">
    <v-container>
      <v-row>
        <v-col cols="12" md="12">
          <v-text-field v-model="jogo" label="Jogo a ser compartilhado" required />
        </v-col>
        
        <v-col cols="12" md="12">
          <v-text-field v-model="amigo" label="Amigo que esta com o jogo" required />
        </v-col>

        <v-col cols="12" md="6">
          <v-btn elevation="2" @click="cadastrar">Compartilhado</v-btn>
        </v-col>
        
      </v-row>
    </v-container>
  </v-form>
</template>


<script>
export default {
    name: "FormLogin",
  data: () => ({
    jogo: null,
    amigo: null
  }),
  computed: {
  },
  methods: {
    cadastrar: async function() {
      await this.$store.dispatch("compartilhar");
    },
  },
}
</script>

<style>

</style>
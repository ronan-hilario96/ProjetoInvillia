<template>
  <v-form v-model="validar">
    <v-container>
      <v-row>        
        <v-col cols="12" md="12">
          <v-text-field v-model="amigo" label="Nome do amigo" required />
        </v-col>

        <v-col cols="12" md="6">
          <v-btn elevation="2" @click="cadastrar">Adicioanr amigo</v-btn>
        </v-col>
        
      </v-row>
    </v-container>
  </v-form>
</template>


<script>
export default {
    name: "FormLogin",
  data: () => ({
    amigo: null
  }),
  computed: {
  },
  methods: {
    cadastrar: async function() {
      await this.$store.dispatch("CadastrarAmigo", {amigo: this.amigo});
    },
  },
}
</script>

<style>

</style>
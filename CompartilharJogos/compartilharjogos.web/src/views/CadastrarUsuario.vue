<template>
  <v-card elevation="2" outlined class="mx-auto" max-width="344">
      <v-card-title>
          Novo usuário
      </v-card-title>
      <v-card-subtitle>
        <FormCadastroUsuario/>
      </v-card-subtitle>
  </v-card>
</template>

<script>
import FormCadastroUsuario from "@/components/FormCadastroUsuario";

export default {
  name: "CadastrarUsuario",
  components: {
    FormCadastroUsuario,
  },
  computed: {
  }
};
</script>

<style>
</style>
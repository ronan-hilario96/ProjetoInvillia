<template>
  <v-card elevation="2" outlined class="mx-auto" max-width="344">
      <v-card-title>
          Login
      </v-card-title>
      <v-card-subtitle>
        <FormLogin/>
      </v-card-subtitle>
  </v-card>
</template>

<script>
import FormLogin from "@/components/FormLogin";
import { mapState } from "vuex";

export default {
  name: "Login",
  components: {
    FormLogin,
  },
  computed: {
      ...mapState(["autenticacao"])
  }
};
</script>

<style>
</style>
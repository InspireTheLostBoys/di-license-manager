<template>
<v-container>
    <v-card
    class="mx-auto"
    max-width="500"
    elevation="5"
    outlined
  >
    <v-list-item three-line>
      <v-list-item-content>
        <v-list-item-title class="headline mb-1">
          Do you want to add a license?
        </v-list-item-title>
      </v-list-item-content>
    </v-list-item>

    <v-card-actions>
      <v-btn
        outlined
        rounded
        text
        @click="addLicense"
      >
        Yes
      </v-btn>

      <v-btn
        outlined
        rounded
        text
        @click="goToHomePage"
      >
        No
      </v-btn>
    </v-card-actions>
  </v-card>
</v-container>
</template>

<script>
export default {
  data: () => ({

  }),
  methods: {
    addLicense(){
      let self = this;
      self.$router.push('/license');
    },

    goToHomePage(){
      alert("homePage");
    }
  }
}
</script>
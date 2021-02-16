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
          select or create site
        </v-list-item-title>
      </v-list-item-content>
    </v-list-item>

    <v-card-actions>
      <v-btn
        outlined
        rounded
        text
        @click="$router.push('/site-select')"
      >
        Select
      </v-btn>

      <v-btn
        outlined
        rounded
        text
        @click="$router.push('/site/add')"
      >
        Create
      </v-btn>
    </v-card-actions>
  </v-card>
</v-container>
</template>

<script>
export default {
  data: () => ({

  })
  
}
</script>
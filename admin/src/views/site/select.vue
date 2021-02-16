<template>
    <v-container>
        <h2>Select site: </h2>
        <v-list>
            <v-list-item v-for="site in lw.crud_site.list" :key="site.id" @click="lw.setSite(site)">
                <v-list-item-content>{{ site.siteName }}</v-list-item-content>
            </v-list-item>
        </v-list>
    </v-container>
</template>

<script>
export default {
  data() {
    return {
      lw: this.license_wizard(),
    };
  }
};
</script>
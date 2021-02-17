<template>
    <v-container>
        <h1>INDEX PAGE</h1>
        <v-btn @click="goTo" color="success"> Add license</v-btn>
    </v-container>
</template>

<script>
export default {
    data: () => ({

    }),
    methods: {
        goTo(){
            let self = this;
            self.$router.push('/new-or-existing-customer');
        }
    }
}
</script>

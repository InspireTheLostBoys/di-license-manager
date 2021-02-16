<template>
    <v-container>
        <h2>Select product: </h2>
        <small>*selects product*</small>
        <v-row class="mt-10"></v-row>
        <v-btn text @click="afterSelect">Next</v-btn>
        <v-btn text @click="back">Cancel</v-btn>

    </v-container>
</template>

<script>
export default {
    data: () => ({
        select: null
    }),

    methods: {
        afterSelect(){
            let self = this;
            self.$router.push('/add-product');
        },

        back(){
            let self = this;
            self.$router.push('/add-product')
        }
    }
}
</script>
<template>
<v-container>
    <v-form @submit.prevent="crudManager.update">
        <v-text-field
            label="First Name"
            v-model="crudManager.formObj.firstName"
        ></v-text-field>
        <v-text-field
            label="Last Name"
            v-model="crudManager.formObj.lastName"
        ></v-text-field>
        <v-text-field
            label="Email Address"
            v-model="crudManager.formObj.emailAddress"
        ></v-text-field>
        <v-text-field
            label="Password"
            v-model="crudManager.formObj.password"
        ></v-text-field>
        <v-btn type="submit" color="success">Submit</v-btn>
    </v-form>
</v-container>
</template>

<script>
import { AdminUserCrud } from '../../libs/adminUser'

export default {
    data() {
        return {
            crudManager: new AdminUserCrud(this)
        }
    }
}
</script>
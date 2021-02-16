<template>

</template>

<script>
import { ProductCrud } from "../../libs/product";

export default {
  data() {
    return {
      crudManager: this.license_wizard().crud_product
    };
  },
};
</script>
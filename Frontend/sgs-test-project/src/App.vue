<template>
  <div id="app">
    <FormComponent />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import FormComponent from "./components/FormComponent.vue";

export default defineComponent({
  components: {
    FormComponent,
  },
});
</script>

<style></style>

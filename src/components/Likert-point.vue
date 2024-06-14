<script setup lang="ts">
const model = defineModel<number>()

</script>

<template>
  <v-radio-group v-model="model">
    <v-radio label="Strongly disagree" :value="1" />
    <v-radio label="Somewhat disagree" :value="2" />
    <v-radio label="Neither agree nor disagree" :value="3" />
    <v-radio label="Somewhat agree" :value="4" />
    <v-radio label="Strongly agree" :value="5" />
  </v-radio-group>
</template>

<style scoped lang="stylus">

</style>
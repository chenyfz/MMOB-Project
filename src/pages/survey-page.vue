<script setup lang="ts">
import {ref} from 'vue'

const preferred = ref('')
const reason = ref('')
const generalComment = ref('')

const onFinish = () => {

}
</script>

<template>
  <div class="survey-page">
    <p class="question">Please rank each version based on which you preferred</p>
    <v-radio-group v-model="preferred">
      <v-radio label="Control" value="Control" />
      <v-radio label="Balance bar" value="Balance bar" />
      <v-radio label="Power bars" value="Power bars" />
    </v-radio-group>

    <p class="question">Please explain why you ranked them this way</p>
    <v-textarea
      v-model="reason"
      row-height="25"
      rows="4"
      variant="outlined"
      auto-grow
      shaped
    />

    <p class="question">If you have any general comments please write them below.</p>
    <v-textarea
      v-model="generalComment"
      row-height="25"
      rows="4"
      variant="outlined"
      auto-grow
      shaped
    />

    <v-btn
      variant="flat"
      color="primary"
      block
      class="text-none mt-4 mb-2"
      @click="onFinish"
    >
      Finish
    </v-btn>
  </div>
</template>

<style scoped lang="stylus">
.survey-page
  margin: 24px 12px 32px
.question
  font-size 15px
  font-weight bold
  margin-top 12px
  margin-bottom 4px
</style>
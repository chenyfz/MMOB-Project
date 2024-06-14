<script setup lang="ts">
import {ref} from 'vue'
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'

const age = ref('')
const gender = ref('')
const generalMobileGames = ref(0)
const mobile2D = ref(0)
const mobileTilt = ref(0)

const isInteger = (str: string) => {
  return /^\d+$/.test(str)
}

const rules = {
  required: (value: string) => !!value || 'This field is required',
  isInteger: (value: string) => isInteger(value) || 'This field should be an integer'
}

const onSubmit = () => {
  stageStore.stage = Stage.GUIDE
}
</script>

<template>
  <div class="pre-survey-page">
    <h3>Survey</h3>

    <p class="question">What is your age?</p>
    <v-text-field
      v-model="age"
      variant="outlined"
      density="compact"
      type="input"
      :rules="[rules.required, rules.isInteger]"
      required
    />

    <p class="question">What is your gender?</p>
    <v-radio-group v-model="gender">
      <v-radio label="Male" value="male" />
      <v-radio label="Female" value="female" />
      <v-radio label="Non-binary / third gender" value="non-binary" />
      <v-radio label="Prefer not to say" value="unknown" />
    </v-radio-group>

    <p class="question">How would you rate your experience in the following concepts (1 being no experience and 100 being an expert)?</p>
    <p>General mobile games: {{ generalMobileGames }}</p>
    <v-slider
      v-model="generalMobileGames"
      thumb-label
      :max="100"
      :min="0"
      :step="1"
    />
    <p>Mobile 2D platformer games: {{ mobile2D }}</p>
    <v-slider
      v-model="mobile2D"
      thumb-label
      :max="100"
      :min="0"
      :step="1"
    />
    <p>Mobile tilt control: {{ mobileTilt }}</p>
    <v-slider
      v-model="mobileTilt"
      thumb-label
      :max="100"
      :min="0"
      :step="1"
    />
    <v-btn
      variant="flat"
      color="primary"
      block
      class="text-none mt-4 mb-2"
      @click="onSubmit"
    >
      Submit
    </v-btn>
  </div>
</template>

<style scoped lang="stylus">
.pre-survey-page
  margin: 24px 12px 32px

p
  font-size 15px

.question
  font-size 17px
  font-weight bold
  margin-top 12px
  margin-bottom 4px
</style>
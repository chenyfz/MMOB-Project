<script setup lang="ts">
import {computed, ref} from 'vue'
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'
import {participantData} from '../store/data-store.ts'
import {writeParticipantData} from '../api'

const preferred = ref<string[]>([])
const reason = ref('')
const generalComment = ref('')

const isComplete = computed(() => {
  return preferred.value.length === 3 &&
      reason.value !== '' &&
      generalComment.value !== ''
})

let loading = false
const onFinish = async () => {
  if (loading) return
  loading = true
  try {
    if (!participantData.value.questionnaire) {
      participantData.value.questionnaire = [] as unknown as [{ questionId: string, questionAnswer: string | number | number[] }]
    }
    participantData.value.questionnaire.push({
      questionId: 'preferred',
      questionAnswer: preferred.value
    })
    participantData.value.questionnaire.push({
      questionId: 'reason',
      questionAnswer: reason.value
    })
    participantData.value.questionnaire.push({
      questionId: 'generalComment',
      questionAnswer: generalComment.value
    })
    const resp = await writeParticipantData(participantData.value)
    localStorage.setItem('mmob-participant-info', JSON.stringify(resp))
    participantData.value = resp
    loading = false
    stageStore.stage = Stage.THANKS
  } catch (e) {
    console.error(e)
    loading = false
  }
}
</script>

<template>
  <div class="survey-page">
    <p class="question">Please rank each version based on which you preferred, first being the most preferred.</p>

    <v-combobox
      v-model="preferred"
      :items="['Power bars (one the character)', 'Control', 'Balance bar (at the top of screen)']"
      multiple
    />

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
      :disabled="!isComplete"
      @click="onFinish"
    >
      Finish
    </v-btn>
    <p v-if="!isComplete" class="error-msg">Please complete all fields.</p>
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
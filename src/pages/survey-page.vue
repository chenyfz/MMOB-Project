<script setup lang="ts">
import {ref} from 'vue'
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'
import {participantData} from '../store/data-store.ts'
import {writeParticipantData} from '../api'

const preferred = ref('')
const reason = ref('')
const generalComment = ref('')

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
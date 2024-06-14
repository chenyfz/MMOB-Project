<script setup lang="ts">
import IntroPage from './pages/intro-page.vue'
import {Stage} from './types/stage-type.ts'
import {stageStore} from './store/stage-store.ts'
import GamePage from './pages/game-page.vue'
import SurveyPage from './pages/survey-page.vue'
import GuidePage from './pages/guide-page.vue'
import PreSurveyPage from './pages/pre-survey-page.vue'
import {participantData} from './store/data-store.ts'
import MidSurvey from './pages/mid-survey.vue'
import {setGameVersionOrder} from './store/game-version-store.ts'

const data = localStorage.getItem('mmob-participant-info')
if (data) {
  participantData.value = JSON.parse(data)
  const order = participantData.value.gameVersionOrder
  if (order) setGameVersionOrder(order)
}
</script>

<template>
  <intro-page v-if="stageStore.stage === Stage.INTRO" />
  <pre-survey-page v-if="stageStore.stage === Stage.PRE_SURVEY" />
  <guide-page v-if="stageStore.stage === Stage.GUIDE" />
  <game-page v-else-if="stageStore.stage === Stage.GAME" />
  <mid-survey v-else-if="stageStore.stage === Stage.MID_SURVEY" />
  <survey-page v-else-if="stageStore.stage === Stage.SURVEY" />
</template>

<style scoped lang="stylus">
</style>

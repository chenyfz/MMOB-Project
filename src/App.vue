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
import ThanksPage from './pages/thanks-page.vue'

const data = localStorage.getItem('mmob-participant-info')
if (data) {
  try {
    participantData.value = JSON.parse(data)
    const order = participantData.value.gameVersionOrder
    if (order) setGameVersionOrder(order)
  } catch (e) {
    console.error(e)
  }
}

const isMobile = window.innerWidth < 600
</script>

<template>
  <template v-if="isMobile">
    <intro-page v-if="stageStore.stage === Stage.INTRO" />
    <pre-survey-page v-if="stageStore.stage === Stage.PRE_SURVEY" />
    <guide-page v-if="stageStore.stage === Stage.GUIDE" />
    <game-page v-else-if="stageStore.stage === Stage.GAME" />
    <mid-survey v-else-if="stageStore.stage === Stage.MID_SURVEY" />
    <survey-page v-else-if="stageStore.stage === Stage.SURVEY" />
    <thanks-page v-else-if="stageStore.stage === Stage.THANKS" />
  </template>
  <div v-else class="QR-container">
    <div>
      <img src="/QR.svg">
      <p>Please open this on a mobile device.</p>
    </div>
  </div>
</template>

<style scoped lang="stylus">
.QR-container
  display flex
  align-items center
  justify-content center
  height 100vh
  > div
    text-align center

  img
    width: 300px

  p
    margin-top 8px
</style>

<script setup lang="ts">
import IntroPage from './pages/intro-page.vue'
import {Stage} from './types/stage-type.ts'
import {stageStore} from './store/stage-store.ts'
import GamePage from './pages/game-page.vue'
import SurveyPage from './pages/survey-page.vue'

</script>

<template>
  <intro-page v-if="stageStore.stage === Stage.INTRO" />
  <game-page v-else-if="stageStore.stage === Stage.GAME" />
  <survey-page v-else-if="stageStore.stage === Stage.SURVEY" />
</template>

<style scoped lang="stylus">
</style>

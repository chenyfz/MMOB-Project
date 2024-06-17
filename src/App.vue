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
import {
  gameVersion,
  gameVersionOrder,
  isTheLastGameVersion,
  setGameVersionOrder,
  setToNextGameVersion
} from './store/game-version-store.ts'
import ThanksPage from './pages/thanks-page.vue'
import {GameVersion} from './types/game-version.ts'
import {getDeviceMotionPermission} from './pages/device-motion-permission'

const data = localStorage.getItem('mmob-participant-info')
if (data) {
  try {
    participantData.value = JSON.parse(data)
    const order = participantData.value.gameVersionOrder
    if (order) setGameVersionOrder(order)

    // region test
    const finalIndex = participantData.value?.questionnaire?.findIndex(item => item.questionId === 'generalComment') ?? -1

    let haveInGameData = false
    if (finalIndex !== -1) {
      stageStore.stage = Stage.THANKS
    } else {
      const reversedGameVersion = [...gameVersionOrder.value].reverse()
      for (const version of reversedGameVersion) {
        const versionIndex = participantData.value?.questionnaire?.findIndex(item => item.questionId === version + 'AdditionalComment') ?? -1
        if (versionIndex !== -1) {
          gameVersion.value = version as GameVersion
          if (isTheLastGameVersion()) {
            stageStore.stage = Stage.SURVEY
          } else {
            setToNextGameVersion()
            stageStore.stage = Stage.GAME
          }
          haveInGameData = true
          getDeviceMotionPermission()
          break
        }
        const performanceIndex = participantData.value?.gamePerformanceData?.findIndex(item => item.version === version) ?? -1
        if (performanceIndex !== -1) {
          stageStore.stage = Stage.MID_SURVEY
          gameVersion.value = version as GameVersion
          haveInGameData = true
          getDeviceMotionPermission()
          break
        }
      }
      if (!haveInGameData) {
        const preIndex = participantData.value?.questionnaire?.findIndex(item => item.questionId === 'age') ?? -1
        if (preIndex !== -1) {
          stageStore.stage = Stage.GAME
          getDeviceMotionPermission()
        }
      }
    }
    // endregion test

  } catch (e) {
    console.error(e)
    localStorage.removeItem('mmob-participant-info')
  }

}

const isMobile = window.innerWidth < 600

// const onClear = () => {
//   localStorage.removeItem('mmob-participant-info')
// }
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
<!--  <v-btn class="test-button" color="error" @click="onClear">test: clear local storage</v-btn>-->
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
.test-button
  position fixed
  right 4px
  bottom 4px
</style>

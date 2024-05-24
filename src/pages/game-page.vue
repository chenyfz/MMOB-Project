<script setup lang="ts">
import UnityCanvas from '../components/unity-canvas.vue'
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'

const toSurveyPage = () => stageStore.stage = Stage.SURVEY
</script>

<template>
  <div class="game-page">
    <unity-canvas />
    <button
      class="test-button"
      @click="toSurveyPage"
    >
      test button, to survey page
    </button>
  </div>
</template>

<style scoped lang="stylus">
.game-page
  position relative
  display flex
  align-items center
  justify-content center
  min-height 100vh

.test-button
  position absolute
  bottom 12px
  right 8px
</style>
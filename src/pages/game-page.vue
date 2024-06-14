<script setup lang="ts">
import UnityCanvas from '../components/unity-canvas.vue'
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'
import {GameVersion} from '../types/game-version.ts'
import {ref} from 'vue'
import {gameVersion, setGameVersion} from '../store/game-version-store.ts'

const toSurveyPage = () => stageStore.stage = Stage.SURVEY

// todo delete for test
let gameVersionIndex = 0
const gameVersionOrder = ref([GameVersion.A, GameVersion.B, GameVersion.C])

setGameVersion(gameVersionOrder.value[gameVersionIndex])

const toNextGameVersion = () => {
  gameVersionIndex = (gameVersionIndex + 1) % gameVersionOrder.value.length
  setGameVersion(gameVersionOrder.value[gameVersionIndex])
}
</script>

<template>
  <div class="game-page">
    <unity-canvas :key="gameVersion" />
    <button
      class="test-button right"
      @click="toSurveyPage"
    >
      test: to survey page
    </button>
    <button
      class="test-button left"
      @click="toNextGameVersion"
    >
      test: next game version
    </button>
  </div>
</template>

<style scoped lang="stylus">
.game-page
  position relative
  display flex
  align-items center
  justify-content center
  background black

.test-button
  position absolute
  top 12px

.left
  left 8px

.right
  right 8px
</style>
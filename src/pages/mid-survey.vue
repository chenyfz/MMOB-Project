<script setup lang="ts">
import {isTheLastGameVersion, setToNextGameVersion} from '../store/game-version-store.ts'
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'

const onNext = () => {
  // todo submit form
  setToNextGameVersion()

  if (isTheLastGameVersion()) {
    stageStore.stage = Stage.SURVEY
  } else {
    stageStore.stage = Stage.GAME
  }
}
</script>

<template>
  <div>Survey between games</div>
  <v-btn
    variant="flat"
    color="primary"
    block
    class="text-none mt-4 mb-2"
    @click="onNext"
  >
    Start Next Version
  </v-btn>
</template>

<style scoped lang="stylus">

</style>
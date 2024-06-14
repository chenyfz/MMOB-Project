<script setup lang="ts">
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'
import {getDeviceMotionPermission} from './device-motion-permission'
import GuideText from '../components/guide-text.vue'
import {participantData} from '../store/data-store.ts'

const onStart = async () => {
  const action = () => stageStore.stage = Stage.GAME
  if (await getDeviceMotionPermission()) {
    action()
  } else {
    console.error('no device orientation permission')
  }
}
</script>

<template>
  <div class="guide-page">
    <guide-text />
    <v-btn
      variant="flat"
      color="primary"
      block
      class="text-none mt-4 mb-2"
      @click="onStart"
    >
      Start
    </v-btn>
  </div>
</template>

<style scoped lang="stylus">
.guide-page
  margin: 24px 12px 32px
</style>
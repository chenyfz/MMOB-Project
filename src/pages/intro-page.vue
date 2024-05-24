<script setup lang="ts">
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'

const toGameStage = () => stageStore.stage = Stage.GAME
</script>

<template>
  <div>introduction page</div>
  <button @click="toGameStage">continue</button>
</template>

<style scoped>

</style>
<script setup lang="ts">
import UnityCanvas from '../components/unity-canvas.vue'
import {gameVersion, gameVersionOrder} from '../store/game-version-store.ts'

const onCheat = () => {
  window.jsbridge.reportData(JSON.stringify({
    Deaths: 2,
    PlayTimeSecondsStr: '2.3333'
  }))
}

</script>

<template>
  <div class="game-page">
    <unity-canvas :key="gameVersion" />
    <v-btn
      class="test-button right"
      @click="onCheat"
    >
      test: Hack to pass!
    </v-btn>
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
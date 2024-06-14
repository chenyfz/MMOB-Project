<script setup lang="ts">
import UnityWebgl from 'unity-webgl'
import VueUnity from 'unity-webgl/vue'

import loaderUrl from '/unity-webgl/Build/unity-webgl.loader.js?url'
import dataUrl from '/unity-webgl/Build/unity-webgl.data?url'
import frameworkUrl from '/unity-webgl/Build/unity-webgl.framework.js?url'
import codeUrl from '/unity-webgl/Build/unity-webgl.wasm?url'
import {ref} from 'vue'

const unityContext = new UnityWebgl({
  loaderUrl,
  dataUrl,
  frameworkUrl,
  codeUrl,
  productVersion: '1.0'
})

const canvasWidth = ref(window.innerWidth)
const canvasHeight = canvasWidth.value / 9 * 16
</script>

<template>
  <vue-unity
    class="unity-canvas"
    :unity="unityContext"
    :width="canvasWidth"
    :height="canvasHeight"
  />
</template>

<style scoped lang="stylus">
.unity-canvas
  max-width 600px
  max-height 1067px
</style>
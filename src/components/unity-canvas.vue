<script setup lang="ts">
import UnityWebgl from 'unity-webgl'
import VueUnity from 'unity-webgl/vue'

import loaderUrl from '/unity-webgl/Build/unity-webgl.loader.js?url'
import dataUrl from '/unity-webgl/Build/unity-webgl.data?url'
import frameworkUrl from '/unity-webgl/Build/unity-webgl.framework.js?url'
import codeUrl from '/unity-webgl/Build/unity-webgl.wasm?url'

const unityContext = new UnityWebgl({
  loaderUrl,
  dataUrl,
  frameworkUrl,
  codeUrl,
  productVersion: '1.0'
})

const getCanvasSize = () => {
  const wWidth = window.innerWidth
  const wHeight = window.innerHeight

  return wWidth < (wHeight / 16 * 9) ? {
    width: wWidth,
    height: wWidth / 9 * 16
  } : {
    width: wHeight / 16 * 9,
    height: wHeight
  }
}

const {width, height} = getCanvasSize()
</script>

<template>
  <vue-unity
    class="unity-canvas"
    :unity="unityContext"
    :width="width"
    :height="height"
  />
</template>

<style scoped lang="stylus">
</style>
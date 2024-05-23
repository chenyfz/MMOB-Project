<script setup>
import UnityWebgl from 'unity-webgl'
import VueUnity from 'unity-webgl/vue'

import loaderUrl from '/unity-webgl/Build/unity-webgl.loader.js?url'
import dataUrl from '/unity-webgl/Build/unity-webgl.data.br?url'
import frameworkUrl from '/unity-webgl/Build/unity-webgl.framework.js.br?url'
import codeUrl from '/unity-webgl/Build/unity-webgl.wasm.br?url'

const unityContext = new UnityWebgl({
  loaderUrl,
  dataUrl,
  frameworkUrl,
  codeUrl,
  productVersion: '1.0'
})
</script>

<template>
  <vue-unity :unity="unityContext" width="400" height="750" />
</template>

<style scoped>

</style>
<script setup>
import UnityWebgl from 'unity-webgl'
import VueUnity from 'unity-webgl/vue'

const unityContext = new UnityWebgl({
  loaderUrl: '/unity-webgl/Build/unity-webgl.loader.js',
  dataUrl: '/unity-webgl/Build/unity-webgl.data.br',
  frameworkUrl: '/unity-webgl/Build/unity-webgl.framework.js.br',
  codeUrl: '/unity-webgl/Build/unity-webgl.wasm.br',
})
</script>

<template>
  <vue-unity :unity="unityContext" width="400" height="750" />
</template>

<style scoped>

</style>
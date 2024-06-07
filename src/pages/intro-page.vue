<script setup lang="ts">
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'
import {writeParticipantData} from '../api'
import {ref} from 'vue'
import {ParticipantData} from '../types/participant-data.ts'
import {getDeviceMotionPermission} from './device-motion-permission'

const resp = ref<Partial<ParticipantData>>({})

const onSubmitForm = async () => {
  const action = () => stageStore.stage = Stage.GAME
  if (await getDeviceMotionPermission()) {
    action()
  } else {
    console.error('no device orientation permission')
  }
}

const onTestServer = async () => {
  resp.value = await writeParticipantData({
    name: 'test from web'
  })
}
</script>

<template>
  <p>{{ resp }}</p>
  <h3>👋Hi, Thanks for join our study!</h3>
  <p>First, we would need your consent for this study: this study is about ...</p>
  <p>
    For any questions, please contact
    <a href="mailto:y.chen40@students.uu.nl">y.chen40@students.uu.nl</a>
  </p>

  <label for="name-input">How should we call you?</label>
  <input id="name-input" type="text">

  <br>
  <br>

  <input id="consent-checkbox" type="checkbox">
  <label for="consent-checkbox">I agree to be part of this study.</label>

  <br>
  <br>

  <button @click="onSubmitForm">continue</button>

  <br>
  <br>

  <button @click="onTestServer">test server</button>
</template>

<style scoped>

</style>
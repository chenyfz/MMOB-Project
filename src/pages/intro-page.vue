<script setup lang="ts">
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'
import {writeParticipantData} from '../api'
import {ref} from 'vue'
import {ParticipantData} from '../types/participant-data.ts'

const resp = ref<Partial<ParticipantData>>({})

const onSubmitForm = () => {
  stageStore.stage = Stage.GAME
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

  <input id="consent-checkbox" type="checkbox">
  <label for="consent-checkbox">I agree to be part of this study.</label>
  
  <button @click="onSubmitForm">continue</button>
  <button @click="onTestServer">test server</button>
</template>

<style scoped>

</style>
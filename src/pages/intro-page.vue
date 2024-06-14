<script setup lang="ts">
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'
import {writeParticipantData} from '../api'
import {ref} from 'vue'
import {ParticipantData} from '../types/participant-data.ts'
import ConsentText from '../components/consent-text.vue'

const resp = ref<Partial<ParticipantData>>({})

const onGiveConsent = async () => {
  stageStore.stage = Stage.PRE_SURVEY
}

const onTestServer = async () => {
  resp.value = await writeParticipantData({
    name: 'test from web'
  })
}
</script>

<template>
  <div class="intro-page">
    <consent-text />
    <v-btn
      variant="flat"
      color="primary"
      block
      class="text-none mt-4 mb-2"
      @click="onGiveConsent"
    >
      Give consent
    </v-btn>
    <v-btn
      variant="flat"
      color="grey-lighten-3"
      block
      class="text-none"
      @click="onTestServer"
    >
      Quit
    </v-btn>
  </div>
</template>

<style scoped lang="stylus">
.intro-page
  margin 24px 12px 32px
</style>
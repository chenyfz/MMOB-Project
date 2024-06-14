<script setup lang="ts">
import {isTheLastGameVersion, setToNextGameVersion} from '../store/game-version-store.ts'
import {stageStore} from '../store/stage-store.ts'
import {Stage} from '../types/stage-type.ts'
import LikertPoint from '../components/Likert-point.vue'
import {ref} from 'vue'

const onNext = () => {
  // todo submit form
  setToNextGameVersion()

  if (isTheLastGameVersion()) {
    stageStore.stage = Stage.SURVEY
  } else {
    stageStore.stage = Stage.GAME
  }
}

const likertList = ref(new Array(15).fill(0))
const questionList = [
  'I was in suspense about whether I would win or lose the game.',
  'I sometimes found myself to become so involved with the game that I wanted to speak to the game directly.',
  'I enjoyed the graphics and imagery of the game.',
  'I enjoyed playing the game.',
  'The controls were hard to pick up.',
  'There were not any particularly frustrating aspects of the controls to get the hang of.',
  'I became unaware that I was even using any controls.',
  'I could clearly see the effect of my tilt inputs.',
  'I did not feel as if I was moving through the game according to my own will.',
  'I was aware of my real world surroundings.',
  'I felt detached from the outside world.',
  'At the time the game was my only concern.',
  'Everyday thoughts and concerns were still very much on my mind.',
  'I did not feel the urge at any point to stop playing and see what was going on around me.',
  'I still felt as if I was in the real world whilst playing.'
]

const immersion = ref(0)
const playstyleImpact = ref('')
const additional_comment = ref('')
</script>

<template>
  <div class="mid-survey-page">
    <h3>For the game version you just played, please rate how far you would agree with the statements below</h3>

    <template v-for="(item, index) in questionList" :key="item">
      <p class="question">{{ item }}</p>
      <likert-point v-model="likertList[index]" />
    </template>


    <p class="question">How immersed did you feel?</p>
    <p>(0=not at all immersed; 10=very immersed)</p>
    <v-slider
      v-model="immersion"
      thumb-label
      :max="10"
      :min="0"
      :step="1"
    />

    <p class="question">Did the additional visualisation or the lack thereof impact your playstyle? Please explain if the impact was positive or negative and why.</p>
    <v-textarea
      v-model="playstyleImpact"
      row-height="25"
      rows="4"
      variant="outlined"
      auto-grow
      shaped
    />

    <p class="question">Additional comments about this version of the game?</p>
    <v-textarea
      v-model="additional_comment"
      row-height="25"
      rows="4"
      variant="outlined"
      auto-grow
      shaped
    />

    <v-btn
      variant="flat"
      color="primary"
      block
      class="text-none mt-4 mb-2"
      @click="onNext"
    >
      Start Next Version
    </v-btn>
  </div>
</template>

<style scoped lang="stylus">
.mid-survey-page
  margin: 24px 12px 32px
.question
  font-size 15px
  font-weight bold
  margin-top 12px
  margin-bottom 4px
</style>
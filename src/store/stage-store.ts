import {reactive} from 'vue'
import {Stage} from '../types/stage-type.ts'

export const stageStore = reactive({
    stage: Stage.INTRO
})
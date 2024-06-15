import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import {gameVersion} from './store/game-version-store.ts'

// Vuetify
import 'vuetify/styles'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import { createVuetify } from 'vuetify'
import {participantData} from './store/data-store.ts'
import {stageStore} from './store/stage-store.ts'
import {Stage} from './types/stage-type.ts'
import {writeParticipantData} from './api'

const vuetify = createVuetify({
    components,
    directives,
})

createApp(App).use(vuetify).mount('#app')

declare global {
    interface Window {
        jsbridge: {
            getGameVersion: () => void
            reportData: (jsonStr: string) => void
        };
    }
}

window.jsbridge = {
    getGameVersion: () => {
        console.log('invoke getGameVersion', gameVersion.value)
        return gameVersion.value
    },
    reportData: (jsonStr: string) => {
        const dataItem = {
            version: gameVersion.value,
            dataJSON: jsonStr
        }
        if (!participantData.value.gamePerformanceData) {
            participantData.value.gamePerformanceData = [dataItem]
        } else {
            const index = participantData.value.gamePerformanceData.findIndex(item => item.version === gameVersion.value)
            if (index !== -1) {
                participantData.value.gamePerformanceData[index] = dataItem
            } else {
                participantData.value.gamePerformanceData.push(dataItem)
            }
        }
        setTimeout(() => {
            stageStore.stage = Stage.MID_SURVEY
        }, 300)

        writeParticipantData(participantData.value)
    }
}
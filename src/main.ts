import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import {gameVersion} from './store/game-version-store.ts'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

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
        console.log(JSON.parse(jsonStr))
    }
}
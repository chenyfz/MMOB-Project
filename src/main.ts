import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import {gameVersion} from './store/game-version-store.ts'

createApp(App).mount('#app')

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
import { createApp } from 'vue'
import './style.css'
import App from './App.vue'

createApp(App).mount('#app')

declare global {
    interface Window {
        jsbridge: {
            test: () => void,
            getGameVersion: () => void
            reportData: (jsonStr: string) => void
        };
    }
}

window.jsbridge = {
    test: () => {
        console.log('success')
    },
    // todo for test
    getGameVersion: () => {
        return 'control'
    },
    reportData: (jsonStr: string) => {
        console.log(JSON.parse(jsonStr))
    }
}
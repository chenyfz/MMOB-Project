import {ref} from 'vue'
import {GameVersion} from '../types/game-version.ts'

export const gameVersion = ref(GameVersion.UNKNOWN)

export const setGameVersion = (version: GameVersion) => {
    gameVersion.value = version
}
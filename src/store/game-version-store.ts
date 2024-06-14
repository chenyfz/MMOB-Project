import {ref} from 'vue'
import {GameVersion} from '../types/game-version.ts'

export const gameVersion = ref(GameVersion.UNKNOWN)
export const gameVersionOrder = ref<GameVersion[]>([])

export const setGameVersion = (version: GameVersion) => {
    gameVersion.value = version
}

// orderCode looks like "ABC"
export const setGameVersionOrder = (orderCode: string) => {
    gameVersionOrder.value = orderCode.split('').map(item => {
        switch (item) {
            case 'A':
                return GameVersion.A
            case 'B':
                return GameVersion.B
            default:
                return GameVersion.C
        }
    })
    if (gameVersion.value === GameVersion.UNKNOWN) {
        gameVersion.value = gameVersionOrder.value[0]
    }
}

export const isTheLastGameVersion = () => {
    return gameVersion.value === gameVersionOrder.value[gameVersionOrder.value.length - 1]
}

export const setToNextGameVersion = () => {
    if (isTheLastGameVersion()) return

    const index = gameVersionOrder.value.indexOf(gameVersion.value)
    gameVersion.value = gameVersionOrder.value[index + 1]
}
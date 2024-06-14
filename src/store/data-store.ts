import {ref} from 'vue'
import {ParticipantData} from '../types/participant-data.ts'

export const participantData = ref<Partial<ParticipantData>>({})

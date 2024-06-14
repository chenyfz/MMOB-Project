export type ParticipantData = {
    ParticipantId: string,
    gameVersionOrder: string,

    gamePerformanceData: [{
        version: string,
        dataJSON: string,
    }]

    questionnaire: [{
        questionId: string,
        questionAnswer: number | string,
    }]
}
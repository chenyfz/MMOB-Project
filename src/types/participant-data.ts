export type ParticipantData = {
    name: string,
    ParticipantId: string,
    gameVersionOrder: string,

    gamePerformanceData: [{
        version: string,
        dataJSON: string,
    }]

    questionnaire: [{
        questionId: string,
        questionAnswer: string,
    }]
}
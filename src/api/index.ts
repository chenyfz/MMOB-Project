import {ParticipantData} from '../types/participant-data.ts'

export async function writeParticipantData (data: Partial<ParticipantData>) {
    const response = await fetch('https://7xhcvwccrm2pfw4ku72tz4lr5i0zqojt.lambda-url.eu-central-1.on.aws/', {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json',
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer',
            body: JSON.stringify({ data })
        })
    return response.json() // parses JSON response into native JavaScript objects
}

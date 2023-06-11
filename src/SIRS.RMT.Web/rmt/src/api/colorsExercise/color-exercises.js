import api from "../api";

export async function getAvailableLevels() {
    return (await api.get('api/bo/exercises/levels')).data
}

export async function getDiagnosticExerciseColors() {
    return (await api.get('api/bo/exercises/diagnostic')).data
}

export async function getTrainingExerciseColors(count) {
    return (await api.get('/api/bo/exercises/training/' + count)).data
}

export async function userAnswer(user_answer) {
    return (await api.post('/api/bo/exercises/user-answer', user_answer)).data
}
import api from "../api";


export async function userAnswers(answer) {
    return (await  api.post('api/bo/word/sendAnswer', answer)).data;
}

export async function getWords(count) {
    return (await api.get('api/bo/word/' + count)).data;
}

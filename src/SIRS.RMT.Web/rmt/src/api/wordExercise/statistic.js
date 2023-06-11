// WordsExercise
import api from "../api";

export async function sendStatistic(obj) {
    return (await api.post("/api/bo/statistics/words/save-result", obj)).status;
}

export async function getWordStatistic() {
    return (await api.get("/api/bo/statistics/words/get-statistic")).data;
}
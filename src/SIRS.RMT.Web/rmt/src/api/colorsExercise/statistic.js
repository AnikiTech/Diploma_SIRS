// ColorsExercise
import api from "../api";

export async function sendStatistic(obj) {
    return (await api.post("/api/bo/statistics/save-result", obj)).status;
}

export async function getColorStatistic() {
    return (await api.get("/api/bo/statistics/colors/get-statistic")).data;
}
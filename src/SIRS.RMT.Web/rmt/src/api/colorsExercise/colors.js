import api from "../api";

export async function getAvailableColors() {
    return (await api.get('api/bo/colors/available')).data
}
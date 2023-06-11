import { api } from "../../utils/apiUtils";

export default {
    state: {
        token: localStorage.getItem('access_token') || null,
        userId: null // Новое свойство для хранения id пользователя
    },
    getters: {
        isAuth: state => !!state.token,
    },
    mutations: {
        retrieveToken(state, token) {
            state.token = token;
        },
        destroyToken(state) {
            state.token = null;
        },
        setUserId(state, userId) {
            state.userId = userId;
        }
    },
    actions: {
        retrieveToken(context, credential) {
            return new Promise((resolve, reject) => {
                api(credential.username, credential.password).then(response => {
                    if (!response) {
                        throw new Error('Неправильный логин или пароль')
                    }

                    const userId = response.userId; // Получение id пользователя из ответа сервера
                    console.log("Current user id: " + userId);
                    localStorage.setItem("access_token", response);
                    context.commit('retrieveToken', response);
                    context.commit('setUserId', userId); // Сохранение id пользователя в состоянии приложения

                    resolve(response);

                }).catch(error => {
                    localStorage.removeItem("access_token");
                    reject(error)
                })
            })
        },
        destroyToken(context) {
            return new Promise((resolve) => {
                context.commit('destroyToken')
                context.commit('setUserId', null); // Удаление id пользователя из состояния приложения
                localStorage.removeItem("access_token")
                resolve()
            })
        }
    }

}
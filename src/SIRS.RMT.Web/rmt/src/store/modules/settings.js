export default {
    state: {
        applicationSettings: {
            usingNightTheme: false,
            primaryColor: { color_name: "Blue", color: '#03a9f4'},
        }
    },
    getters: {
        isUsedLightTheme(state) {
            return state.applicationSettings.usingNightTheme
        },
        getPrimaryColor(state) {
            return state.applicationSettings.primaryColor
        }
    },
    mutations: {
        changeUsedTheme(state, on) {
            state.applicationSettings.usingNightTheme = on
        },
        changePrimaryColor(state, color) {
            state.applicationSettings.primaryColor = color
        }
    },
    actions: {
        changeUsedTheme({commit}, credential) {
            commit("changeUsedTheme", credential.on)
        },
        changePrimaryColor({commit}, color) {
            commit('changePrimaryColor', color)
        }
    }
}
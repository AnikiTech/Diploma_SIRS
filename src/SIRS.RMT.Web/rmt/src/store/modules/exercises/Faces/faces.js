export default {
    state: {
        ArrayForImg: {},
    },

    getters: {
        getArrayForImg: state => state.ArrayForImg,
    },

    mutations: {
        getArrayForImg(state, img) {
            state.ArrayForImg = img;
        },
    },

    actions: {
        getArrayForImg({commit}, img) {
            commit('getArrayForImg', img);
        },
    }
}
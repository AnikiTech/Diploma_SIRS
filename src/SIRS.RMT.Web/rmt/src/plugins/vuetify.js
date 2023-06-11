import Vue from 'vue';
import Vuetify from 'vuetify/lib';
import "@mdi/font/css/materialdesignicons.min.css"
import ru from "vuetify/lib/locale/ru";
Vue.use(Vuetify);

export default new Vuetify({
    lang: {
        locales: { ru },
        current: 'ru',
    },
    icons: {
        iconfont: 'mdi'
    },
    theme: {
        themes: {
            light: {
                primary: '#ff3347',
                secondary: '#3f51b5',
                accent: '#018786',
                error: '#f44336',
                like_color: '#ff3347'
            },
            dark: {
                primary: '#ff3347',
                secondary: '#3f51b5',
                accent: '#018786',
                error: '#f44336',
                vk_color: '#ff3347'
            }
        },
    }
});

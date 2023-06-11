<template>
  <Home />
</template>

<script>
import Home from "./views/Home";

export default {
  name: 'App',

  mounted: function () {
    // Подгружаем настройки приложения
    this.loadSettings();
  },

  methods: {
    loadSettings: function () {
      let color = this.$store.getters.getPrimaryColor;

      this.$root.$vuetify.theme.dark = this.$store.getters.isUsedLightTheme;

      this.$root.$vuetify.theme.themes.light.primary = color.color;
      this.$root.$vuetify.theme.themes.dark.primary = color.color;
    }
  },
  components: {
    Home
  }
};
</script>
<template>
  <v-app id="sandbox">
    <v-navigation-drawer
        app
        v-model="primaryDrawer.model"
        :temporary="primaryDrawer.type"
        disable-resize-watcher
    >
      <v-list dense rounded>
        <v-list-item v-for="item in items" :key="item.title" :to="item.path" link>
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
      <v-divider></v-divider>

      <template v-slot:append>
        <v-list dense rounded>
          <v-list-item to="/about" link>
            <v-list-item-icon>
              <v-icon>mdi-information-outline</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title>О приложении</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </template>
    </v-navigation-drawer>
    <v-toolbar color="" flat>
      <v-app-bar-nav-icon @click.stop="primaryDrawer.model = !primaryDrawer.model"/>
      <div class="svg-wrapper" title="Система Интенсивного Развития Способностей">
        <svg preserveAspectRatio="xMidYMid meet" data-bbox="547.84 190.1 8931.65 2929.08" viewBox="0 0 10065.8 3301" height="20mm" width="150" xmlns="http://www.w3.org/2000/svg" shape-rendering="geometricPrecision" text-rendering="geometricPrecision" image-rendering="optimizeQuality" fill-rule="evenodd" clip-rule="evenodd" data-type="ugc" role="img">
          <g>
            <path fill="none" d="M1857.82 190.1l654.99 366.14 655 366.13v1464.54l-655 366.13-654.99 366.14-654.98-366.14-655-366.13V922.37l655-366.13 654.98-366.14z"></path>
            <path fill="none" d="M547.84 2386.9L1857.82 190.1"></path>
            <path fill="none" d="M3167.81 2386.9L1857.82 190.1"></path>
            <path fill="none" d="M3167.81 922.38L547.84 2386.9"></path>
            <path fill="none" d="M547.84 922.38L3167.81 2386.9"></path>
            <path fill="none" d="M1857.82 3119.18V1654.64"></path>
            <path fill="none" d="M547.84 2386.9h2619.97"></path>
            <path fill="#3cecd6" d="M2512.81 1288.51l655 1098.39V922.38l-655 366.13z"></path>
            <path fill="#00a0e3" d="M2512.81 1288.51l655-366.13-655-366.14-654.99-366.14 654.99 1098.41z"></path>
            <path fill="#00a0e3" d="M1202.83 1288.51L1857.82 190.1l-654.98 366.14-655 366.14 654.99 366.13z"></path>
            <path fill="#00a0e3" d="M1857.82 190.1l-654.99 1098.41 654.99 366.13 654.99-366.13L1857.82 190.1z"></path>
            <path fill="#003399" d="M2512.81 1288.51L1857.82 190.1l-654.99 1098.41 654.99 366.13 654.99-366.13z"></path>
            <path fill="#f6ee6b" d="M1202.83 1288.51L547.84 922.38V2386.9l654.99-1098.39z"></path>
            <path fill="#fff000" d="M1202.83 1288.51L547.84 2386.9l1309.98-732.26-654.99-366.13z"></path>
            <path fill="#ffba00" d="M1857.82 1654.64L547.84 2386.9h1309.98v-732.26z"></path>
            <path fill="#ffd734" d="M1857.82 2386.9H547.84l655 366.14 654.98 366.14V2386.9z"></path>
            <path fill="#09f387" d="M1857.82 2386.9v732.28l654.99-366.14 655-366.14H1857.82z"></path>
            <path fill="#175147" d="M1857.82 2386.9h1309.99l-1309.99-732.26v732.26z"></path>
            <path fill="#175a69" d="M1857.82 1654.64l1309.99 732.26-655-1098.39-654.99 366.13z"></path>
            <path d="M4981.83 1129.85l-118.85 91.23c-65.36-85.29-144.01-149.96-235.94-194-91.58-44.04-192.25-66.07-302.36-66.07-119.89 0-231.05 29.02-333.47 86.7-102.42 57.67-181.42 135.27-237.69 232.44-56.28 97.18-84.59 206.94-84.59 328.23 0 183.87 62.92 337.31 188.75 460 125.84 123.05 284.53 184.57 476.44 184.57 210.77 0 386.95-82.5 528.86-247.48l118.85 90.18c-75.15 95.43-168.83 169.54-281.03 221.61-112.21 52.09-237.7 78.3-376.12 78.3-263.56 0-471.54-87.73-623.6-263.21-127.59-147.85-191.55-326.82-191.55-536.2 0-220.22 77.25-405.83 231.75-556.14 154.85-150.65 348.5-225.81 581.3-225.81 140.52 0 267.41 27.62 380.66 82.85 113.26 55.58 206.24 133.18 278.59 232.8zm1489.09 1227.96h-157.3v-1157l-993.77 1157h-33.9V851.96h151v1174.13L6437.01 851.96h33.91v1505.85zm364.23-1505.85h300.26c171.98 0 288.38 7.34 348.5 22.37 85.99 21.32 156.25 64.66 210.79 130.73 54.87 65.72 82.14 148.56 82.14 248.18 0 100.32-26.57 182.81-80.05 248.18-53.13 65.01-126.53 108.71-219.87 131.43-68.51 16.43-196.09 24.47-383.11 24.47h-107.66v700.49h-151V851.96zm151 146.81v511.74l255.17 3.14c103.12 0 178.62-9.44 226.51-28.31 47.89-18.88 85.65-48.94 112.91-90.88 27.26-41.95 40.89-89.14 40.89-140.88 0-50.33-13.63-96.81-40.89-138.77-27.26-41.94-63.62-71.65-108.37-89.47-44.73-17.83-117.79-26.57-219.86-26.57h-266.36zm2493.34 131.08l-118.85 91.23c-65.36-85.29-144.01-149.96-235.94-194-91.58-44.04-192.25-66.07-302.36-66.07-119.89 0-231.05 29.02-333.47 86.7-102.42 57.67-181.42 135.27-237.69 232.44-56.28 97.18-84.59 206.94-84.59 328.23 0 183.87 62.92 337.31 188.75 460 125.84 123.05 284.53 184.57 476.43 184.57 210.78 0 386.96-82.5 528.87-247.48l118.85 90.18c-75.15 95.43-168.83 169.54-281.03 221.61-112.21 52.09-237.7 78.3-376.12 78.3-263.56 0-471.54-87.73-623.6-263.21-127.59-147.85-191.55-326.82-191.55-536.2 0-220.22 77.25-405.83 231.75-556.14 154.85-150.65 348.5-225.81 581.3-225.81 140.52 0 267.41 27.62 380.66 82.85 113.25 55.58 206.24 133.18 278.59 232.8z"
                  fill="gray"></path>
          </g>
        </svg>
        <strong style="font-size: 30px" class="primary--text">.Мнемоническая память</strong>
      </div>
      <v-spacer/>

      <v-tooltip bottom>
        <template v-slot:activator="{ on }">
          <v-switch v-model="$vuetify.theme.dark" hide-details v-on="on"/>
        </template>

        <span v-if="$vuetify.theme.dark">Использовать светлую тему</span>
        <span v-else>Использовать темную тему</span>
      </v-tooltip>

      <v-menu bottom origin="center center" transition="slide-x-reverse-transition">
        <template v-slot:activator="{ on }">
          <v-btn icon v-on="on">
            <v-icon>mdi-account-circle-outline</v-icon>
          </v-btn>
        </template>
        <v-list dense rounded>
          <v-list-item @click="logout" color="like_color">
            <v-list-item-icon>
              <v-icon color="like_color">mdi-exit-to-app</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title class="like_color--text">Выйти из аккаунта</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-toolbar>
    <v-divider/>
    <v-content>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-content>
    <v-footer app></v-footer>
  </v-app>
</template>

<script>

export default {
  data: () => ({
    primaryDrawer: {
      model: null,
      type: 'temporary',
    },
    items: [
      { title: 'Главная', icon: 'mdi-home-outline', path: "/" },
      { title: 'Настройки', icon: 'mdi-animation-outline', path: "/settings"}
    ],
  }),
  methods: {
    logout: function () {
      this.$store.dispatch("destroyToken").then(() => {
        this.$router.push({name: "Login"})
      })
    },
  }
}
</script>

<style scoped>
.svg-wrapper
{
  display: flex;
  align-items: center;
}

.toolbar-title{
  align-items: center;
  font-size: xx-large;
}
</style>
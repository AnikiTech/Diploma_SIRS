<template>
  <v-app id="sandbox">
    <v-navigation-drawer
            v-if="isAuth"
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
    <v-toolbar flat>
      <v-app-bar-nav-icon v-if="isAuth" @click.stop="primaryDrawer.model = !primaryDrawer.model"/>
      <v-toolbar-title>СИРС. Быстрое чтение, память, мышление</v-toolbar-title>
      <v-spacer/>

      <v-tooltip bottom>
        <template v-slot:activator="{ on }">
          <v-switch v-model="$vuetify.theme.dark" hide-details v-on="on"/>
        </template>

        <span v-if="$vuetify.theme.dark">Использовать светлую тему</span>
        <span v-else>Использовать темную тему</span>
      </v-tooltip>

      <v-menu v-bind:disabled="!isAuth" bottom origin="center center" transition="slide-x-reverse-transition">
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
  import {mapGetters} from "vuex";

  export default {
    data: () => ({
      primaryDrawer: {
        model: null,
        type: 'temporary',
      },
      items: [
        { title: 'Главная', icon: 'mdi-home-outline', path: "/home" },
        { title: 'Упражнения', icon: 'mdi-bookmark-outline', path: "/exercises"},
        { title: 'Настройки', icon: 'mdi-animation-outline', path: "/settings"}
      ],
    }),
    computed: {
      ...mapGetters(['isAuth'])
    },
    methods: {
      logout: function () {
        this.$store.dispatch("destroyToken").then(() => {
          this.$router.push({name: "Login"})
        })
      },
    }
  }
</script>
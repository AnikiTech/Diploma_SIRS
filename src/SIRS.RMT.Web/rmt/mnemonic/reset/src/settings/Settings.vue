<template>
    <v-app>
        <v-container grid-list-md text-xs-center>
            <v-layout>
                <v-flex>
                    <v-card outlined>
                        <v-card-title> Настройки </v-card-title>
                    </v-card>
                </v-flex>
            </v-layout>
            <v-layout>
                <v-flex>
                    <v-card outlined>
                        <v-card-title primary-title>Основное</v-card-title>
                        <v-card-subtitle>Настройки всего приложения</v-card-subtitle>
                        <v-divider/>
                        <v-list dense>
                            <v-subheader>Внешний вид и оформление</v-subheader>
                            <v-list-item>
                                <v-list-item-icon>
                                    <v-icon>mdi-palette-outline</v-icon>
                                </v-list-item-icon>
                                <v-list-item-content>
                                    <v-list-item-title>Темная тема</v-list-item-title>
                                    <v-list-item-subtitle>Использовать темную тему по-умолчанию</v-list-item-subtitle>
                                </v-list-item-content>
                                <v-list-item-action>
                                    <v-switch
                                            v-model="$vuetify.theme.dark"
                                            @change="changeUsedTheme($event)"
                                            color="primary"
                                    ></v-switch>
                                </v-list-item-action>
                            </v-list-item>
                            <v-divider />
                            <v-list-item>
                                <v-list-item-icon>
                                    <v-icon>mdi-palette-outline</v-icon>
                                </v-list-item-icon>
                                <v-list-item-content>
                                    <v-list-item-title>Основной цвет приложения</v-list-item-title>
                                    <v-list-item-subtitle>Выбрать основной цвет приложения</v-list-item-subtitle>
                                </v-list-item-content>
                                <v-list-item-action>
                                    <v-btn outlined color="primary" @click="showDialog = !showDialog">Выбрать</v-btn>
                                </v-list-item-action>
                            </v-list-item>
                        </v-list>
                    </v-card>
                </v-flex>
            </v-layout>
            <v-layout>
                <v-flex>
                    <v-card outlined disabled>
                        <v-card-title primary-title>Слова</v-card-title>
                        <v-card-subtitle>Настройки комплекса приложения</v-card-subtitle>
                        <v-divider/>
                        <v-list dense>
                            <v-list-item>
                                <v-list-item-content>
                                    <v-list-item-title>Настройки списка слов</v-list-item-title>
                                </v-list-item-content>
                            </v-list-item>
                        </v-list>
                    </v-card>
                </v-flex>
            </v-layout>
            <v-layout>
                <v-flex>
                    <v-card outlined disabled>
                        <v-card-title primary-title>Лица</v-card-title>
                        <v-card-subtitle>Настройки комплекса приложения</v-card-subtitle>
                        <v-divider/>
                        <v-list dense>
                            <v-list-item>
                                <v-list-item-content>
                                    <v-list-item-title>Настройки запоминания лиц</v-list-item-title>
                                </v-list-item-content>
                            </v-list-item>
                        </v-list>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
        <v-dialog v-model="showDialog" persistent max-width="500">
            <v-card outlined>
                <v-card-title>Выбрать цвет</v-card-title>
                <v-card-text>Выберите Primary (основной) цвет приложения</v-card-text>
                <v-card-actions>
                    <v-select
                            color="primary"
                            outlined
                            dense
                            label="Изменить основной цвет"
                            v-model="select"
                            :items="primaryColors"
                            item-value="color"
                            item-text="color_name"
                            persistent-hint
                            return-object
                            single-line
                            @change="changePrimaryColor"
                    />
                </v-card-actions>
                <v-divider></v-divider>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn outlined color="primary" @click="showDialog = false">OK</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
        <v-row justify="center">
        
        <v-btn v-bind="attrs" v-on="on" outlined color="primary" @click="$router.push('/')">Назад</v-btn></v-row>
                
    </v-app>
</template>

<script>

    export default {
        name: "Settings",
        data: () => ({
            showDialog: false,
            select: {},
            primaryColors: [
                { color_name: "Android 10 Green", color: '#3ddc84'},
                { color_name: "Android 10 Blue", color: '#4285f4'},
                { color_name: "Violet", color: '#8e85ee' },
                { color_name: "Blue", color:'#527da3' },
                { color_name: 'Blue Light', color: '#2492d6' },
                { color_name: "Red", color: '#ff0000' },
                { color_name: "Green", color: '#00a60e' },
                { color_name: "Orange", color: '#f28c48' },
                { color_name: "Cyan", color: '#5fbdd5' },
                { color_name: "Gray", color: '#b3bbc1' },
                { color_name: "Yellow", color: '#f2c04b' },
                { color_name: "Gray-Dark", color: '#7ca0c1' },
            ]
        }),
        mounted() {
            this.select = this.$store.getters.getPrimaryColor;
        },
        methods: {
            changeUsedTheme: function (on) {
                this.$root.$vuetify.theme.dark = on;
                this.$store.dispatch('changeUsedTheme', {on: on})
            },

            changePrimaryColor: function (color) {
                this.$root.$vuetify.theme.themes.light.primary = color.color;
                this.$root.$vuetify.theme.themes.dark.primary = color.color;
                this.$store.dispatch('changePrimaryColor', color)
            }
        }
    }
</script>

<style scoped>

</style>
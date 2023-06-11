<template>
    <v-app>
        <v-container fluid>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="5" md="5" lg="5">
                    <form action="#" @submit.prevent="login">
                        <v-card outlined>
                            <v-toolbar dense flat>
                            </v-toolbar>
                            <v-divider />
                            <v-card-text>
                                <v-form>
                                    <v-text-field outlined
                                                  dense
                                                  v-model="username"
                                                  label="Логин" />
                                    <v-text-field outlined
                                                  dense
                                                  :type="showPassword ? 'text' : 'password'"
                                                  v-model="password"
                                                  label="Пароль"
                                                  :append-icon="showPassword ? 'mdi-eye-outline' : 'mdi-eye-off-outline'"
                                                  @click:append="showPassword = !showPassword"
                                                  autocomplete="on" />
                                </v-form>
                            </v-card-text>
                            <v-divider />
                            <v-card-actions>
                                <v-spacer />
                                <v-btn type="submit"
                                       color="primary"
                                       block
                                       outlined
                                       :loading="isLoading"
                                       :disabled="isLoading">Войти в аккаунт </v-btn>
                            </v-card-actions>
                        </v-card>

                        <v-dialog v-model="showDialog" persistent max-width="300">
                            <v-card>
                                <v-card-title>Внимание</v-card-title>
                                <v-card-text>Произошла ошибка при попытке входа</v-card-text>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn text color="primary" @click="showDialog = false">OK</v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </form>
                </v-col>
            </v-row>
        </v-container>
    </v-app>
</template>

<script>
    export default {
        name: "Login",

        data() {
            return {
                username: '',
                password: '',
                showPassword: false,
                isLoading: false,
                showDialog: false
            }
        },

        methods: {
            login() {
                this.isLoading = true;

                this.$store.dispatch('retrieveToken', {
                    username: this.username,
                    password: this.password
                }).then(() => {
                    this.isLoading = false;
                    this.$router.push({ name: 'Home' })
                }).catch(() => {
                    this.isLoading = false;
                    this.showDialog = true;
                })
            }
        }
    }
</script>
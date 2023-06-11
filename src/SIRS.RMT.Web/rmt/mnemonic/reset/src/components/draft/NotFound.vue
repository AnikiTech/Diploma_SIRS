<template><v-app>
    <v-container
            class="text-center"
            fill-height
            style="height: calc(100vh - 58px);"
    ><v-container fluid>
            
        <v-row align="center">
            
            <v-col>
                <h1 class="display-2 primary--text">Ошибка 404</h1>

                <p>Ничего не найдено</p>

                <v-btn
                        :to="'/'"
                        color="primary"
                        outlined
                >
                    Назад
                </v-btn>
            </v-col>
        </v-row>
        </v-container>
    </v-container></v-app>
</template>

<script>
    export default {
        name: 'FourOhFour',
        props: {
        },
        created() {
            /*this.$ssrContext && this.$ssrContext.res.status(404)*/
        }
    }
</script>
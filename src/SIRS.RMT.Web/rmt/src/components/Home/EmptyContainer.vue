<template>
    <v-app>
        <v-container fluid>
            <v-row justify="center" align="center">
                <v-col cols="12" sm="8" md="8" lg="8">
                    <v-timeline>
                        <v-timeline-item>
                            <span slot="opposite">Это начальная страница</span>
                            <v-card class="elevation-8">
                                <v-card-text>
                                    Добро пожаловать
                                </v-card-text>
                            </v-card>
                        </v-timeline-item>
                    </v-timeline>
                </v-col>
            </v-row>
        </v-container>
    </v-app>
</template>

<script>

    export default {
        name: "EmptyContainer",

        data: () => ({
        }),
    }
</script>
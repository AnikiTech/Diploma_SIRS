<template>
    <div>
        <v-card-actions>
            <v-row justify="center" align="center">
                <v-col
                        cols="12" sm="8" md="8" wrap
                        v-for="(book, index) of getExerciseTrainingTexts" :key="index"
                >
                    <v-btn block outlined color="primary" @click="selectText(index)">
                        <v-icon></v-icon>{{book.author}} - {{book.title}}
                    </v-btn>
                </v-col>
            </v-row>
        </v-card-actions>
    </div>
</template>

<script>
    import {mapGetters} from "vuex";

    export default {
        name: "GetTextTraining",

        data: () => ({
            selected: {}
        }),

        computed: {
            ...mapGetters(['getExerciseTrainingTexts'])
        },

        methods: {
            selectText: function (id) {
                this.selected = id;
                this.$store.dispatch('setExerciseTrainingText', id).then(() => {
                    this.$emit('startTrainingReadText')
                })
            },
        }
    }
</script>

<style scoped>

</style>
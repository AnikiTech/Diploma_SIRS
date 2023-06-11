<!--<template>
    <v-treeview
        v-model="tree"
        :open="initiallyOpen"
        :colors="colors"
        activatable
        color-key="name"
        open-on-click>
        <template v-slot:prepend="{ color, open }">
            <v-icon v-if="!color.file">
                {{ open ? 'mdi-folder-open' : 'mdi-folder' }}
            </v-icon>
            <v-icon v-else>
                {{ files[color.file] }}
            </v-icon>
        </template>
    </v-treeview>
              
</template>

<script>S
export default {
    data: () => ({
        items: [
            {name: 'Стилизация',
          children: [
            {name: 'Синий'},
            {name: 'Фиолетовый'},
            {name: 'Красный'}
          ]
        }
      ]
    }),
  }
</script>
-->
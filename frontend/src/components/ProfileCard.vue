<template>
    <div>
        <v-card 
            class="mx-auto"
            max-width="500"
            outlined
        >
            <v-list-item three-line>
            <v-list-item-content>
                <v-list-item-subtitle class="description">
                    Имя
                </v-list-item-subtitle>
                <div>
                {{ Name }}
                </div>
                <v-list-item-subtitle class="description" style="margin-top: 20px;">
                    Фамилия
                </v-list-item-subtitle>
                <v-list-item-title>
                {{ Surname }}
                </v-list-item-title>
                <v-list-item-subtitle class="description" style="margin-top: 20px;">
                    Почта
                </v-list-item-subtitle>
                <v-list-item-title>
                {{ Email }}
                </v-list-item-title>
                <v-list-item-subtitle class="description" style="margin-top: 20px;">
                    Баланс
                </v-list-item-subtitle>
                <div>
                {{ Balance }}
                </div>
            </v-list-item-content>

            <v-list-item-avatar
                tile
                size="200"
                
            >
                <v-img
                    :src="require('@/assets/profile_pictures/pp' + this.PictureNumber + '.jpeg')"
                >
                </v-img>
            </v-list-item-avatar>
            </v-list-item>

            <v-card-actions>
            <v-btn 
                class="description" 
                color="purple"
                outlined
                rounded
                text
            >
                Пополнить баланс
            </v-btn>
            </v-card-actions>
        </v-card>
     </div>
</template>

<script>
  export default {
  props: ['Name', 'Surname', 'Email', 'Balance', 'PictureNumber']
}
</script>
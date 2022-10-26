<template>
  <div>
    <CharacterForm />

    <div>
      <div v-for="c in characters">
        <img :src="c.imgUrl" alt="" height="250">
        <h3>{{ c.name }}</h3>
      </div>
    </div>


  </div>
</template>

<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { charactersService } from '../services/CharactersService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {

    async function getCharacters() {
      try {
        await charactersService.get()
      } catch (error) {
        Pop.error(error)
      }
    }

    onMounted(() => {
      getCharacters()
    })

    return {
      characters: computed(() => AppState.characters)
    }
  }
}
</script>

<style scoped lang="scss">

</style>

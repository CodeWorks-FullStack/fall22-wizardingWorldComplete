<template>
  <form class="col-md-6 card p-3 my-2" @submit.prevent="handleSubmit">
    <h4>Character Creator</h4>
    <input type="text" class="form-control" v-model="editable.name" placeholder="Name">
    <input type="url" class="form-control" v-model="editable.imgUrl" placeholder="http://youknow...">

    <div>
      <label for="age">Age {{editable.age}}</label>
      <input name="age" type="number" min="0" max="1000" class="form-control" v-model="editable.age">
    </div>

    <div>
      <input id="is-alive" type="checkbox" v-model="editable.isAlive">
      <label for="is-alive" class="no-select selectable">Living</label>
    </div>

    <select type="text" class="form-control" v-model="editable.house" placeholder="Name">
      <option :value="h" v-for="h in houses">{{ h }}</option>
    </select>

    <textarea type="text" class="form-control" v-model="editable.description" placeholder="Name"></textarea>

    <div class="my-3">
      <button class="btn btn-primary" type="submit">Add Character</button>
    </div>
  </form>
</template>


<script>
import { ref } from 'vue';
import { charactersService } from '../services/CharactersService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      houses: [
        "Gryffindor",
        "Hufflepuff",
        "Ravenclaw",
        "Slytherin",
        "Unassigned",
        "Muggle"
      ],
      async handleSubmit() {
        try {
          await charactersService.create(editable.value)
          editable.value = {}
        } catch (error) {
          Pop.error(error, '[Creating CharacterForm]')
        }

      }
    }
  }
}
</script>


<style lang="scss" scoped>
input, textarea, select{
  margin-bottom: 1rem
}
</style>

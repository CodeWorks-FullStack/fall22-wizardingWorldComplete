import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js"

class CharactersService {
  async create(characterData) {
    const res = await api.post('api/characters', characterData)
    AppState.characters.push(res.data)
  }

  async get() {
    const res = await api.get('api/characters')
    AppState.characters = res.data
  }


}

export const charactersService = new CharactersService()

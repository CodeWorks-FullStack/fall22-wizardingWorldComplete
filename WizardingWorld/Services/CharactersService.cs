namespace WizardingWorld.Services;

public class CharactersService
{
  private readonly CharactersRepository _charactersRepo;

  public List<Character> GetCharacters()
  {
    // This will get a bit more complicated later....
    return _charactersRepo.Get();
  }

  public List<Character> GetCharactersByAuthorId(string authorId)
  {
    return _charactersRepo.Get(authorId);
  }

  public Character GetCharacter(int id)
  {
    var character = _charactersRepo.Get(id);
    if (character == null)
    {
      throw new Exception("Invalid Id");
    }

    return character;
  }


  public Character AddCharacter(Character characterData)
  {
    // this does get more complex.... tomorrow ☀️ 🌈
    // _db.Characters.Add(characterData);
    return _charactersRepo.Create(characterData);
  }

  // Every single service will follow a similar pattern... which means you could
  // probably use something like inheritance to simplify it....!?!?!?!!?
  public CharactersService(CharactersRepository charactersRepository)
  {
    _charactersRepo = charactersRepository;
  }


}
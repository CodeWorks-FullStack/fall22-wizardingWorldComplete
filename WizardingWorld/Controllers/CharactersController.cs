namespace WizardingWorld.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
  private readonly CharactersService _cs;
  private readonly Auth0Provider _auth0Provider;

  [HttpGet]
  public async Task<ActionResult<List<Character>>> Get()
  {
    try
    {
      var userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      var characters = _cs.GetCharactersByAuthorId(userInfo?.Id);
      return Ok(characters);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Character> GetCharacter(int id)
  {
    try
    {
      var character = _cs.GetCharacter(id);
      return Ok(character);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPost]
  public async Task<ActionResult<Character>> Create([FromBody] Character characterData)
  {
    try
    {
      ///.... how to get the user from the bearer token
      var userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      characterData.AuthorId = userInfo?.Id; // forced this character to belong to YOU!!!

      Character character = _cs.AddCharacter(characterData);
      return Ok(character);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  public CharactersController(CharactersService cs, Auth0Provider auth0Provider)
  {
    _cs = cs;
    _auth0Provider = auth0Provider;
  }

}

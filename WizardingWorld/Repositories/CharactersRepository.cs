namespace WizardingWorld.Repositories;

public class CharactersRepository : BaseRepository
{
  public CharactersRepository(IDbConnection db) : base(db)
  {
  }

  // THIS IS AN EXAMPLE OF METHOD OVERLOADING....

  /// <summary>
  ///   Get all Characters
  /// </summary>
  public List<Character> Get()
  {
    var sql = "SELECT * FROM characters";
    return _db.Query<Character>(sql).ToList();
  }

  /// <summary>
  ///   Get all Characters by <paramref name="authorId"/>
  /// </summary>
  public List<Character> Get(string authorId)
  {
    // NEVER EVER EVER EVER EVER EVER EVER EVER EVER EVER EVER EVER NEVER 
    // use the $ string interpolation on your sql query !!!!!!!!!!!
    var sql = "SELECT * FROM characters WHERE authorId = @authorId";
    return _db.Query<Character>(sql, new { authorId }).ToList();
  }

  /// <summary>
  ///   Get a Character by id
  /// </summary>
  public Character Get(int id)
  {
    var sql = "SELECT * FROM characters WHERE id = @id";
    return _db.QueryFirstOrDefault<Character>(sql, new { id });
  }

  public Character Create(Character characterData)
  {
    var sql = @"
      INSERT INTO characters
        (name, age, description, imgUrl, house, isAlive, authorId)
      VALUES
        (@Name, @Age, @Description, @ImgUrl, @House, @IsAlive, @AuthorId);
      SELECT LAST_INSERT_ID();
    ";

    characterData.Id = _db.ExecuteScalar<int>(sql, characterData);
    return characterData;
  }


}



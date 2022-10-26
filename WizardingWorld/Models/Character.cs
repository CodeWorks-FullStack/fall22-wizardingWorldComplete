using WizardingWorld.Enums;

namespace WizardingWorld.Models;

public class Character
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public int Age { get; set; }
  public bool IsAlive { get; set; }
  public WizardingHouse House { get; set; }
  public string Description { get; set; }
  public string ImgUrl { get; set; }
  public string AuthorId { get; set; }

}



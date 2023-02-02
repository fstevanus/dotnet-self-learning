namespace Learning.Entities.Models;

public class Blog : ModelBase
{
  public string Url { get; set; }
  
  public List<Post> Posts { get; }
}
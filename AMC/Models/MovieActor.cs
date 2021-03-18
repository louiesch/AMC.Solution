namespace AMC.Models
{
  public class MovieActor
  {
    public int MovieActorId { get; set; }
    public int ActorId { get; set; }
    public int MovieId { get; set; }
    public virtual Actor Actor { get; set; } //what
    public virtual Movie Movie { get; set; }
  }
}
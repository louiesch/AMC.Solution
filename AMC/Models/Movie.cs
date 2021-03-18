using System.Collections.Generic;

namespace AMC.Models
{
  public class Movie
  {
    public Movie()
    {
      this.JoinEntities = new HashSet<MovieActor>();
    }

    public int MovieId { get; set; }
    public string MovieName { get; set; }
    public virtual ICollection<MovieActor> JoinEntities { get; set; }
  }
}
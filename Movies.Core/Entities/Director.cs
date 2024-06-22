using Movies.Core.Common;

namespace Movies.Core.Entities;

public class Director : BaseEntity
{
    public string Name { get; set; }
    public IList<Movie> Movies { get; set; }
}
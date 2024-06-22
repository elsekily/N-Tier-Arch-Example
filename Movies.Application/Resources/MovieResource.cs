using Movies.Core.Common;
using Movies.Core.Enums;

namespace Movies.Application.Resources;
public class MovieResource
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public MpaaRating MpaaRating { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
}
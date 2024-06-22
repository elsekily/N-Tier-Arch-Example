using Movies.Core.Common;
using Movies.Core.Enums;

namespace Movies.Core.Entities;

public class Movie : BaseEntity //, IAuditedEntity
{
    public  string Name { get; set; }
    public  DateTime ReleaseDate { get; set; }
    public MpaaRating MpaaRating { get; set; }
    public  string Genre { get; set; }
    public  double Rating { get; set; }
    //public string CreatedBy { get; set; }
    //public DateTime CreatedOn { get; set; }
    //public string UpdatedBy { get; set; }
    //public DateTime? UpdatedOn { get; set; }
}
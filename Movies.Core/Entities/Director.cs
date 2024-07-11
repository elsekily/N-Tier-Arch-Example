using Movies.Core.Common;

namespace Movies.Core.Entities;

public class Director : BaseEntity , IAuditedEntity
{
    public string Name { get; set; }
    public IList<Movie> Movies { get; set; }
    public IUser CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public IUser? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
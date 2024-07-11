namespace Movies.Core.Common;

public interface IAuditedEntity
{
    public IUser CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }

    public IUser? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}

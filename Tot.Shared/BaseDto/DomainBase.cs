using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Tot.Shared.BaseDto;

[Index(nameof(UniqueId), IsUnique = true)]
public abstract class DomainBase
{
    [Key]
    public int Id { get; private set; }
    public Guid UniqueId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public DomainBase(int id, Guid uniqueId ,DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        UniqueId = uniqueId;
    }
    protected DomainBase()
    {
    }
}
public abstract class DomainBaseWithActive : DomainBase
{
    public bool IsActive { get; private set; }

    protected DomainBaseWithActive()
    {
    }
    public DomainBaseWithActive(int id,
                                Guid uniqueId,
                                DateTime createdAt,
                                DateTime updatedAt,
                                bool isActive) : base(id, uniqueId, createdAt, updatedAt)
    {
        IsActive = isActive;
    }
}


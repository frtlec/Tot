using Tot.Shared.BaseDto;

namespace Tot.Domain.Entities.Question;

public class QuestionPoolCategory : DomainBaseWithActive
{
    private readonly List<QuestionPool> _items = new();
    public string Title { get; set; }
    public IReadOnlyCollection<QuestionPool> Items => _items.AsReadOnly();
    public QuestionPoolCategory(int id,
                         Guid uniqueId,
                         string title,
                         DateTime createdAt,
                         DateTime updatedAt,
                         bool isActive) : base(id, uniqueId, createdAt, updatedAt, isActive)
    {
        Title = title;
    }
}

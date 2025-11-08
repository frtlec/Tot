using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Tot.Domain.Enums;
using Tot.Shared.BaseDto;

namespace Tot.Domain.Entities.Question;

public class QuestionPool : DomainBaseWithActive
{
    private readonly List<QuestionPoolItem> _items = new();
    public string Question { get; private set; }
    public int CategoryId { get; private set; }

    public QuestionFormatType QuestionFormatType { get; private set; }
    public QuestionSourceType SourceType { get; private set; }
    public long LikeCount { get; private set; }

    [StringLength(250)]
    public string FriendlyUrl { get; private set; }
    public DateTime? UseLastAt { get; private set; }
    public IReadOnlyCollection<QuestionPoolItem> Items => _items.AsReadOnly();

    public QuestionPoolCategory QuestionPoolCategory { get; private set; }
    public QuestionPool(int id,
                         Guid uniqueId,
                         string question,
                         int likeCount,
                         string friendlyUrl,
                         DateTime? useLastAt,
                         int categoryId,
                         QuestionSourceType sourceType,
                         QuestionFormatType questionFormatType,
                         DateTime createdAt,
                         DateTime updatedAt,
                         bool isActive) : base(id, uniqueId, createdAt, updatedAt, isActive)
    {
        Question = question;
        CategoryId = categoryId;
        SourceType = sourceType;
        LikeCount = likeCount;
        FriendlyUrl = friendlyUrl;
        UseLastAt = useLastAt;
        QuestionFormatType = questionFormatType;
    }

    /// <summary>
    /// For Creation
    /// </summary>
    public QuestionPool(string question,
                     string friendlyUrl,
                     int categoryId,
                     QuestionSourceType sourceType,
                     QuestionFormatType questionFormatType,
                     bool? isActive = null) : base(default, Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow, isActive ?? true)
    {
        Question = question;
        CategoryId = categoryId;
        SourceType = sourceType;
        LikeCount = default;
        FriendlyUrl = friendlyUrl;
        UseLastAt = null;
        QuestionFormatType = questionFormatType;
    }

    private QuestionPool()
    {
    }

    public void AddItem(QuestionPoolItem item) => _items.Add(item);
}
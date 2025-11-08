using System.ComponentModel.DataAnnotations;
using Tot.Domain.Enums;
using Tot.Shared.BaseDto;

namespace Tot.Domain.Entities.Question;

public class QuestionPoolItem : DomainBaseWithActive
{

    public int QuestionPoolId { get; private set; }

    [StringLength(2000)]
    public string? OptionText { get; private set; }
    [StringLength(300)]
    public string? ImageUrl { get; private set; }
    public long VoteCount { get; private set; }

    public short Order { get; private set; }
    public QuestionPoolItem(int id,
                        Guid uniqueId,
                        int questionPoolId,
                        string optionText,
                        string imageUrl,
                        long voteCount,
                        short order,
                        DateTime createdAt,
                        DateTime updatedAt,
                        bool isActive) : base(id, uniqueId, createdAt, updatedAt, isActive)
    {
        QuestionPoolId = questionPoolId;
        OptionText = optionText;
        ImageUrl = imageUrl;
        VoteCount = voteCount;
        Order = order;
    }
    /// <summary>
    /// For Creation
    /// </summary>
    public QuestionPoolItem(int questionPoolId,
                     string optionText,
                     string imageUrl,
                     short order,
                     bool? isActive = null) : base(default, Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow, isActive ?? true)
    {
        QuestionPoolId = questionPoolId;
        OptionText = optionText;
        ImageUrl = imageUrl;
        VoteCount = 0;
        Order = order;
    }
    private QuestionPoolItem()
    {
    }

}

using Tot.Domain.Entities.Question;

namespace Tot.Application.Dtos.Responses;

public record QuestionPoolItemResponseDto(int id, string? optionText, string? imageUrl, short order)
{
    public QuestionPoolItemResponseDto(QuestionPoolItem poolItem) : this(poolItem.Id, poolItem.OptionText, poolItem.ImageUrl, poolItem.Order)
    {

    }
}

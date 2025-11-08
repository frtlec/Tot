using Tot.Domain.Entities.Question;

namespace Tot.Application.Dtos.Commands;

public record CreateQuestionPoolItemDto(
    string? OptionText,
    string? ImageUrl,
    short Order
)
{
    public QuestionPoolItem ToQuestionPoolItem(int poolId) => new QuestionPoolItem(
                questionPoolId: poolId,
                optionText: OptionText,
                imageUrl: ImageUrl,
                order: Order
            );
}
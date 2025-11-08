using MediatR;
using Tot.Application.Dtos.Responses;
using Tot.Domain.Entities.Question;
using Tot.Domain.Enums;
using Tot.Shared.Reponses;

namespace Tot.Application.Dtos.Commands;

public record CreateQuestionPoolCommand(
    string Question,
    int categoryId,
    QuestionSourceType SourceType,
    QuestionFormatType formatType,
    string FriendlyUrl,
    List<CreateQuestionPoolItemDto> Items
) : IRequest<ServiceResponse<QuestionPoolResponseDto>>
{
    public QuestionPool ToQuestionPool() => new QuestionPool(
            question: Question,
            friendlyUrl: FriendlyUrl,
            categoryId: categoryId,
            sourceType: SourceType,
            questionFormatType: formatType
        );
}

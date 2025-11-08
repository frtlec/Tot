using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tot.Domain.Entities.Question;
using Tot.Domain.Enums;

namespace Tot.Application.Dtos.Responses;

public record QuestionPoolResponseDto(
    int id,
    string question,
    string categoryTitle,
    QuestionSourceType sourceType,
    string friendUrl,
    List<QuestionPoolItemResponseDto> items)
{
    public QuestionPoolResponseDto(QuestionPool questionPool)
        : this(
            questionPool.Id,
            questionPool.Question,
            questionPool.QuestionPoolCategory.Title,
            questionPool.SourceType,
            questionPool.FriendlyUrl,
            questionPool.Items.Select(i => new QuestionPoolItemResponseDto(i)).ToList()
        )
    { }
}
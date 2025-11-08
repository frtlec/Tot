using MediatR;
using Microsoft.EntityFrameworkCore;
using Tot.Application.Dtos.Queries;
using Tot.Application.Dtos.Responses;
using Tot.Infrastructure.Persistence;
using Tot.Shared.Reponses;

namespace Tot.Application.Handlers;

public class QuestionPoolCategoriesListQueryActiveHandler : IRequestHandler<QuestionPoolCategoriesListActiveQuery, ServiceResponse<List<QuestionPoolCategoriesResponseDto>>>
{
    private readonly TotPostgreSqlDbContext _context;

    public QuestionPoolCategoriesListQueryActiveHandler(TotPostgreSqlDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<QuestionPoolCategoriesResponseDto>>> Handle(QuestionPoolCategoriesListActiveQuery request, CancellationToken cancellationToken)
    {
        var categories = await _context.QuestionPoolCategories
            .Where(c => c.IsActive)
            .Select(c => new QuestionPoolCategoriesResponseDto(c.Id, c.Title))
            .ToListAsync();

        return ServiceResponse<List<QuestionPoolCategoriesResponseDto>>.Ok(categories);
    }
}

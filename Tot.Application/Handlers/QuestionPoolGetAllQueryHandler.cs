using MediatR;
using Microsoft.EntityFrameworkCore;
using Tot.Application.Dtos.Queries;
using Tot.Application.Dtos.Responses;
using Tot.Infrastructure.Persistence;
using Tot.Shared.Reponses;

namespace Tot.Application.Handlers;

public class QuestionPoolGetAllQueryHandler : IRequestHandler<QuestionPoolGetAllQuery, ServiceResponse<List<QuestionPoolResponseDto>>>
{
    private readonly TotPostgreSqlDbContext _context;

    public QuestionPoolGetAllQueryHandler(TotPostgreSqlDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<QuestionPoolResponseDto>>> Handle(QuestionPoolGetAllQuery request, CancellationToken cancellationToken)
    {
        var pools = await _context.QuestionPools
            .Include(x => x.Items)
            .Include(x=>x.QuestionPoolCategory)
            .Where(x => x.IsActive)
            .ToListAsync(cancellationToken);

        if (!pools.Any())
            return ServiceResponse<List<QuestionPoolResponseDto>>.NotFound("Hiç soru havuzu bulunamadı.");

        var dtos = pools.Select(pool => new QuestionPoolResponseDto(pool)).ToList();

        return ServiceResponse<List<QuestionPoolResponseDto>>.Ok(dtos);
    }
}
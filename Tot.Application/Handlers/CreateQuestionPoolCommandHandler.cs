using MediatR;
using Microsoft.EntityFrameworkCore;
using Tot.Application.Dtos.Commands;
using Tot.Application.Dtos.Responses;
using Tot.Domain.Entities.Question;
using Tot.Infrastructure.Persistence;
using Tot.Shared.Reponses;

namespace Tot.Application.Handlers;

public class CreateQuestionPoolCommandHandler : IRequestHandler<CreateQuestionPoolCommand, ServiceResponse<QuestionPoolResponseDto>>
{
    private readonly TotPostgreSqlDbContext _context;
    public CreateQuestionPoolCommandHandler(TotPostgreSqlDbContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<QuestionPoolResponseDto>> Handle(CreateQuestionPoolCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.QuestionPoolCategories
            .FirstOrDefaultAsync(x => x.Id == request.categoryId && x.IsActive, cancellationToken);
        if (category == null)
            return ServiceResponse<QuestionPoolResponseDto>.NotFound("Belirtilen kategori bulunamadı.");


        QuestionPool pool = request.ToQuestionPool();

        foreach (var item in request.Items)
        {
            var poolItem = item.ToQuestionPoolItem(pool.Id);
            pool.AddItem(poolItem); // bu metodu domain tarafına ekleyelim
        }

        await _context.QuestionPools.AddAsync(pool, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var dto = new QuestionPoolResponseDto(pool);

        return ServiceResponse<QuestionPoolResponseDto>.Ok(dto);
    }
}

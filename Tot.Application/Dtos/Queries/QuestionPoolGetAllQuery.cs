using MediatR;
using Tot.Application.Dtos.Responses;
using Tot.Shared.Reponses;

namespace Tot.Application.Dtos.Queries;
public record QuestionPoolGetAllQuery() : IRequest<ServiceResponse<List<QuestionPoolResponseDto>>>;

using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.AulaQuery.ObterTodasAulasQuery
{
    public class ObterTodasAulasQuery : IRequest<List<AulaDTO>>
    {
    }
}

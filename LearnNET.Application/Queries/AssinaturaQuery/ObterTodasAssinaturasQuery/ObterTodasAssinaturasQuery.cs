using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.AssinaturaQuery.ObterTodasAssinaturasQuery
{
    public class ObterTodasAssinaturasQuery : IRequest<List<AssinaturaDTO>>
    {
    }
}

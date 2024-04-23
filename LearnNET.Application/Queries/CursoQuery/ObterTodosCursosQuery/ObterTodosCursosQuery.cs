using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.CursoQuery.ObterTodosCursosQuery
{
    public class ObterTodosCursosQuery : IRequest<List<CursoDTO>>
    {
    }
}

using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.CursoQuery.ObterCursoPorIdQuery
{
    public class ObterCursoPorIdQuery : IRequest<CursoDTO>
    {
        public ObterCursoPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

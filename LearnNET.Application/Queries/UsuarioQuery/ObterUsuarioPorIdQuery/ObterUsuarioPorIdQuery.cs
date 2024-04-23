using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.UsuarioQuery.ObterUsuarioPorIdQuery
{
    public class ObterUsuarioPorIdQuery : IRequest<UsuarioDTO>
    {
        public ObterUsuarioPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

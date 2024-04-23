using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.UsuarioQuery.ObterTodosUsuariosQuery
{
    public class ObterTodosUsuariosQuery : IRequest<List<UsuarioDTO>>
    {
    }
}

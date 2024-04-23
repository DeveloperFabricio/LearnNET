using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.ModuloQuery.ObterTodosModulosQuery
{
    public class ObterTodosModulosQuery : IRequest<List<ModuloDTO>>
    {
    }
}

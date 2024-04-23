using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.ModuloQuery.ObterModuloPorIdQuery
{
    public class ObterModuloPorIdQuery : IRequest<ModuloDTO>
    {
        public ObterModuloPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.AssinaturaQuery.ObterAssinaturaPorIdQuery
{
    public class ObterAssinaturaPorIdQuery : IRequest<AssinaturaDTO>
    {
        public int Id { get; set; }

        public ObterAssinaturaPorIdQuery(int id)
        {
            Id = id;
        }
    }
}

using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Queries.AulaQuery.ObterAulaPorIdQuery
{
    public class ObterAulaPorIdQuery : IRequest<AulaDTO>
    {
        public ObterAulaPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

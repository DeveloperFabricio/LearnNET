using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.AulaQuery.ObterAulaPorIdQuery
{
    public class ObterAulaPorIdQueryHandler : IRequestHandler<ObterAulaPorIdQuery, AulaDTO>
    {
        private readonly IAulaRepository _repository;
        private readonly IMapper _mapper;

        public ObterAulaPorIdQueryHandler(IAulaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AulaDTO> Handle(ObterAulaPorIdQuery request, CancellationToken cancellationToken)
        {
            var aula = await _repository.ObterPorId(request.Id);
            return _mapper.Map<AulaDTO>(aula);
        }
    }
}

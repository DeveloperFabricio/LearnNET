using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.AulaQuery.ObterTodasAulasQuery
{
    public class ObterTodasAulasQueryHandler : IRequestHandler<ObterTodasAulasQuery, List<AulaDTO>>
    {
        private readonly IAulaRepository _aulaRepository;
        private readonly IMapper _mapper;

        public ObterTodasAulasQueryHandler(IAulaRepository aulaRepository, IMapper mapper)
        {
            _aulaRepository = aulaRepository;
            _mapper = mapper;
        }

        public async Task<List<AulaDTO>> Handle(ObterTodasAulasQuery request, CancellationToken cancellationToken)
        {
            var aulas = await _aulaRepository.ObterTodas();
            return _mapper.Map<List<AulaDTO>>(aulas);
        }
    }
}

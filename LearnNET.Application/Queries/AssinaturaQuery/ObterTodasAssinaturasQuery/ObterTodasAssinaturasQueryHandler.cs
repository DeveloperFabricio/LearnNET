using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.AssinaturaQuery.ObterTodasAssinaturasQuery
{
    public class ObterTodasAssinaturasQueryHandler : IRequestHandler<ObterTodasAssinaturasQuery, List<AssinaturaDTO>>
    {
        private readonly IAssinaturaRepository _assinaturaRepository;
        private readonly IMapper _mapper;

        public ObterTodasAssinaturasQueryHandler(IAssinaturaRepository assinaturaRepository, IMapper mapper)
        {
            _assinaturaRepository = assinaturaRepository;
            _mapper = mapper;
        }

        public async Task<List<AssinaturaDTO>> Handle(ObterTodasAssinaturasQuery request, CancellationToken cancellationToken)
        {
            var assinaturas = await _assinaturaRepository.ObterTodas();
            return _mapper.Map<List<AssinaturaDTO>>(assinaturas);
        }
    }
}

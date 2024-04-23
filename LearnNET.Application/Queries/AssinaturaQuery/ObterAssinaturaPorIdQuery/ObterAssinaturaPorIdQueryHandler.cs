using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.AssinaturaQuery.ObterAssinaturaPorIdQuery
{
    public class ObterAssinaturaPorIdQueryHandler : IRequestHandler<ObterAssinaturaPorIdQuery, AssinaturaDTO>
    {
        private readonly IAssinaturaRepository _repository;
        private readonly IMapper _mapper;

        public ObterAssinaturaPorIdQueryHandler(IAssinaturaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AssinaturaDTO> Handle(ObterAssinaturaPorIdQuery request, CancellationToken cancellationToken)
        {
            var assinatura = await _repository.ObterPorId(request.Id);
            return _mapper.Map<AssinaturaDTO>(assinatura);
        }
    }
}

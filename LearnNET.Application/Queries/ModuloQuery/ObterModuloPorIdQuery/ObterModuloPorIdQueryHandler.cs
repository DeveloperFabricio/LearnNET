using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.ModuloQuery.ObterModuloPorIdQuery
{
    public class ObterModuloPorIdQueryHandler : IRequestHandler<ObterModuloPorIdQuery, ModuloDTO>
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IMapper _mapper;

        public ObterModuloPorIdQueryHandler(IModuloRepository moduloRepository, IMapper mapper)
        {
            _moduloRepository = moduloRepository;
            _mapper = mapper;
        }

        public async Task<ModuloDTO> Handle(ObterModuloPorIdQuery request, CancellationToken cancellationToken)
        {
            var modulo = await _moduloRepository.ObterPorId(request.Id);
            return _mapper.Map<ModuloDTO>(modulo);
        }
    }
}

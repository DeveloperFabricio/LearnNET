using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.ModuloQuery.ObterTodosModulosQuery
{
    public class ObterTodosModulosQueryHandler : IRequestHandler<ObterTodosModulosQuery, List<ModuloDTO>>
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IMapper _mapper;

        public ObterTodosModulosQueryHandler(IModuloRepository moduloRepository, IMapper mapper)
        {
            _moduloRepository = moduloRepository;
            _mapper = mapper;
        }

        public async Task<List<ModuloDTO>> Handle(ObterTodosModulosQuery request, CancellationToken cancellationToken)
        {
            var modulos = await _moduloRepository.ObterTodos();
            return _mapper.Map<List<ModuloDTO>>(modulos);
        }
    }
}

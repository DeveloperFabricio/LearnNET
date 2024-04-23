using AutoMapper;
using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.ModuloCommand.CriarModuloCommand
{
    public class CriarModuloCommandHandler : IRequestHandler<CriarModuloCommand, Unit>
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IMapper _mapper;

        public CriarModuloCommandHandler(IModuloRepository moduloRepository, IMapper mapper)
        {
            _moduloRepository = moduloRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CriarModuloCommand request, CancellationToken cancellationToken)
        {
            // Mapear o DTO para a entidade Módulo
            var modulo = _mapper.Map<Modulo>(request.moduloDTO);

            // Adicionar o módulo ao repositório
            await _moduloRepository.Adicionar(modulo);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}

using AutoMapper;
using LearnNET.Core.Entities;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.ModuloCommand.AtualizarModuloCommand
{
    public class AtualizarModuloCommandHandler : IRequestHandler<AtualizarModuloCommand, Unit>
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IMapper _mapper;

        public AtualizarModuloCommandHandler(IModuloRepository moduloRepository, IMapper mapper)
        {
            _moduloRepository = moduloRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AtualizarModuloCommand request, CancellationToken cancellationToken)
        {
            // Recuperar o módulo a ser atualizado com base no ID
            var modulo = await _moduloRepository.ObterPorId(request.Id);

            if (modulo == null)
            {
                throw new NotFoundException($"Módulo com o ID {request.Id} não encontrado.");
            }

            // Mapear o DTO para a entidade Módulo
            var moduloAtualizado = _mapper.Map<Modulo>(request.moduloDTO);

            // Atualizar os dados do módulo
            modulo.Nome = moduloAtualizado.Nome;
            modulo.Descricao = moduloAtualizado.Descricao;
            modulo.Aulas = moduloAtualizado.Aulas;
            modulo.DataCriacao = moduloAtualizado.DataCriacao;

            // Atualizar o módulo no repositório
            await _moduloRepository.Atualizar(modulo);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}

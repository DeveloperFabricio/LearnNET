using AutoMapper;
using LearnNET.Core.Entities;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.CursoCommand.AtualizarCursoCommand
{
    public class AtualizarCursoCommandHandler : IRequestHandler<AtualizarCursoCommand, Unit>
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public AtualizarCursoCommandHandler(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AtualizarCursoCommand request, CancellationToken cancellationToken)
        {
            // Recuperar o curso a ser atualizado com base no ID
            var curso = await _cursoRepository.ObterPorId(request.Id);

            if (curso == null)
            {
                throw new NotFoundException($"Curso com o ID {request.Id} não encontrado.");
            }

            // Mapear o DTO para a entidade Curso
            var cursoAtualizado = _mapper.Map<Curso>(request.cursoDTO);

            // Atualizar os dados do curso
            curso.Nome = cursoAtualizado.Nome;
            curso.Descricao = cursoAtualizado.Descricao;
            curso.DataCriacao = cursoAtualizado.DataCriacao;
            curso.Modulos = cursoAtualizado.Modulos;

            // Atualizar o curso no repositório
            await _cursoRepository.Atualizar(curso);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}

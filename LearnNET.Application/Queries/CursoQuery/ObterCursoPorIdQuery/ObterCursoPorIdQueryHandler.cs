using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.CursoQuery.ObterCursoPorIdQuery
{
    public class ObterCursoPorIdQueryHandler : IRequestHandler<ObterCursoPorIdQuery, CursoDTO>
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public ObterCursoPorIdQueryHandler(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<CursoDTO> Handle(ObterCursoPorIdQuery request, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.ObterPorId(request.Id);
            return _mapper.Map<CursoDTO>(curso);
        }
    }
}

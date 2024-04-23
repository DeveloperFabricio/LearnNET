using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.UsuarioQuery.ObterUsuarioPorIdQuery
{
    public class ObterUsuarioPorIdQueryHandler : IRequestHandler<ObterUsuarioPorIdQuery, UsuarioDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public ObterUsuarioPorIdQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(request.Id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }
    }
}

using LearnNET.Core.Entities;
using LearnNET.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Service

{
    public class UsuarioCursoStatusCalculator
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioCursoStatusCalculator(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public UsuarioCursoStatus GetCursoStatus(int idCurso, int idUsuario)
        {
            var curso = _appDbContext.Cursos
            .Include(c => c.Modulos)
                .ThenInclude(m => m.Aulas)
            .FirstOrDefault(c => c.Id == idCurso);

            var aulasConcluidas = _appDbContext.UsuarioAulaConcluidas
                .Where(uac => uac.IdUsuario == idUsuario && curso.Modulos.Any(m => m.Aulas.Any(a => a.Id == uac.IdAula)))
                .ToList();

            // Calcular o tempo total do curso em minutos
            int tempoTotal = curso.Modulos.Sum(m => m.Aulas.Sum(a => a.Duracao));

            // Calcular o tempo total de aulas concluídas pelo usuário em minutos
            int tempoConcluido = aulasConcluidas.Sum(uac => uac.Aula.Duracao);

            // Calcular o tempo restante do curso em minutos
            int tempoRestante = tempoTotal - tempoConcluido;

            // Calcular a porcentagem concluída do curso
            double porcentagemConcluido = (double)tempoConcluido / tempoTotal * 100;

            // Retornar o status do curso para o usuário
            return new UsuarioCursoStatus
            {
                IdCurso = idCurso,
                IdUsuario = idUsuario,
                TempoTotal = tempoTotal,
                TempoConcluido = tempoConcluido,
                TempoRestante = tempoRestante,
                PorcentagemConcluido = porcentagemConcluido
            };
        }
    }
}

namespace LearnNET.Core.Entities
{
    public class UsuarioCursoStatus
    {
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }
        public int TempoTotal { get; set; } // Tempo total do curso em minutos
        public int TempoConcluido { get; set; } // Tempo total de aulas concluídas pelo usuário em minutos
        public int TempoRestante { get; set; } // Tempo restante do curso em minutos
        public double PorcentagemConcluido { get; set; } // Porcentagem de conclusão do curso
    }
}


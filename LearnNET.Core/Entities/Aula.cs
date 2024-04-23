using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Entities
{
    public class Aula
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LinkVideo { get; set; }
        public int Duracao { get; set; }
        public int ModuloId { get; set; }
    }
}

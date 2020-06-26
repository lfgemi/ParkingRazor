using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.Entities
{
    public class Manobrista
    {
        public int IdManobrista { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime DtAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}

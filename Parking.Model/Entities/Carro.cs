using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.Entities
{
    public class Carro
    {
        public int IdCarro { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public DateTime DtAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}

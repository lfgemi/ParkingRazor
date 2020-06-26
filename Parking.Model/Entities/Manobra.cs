using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.Entities
{
    public class Manobra
    {
        public int IdManobra { get; set; }
        public int? IdManobrista { get; set; }
        public int? IdCarro { get; set; }
        public DateTime? DtInclusao { get; set; }
        public int IdTipoManobra { get; set; }
    }
}

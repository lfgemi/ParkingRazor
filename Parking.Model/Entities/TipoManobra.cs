using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.Entities
{
    public class TipoManobra
    {
        public int IdTipoManobra { get; set; }
        public string Descricao { get; set; }
    }
}

using Parking.Entities;
using System.Collections.Generic;

namespace Parking.DAL.Repository
{
    public interface IManobraRepository
    {
        int Add(Manobra manobra);
        List<Manobra> GetManobras();
        Manobra Get(int id);
        int Edit(Manobra carro);
        int Delete(int id);
        List<TipoManobra> GetTipoManobras();
    }
}

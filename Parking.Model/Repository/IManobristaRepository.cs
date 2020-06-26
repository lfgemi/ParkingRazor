using Parking.Entities;
using System.Collections.Generic;

namespace Parking.DAL.Repository
{
    public interface IManobristaRepository
    {
        int Add(Manobrista manobrista);
        List<Manobrista> GetManobristas();
        Manobrista Get(int id);
        int Edit(Manobrista manobrista);
        int Delete(int id);
    }
}

using Parking.Entities;
using System.Collections.Generic;

namespace Parking.DAL.Repository
{
    public interface ICarroRepository
    {
        int Add(Carro carro);
        List<Carro> GetCarros();
        Carro Get(int id);
        int Edit(Carro carro);
        int Delete(int id);
    }
}

using Dapper;
using Microsoft.Extensions.Configuration;
using Parking.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Parking.DAL.Repository
{
    public class CarroRepository : ICarroRepository
    {
        IConfiguration _configuration;
        public CarroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("ParkingDB").Value;
            return connection;
        }
        public int Add(Carro Carro)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Carros(Marca, Modelo, Placa) VALUES(@Marca, @Modelo, @Placa); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, Carro);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public int Delete(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Carros WHERE IdCarro =" + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public int Edit(Carro Carro)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Carros SET Modelo = @Modelo, Marca = @Marca, Placa = @Placa WHERE IdCarro = " + Carro.IdCarro;
                    count = con.Execute(query, Carro);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        public Carro Get(int id)
        {
            var connectionString = this.GetConnection();
            Carro Carro = new Carro();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Carros WHERE IdCarro =" + id;
                    Carro = con.Query<Carro>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return Carro;
            }
        }
        public List<Carro> GetCarros()
        {
            var connectionString = this.GetConnection();
            List<Carro> Carros = new List<Carro>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Carros";
                    Carros = con.Query<Carro>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return Carros;
            }
        }
    }
}
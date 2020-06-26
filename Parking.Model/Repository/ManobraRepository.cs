using Dapper;
using Microsoft.Extensions.Configuration;
using Parking.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Parking.DAL.Repository
{
    public class ManobraRepository : IManobraRepository
    {
        IConfiguration _configuration;
        public ManobraRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("ParkingDB").Value;
            return connection;
        }
        public int Add(Manobra manobra)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Manobras(IdManobrista, IdCarro, IdTipoManobra) VALUES(@IdManobrista, @IdCarro, @IdTipoManobra); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, manobra);
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
                    var query = "DELETE FROM Manobras WHERE IdManobra =" + id;
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
        public int Edit(Manobra manobra)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Manobras SET IdManobrista = @IdManobra, IdCarro= @IdCarro, DtInclusao = @DtInclusao WHERE IdManobra = " + manobra.IdManobra;
                    count = con.Execute(query, manobra);
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
        public Manobra Get(int id)
        {
            var connectionString = this.GetConnection();
            Manobra manobra = new Manobra();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Manobras WHERE IdManobra =" + id;
                    manobra = con.Query<Manobra>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return manobra;
            }
        }
        public List<Manobra> GetManobras()
        {
            var connectionString = this.GetConnection();
            var manobras = new List<Manobra>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Manobras";
                    manobras = con.Query<Manobra>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return manobras;
            }
        }
        public List<TipoManobra> GetTipoManobras() 
        {
            var connectionString = this.GetConnection();
            var tipoManobras = new List<TipoManobra>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM TipoManobra";
                    tipoManobras = con.Query<TipoManobra>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return tipoManobras;
            }
        }
    }
}
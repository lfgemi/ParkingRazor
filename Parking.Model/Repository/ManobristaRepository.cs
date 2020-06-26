using Dapper;
using Microsoft.Extensions.Configuration;
using Parking.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Parking.DAL.Repository
{
    public class ManobristaRepository : IManobristaRepository
    {
        IConfiguration _configuration;
        public ManobristaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("ParkingDB").Value;
            return connection;
        }
        public int Add(Manobrista manobrista)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Manobristas(Nome, Cpf, DataNascimento) VALUES(@Nome, @Cpf, @DataNascimento); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, manobrista);
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
                    var query = "DELETE FROM Manobristas WHERE IdManobrista =" + id;
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
        public int Edit(Manobrista manobrista)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Manobristas SET Nome = @Nome, Cpf = @Cpf, DataNascimento = @DataNascimento WHERE IdManobrista = " + manobrista.IdManobrista;
                    count = con.Execute(query, manobrista);
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
        public Manobrista Get(int id)
        {
            var connectionString = this.GetConnection();
            Manobrista manobrista = new Manobrista();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Manobristas WHERE IdManobrista =" + id;
                    manobrista = con.Query<Manobrista>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return manobrista;
            }
        }
        public List<Manobrista> GetManobristas()
        {
            var connectionString = this.GetConnection();
            List<Manobrista> manobristas = new List<Manobrista>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Manobristas";
                    manobristas = con.Query<Manobrista>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return manobristas;
            }
        }
    }
}
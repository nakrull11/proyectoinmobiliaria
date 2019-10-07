using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPruebaFinal.Models
{
    public class RepositorioAlquiler : RepositorioBase, IRepositorioAlquiler
    {
        public RepositorioAlquiler(IConfiguration configuration) : base(configuration)
        {

        }

        public int Alta(Alquiler p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Alquiler (Precio,FechaInicio, FechaFin, InquilinoId, InmuebleId) " +
                    $"VALUES ('{p.Precio}','{p.FechaInicio}', '{p.FechaFin}','{p.InquilinoId}','{p.InmuebleId}')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    p.IdAlquiler = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Alquiler WHERE IdAlquiler = {id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public int Modificacion(Alquiler p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Alquiler SET Precio='{p.Precio}', FechaInicio='{p.FechaInicio}', FechaFin='{p.FechaFin}', InquilinoId='{p.InquilinoId}', InmuebleId='{p.InmuebleId}'" +
                    $"WHERE IdAlquiler = {p.IdAlquiler}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }


        

        public Alquiler ObtenerPorInmueble(int id)
        {
            Alquiler p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdAlquiler, Precio, FechaInicio, FechaFin, InquilinoId, InmuebleId " +
                    $" FROM Alquiler WHERE InmuebleId=@id;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Alquiler
                        {
                            IdAlquiler = reader.GetInt32(0),
                            Precio = reader.GetDecimal(1),
                            FechaInicio = reader.GetString(2),
                            FechaFin = reader.GetString(3),
                            InquilinoId = reader.GetInt32(4),
                            InmuebleId = reader.GetInt32(5)

                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }

        public Alquiler ObtenerPorInquilino(int id)
        {
            throw new NotImplementedException();
        }

        public Alquiler ObtenerPorId(int id)
        {
            Alquiler p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdAlquiler, Precio, FechaInicio, FechaFin, InquilinoId, InmuebleId " +
                    $" FROM Alquiler WHERE IdAlquiler=@id;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Alquiler
                        {
                            IdAlquiler = reader.GetInt32(0), 
                            Precio= reader.GetDecimal(1), 
                            FechaInicio = reader.GetString(2), 
                            FechaFin = reader.GetString(3),
                            InquilinoId = reader.GetInt32(4),
                            InmuebleId = reader.GetInt32(5)
                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }

        public IList<Alquiler> ObtenerTodos()
        {
            IList<Alquiler> res = new List<Alquiler>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * " +
                    $" FROM Alquiler ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Alquiler p = new Alquiler
                        {
                            IdAlquiler = reader.GetInt32(0),
                            Precio = reader.GetDecimal(1),
                            FechaInicio = reader.GetString(2),
                            FechaFin = reader.GetString(3),
                            InquilinoId = reader.GetInt32(4),
                            InmuebleId = reader.GetInt32(5)
                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }
    }
}

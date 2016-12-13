using AplicacionMantenimiento.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AplicacionMantenimiento.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace AplicacionMantenimiento.Repositorios
{
    public class SQLVideosRepository : IVideosInterface
    {
        public void crearVideo(Video videoNuevo)
        {
            var sql = "INSERT INTO dbo.Videos (Nombre, Precio, Tipo) VALUES (@nombre, @precio, @tipo)";
            var cmd = new SqlCommand(sql);

            cmd.Parameters.AddWithValue("@nombre", videoNuevo.Nombre);
            cmd.Parameters.AddWithValue("@precio", videoNuevo.Precio);
            cmd.Parameters.AddWithValue("@tipo", videoNuevo.Tipo.ToString());

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void editarVideo(Video videoEditar)
        {
            throw new NotImplementedException();
        }

        public void eliminarVideo(int id)
        {
            throw new NotImplementedException();
        }

        public Video LeerVideo(int id)
        {
            throw new NotImplementedException();
        }

        public List<Video> obtenerVideos()
        {
            var lista = new List<Video>();

            var sql = "SELECT ID, Nombre ,Precio, Tipo FROM dbo.Videos";
            var cmd = new SqlCommand(sql);

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var v = new Video();
                        v.ID = reader.GetInt32(0);
                        v.Nombre = reader.GetString(1);
                        v.Precio = reader.GetDecimal(2);
                        v.TiposAsString = reader.GetString(3);
                        lista.Add(v);
                    }
                }
                sqlConnection.Close();
                return lista;
            }
        }
    }
}
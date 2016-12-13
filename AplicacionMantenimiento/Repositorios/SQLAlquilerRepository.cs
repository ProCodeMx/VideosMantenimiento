using AplicacionMantenimiento.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AplicacionMantenimiento.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.ModelBinding;

namespace AplicacionMantenimiento.Repositorios
{
    public class SQLAlquilerRepository : IAlquilerInterface
    {
        public Boolean alquilarVideo(Alquiler alquiler)
        {
            if (verificarVideo(alquiler))
            {
                return false;
            }
            else
            {
                var sql = "INSERT INTO dbo.Alquileres (UserId, VideoId) VALUES (@userid, @videoid)";
                var cmd = new SqlCommand(sql);

                cmd.Parameters.AddWithValue("@userid", alquiler.UserId);
                cmd.Parameters.AddWithValue("@videoid", alquiler.VideoId);

                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
                {
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public List<Video> getPeliculaByMembresia(string membresia)
        {
            var lista = new List<Video>();

            var sql = "SELECT video.Nombre, video.Precio,video.Tipo FROM Videos video JOIN Alquileres alquileres ON alquileres.VideoId=video.ID JOIN AspNetUsers users ON users.Id=alquileres.UserId AND users.Membresia = @membresia";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@membresia", membresia);


            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var p = new Video();
                        p.Nombre = reader.GetString(0);
                        p.Precio = reader.GetDecimal(1);
                        lista.Add(p);
                    }
                }
                sqlConnection.Close();
                return lista;
            }
        }

        public List<Video> getPeliculaByTipo(string tipo)
        {
            var lista = new List<Video>();

            var sql = "SELECT video.Nombre, video.Precio,video.Tipo FROM Videos video JOIN Alquileres alquileres ON alquileres.VideoId=video.ID JOIN AspNetUsers users ON users.Id=alquileres.UserId AND video.Tipo = @tipo";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@tipo", tipo);


            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var p = new Video();
                        p.Nombre = reader.GetString(0);
                        p.Precio = reader.GetDecimal(1);
                        lista.Add(p);
                    }
                }
                sqlConnection.Close();
                return lista;
            }
        }

        public List<Video> getPeliculaByUser(string userId)
        {
            var lista = new List<Video>();

            var sql = "SELECT videos.Nombre, videos.Precio FROM dbo.Videos videos JOIN Alquileres alq ON alq.VideoId=videos.ID AND alq.UserId = @userid";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@userid", userId);


            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var p = new Video();
                        p.Nombre = reader.GetString(0);
                        p.Precio = reader.GetDecimal(1);
                        lista.Add(p);
                    }
                }
                sqlConnection.Close();
                return lista;
            }
        }

        public bool verificarVideo(Alquiler alquiler)
        {
            var lista = new List<Alquiler>();

            var sql = "SELECT ID, UserId ,VideoId FROM dbo.Alquileres WHERE UserId = @userid AND VideoId = @videoid";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@userid", alquiler.UserId);
            cmd.Parameters.AddWithValue("@videoid", alquiler.VideoId);

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var p = new Alquiler();
                    p.ID = reader.GetInt32(0);
                    p.UserId = reader.GetString(1);
                    p.VideoId = reader.GetInt32(2);
                    return true;
                }
                sqlConnection.Close();
                return false;
            }
        }
    }
}
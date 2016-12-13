using AplicacionMantenimiento.Interfaces;
using AplicacionMantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionMantenimiento.Controllers
{
    public class HomeController : Controller
    {
        private IAlquilerInterface alquileres;
        private IVideosInterface videos;
        public HomeController(IAlquilerInterface alqui, IVideosInterface vids)
        {
            alquileres = alqui;
            videos = vids;
        }

        public ActionResult Index()
        {
            var Normal = alquileres.getPeliculaByMembresia("Normal");
            ViewBag.Normal = Normal;
            ViewBag.TotalNormal = obtenerTotal(Normal);

            var Gold = alquileres.getPeliculaByMembresia("Gold");
            ViewBag.Gold = Gold;
            ViewBag.TotalGold = obtenerTotal(Gold);

            var Infantil = alquileres.getPeliculaByTipo("Infantil");
            ViewBag.Infantil = Infantil;
            ViewBag.TotalInfantil = obtenerTotal(Infantil);

            var Adolescentes = alquileres.getPeliculaByTipo("Adolescentes");
            ViewBag.Adolescentes = Adolescentes;
            ViewBag.TotalAdolescentes = obtenerTotal(Adolescentes);

            var Adultos = alquileres.getPeliculaByTipo("Adultos");
            ViewBag.Adultos = Adultos;
            ViewBag.TotalAdultos = obtenerTotal(Adultos);

            return View();
        }

        public decimal obtenerTotal(List<Video> peliculas)
        {
            decimal sum = 0;
            foreach (var item in peliculas)
            {
                sum += item.Precio;
            }
            return sum;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
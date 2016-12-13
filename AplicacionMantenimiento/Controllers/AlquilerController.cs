using AplicacionMantenimiento.Interfaces;
using AplicacionMantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AplicacionMantenimiento.Controllers
{
    public class AlquilerController : Controller
    {
        private IAlquilerInterface alquileres;
        private IVideosInterface videos;


        public AlquilerController(IAlquilerInterface alqui, IVideosInterface vids)
        {
            alquileres = alqui;
            videos = vids;
            ViewBag.Videos = videos.obtenerVideos();
        }


        // GET: Alquiler
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var peliculas = alquileres.getPeliculaByUser(userId);
            ViewBag.Total = obtenerTotal(peliculas);
            return View(peliculas);
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

        // GET: Alquiler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alquiler/Create
        [Authorize]
        public ActionResult Create()
        {
            var model = new Alquiler();
            return View(model);
        }

        // POST: Alquiler/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Alquiler alquilerACrear)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(alquilerACrear);
                }

                
                alquilerACrear.UserId = User.Identity.GetUserId();
                

                var verifica = alquileres.alquilarVideo(alquilerACrear);

                if (verifica)
                {
                    return RedirectToAction("Index");
                }else
                {
                    ModelState.AddModelError("VideoId", "Ya rentaste esta pelicula");
                }
                return View(alquilerACrear);

            }
            catch
            {
                return View();
            }
        }

        // GET: Alquiler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alquiler/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alquiler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alquiler/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}

using AplicacionMantenimiento.Interfaces;
using AplicacionMantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionMantenimiento.Controllers
{
    public class VideosController : Controller
    {
        private IVideosInterface videos;

        public VideosController(IVideosInterface vids)
        {
            videos = vids;
        }

        // GET: Videos
        public ActionResult Index()
        {
            var model = videos.obtenerVideos();
            return View(model);
        }

        // GET: Videos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            var model = new Video();
            return View(model);
        }

        // POST: Videos/Create
        [HttpPost]
        public ActionResult Create(Video videoACrear)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(videoACrear);
                }

                videos.crearVideo(videoACrear);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Videos/Edit/5
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

        // GET: Videos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Videos/Delete/5
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

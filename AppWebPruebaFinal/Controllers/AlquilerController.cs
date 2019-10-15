using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWebPruebaFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWebPruebaFinal.Controllers
{
    public class AlquilerController : Controller
    {
        private readonly IRepositorio<Alquiler> repositorio;
        

        public AlquilerController(IRepositorio<Alquiler> repositorio, IRepositorioInmueble inmuebles, IRepositorio<Inquilino> inquilinos)
        {
            this.repositorio = repositorio;
            Inmuebles = inmuebles;
            Inquilinos = inquilinos;

        }

        public IRepositorioInmueble Inmuebles { get; set; }
        public IRepositorio<Inquilino> Inquilinos { get; set; }
        // GET: Alquiler
        public ActionResult Index()
        {
            var lista = repositorio.ObtenerTodos();
            if (TempData.ContainsKey("Id"))
                ViewBag.Id = TempData["Id"];

            return View(lista);
        }

        // GET: Alquiler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alquiler/Create
        public ActionResult Create()
        {
            ViewBag.Inquilinos = Inquilinos.ObtenerTodos();
            ViewBag.Inmuebles = Inmuebles.ObtenerTodos();
            return View();
        }

        // POST: Alquiler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alquiler alquiler)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Alta(alquiler);
                    TempData["Id"] = alquiler.IdAlquiler;
                    return View(alquiler);
                }
                else
                return View(alquiler);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(alquiler);
            }
        }

        // GET: Alquiler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alquiler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
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
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Baja(id);
                    ViewBag.Mensaje = "Se borro con exito el alquiler";
                    return View();
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWebPruebaFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWebPruebaFinal.Controllers
{
    public class InquilinoController : Controller
    {

        private readonly IRepositorio<Inquilino> repositorio;
        public InquilinoController(IRepositorio<Inquilino> repositorio)
        {
            this.repositorio = repositorio;
        }
        // GET: Inquilino
        public ActionResult Index()
        {
            var lista = repositorio.ObtenerTodos();
            return View(lista);
        }

        // GET: Inquilino/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inquilino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquilino/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino inquilino)
        {
            try
            {
                TempData["Nombre"] = inquilino.Nombre;
                if (ModelState.IsValid)
                {
                    repositorio.Alta(inquilino);
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(inquilino);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(inquilino);
            }
        }

        // GET: Inquilino/Edit/5
        public ActionResult Edit(int id)
        {
            var i = repositorio.ObtenerPorId(id);
            return View(i);
        }

        // POST: Inquilino/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inquilino collection)
        {
            try
            {
                collection.IdInquilino= id;
                repositorio.Modificacion(collection);
               
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(collection);
            }
        }

        // GET: Inquilino/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inquilino/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
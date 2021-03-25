using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frutasyverduras.Models;


namespace frutasyverduras.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: Home/Details/5
        public ActionResult Details(string celular)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = ma.Recuperar(celular);
            return View(usu);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = new usuario
            {
                nombre = collection["nombre"].ToString(),
                celular = collection["celular"].ToString(),
                email = collection["email"].ToString(),
                ciudad = collection["ciudad"].ToString(),
                fecharegistro = collection["fecharegistro"].ToString()
            };
            ma.Alta(usu);
            return RedirectToAction("Index");
        }

        public ActionResult BuscarTodos()
        {
            mantenimientousuario ma = new mantenimientousuario();
            return View(ma.RecuperarTodos());
        }

        // GET: Home/Edit/5
        public ActionResult Edit(string celular)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = ma.Recuperar(celular);
            return View(usu);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(string celular, FormCollection collection)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = new usuario
            {
                nombre = collection["nombre"].ToString(),
                celular = collection["celular"].ToString(),
                email = collection["email"].ToString(),
                ciudad = collection["ciudad"].ToString(),
                fecharegistro = collection["fecharegistro"].ToString()
            };
            ma.Modificar(usu);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(string celular)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = ma.Recuperar(celular);
            return View(usu);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(string celular, FormCollection collection)
        {
            mantenimientousuario ma = new mantenimientousuario();
            ma.Borrar(celular);
            return RedirectToAction("Index");
        }
    }
}
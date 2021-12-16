using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.BL;

namespace Web.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            var productosBL = new ProductosBL();
            var listaDeProductos = productosBL.ObtenerProductos();

            return View(listaDeProductos);
        }
    }
}
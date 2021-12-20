using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.BL;

namespace TiendaOnline.Admin.Controllers
{
    public class ProductosController : Controller
    {
        ProductosBL _productoBL;

        public ProductosController()
        {
            _productoBL = new ProductosBL();
        }
        // GET: Productos
        public ActionResult Index()
        {
            var listadeProductos = _productoBL.ObtenerProductos();

            return View(listadeProductos);
        }

        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();
            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            _productoBL.GuardarProducto(producto);

            return RedirectToAction("Index");
        }
    }
}
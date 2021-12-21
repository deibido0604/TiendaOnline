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
        CategoriasBL _categoriaBL;

        public ProductosController()
        {
            _productoBL = new ProductosBL();
            _categoriaBL = new CategoriasBL();
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
            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.ListaCategorias = new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            _productoBL.GuardarProducto(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var producto = _productoBL.ObtenerProductos(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            _productoBL.GuardarProducto(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var producto = _productoBL.ObtenerProductos(id);
            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productoBL.ObtenerProductos(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productoBL.EliminarProductos(producto.Id);

            return RedirectToAction("Index");
        }
    }
}
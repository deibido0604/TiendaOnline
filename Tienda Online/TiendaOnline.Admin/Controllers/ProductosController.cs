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

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult Crear(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if(producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }

                if(imagen != null){
                    producto.UrlImagen = GuardarImagen(imagen);
                }

                _productoBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }

            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(producto);
        }

        public ActionResult Editar(int id)
        {
            var producto = _productoBL.ObtenerProductos(id);
            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }
                _productoBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }

            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(producto);
        }

        public ActionResult Detalle(int id)
        {
            var producto = _productoBL.ObtenerProductos(id);
            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productoBL.ObtenerProductos(id);
            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productoBL.EliminarProductos(producto.Id);

            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "~/Imagenes/" + imagen.FileName;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            var producto1 = new ProductoModel();
            producto1.Id = 1;
            producto1.Descripcion = "Retrato";

            var producto2 = new ProductoModel();
            producto2.Id = 1;
            producto2.Descripcion = "Paisaje";

            var producto3 = new ProductoModel();
            producto3.Id = 1;
            producto3.Descripcion = "Animal";

            var listaDeProductos = new List<ProductoModel>();
            listaDeProductos.Add(producto1);
            listaDeProductos.Add(producto2);
            listaDeProductos.Add(producto3);

            return View(listaDeProductos);
        }
    }
}
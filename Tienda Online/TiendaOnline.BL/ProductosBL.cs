using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    public class ProductosBL
    {
        public List<Producto> ObtenerProductos()
        {
            var producto1 = new Producto();
            producto1.Id = 1;
            producto1.Descripcion = "Retrato";
            producto1.Precio = 1400;

            var producto2 = new Producto();
            producto2.Id = 1;
            producto2.Descripcion = "Paisaje";

            var producto3 = new Producto();
            producto3.Id = 1;
            producto3.Descripcion = "Animal";

            var listaDeProductos = new List<Producto>();
            listaDeProductos.Add(producto1);
            listaDeProductos.Add(producto2);
            listaDeProductos.Add(producto3);

            return listaDeProductos;
        }
    }
}

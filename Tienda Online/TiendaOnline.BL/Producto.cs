using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    public class Producto
    {
        public Producto()
        {
            Activo = true;
        }
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Ingrese la descripcion")]
        public string  Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese el precio")]
        public double Precio { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
        public int CategoriaId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.BL
{
    public class CategoriasBL
    {
        Contexto _contexto;
        public List<Categoria> ListaDeCategorias { get; set; }

        public CategoriasBL()
        {
            _contexto = new Contexto();
            ListaDeCategorias = new List<Categoria>();
        }

        public List<Categoria> ObtenerCategorias()
        {
            ListaDeCategorias = _contexto.Categorias.ToList();
            return ListaDeCategorias;
        }

        public void GuardarCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var categoriaExistente = _contexto.Categorias.Find(categoria.Id);
                categoriaExistente.Descripcion = categoria.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public Categoria ObtenerCategorias(int id)
        {
            var categoria = _contexto.Categorias.Find(id);

            return categoria;
        }

        public void EliminarCategorias(int id)
        {
            var categoria = _contexto.Categorias.Find(id);

            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }

    }
}

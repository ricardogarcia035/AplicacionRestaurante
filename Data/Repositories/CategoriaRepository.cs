using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Repositories
{
    public class CategoriaRepository
    {
        private RestauEFContext _context;
 
        public CategoriaRepository(RestauEFContext context)
        {
            this._context = context;
        }
        public void Delete(int id)
        {
            Categoria categoria = this._context.Categorias.Find(id);
            this._context.Categorias.Remove(categoria);
            this._context.SaveChanges();
        }
        public void Insert(Categoria categoria)
        {
            this._context.Categorias.Add(categoria);
            this._context.SaveChanges();
        }

        public List<Categoria> Get()
        {
            return this._context.Categorias.ToList();
        }

        public Categoria GetById(int id)
        {
            Categoria categoria = this._context.Categorias.Find(id);
            return categoria;
        }
    }
}

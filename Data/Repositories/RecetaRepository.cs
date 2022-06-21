using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repositories
{
    public class RecetaRepository
    {
        private RestauEFContext _context;

        public RecetaRepository(RestauEFContext context)
        {
            this._context = context;
        }
        public List<Receta> Get(int[] listCategorias, int? id, string nombre, string ingredientes, int? idUsuario, DateTime? from, DateTime? to)
        {
            var list = this._context.Recetas.AsQueryable();
            if (id != null)
                list = list.Where(x => (x.Id == id));

            if (!string.IsNullOrWhiteSpace(nombre)&& !string.IsNullOrEmpty(nombre)) 
                list = list.Where(x => (x.Nombre.Contains(nombre)));

            if (!string.IsNullOrWhiteSpace(ingredientes) && !string.IsNullOrEmpty(ingredientes))
                list = list.Where(x => (x.Ingredientes.Contains(ingredientes)));

            if (idUsuario != null)
                list = list.Where(x => (x.IdUsuario ==idUsuario));

            if (from != null)
                list = list.Where(x => (x.Fecha >= from));

            if (to != null)
                list = list.Where(x => (x.Fecha <= to));

            if (listCategorias != null)
                list = list.Where(x => (x.Categorias.Any(z => listCategorias.Contains(z.Id))));
            
            return list.ToList();
            
        }

        public Receta GetById(int id)
        {
            Receta receta = this._context.Recetas.Find(id);
            return receta;
        }
        public void Insert(Receta receta)
        {
            this._context.Recetas.Add(receta);
            this._context.SaveChanges();
        }
        public void Update(Receta recetaModificada, int id)
        {
            var receta = this._context.Recetas.Find(id);

            receta.Nombre = recetaModificada.Nombre;
            receta.Ingredientes = recetaModificada.Ingredientes;
            receta.Instrucciones = recetaModificada.Instrucciones;
            receta.DireccionFoto = recetaModificada.DireccionFoto;
            receta.Categorias.Clear();
            receta.Categorias = recetaModificada.Categorias;

            this._context.Entry(receta).State = System.Data.Entity.EntityState.Modified;

            this._context.SaveChanges();
        }
        public void Delete(int id)
        {
            Receta receta = _context.Recetas.Find(id);
            this._context.Recetas.Remove(receta);
            this._context.SaveChanges();
        }

        public void Ocultar(int id,  bool estado)
        {
            var receta = this._context.Recetas.Find(id);
            receta.Estado = estado;

            this._context.Entry(receta).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();  
        }

        /*public List<Receta> Get(List<Categoria> listCategorias, int? id, string nombre, string ingredientes, int? idUsuario, DateTime? from, DateTime? to)
        {
            List<Receta> list = this._context.Recetas.Where(x => (id == null || x.Id == id)
            && (nombre == null || x.Nombre == nombre)
            && (ingredientes == null || x.Ingredientes == ingredientes)
            && (idUsuario == null || x.IdUsuario == idUsuario)
            && (from == null || x.Fecha >= from)
            && (to == null || x.Fecha <= to)
            //&&(x.Categorias.Any(o => listCategorias.Any(w => w.Id == o.Id && w.Nombre == o.Nombre)))
            ).ToList();

            return list;
        }*/
    }
}

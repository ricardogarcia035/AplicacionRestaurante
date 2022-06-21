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
    public class PublicacionRepository
    {
        private RestauEFContext _context;

        public PublicacionRepository(RestauEFContext context)
        {
            this._context = context;
        }
        public List<Publicacion> Get(int[] listCategorias,int? id, int? idReceta, int? idUsuario, string nombre, DateTime? from, DateTime? to, bool estado)
        {
            //poder ver las publicaciones ocultas
            var list = this._context.Publicaciones.AsQueryable();
                list = list.Where(x=>(x.Receta.Estado==estado));
            if (id != null)
                list = list.Where(x => (x.Id == id));

            if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrEmpty(nombre))
                list = list.Where(x => (x.Receta.Nombre.Contains(nombre)));

            if (idReceta != null)
                list = list.Where(x => (x.Receta.Id == idReceta));

            if (idUsuario != null)
                list = list.Where(x => (x.Receta.IdUsuario == idUsuario));

            if (from != null)
                list = list.Where(x => (x.Fecha >= from));

            if (to != null)
                list = list.Where(x => (x.Fecha <= to));

            if (listCategorias != null)
                list = list.Where(x => (x.Receta.Categorias.Any(z => listCategorias.Contains(z.Id))));
            return list.ToList();
        }

        public Publicacion GetById(int id)
        {
            var publicacion = this._context.Publicaciones.Find(id);

            return publicacion;
        }
        public void Insert(Publicacion publicacion)
        {
            this._context.Publicaciones.Add(publicacion);
            this._context.SaveChanges();
        }
        public void Update(Publicacion publicacion)
        {
            //var publicacionNew = this._context.Publicaciones.Find(publicacion.Id);

            //publicacionNew.Descripcion = publicacion.Descripcion;

            this._context.Entry(publicacion).State = System.Data.Entity.EntityState.Modified;

            this._context.SaveChanges();
        }
        public void Delete(int id)
        {
            Publicacion entity = this._context.Publicaciones.Find(id);
            this._context.Publicaciones.Remove(entity);
            this._context.SaveChanges();
        }


        /*
        public List<Comentario> GetListComentarios(int idPublicacion)
        {
            Publicacion publicacion = this._context.Publicaciones.Find(idPublicacion);
            return publicacion.Comentarios;
        }*/

        /* public void Update(Publicacion publicacionModificada)
        {
           
            publicacionModificada = (Publicacion)this._context.Publicaciones.Where(x => x.Id == publicacionModificada.Id);

            //publicacionNew.Descripcion = publicacion.Descripcion;

           this._context.Entry(publicacionModificada).State = System.Data.Entity.EntityState.Modified;

            this._context.SaveChanges();
        }*/
        /*
          List<Publicacion> list = this._context.Publicaciones.Where(x => (id == null || x.Id == id)
            && (nombre == null || x.Receta.Nombre == nombre)
            && (idUsuario == null || x.Receta.IdUsuario == idUsuario)
            && (idReceta == null || x.IdReceta == idReceta)
            && (from == null || x.Fecha >= from)
            && (to == null || x.Fecha <= to)
            &&(x.Receta.Estado==true)
            ).ToList();

            return list;*/
    }
}

using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repositories
{
    public class ComentarioRepository
    {
        private RestauEFContext _context;

        public ComentarioRepository(RestauEFContext context)
        {
            this._context = context;
        }

        public void Insert(Comentario comentario)
        {
            this._context.Comentarios.Add(comentario);
            this._context.SaveChanges();
        }

        public Comentario Get(int id)
        {
            Comentario comentario = this._context.Comentarios.Find(id);
            return comentario;

        }
        public void Delete(int id)
        {
            Comentario entity = this._context.Comentarios.Find(id);
            this._context.Comentarios.Remove(entity);
            this._context.SaveChanges();

        }

        public void Update(Comentario comentarioModificado)
        {
            var comentario = this._context.Comentarios.Find(comentarioModificado.Id);
            comentario.Texto = comentarioModificado.Texto;

            this._context.Entry(comentario).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}

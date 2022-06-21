using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Repositories
{
    public class CalificacionRepository
    {
        private RestauEFContext _context;

        public CalificacionRepository(RestauEFContext context)
        {
            this._context = context;
        }

        public void Insert(Calificacion calificacion)
        {
            this._context.Calificaciones.Add(calificacion);
            this._context.SaveChanges();
        }
        public void Update(Calificacion calificacionModificada)
        {
            Calificacion calificacion = (Calificacion)this._context.Calificaciones.Where(x => (x.IdReceta == calificacionModificada.IdReceta) && (x.IdUsuario == calificacionModificada.IdUsuario));
           
            calificacion.Valor = calificacionModificada.Valor;

            this._context.Entry(calificacion).State = System.Data.Entity.EntityState.Modified;

            this._context.SaveChanges();
        }

        public void Delete(int idUsuario, int idReceta)
        {
            Calificacion entity = (Calificacion)this._context.Calificaciones.Where(x => (x.IdReceta == idReceta) && (x.IdUsuario == idUsuario));

            this._context.Calificaciones.Remove(entity);
            this._context.SaveChanges();
        }

    }
}

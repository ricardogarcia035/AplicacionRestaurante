using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Repositories;
using Domain.Entities;

namespace Restaurante_v1.Restaurante_Services
{
    public class PublicacionCtrl
    {
        private readonly PublicacionRepository _repository;
        private readonly RecetaRepository _recetaRepository;
        private readonly ComentarioRepository _comentarioRepository;

        public PublicacionCtrl(RestauEFContext contx)
        {
            this._repository = new PublicacionRepository(contx);
            this._recetaRepository = new RecetaRepository(contx);
            this._comentarioRepository = new ComentarioRepository(contx);
        }
        public PublicacionCtrl(PublicacionRepository repository)
        {
            this._repository = repository;
        }
        public List<Publicacion> Get(int[] idCategorias = null,int ? id = null, int? idReceta = null, int? idUsuario = null, string nombre = "", DateTime? from = null, DateTime? to = null, bool estado=true)
        {
            var list = this._repository.Get(idCategorias, id, idReceta, idUsuario, nombre, from, to, estado);

            return list;
        }
        public Publicacion Insert(int idReceta, string descripcion)
        {
            var entity = new Publicacion();

            Receta receta = this._recetaRepository.GetById(idReceta);

            entity.Fecha = DateTime.Now;
            entity.Descripcion = descripcion;
            entity.Receta = receta;
            
            this._repository.Insert(entity);

            return entity;
        }
        public Publicacion Update(int id, string descripcion)
        {
            Publicacion entity = _repository.GetById(id);

            entity.Descripcion = descripcion;

            this._repository.Update(entity);

            return entity;

        }
        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        //comentarios
        public Comentario InsertComentario(string texto, int idUsuario, int idPublicacion)
        {

            var entity = new Comentario();

            entity.Texto = texto;
            entity.IdPublicacion = idPublicacion;
            entity.IdUsuario = idUsuario;
            entity.Fecha = DateTime.Now;

            this._comentarioRepository.Insert(entity);

            return entity;
        }

        public List<Comentario> GetComentariosPublicacion(int idPublicacion)
        {
            var publicacion = this._repository.GetById(idPublicacion);
            List<Comentario> list = publicacion.Comentarios;

            return list;  
        }
        //agregar id de la publicacion y consultar
        public void DeleteComentario(int idComentario, int idPublicacion)
        {
            var publicacion = this._repository.GetById(idPublicacion);
            if (!(publicacion is null))
            {
                this._comentarioRepository.Delete(idComentario);
            }
        }

        public Comentario UpdateComentario(int idComentario, string texto)
        {

            Comentario entity = new Comentario();
            entity.Id = idComentario;
            entity.Texto = texto;

            this._comentarioRepository.Update(entity);

            return entity;
        }


        /*public Publicacion Update(int id, string descripcion)
        {
            Publicacion entity = new Publicacion;

            entity.Descripcion = descripcion;

            this._repository.Update(entity);

            return entity;

        }*/
    }
}

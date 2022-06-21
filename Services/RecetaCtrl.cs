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
    public class RecetaCtrl
    {
        private readonly RecetaRepository _repository;
        private readonly CalificacionRepository _calificacionRepository;
        private readonly CategoriaRepository _categoriaRepository;

        public RecetaCtrl(RestauEFContext contx)
        {
            this._repository = new RecetaRepository(contx);
            this._calificacionRepository = new CalificacionRepository(contx);
            this._categoriaRepository = new CategoriaRepository(contx);
        }
        public RecetaCtrl(RecetaRepository repository)
        {
            this._repository = repository;
        }

        public List<Receta> Get(int[] idCategorias = null, int? id = null, string nombre = "", string ingredientes = "", int? idUsuario = null, DateTime? from = null, DateTime? to = null)
        {

            var receta = this._repository.Get(idCategorias, id, nombre, ingredientes, idUsuario, from, to);

            return receta;
        }
        public Receta Insert(int[] idCategorias,string nombre, string ingredientes, string instrucciones, string direccionFoto, int idUsuario)
        {
            var entity = new Receta();

            var listCategorias = new List<Categoria>();

            foreach (var el in idCategorias)
            {
                Categoria categoria = new Categoria();
                categoria = this._categoriaRepository.GetById(el);
                listCategorias.Add(categoria);    
            }
            entity.Nombre = nombre;
            entity.Ingredientes = ingredientes;
            entity.Instrucciones = instrucciones;
            entity.DireccionFoto = direccionFoto;
            entity.IdUsuario = idUsuario;
            entity.Estado = true;
            entity.Categorias = listCategorias;
            entity.Fecha = DateTime.Now;

            this._repository.Insert(entity);

            return entity;
        }
        public Receta Update(int[] idCategorias, int id, string nombre, string ingredientes, string instrucciones, string direccionFoto)
        {

            var listCategorias = new List<Categoria>();

            foreach (var el in idCategorias)
            {
                Categoria categoria = new Categoria();
                categoria = this._categoriaRepository.GetById(el);
                listCategorias.Add(categoria);
            }

            Receta entity = new Receta();

            entity.Id = id;
            entity.Nombre = nombre;
            entity.Ingredientes = ingredientes;
            entity.Instrucciones = instrucciones;
            entity.DireccionFoto = direccionFoto;
            entity.Categorias = listCategorias;

            this._repository.Update(entity, id);

            return entity;

        }
        //eliminar receta
        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public void Ocultar(int id, bool estado)
        {
            this._repository.Ocultar(id, estado); 
        }
        

        //calificacion
        public Calificacion InsertCalificacion(int idUsuario, int idReceta, int valor) {
            var entity = new Calificacion();

            entity.Valor = valor;
            entity.IdReceta = idReceta;
            entity.IdUsuario = idUsuario;
            entity.Fecha = DateTime.Now;

            try
            {
                this._calificacionRepository.Insert(entity);
            } catch (Exception ex)
            {
                Console.WriteLine("Ya existe una calificación del usuario en esta receta");
            }
            return entity;
        }
        public Calificacion UpdateCalificacion(int idUsuario, int idReceta, int valor)
        {
            var entity = new Calificacion();

            entity.Valor = valor;
            entity.IdReceta = idReceta;
            entity.IdUsuario = idUsuario;
            this._calificacionRepository.Update(entity);

            return entity;
        }

        public void DeleteCalificacion(int idUsuario, int idReceta )
        {   
            this._calificacionRepository.Delete(idUsuario, idReceta);
        }

        /*public Receta GetbyId(int id)
        {
            var receta = this._repository.Get(id);
            //receta.Calificacion = this._calificacionRepository.GetById(receta.Id);
            
            return receta;
        }*/

        /*if (!(idCategorias is null))
         {
             foreach (var el in idCategorias)
             {
                 Categoria categoria = new Categoria();
                 categoria = this._categoriaRepository.Get(el);
                 listCategorias.Add(categoria);
             }
         }
         else {
                 listCategorias = this._categoriaRepository.Get();
         }
         */

        /*var listCategorias = new List<Categoria>();
if (!(idCategorias is null)) { 
foreach (var el in idCategorias)
    {
        Categoria categoria = new Categoria();
        categoria = this._categoriaRepository.GetById(el);
        listCategorias.Add(categoria);
    }
}*/

    }
}

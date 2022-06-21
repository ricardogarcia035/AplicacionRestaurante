using Data;
using Data.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurante_v1.Restaurante_Services
{
    public class CategoriaCtrl
    {
        private readonly CategoriaRepository _repository;

        public CategoriaCtrl(RestauEFContext contx)
        {
            this._repository = new CategoriaRepository(contx);
        }
        public CategoriaCtrl(CategoriaRepository repository)
        {
            this._repository = repository;
        }
        public Categoria Insert(string name)
        {

            var entity = new Categoria();
            entity.Nombre = name;
            this._repository.Insert(entity);
            return entity;
        }
        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public List<Categoria> GetList()
        {
            var list = this._repository.Get();
            return list;
        }

    }
}

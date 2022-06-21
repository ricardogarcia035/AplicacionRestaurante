using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Domain.Entities;

namespace Data
{
    public partial class RestauEFContext : DbContext
    {
        public RestauEFContext() : base("name=Restaurante1")
        {
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Receta>().ToTable("Recetas");
            modelBuilder.Entity<Publicacion>().ToTable("Publicaciones");
            modelBuilder.Entity<Comentario>().ToTable("Comentarios");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Calificacion>().ToTable("Calificaciones");

            modelBuilder.Entity<Publicacion>().HasRequired(x => x.Receta).WithMany().HasForeignKey(x => x.IdReceta);

            modelBuilder.Entity<Publicacion>().HasMany(x => x.Comentarios).WithRequired().HasForeignKey(x => x.IdPublicacion);//cambiar
            
            modelBuilder.Entity<Calificacion>().HasKey(x => new { x.IdUsuario, x.IdReceta });

            modelBuilder.Entity<Receta>().HasMany(x => x.Calificaciones).WithRequired().HasForeignKey(x => x.IdReceta);

            modelBuilder.Entity<Receta>().HasMany<Categoria>(x => x.Categorias).WithMany()
                .Map(ru =>
                {
                    ru.MapLeftKey("IdReceta");
                    ru.MapRightKey("IdCategoria");
                    ru.ToTable("RecetaCategorias");
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

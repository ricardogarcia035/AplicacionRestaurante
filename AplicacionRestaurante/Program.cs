using Data;
using Domain.Entities;
using Restaurante_v1.Restaurante_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRestaurante
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RestauEFContext();

            var publicacion = new PublicacionCtrl(db);
            var receta = new RecetaCtrl(db);
            var categoria = new CategoriaCtrl(db);

            string flag2;
            string flag;
            do {
                
                Console.WriteLine("1 Recetas");
                Console.WriteLine("2 Publicaciones");
                Console.WriteLine("3 Categorias");
                 flag = Console.ReadLine();
                Console.WriteLine("--------------------------------");

                if (flag == "1")
                {
                    
                    Console.WriteLine("1 Consultar Recetas");
                    Console.WriteLine("2 Insertar Receta");
                    Console.WriteLine("3 Actualizar Receta");
                    Console.WriteLine("4 Eliminar Receta");
                    Console.WriteLine("5 Ocultar Receta");
                    Console.WriteLine("6 Calificar Receta");
                    Console.WriteLine("7 Consultar por categoria [Postres]");
                    flag2 = Console.ReadLine();
                    Console.WriteLine("--------------------------------");
                    if (flag2 == "1")
                    {
                        var list = receta.Get(null,null, null, null, 1, null,null);

                        foreach (var item in list)
                        {
                            
                            Console.WriteLine("Receta");
                            Console.WriteLine(item.Nombre);
                            Console.WriteLine("Id de la receta: " + item.Id);
                            Console.WriteLine("Id del usuario: " + item.IdUsuario);
                            Console.WriteLine("Ingredientes: " + item.Ingredientes);
                            Console.WriteLine("Instrucciones: " + item.Instrucciones);
                            Console.WriteLine("Calificación: " + item.Calificacion);
                            List<Categoria> lst = item.Categorias;
                            Console.Write("Categorias:");
                            foreach (var cate in lst)
                            {
                                Console.Write(cate.Nombre + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------");
                        }
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                        
                    }
                    else if (flag2 == "2")
                    {
                        int[] array = new int[] { 4 };
                        var list2 = receta.Insert(array, "Pastel", "Harina, leche, huevos", "Paso 1, Paso 2, Paso 3", "Enlace.com", 2);


                        Console.WriteLine("Receta");
                        Console.WriteLine(list2.Nombre);
                        Console.WriteLine("Id de la receta: " + list2.Id);
                        Console.WriteLine("Id del usuario: " + list2.IdUsuario);
                        Console.WriteLine("Ingredientes: " + list2.Ingredientes);
                        Console.WriteLine("Instrucciones: " + list2.Instrucciones);
                        
                        List<Categoria> lst = list2.Categorias;
                        Console.Write("Categorias:");
                        foreach (var cate in lst)
                        {
                            Console.Write(cate.Nombre + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }
                    else if (flag2 == "3")
                    {
                        int[] array = new int[] { 4 };
                        var list3 = receta.Update(array, 1, "Pastel", "Harina, leche, huevos", "Paso 1, Paso 2, Paso 3, Paso 4", "Enlace.com");
                        
                        Console.WriteLine("Receta");
                        Console.WriteLine(list3.Nombre);
                        Console.WriteLine("Id de la receta: " + list3.Id);
                        //Console.WriteLine("Id del usuario: " + list3.IdUsuario);
                        Console.WriteLine("Ingredientes: " + list3.Ingredientes);
                        Console.WriteLine("Instrucciones: " + list3.Instrucciones);
                        Console.WriteLine("Calificación: " + list3.Calificacion);
                        List<Categoria> lst = list3.Categorias;
                        Console.Write("Categorias:");
                        foreach (var cate in lst)
                        {
                            Console.Write(cate.Nombre + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Seguir");
                        Console.ReadKey();

                    }
                    else if (flag2 == "4")
                    {
                       
                        Console.WriteLine("Ingrese la receta a eliminar:");
                        int idrec = Convert.ToInt32(Console.ReadLine());
                        receta.Delete(idrec);
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }
                    else if (flag2 == "5")
                    {
                        
                        Console.WriteLine("Ingrese la Id de la receta:");
                        int idrec = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Desea ocultar[1] o mostrar de nuevo [2]:");
                        string ocult = Console.ReadLine();
                        if (ocult == "1")
                        {
                            receta.Ocultar(idrec, false);
                        }
                        else if (ocult == "2")
                        {
                            receta.Ocultar(idrec, true);
                        }
                        Console.WriteLine("Cambio realizado");
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }
                    else if (flag2 == "6")
                    {
                        
                        Console.WriteLine("Ingrese la Id de la receta:");
                        int idrec = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese la calificación:");
                        int cal = Convert.ToInt32(Console.ReadLine());
                        receta.InsertCalificacion(2, idrec, cal);
                        //Console.WriteLine("Calificación realizada");
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }
                    else if (flag2 == "7")
                    {
                        int[] array = new int[] { 4 };
                        var list = receta.Get(array, null, null, null, null, null, null);

                        foreach (var item in list)
                        {

                            Console.WriteLine("Receta");
                            Console.WriteLine(item.Nombre);
                            Console.WriteLine("Id de la receta: " + item.Id);
                            Console.WriteLine("Id del usuario: " + item.IdUsuario);
                            Console.WriteLine("Ingredientes: " + item.Ingredientes);
                            Console.WriteLine("Instrucciones: " + item.Instrucciones);
                            Console.WriteLine("Calificación: " + item.Calificacion);
                            List<Categoria> lst = item.Categorias;
                            Console.Write("Categorias:");
                            foreach (var cate in lst)
                            {
                                Console.Write(cate.Nombre + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------");
                        }
                        Console.WriteLine("Seguir");
                        Console.ReadKey();

                    }
                }
                else if (flag == "2")
                {
                    
                    Console.WriteLine("1 Consultar Publicacion");
                    Console.WriteLine("2 Insertar Publicacion");
                    Console.WriteLine("3 Actualizar Publicacion");
                    Console.WriteLine("4 Eliminar Publicacion");
                    Console.WriteLine("5 Comentar Publicacion");
                    Console.WriteLine("6 Editar Comentario");
                    Console.WriteLine("7 Eliminar Comentario");
                    Console.WriteLine("8 Consultar publicacion por categoria");
                    flag2 = Console.ReadLine();
                    if (flag2 == "1")
                    {
                        var publi = publicacion.Get(null, null, null, null, null, null,null,true);

                        foreach (var item in publi)
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Receta");
                            Console.WriteLine(item.Receta.Nombre);
                            Console.WriteLine(item.Descripcion);
                            Console.WriteLine("Id de la publicacion: " + item.Id);
                            Console.WriteLine("Id del usuario: " + item.Receta.IdUsuario);
                            Console.WriteLine("Estado: " + item.Receta.Estado);
                            Console.WriteLine("Ingredientes: " + item.Receta.Ingredientes);
                            Console.WriteLine("Instrucciones: " + item.Receta.Instrucciones);
                            Console.WriteLine("Calificacion: " + item.Receta.Calificacion);
                            List<Categoria> lstCate = item.Receta.Categorias;
                            Console.Write("Categorias:");
                            foreach (var cate in lstCate)
                            {
                                Console.Write(cate.Nombre + " ");
                            }
                            List<Comentario> lstComen = item.Comentarios;
                            Console.WriteLine("\nComentarios:");
                            if (!(lstComen is null))
                            {
                                foreach (var cate in lstComen)
                                {
                                    Console.WriteLine(cate.Texto + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Seguir");
                        Console.ReadKey();

                    }
                    else if (flag2 == "2")
                    {
                        
                        var item = publicacion.Insert(2, "Buenos dias");

                        
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Receta");
                            Console.WriteLine(item.Receta.Nombre);
                            Console.WriteLine(item.Descripcion);
                            Console.WriteLine("Id de la publicacion: " + item.Id);
                            Console.WriteLine("Id del usuario: " + item.Receta.IdUsuario);
                            Console.WriteLine("Ingredientes: " + item.Receta.Ingredientes);
                            Console.WriteLine("Instrucciones: " + item.Receta.Instrucciones);
                            Console.WriteLine("Calificacion: " + item.Receta.Calificacion);
                            List<Categoria> lstCate = item.Receta.Categorias;
                            Console.Write("Categorias:");
                            foreach (var cate in lstCate)
                            {
                                Console.Write(cate.Nombre + " ");
                            }
                            List<Comentario> lstComen = item.Comentarios;


                            Console.WriteLine("\nComentarios:");
                            if (!(lstComen is null))
                            {

                                Console.WriteLine("\nComentarios:");
                                foreach (var cate in lstComen)
                                {
                                    Console.WriteLine(cate.Texto + " ");
                                }
                            }
                            Console.WriteLine();
                        
                        Console.WriteLine();
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }
                    else if (flag2 == "3")
                    {
                        var item = publicacion.Update(1,"Buenas tardes");


                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Receta");
                        Console.WriteLine(item.Receta.Nombre);
                        Console.WriteLine(item.Descripcion);
                        Console.WriteLine("Id de la publicacion: " + item.Id);
                        Console.WriteLine("Id del usuario: " + item.Receta.IdUsuario);
                        Console.WriteLine("Ingredientes: " + item.Receta.Ingredientes);
                        Console.WriteLine("Instrucciones: " + item.Receta.Instrucciones);
                        Console.WriteLine("Calificacion: " + item.Receta.Calificacion);
                        List<Categoria> lstCate = item.Receta.Categorias;
                        Console.Write("Categorias:");
                        foreach (var cate in lstCate)
                        {
                            Console.Write(cate.Nombre + " ");
                        }
                        List<Comentario> lstComen = item.Comentarios;
                        Console.WriteLine("\nComentarios:");
                        foreach (var cate in lstComen)
                        {
                            Console.WriteLine(cate.Texto + " ");
                        }
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.WriteLine("Seguir");
                        Console.ReadKey();

                    }
                    else if (flag2 == "4")
                    {

                        Console.WriteLine("Ingrese la publicacion a eliminar:");
                        int idPub = Convert.ToInt32(Console.ReadLine());
                        publicacion.Delete(idPub);
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }
                    else if (flag2 == "5")
                    {
                        var com = publicacion.InsertComentario("Muy bueno",2,1);
                        Console.WriteLine("Id del comentario: "+com.Id);
                        Console.WriteLine(com.Texto);
                        
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }
                    else if (flag2 == "6")
                    {

                        var com = publicacion.UpdateComentario(1,"Muy bueno");

                        Console.WriteLine(com.Texto);

                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }
                    else if (flag2 == "7")
                    {
                        Console.WriteLine("Ingrese la publicación del comentario:");
                        int idPub = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el comentario a eliminar:");
                        int idCom = Convert.ToInt32(Console.ReadLine());
                        publicacion.DeleteComentario(idCom,idPub);
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }
                    else if (flag2 == "8")
                    {
                        int[] array = new int[] { 4 };
                        var publi = publicacion.Get(array, null, null, null, null, null,null,true);

                        foreach (var item in publi)
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Receta");
                            Console.WriteLine(item.Receta.Nombre);
                            Console.WriteLine(item.Descripcion);
                            Console.WriteLine("Id de la publicacion: " + item.Id);
                            Console.WriteLine("Id del usuario: " + item.Receta.IdUsuario);
                            Console.WriteLine("Ingredientes: " + item.Receta.Ingredientes);
                            Console.WriteLine("Instrucciones: " + item.Receta.Instrucciones);
                            Console.WriteLine("Calificacion: " + item.Receta.Calificacion);
                            List<Categoria> lstCate = item.Receta.Categorias;
                            Console.Write("Categorias:");
                            foreach (var cate in lstCate)
                            {
                                Console.Write(cate.Nombre + " ");
                            }
                            List<Comentario> lstComen = item.Comentarios;
                            Console.WriteLine("\nComentarios:");
                            if (!(lstComen is null))
                            {
                                foreach (var cate in lstComen)
                                {
                                    Console.WriteLine(cate.Texto + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Seguir");
                        Console.ReadKey();

                    }
                }
                else if (flag == "3")
                {
                    
                    Console.WriteLine("1 Subir Categoria");
                    Console.WriteLine("2 Consultar Categorias");
                    
                    flag2 = Console.ReadLine();
                    if (flag2 == "1")
                    {

                        Console.WriteLine("Ingrese el nombre de la categoria:");
                        string nombreCat = Console.ReadLine();
                        var item =categoria.Insert(nombreCat);
                        Console.WriteLine("Id de la categoria: "+item.Id);
                        Console.WriteLine("Nombre de la categoria: " + item.Nombre);
                        Console.WriteLine("Seguir");
                        Console.ReadKey();

                    }
                    else if (flag2 == "2")
                    {

                        var cat = categoria.GetList();
                        Console.WriteLine("Categorias:");
                        foreach (var item in cat)
                        {
                            Console.WriteLine(item.Nombre);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Seguir");
                        Console.ReadKey();
                    }

                }
                Console.Clear();
            } while (flag!="e");


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();



            //Categorias
            //Insertar
            /*categoria.Insert("Vegetariano");
            categoria.Insert("Carnes");
            categoria.Insert("Pastas");
            categoria.Insert("Postres");
            */

            //Recetas
            //Insertar
            /*
                int[] array = new int[] { 4 };
                int[] array2 = new int[] { 2,3 };
                int[] array3 = new int[] { 4 };
                receta.Insert(array, "Pastel", "Harina, leche, huevos", "Paso 1, Paso 2, Paso 3", "Enlace.com", 1);
                receta.Insert(array2, "Pizza pepperoni", "Queso, masa, tomates, peperoni ", "Paso 1, Paso 2, Paso 3", "Enlace.com", 1);
                receta.Insert(array3, "Galletas", "Harina, leche, huevos", "Paso 1, Paso 2, Paso 3", "Enlace.com", 1);
                
            */
            //Obtener receta
            /*
             var list= receta.Get(null,null,null,1,null,null);

            foreach (var item in list)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Receta");
                Console.WriteLine( item.Nombre);
                Console.WriteLine("Id de la receta: "+item.Id);
                Console.WriteLine("Id del usuario: " + item.IdUsuario);  
                Console.WriteLine("Ingredientes: "+item.Ingredientes);
                Console.WriteLine("Instrucciones: "+item.Instrucciones);
                Console.WriteLine("Calificacion: " + item.Calificacion);
                List<Categoria> lst = item.Categorias;
                Console.Write("Categorias:");
                foreach (var cate in lst)
                {
                    Console.Write(cate.Nombre+" ");
                }
                Console.WriteLine();
            }
            //Actualizar
              int[] array = new int[] { 4 };
            receta.Update(array, 1, "Pastel", "Harina, leche, huevos", "Paso 1, Paso 2, Paso 3, Paso 4", "Enlace.com");
            
            receta.Ocultar(2, true);

            receta.Delete(3);
           
 
             */
            //Insertar calificacion
            /* receta.Calificar(2, 1, 9);
             receta.Calificar(3, 1, 7);
            */


            //Publicacion
            //Insertar
            /*
                publicacion.Insert(1, "Buenos dias");
                publicacion.Insert(2, "Buenos tardes");
                publicacion.Insert(3, "Buenos noches");
             */
            //InsertarComentario
            /*publicacion.InsertComentario("Muy bueno", 2, 1);
            publicacion.InsertComentario("Excelente", 3, 1);
            */
            //Obtener comentarios de una publicacion
            /*var lst = publicacion.GetComentariosByPublicacion(1);
            Console.WriteLine("Comentarios: ");
            foreach (var item in lst)
            {
                Console.WriteLine(item.Texto);

            }*/

            //Obtener publicacion
            /* var publi = publicacion.Get(1, null, null, null, null, null);

             foreach (var item in publi)
             {
                 Console.WriteLine("--------------------------------");
                 Console.WriteLine("Receta");
                 Console.WriteLine(item.Receta.Nombre);
                 Console.WriteLine(item.Descripcion);
                 Console.WriteLine("Id de la publicacion: " + item.Id);
                 Console.WriteLine("Id del usuario: " + item.Receta.IdUsuario);
                 Console.WriteLine("Ingredientes: " + item.Receta.Ingredientes);
                 Console.WriteLine("Instrucciones: " + item.Receta.Instrucciones);
                 Console.WriteLine("Calificacion: " + item.Receta.Calificacion);
                 List<Categoria> lstCate = item.Receta.Categorias;
                 Console.Write("Categorias:");
                 foreach (var cate in lstCate)
                 {
                     Console.Write(cate.Nombre + " ");
                 }
                 List<Comentario> lstComen = item.Comentarios;
                 Console.WriteLine("\nComentarios:");
                 foreach (var cate in lstComen)
                 {
                     Console.WriteLine(cate.Texto + " ");
                 }
                 Console.WriteLine();
             }
            */

            //Categorias
            //Obtener Categorias
            /*
             var list = categoria.GetList();
            Console.WriteLine("Todas las categorias en la base de datos:");
            foreach (var item in list)
            {
                Console.WriteLine(item.Nombre);
            }
             */
        }
    }
}

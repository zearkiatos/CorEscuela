using System;
using CorEscuela.Entities;
using CorEscuela.Entities.Enum;

namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Escuela Platzi",2006,TipoEscuelas.PreEscolar,pais:"Colombia",ciudad:"Bogotá");

            var curso1 = new Curso(){
                Nombre = "101",
            };

            var curso2 = new Curso(){
                Nombre = "201",
            };

            var curso3 = new Curso(){
                Nombre = "301",
            };
            Console.WriteLine(escuela);
            System.Console.WriteLine("================");
            System.Console.WriteLine($"{curso1.Nombre}, {curso1.UniqueId}");
            System.Console.WriteLine($"{curso2.Nombre}, {curso2.UniqueId}");
        }
    }
}

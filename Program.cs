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
            Console.WriteLine(escuela);
        }
    }
}

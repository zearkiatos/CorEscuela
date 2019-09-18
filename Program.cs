using System;
using CorEscuela.Entities;
using CorEscuela.Entities.Enum;

namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Escuela Platzi",2006);
            
            escuela.TipoEscuela = TipoEscuelas.Primaria;
            Console.WriteLine(escuela);
        }
    }
}

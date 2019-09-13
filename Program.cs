using System;
using CorEscuela.Entities;

namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela();
            escuela.Nombre = "Platzi Escuela";
            
            Console.WriteLine("Hello World!");
        }
    }
}

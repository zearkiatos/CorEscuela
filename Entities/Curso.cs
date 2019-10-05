using System;
using System.Collections.Generic;
using CorEscuela.Entities.Enum;
using CorEscuela.Entities.Interfaces;
using CorEscuela.Utils;

namespace CorEscuela.Entities
{
    public class Curso : ObjetoEscuelaBase, ILugar
    {

        public TipoJornadas Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public string Direccion { get; set; }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Curso...");
            Console.WriteLine($"Curso {Nombre} esta Limpio");
        }
    }
}
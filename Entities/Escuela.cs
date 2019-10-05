using System;
using System.Collections.Generic;
using CorEscuela.Entities.Enum;
using CorEscuela.Entities.Interfaces;
using CorEscuela.Utils;

namespace CorEscuela.Entities
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        public Escuela(int anioDeCreacion, string pais, string ciudad, string direccion, TipoEscuelas tipoEscuela)
        {
            this.AnioDeCreacion = anioDeCreacion;
            this.Pais = pais;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
            this.TipoEscuela = tipoEscuela;

        }
        public int AnioDeCreacion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public string Direccion { get; set; }


        public TipoEscuelas TipoEscuela { get; set; }

        public Escuela(string nombre, int anio) => (Nombre, AnioDeCreacion) = (nombre, anio);

        public Escuela(string nombre, int anio, TipoEscuelas tipo, string pais = "", string ciudad = "")
        {
            (Nombre, AnioDeCreacion) = (nombre, anio);
            Pais = pais;
            Ciudad = ciudad;

        }

        public List<Curso> Cursos { get; set; }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\" , Tipo: {TipoEscuela} \n Pais: {System.Environment.NewLine} {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela...");
            try
            {
                Printer.Beep(1000, qty: 3);
            }
            catch (PlatformNotSupportedException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                foreach (var curso in Cursos)
                {
                    curso.LimpiarLugar();
                }
                Printer.WriteTitle($"Escuela {Nombre} esta Limpio");
            }

        }
    }
}
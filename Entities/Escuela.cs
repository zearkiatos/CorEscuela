using System.Collections.Generic;
using CorEscuela.Entities.Enum;

namespace CorEscuela.Entities
{
    class Escuela
    {
        private string nombre;

        public string Nombre
        {
            get{ return nombre;}

            set{ nombre = value.ToUpper();}
        }

        public int AnioDeCreacion{ get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }


        public TipoEscuelas TipoEscuela { get; set; }

        public Escuela(string nombre, int anio) =>(Nombre, AnioDeCreacion) = (nombre, anio);

        public Escuela(string nombre, int anio, TipoEscuelas tipo, string pais="", string ciudad="")
        {
            (Nombre, AnioDeCreacion)=(nombre, anio);
            Pais = pais;
            Ciudad = ciudad;
    
        }

        public List<Curso> Cursos { get; set; }

        public override string ToString(){
            return $"Nombre: \"{Nombre}\" , Tipo: {TipoEscuela} \n Pais: {System.Environment.NewLine} {Pais}, Ciudad: {Ciudad}";
        }
            

    }
}
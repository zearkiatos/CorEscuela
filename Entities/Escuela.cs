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

        public Escuela(string nombre, int anio)
        {
            this.nombre = nombre;
            this.AnioDeCreacion = anio;
    
        }

        public override string ToString(){
            return $"Nombre{Nombre} , Tipo{TipoEscuela} \n Pais{Pais}, Ciudad{Ciudad}";
        }
            

    }
}
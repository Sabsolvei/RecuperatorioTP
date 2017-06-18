using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class Profesor : Universitario
    {
        //Atributos ClasesDelDia del tipo Cola y random del tipo Random y estático.
        //Sobrescribir el método MostrarDatos con todos los datos del alumno.
        //ParticiparEnClase retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        //ToString hará públicos los datos del Profesor.

        //Se inicializará a Random sólo en un constructor.
        //En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor
        //mediante el método randomClases. Las dos clases pueden o no ser la misma.
        //Un Profesor será igual a un EClase si da esa clase.

        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        static Profesor()
        {
            Profesor._random = new Random();
        }
        private Profesor()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {

        }
        private void RandomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this._clasesDelDia.Enqueue((Universidad.EClases)(Profesor._random.Next(0, 2)));
            }
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool igualdad = false;
            foreach (Universidad.EClases claseI in i._clasesDelDia)
            {
                if (claseI == clase)
                {
                    igualdad = true;
                    break;
                }
            }
            return igualdad;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Universidad.EClases clase in this._clasesDelDia)
	        {
		        sb.AppendFormat("{0}\n", clase);
	        }
            return "CLASES DEL DIA: " + sb.ToString();  
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }


    }
}

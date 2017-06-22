using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #region CONSTRUCTORES

        static Profesor()
        {
            Profesor._random = new Random(DateTime.Now.Millisecond);
        }

        public Profesor()
            :base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }
     
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases();
        }

        #endregion

        #region MÉTODOS
        /// <summary>
        /// Se asignan dos clases al azar al Profesor
        /// </summary>
        private void RandomClases()
        {
            for (int i = 0; i < 2; i++)
            {              
                this._clasesDelDia.Enqueue((Universidad.EClases)(Profesor._random.Next(0, 3)));
            }
        }

        /// <summary>
        /// Devuelve string con los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        /// <summary>
        /// Retorna la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases clase in this._clasesDelDia)
            {
                sb.AppendLine(string.Format("{0}", clase.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Hace públicos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region OPERADORES SOBRECARGADOS

        /// <summary>
        /// Un Profesor es igual a una EClase si da esa clase.
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
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

   

        #endregion
    }
}

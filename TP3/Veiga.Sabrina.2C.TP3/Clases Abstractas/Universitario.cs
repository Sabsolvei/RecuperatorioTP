using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;


namespace EntidadesAbstractas
{   
    public abstract class Universitario : Persona
    {   
        private int _legajo;

        #region CONSTRUCTORES
        public Universitario()
            :base()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion

        #region OPERADORES SOBRECARGADOS
        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool igualdad = false;
            if ((pg1.GetType() == pg2.GetType()) && (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo))
            {
                igualdad = true;      
            }
            return igualdad;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            return this == ((Universitario)obj);
        }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Retorna todos los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat(string.Format("LEGAJO NÚMERO: {0}\n", this._legajo));
            return sb.ToString();
        }

        /// <summary>
        /// Método abstracto, implementado en las clases que heredan
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion


    }
}

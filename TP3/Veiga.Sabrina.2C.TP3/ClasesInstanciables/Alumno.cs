using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region ATRIBUTOS / ENUM

        public enum EEstadoCuenta { Becado, Deudor, AlDia }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region CONSTRUCTORES
        public Alumno()
            :base()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region MÉTODOS
        /// <summary>
        /// Retorna todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendLine(string.Format("ESTADO DE CUENTA: {0}", this._estadoCuenta));
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Retorna la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return (string.Format("TOMA CLASES DE: {0}", this._claseQueToma.ToString()));  
        }

        /// <summary>
        /// Hace públicos los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region OPERADORES SOBRECARGADOS
        /// <summary>
        /// Un Alumno es igual a una EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool igualdad = false;
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                igualdad = true;
            }
            return igualdad;
        }

        /// <summary>
        /// Un Alumno es distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool igualdad = false;
            if (a._claseQueToma != clase)
            {
                igualdad = true;
            }
            return igualdad;
        }

        public override bool Equals(object obj)
        {
            return this == ((Alumno)obj);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraClase
{
    public class Numero
    {
        private double _numero;

        /// <summary>
        /// Constructor de la clase 'Numero' sin parámetros.
        /// </summary>
        public Numero()
        {
            _numero = 0;
        }
        /// <summary>
        /// Sobrecarga del constructor con un parámetro de tipo double.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            _numero = numero;  
        }

        /// <summary>
        /// Sobrecarga del constructor con un parámetro del tipo string para validar el mismo.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            SetNumero(numero);
        }

        /// <summary>
        /// Funcion 'Getter': Devuelve el valor de la variables de la clase Numero.
        /// </summary>
        /// <returns>Retorna el valor de la variable privada '_numero'.</returns>
        public double GetNumero()
        {
            return _numero;
        }

        /// <summary>
        /// Función 'Setter': Guarda el valor enviado en la variable privada '_numero'.
        /// </summary>
        /// <param name="numero"></param>
        private void SetNumero(string numero)
        {
            _numero = Numero.ValidarNumero(numero);
        }

        /// <summary>
        /// Valida el número ingresado. 
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns>Devuelve el número ingresado. Si no es válido devuelve 0.</returns>
        private static double ValidarNumero(string numeroString)
        {
            double numero = 0;
            double.TryParse(numeroString, out numero);
            return numero;
        }
    }
}

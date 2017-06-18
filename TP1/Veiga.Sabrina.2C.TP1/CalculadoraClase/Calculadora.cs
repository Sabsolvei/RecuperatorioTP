using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraClase
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza operaciones matemáticas (suma, resta, multiplicación y división).
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double numeroUno = numero1.GetNumero();
            double numeroDos = numero2.GetNumero();
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case "-":
                    resultado = numeroUno - numeroDos;
                    break;

                case "*":
                    resultado = numeroUno * numeroDos;
                    break;

                case "/":
                    resultado = numeroUno / numeroDos;
                    if (numeroDos == 0)
                    {
                        resultado = 0;   
                    }
                    break;
                    
                default:
                    resultado = numeroUno + numeroDos;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida que el operador esté dentro de los posibles. Si no lo está devuelve signo "+".
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string ValidarOperador (string operador)
        {
            if (!(operador == "/" || operador == "*" || operador == "-"))
                operador = "+";
            return operador;

        }




    }
}

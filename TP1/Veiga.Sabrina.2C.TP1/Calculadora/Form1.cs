using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculadoraClase;


namespace CalculadoraForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNumero1.Text = "0.00";
            txtNumero2.Text = "0.00";
            lblResultado.Text = "0.00";
            cmbOperacion.Text = "+";
            btnOperar.Text = "=";
        }

        /// <summary>
        /// Ejecuta la operación matemática seleccionada de los valores ingresados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numeroUno = new Numero(txtNumero1.Text);
            Numero numeroDos = new Numero(txtNumero2.Text);

            cmbOperacion.Text = Calculadora.ValidarOperador(cmbOperacion.Text);
            lblResultado.Text = Calculadora.Operar(numeroUno, numeroDos, cmbOperacion.Text).ToString();
        }
        /// <summary>
        /// Resetea los valores de los textBox por default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "0.00";
            txtNumero2.Text = "0.00";
            lblResultado.Text = "0.00";
            cmbOperacion.Text = "+";
            
        }
    }
}

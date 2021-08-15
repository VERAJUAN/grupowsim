using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMULACION_TP1
{
    public partial class Mixto : System.Windows.Forms.Form
    {
        public Mixto()
        {
            InitializeComponent();
        }

        List<decimal> numAleatorios = new List<decimal>();
        int posicion = 0;

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            int a = int.Parse(txtA.Text);
            int c = int.Parse(txtC.Text);
            int m = int.Parse(txtM.Text);
            decimal xi = int.Parse(txtS.Text);

            for (int i = 1; i <= 50000; i++)
            {
                do
                {
                    xi = ((a * xi) + c) % m;
                }while(xi / (m - 1) == 1);

                numAleatorios.Add(xi);
                if(i < 21)
                {
                    dgvLista.Rows.Add(i, xi / (m - 1));
                }
            }

            posicion = 20;

            btnAgregar.Enabled = true;
            btnLimpiar.Enabled = true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtA.Text);
            int c = int.Parse(txtC.Text);
            int m = int.Parse(txtM.Text);

            for (int i = 1; i <= 20; i++)
            {
                decimal xi = numAleatorios.ElementAt(posicion - 1 + i);
                ///aleatorios.Insert(i, (int)(z % m));
                dgvLista.Rows.Add(posicion + i, xi / (m - 1));
            }

            posicion += 20;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnLimpiar.Enabled = false;

        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("El caracter ingresado no es un número ( " + e.KeyChar + " )", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("El caracter ingresado no es un número ( " + e.KeyChar + " )", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("El caracter ingresado no es un número ( " + e.KeyChar + " )", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("El caracter ingresado no es un número ( " + e.KeyChar + " )", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}

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
    public partial class Ejercicio__A : System.Windows.Forms.Form
    {
        public Ejercicio__A()
        {
            InitializeComponent();
        }
        
        List<decimal> numAleatorios = new List<decimal>();
        int posicion = 0;
        int a;
        int c;
        int m;

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            limpiar();
            a = int.Parse(txtA.Text);
            c = int.Parse(txtC.Text);
            m = int.Parse(txtM.Text);
            decimal xi = int.Parse(txtS.Text);

            for (int i = 1; i <= 50000; i++)
            {
                do
                {
                    if (radioButton1.Checked)
                    {
                        xi = ((a * xi)) % m;
                    }
                    else
                    {
                        xi = ((a * xi) + c) % m;
                    }
                } while (xi / (m - 1) == 1);

                numAleatorios.Add(xi);
                if (i < 21)
                {
                    dgvLista.Rows.Add(i, xi / (m - 1));
                }
            }

            posicion = 20;

            btnAgregar.Enabled = true;
            btnListarFinal.Enabled = true;
            btnListar.Enabled = true;
            txtDesde.Enabled = true;
            txtHasta.Enabled = true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            for (int i = 1; i <= 20; i++)
            {
                decimal xi = numAleatorios.ElementAt(posicion - 1 + i);
                ///aleatorios.Insert(i, (int)(z % m));
                dgvLista.Rows.Add(posicion + i, xi / (m - 1));
            }

            posicion += 20;
        }




        // Lista desde la posición que quedó hasta el 50mil
        private void button1_Click(object sender, EventArgs e)
        {
            while (posicion <= 50000)
            {
                decimal xi = numAleatorios.ElementAt(posicion - 1);
                ///aleatorios.Insert(i, (int)(z % m));
                dgvLista.Rows.Add(posicion, xi / (m - 1));
                posicion++;
            }

        }

        // Listar desde - hasta
        private void button2_Click(object sender, EventArgs e)
        {
            int desde = int.Parse(txtDesde.Text);
            int hasta = int.Parse(txtHasta.Text);

            if (desde < hasta)
            {
                dgvLista.Rows.Clear();
                posicion = desde;

                while (posicion <= hasta)
                {
                    decimal xi = numAleatorios.ElementAt(posicion - 1);
                    ///aleatorios.Insert(i, (int)(z % m));
                    dgvLista.Rows.Add(posicion, xi / (m - 1));
                    posicion++;
                }
            }
            else
            {
                MessageBox.Show("El valor DESDE es mayor a HASTA ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }



        private void limpiar()
        {
            btnAgregar.Enabled = false;
            btnListarFinal.Enabled = false;
            txtDesde.Enabled = false;
            txtHasta.Enabled = false;
            dgvLista.Rows.Clear();
        }

        // Keypress

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
                MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void txtM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                if ((int)e.KeyChar < 50)
                {
                    e.Handled = true;
                    MessageBox.Show("El caracter ingresado no debe ser menor a 2 ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    e.Handled = false;
                }
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void txtDesde_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void txtHasta_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        // Salir al menú
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Activación de métodos
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtC.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtC.Enabled = false;
        }
    }
}

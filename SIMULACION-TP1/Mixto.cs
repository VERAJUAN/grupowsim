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

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtA.Text);
            int c = Convert.ToInt32(txtC.Text);
            int m = Convert.ToInt32(txtM.Text);
            Double xi = Convert.ToDouble(txtS.Text);

            for (int i = 1; i <= 50000; i++)
            {
                xi = ((a * xi) + c) % m;
                ///aleatorios.Insert(i, (int)(z % m));
                dgvLista.Rows.Add(i, (xi / m));

            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtA.Text);
            int c = Convert.ToInt32(txtC.Text);
            int m = Convert.ToInt32(txtM.Text);
            Double xi = Convert.ToDouble(txtS.Text);
            for (int i = 1; i <= 20; i++)
            {
                xi = ((a * xi) + c) % m;
                ///aleatorios.Insert(i, (int)(z % m));
                dgvLista.Rows.Add(i + 20, (xi / m));

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}

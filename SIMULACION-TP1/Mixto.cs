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
    public partial class Mixto : Form
    {

        public Mixto()
        {
            InitializeComponent();
        }

        
        private void btnGenerar_Click(object sender, EventArgs e)
        {

            int a = (int)numA.Value;
            int c = (int)numC.Value;
            int m = (int)numC.Value;
            Double xi = (int)numS.Value;
            
            for (int i = 1; i <= 50000; i++)
            {
                    xi = ((a * xi) + c) % m;
                    ///aleatorios.Insert(i, (int)(z % m));
                    dgvLista.Rows.Add(i, (xi / m));
                
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int a = (int)numA.Value;
            int c = (int)numC.Value;
            int m = (int)numC.Value;
            Double xi = (int)numS.Value;
            for (int i = 1; i <= 20; i++)
            {
                xi = ((a * xi) + c) % m;
                ///aleatorios.Insert(i, (int)(z % m));
                dgvLista.Rows.Add(i+20, (xi / m));

            }
        }
    }
}

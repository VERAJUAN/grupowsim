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
    public partial class FormMixto : System.Windows.Forms.Form
    {
        public FormMixto()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
          
           
            for i = 1 To 20
                rnd = GenerarAleatorio()
                n = n + 1
                dgvLista.Rows.Add(New Object() { i, rnd})


            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}





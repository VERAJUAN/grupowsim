﻿using System;
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
    public partial class EjercicioA : System.Windows.Forms.Form
    {
        public EjercicioA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mixto ventana = new Mixto();
            ventana.Show();
        }
    }
}
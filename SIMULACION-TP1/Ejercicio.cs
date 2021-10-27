using Distribuciones;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace SIMULACION_TP1
{
    public partial class Ejercicio__B : System.Windows.Forms.Form
    {
        int cantProyectos = 0;        

        private void cboSignificancia_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDist1.SelectedIndex = 0;
        }

        public Ejercicio__B()
        {
            InitializeComponent();
            tablaVectorEstado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //SETEO INICIAL DE ACTIVIDADES
            comboDist1.SelectedIndex = 2;
            constante1_1.Text = "20";
            constante1_2.Text = "30";

            comboDist2.SelectedIndex = 2;
            constante2_1.Text = "30";
            constante2_2.Text = "50";

            comboDist3.SelectedIndex = 1;
            constante3_1.Text = "30";

            comboDist4.SelectedIndex = 2;
            constante4_1.Text = "10";
            constante4_2.Text = "30";

            comboDist5.SelectedIndex = 1;
            constante5_1.Text = "5";

        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            var val1 = validaciones(comboDist1.SelectedIndex, constante1_1.Text, constante1_2.Text);
            var val2 = validaciones(comboDist2.SelectedIndex, constante2_1.Text, constante2_2.Text);
            var val3 = validaciones(comboDist3.SelectedIndex, constante3_1.Text, constante3_2.Text);
            var val4 = validaciones(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text);
            var val5 = validaciones(comboDist5.SelectedIndex, constante5_1.Text, constante5_2.Text);
            if (int.Parse(txt_cantProy.Text) < 1)
            {
                MessageBox.Show("La cantidad de proyectos debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cantProy.Focus();
            }
  
            if(val1 && val2 && val3 && val4 && val5) Simular();
        }


        private void Simular(int desde = 0, int hasta = 0)
        {
            tablaVectorEstado.Rows.Clear();
            cantProyectos = int.Parse(txt_cantProy.Text);
            double A1, A2, A3, A4, A5;
            Random r = new Random();
            double RND1 = r.NextDouble();

            VectorEstadoDinamico vectorEstado = new VectorEstadoDinamico();
            VectorEstadoDinamico vectorEstadoMasUno = new VectorEstadoDinamico();

            for (int i = 0; i <= cantProyectos; i++)
            {
                List<double> lista = new List<double>();

                var numAleatorioLlegadaPedido = r.NextDouble();
                var tiempoEntrePedidos = GeneracionTiemposActividad(1, txtLambdaPedidos.Text, "", numAleatorioLlegadaPedido);

                var numAleatorio1 = r.NextDouble();
                A1 = GeneracionTiemposActividad(comboDist1.SelectedIndex, constante1_1.Text, constante1_2.Text, numAleatorio1);

                var numAleatorio2 = r.NextDouble();
                A2 = GeneracionTiemposActividad(comboDist2.SelectedIndex, constante2_1.Text, constante2_2.Text, numAleatorio2);

                var numAleatorio3 = r.NextDouble();
                A3 = GeneracionTiemposActividad(comboDist3.SelectedIndex, constante3_1.Text, constante3_2.Text, numAleatorio3);

                var numAleatorio4 = r.NextDouble();
                A4 = GeneracionTiemposActividad(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text, numAleatorio4);

                var numAleatorio5 = r.NextDouble();
                A5 = GeneracionTiemposActividad(comboDist5.SelectedIndex, constante5_1.Text, constante5_2.Text, numAleatorio5);

                if (i == 0)
                {
                    vectorEstado = new VectorEstadoDinamico(i + 1, tiempoEntrePedidos);

                    if (desde == 0 && hasta == 0)
                    {
                        //tablaVectorEstado.Rows.Add(0.ToString());

                        tablaVectorEstado.Rows.Add(vectorEstado.nroEvento.ToString(), vectorEstado.reloj.ToString(), (Evento)vectorEstado.evento, vectorEstado.pedido == 0 ? "-" : vectorEstado.pedido.ToString(),
                            vectorEstado.proxPedido.ToString(), ((Evento)vectorEstado.evento == Evento.LlegaPedido || (Evento)vectorEstado.evento == Evento.Inicio) ? numAleatorioLlegadaPedido.ToString() : "-", vectorEstado.tiempoEntrePedidos.ToString(), ((Evento)vectorEstado.evento == Evento.LlegaPedido || (Evento)vectorEstado.evento == Evento.Inicio) ? vectorEstado.proxLlegada.ToString() : "-",
                            (Estado)vectorEstado.a1Estado, vectorEstado.a1Pedido == 0 ? "-" : vectorEstado.a1Pedido.ToString(), (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? numAleatorio1.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a1Tiempo.ToString() : "-", vectorEstado.a1ProxFin == 0 ? "-" : vectorEstado.a1ProxFin.ToString(), vectorEstado.a1Cola.ToString(),
                            (Estado)vectorEstado.a2Estado, vectorEstado.a2Pedido == 0 ? "-" : vectorEstado.a2Pedido.ToString(), (i != 0 && vectorEstado.a2Pedido != vectorEstadoMasUno.a2Pedido) ? numAleatorio2.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a2Tiempo.ToString() : "-", vectorEstado.a2ProxFin == 0 ? "-" : vectorEstado.a2ProxFin.ToString(), vectorEstado.a2Cola.ToString(),
                            (Estado)vectorEstado.a3Estado, vectorEstado.a3Pedido == 0 ? "-" : vectorEstado.a3Pedido.ToString(), (i != 0 && vectorEstado.a3Pedido != vectorEstadoMasUno.a3Pedido) ? numAleatorio3.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a3Tiempo.ToString() : "-", vectorEstado.a3ProxFin == 0 ? "-" : vectorEstado.a3ProxFin.ToString(), vectorEstado.a3Cola.ToString(),
                            (Estado)vectorEstado.a4Estado, vectorEstado.a4Pedido == 0 ? "-" : vectorEstado.a4Pedido.ToString(), (i != 0 && vectorEstado.a4Pedido != vectorEstadoMasUno.a4Pedido) ? numAleatorio4.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a4Tiempo.ToString() : "-", vectorEstado.a4ProxFin == 0 ? "-" : vectorEstado.a4ProxFin.ToString(), vectorEstado.a4Cola.ToString(),
                            (Estado)vectorEstado.a5Estado, vectorEstado.a5Pedido == 0 ? "-" : vectorEstado.a5Pedido.ToString(), (i != 0 && vectorEstado.a5Pedido != vectorEstadoMasUno.a5Pedido) ? numAleatorio5.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a5Tiempo.ToString() : "-", vectorEstado.a5ProxFin == 0 ? "-" : vectorEstado.a5ProxFin.ToString(), vectorEstado.a5ColaA4.ToString(), vectorEstado.a5ColaA2.ToString());
                    }
                }
                else
                {

                    vectorEstado = new VectorEstadoDinamico(i + 1, tiempoEntrePedidos, A1, A2, A3, A4, A5, vectorEstadoMasUno);

                    if ((desde != 0 && hasta != 0
                        && vectorEstadoMasUno.nroEvento >= desde && vectorEstadoMasUno.nroEvento <= hasta)
                        ||
                        (desde == 0 && hasta == 0
                        && (vectorEstadoMasUno.nroEvento < 20 || vectorEstadoMasUno.nroEvento % 10000 == 0)
                        ))
                    {
                        tablaVectorEstado.Rows.Add(vectorEstado.nroEvento.ToString(), vectorEstado.reloj.ToString(), (Evento)vectorEstado.evento, vectorEstado.pedido == 0 ? "-" : vectorEstado.pedido.ToString(),
                            vectorEstado.proxPedido.ToString(), ((Evento)vectorEstado.evento == Evento.LlegaPedido || (Evento)vectorEstado.evento == Evento.Inicio) ? numAleatorioLlegadaPedido.ToString() : "-", vectorEstado.tiempoEntrePedidos.ToString(), ((Evento)vectorEstado.evento == Evento.LlegaPedido || (Evento)vectorEstado.evento == Evento.Inicio) ? vectorEstado.proxLlegada.ToString() : "-",
                            (Estado)vectorEstado.a1Estado, vectorEstado.a1Pedido == 0 ? "-" : vectorEstado.a1Pedido.ToString(), (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? numAleatorio1.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a1Tiempo.ToString() : "-", vectorEstado.a1ProxFin == 0 ? "-" : vectorEstado.a1ProxFin.ToString(), vectorEstado.a1Cola.ToString(),
                            (Estado)vectorEstado.a2Estado, vectorEstado.a2Pedido == 0 ? "-" : vectorEstado.a2Pedido.ToString(), (i != 0 && vectorEstado.a2Pedido != vectorEstadoMasUno.a2Pedido) ? numAleatorio2.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a2Tiempo.ToString() : "-", vectorEstado.a2ProxFin == 0 ? "-" : vectorEstado.a2ProxFin.ToString(), vectorEstado.a2Cola.ToString(),
                            (Estado)vectorEstado.a3Estado, vectorEstado.a3Pedido == 0 ? "-" : vectorEstado.a3Pedido.ToString(), (i != 0 && vectorEstado.a3Pedido != vectorEstadoMasUno.a3Pedido) ? numAleatorio3.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a3Tiempo.ToString() : "-", vectorEstado.a3ProxFin == 0 ? "-" : vectorEstado.a3ProxFin.ToString(), vectorEstado.a3Cola.ToString(),
                            (Estado)vectorEstado.a4Estado, vectorEstado.a4Pedido == 0 ? "-" : vectorEstado.a4Pedido.ToString(), (i != 0 && vectorEstado.a4Pedido != vectorEstadoMasUno.a4Pedido) ? numAleatorio4.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a4Tiempo.ToString() : "-", vectorEstado.a4ProxFin == 0 ? "-" : vectorEstado.a4ProxFin.ToString(), vectorEstado.a4Cola.ToString(),
                            (Estado)vectorEstado.a5Estado, vectorEstado.a5Pedido == 0 ? "-" : vectorEstado.a5Pedido.ToString(), (i != 0 && vectorEstado.a5Pedido != vectorEstadoMasUno.a5Pedido) ? numAleatorio5.ToString() : "-", (i != 0 && vectorEstado.a1Pedido != vectorEstadoMasUno.a1Pedido) ? vectorEstado.a5Tiempo.ToString() : "-", vectorEstado.a5ProxFin == 0 ? "-" : vectorEstado.a5ProxFin.ToString(), vectorEstado.a5ColaA4.ToString(), vectorEstado.a5ColaA2.ToString());
                    }

                    vectorEstadoMasUno = vectorEstado;
                    //vectorEstado = vectorEstadoMasUno;
                }
            }
        }

        private double GeneracionTiemposActividad(int comboDistrSelectedIndex, string constante1, string constante2, double xi)
        {
            switch (comboDistrSelectedIndex)
            {
                case 0:
                    //Normal
                    return Distribucion.Normal(xi, double.Parse(constante1), double.Parse(constante2));
                case 1:
                    //Exponencial
                    return Distribucion.Exponencial(xi, double.Parse(constante1));
                case 2:
                    // uniforme 
                    return Distribucion.Uniforme(xi, double.Parse(constante1), double.Parse(constante2));
                default:
                    return -1;
            }
        }

        private bool validaciones(int comboDistrSelectedIndex, string constante1, string constante2)
        {
            switch (comboDistrSelectedIndex)
            {
                case 0:
                    //Normal
                    if (double.Parse(constante2) < 0)
                    {
                        MessageBox.Show("Desviación tiene que ser positivo en la distribución normal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                case 1:
                    //Exponencial
                    if (double.Parse(constante1) <= 0)
                    {
                        MessageBox.Show("Lambda tiene que ser positivo en la distribución exponencial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                case 2:
                    // uniforme 
                    if ((double.Parse(constante1) > double.Parse(constante2)) || (double.Parse(constante1) < 0) || (double.Parse(constante2) < 0))
                    {
                        MessageBox.Show("Desde debe ser menor que hasta y no se pueden ingresar valores negativos en la distribución uniforme.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                default:
                    return true;
            }
        }

        //Keypress
        private void txt_m_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txt_k_KeyPress(object sender, KeyPressEventArgs e)
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
        private void constante1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void constante2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist1.SelectedIndex)
            {
                case 0:
                    label10.Text = "Media";
                    label11.Text = "Desviación";
                    label10.Visible = true;
                    label11.Visible = true;
                    constante1_1.Visible = true;
                    constante1_2.Visible = true;
                    break;

                case 1:
                    label10.Text = "Lambda";
                    label10.Visible = true;
                    label11.Visible = false;
                    constante1_1.Visible = true;
                    constante1_2.Visible = false;
                    break;
                case 2:
                    label10.Text = "Desde";
                    label11.Text = "Hasta";
                    label10.Visible = true;
                    label11.Visible = true;
                    constante1_1.Visible = true;
                    constante1_2.Visible = true;
                    break;
                default:

                    label10.Visible = false;
                    label11.Visible = false;
                    constante1_1.Visible = false;
                    constante1_2.Visible = false;
                    break;
            }
        }

        private void comboDist3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist3.SelectedIndex)
            {
                case 0:
                    label23.Text = "Media";
                    label22.Text = "Desviación";
                    label23.Visible = true;
                    label22.Visible = true;
                    constante3_1.Visible = true;
                    constante3_2.Visible = true;
                    break;

                case 1:
                    label23.Text = "Lambda";
                    label23.Visible = true;
                    label22.Visible = false;
                    constante3_1.Visible = true;
                    constante3_2.Visible = false;
                    break;
                case 2:
                    label23.Text = "Desde";
                    label22.Text = "Hasta";
                    label23.Visible = true;
                    label22.Visible = true;
                    constante3_1.Visible = true;
                    constante3_2.Visible = true;
                    break;
                default:

                    label23.Visible = false;
                    label22.Visible = false;
                    constante3_1.Visible = false;
                    constante3_2.Visible = false;
                    break;
            }
        }

        private void comboDist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist2.SelectedIndex)
            {
                case 0:
                    label19.Text = "Media";
                    label18.Text = "Desviación";
                    label19.Visible = true;
                    label18.Visible = true;
                    constante2_1.Visible = true;
                    constante2_2.Visible = true;
                    break;

                case 1:
                    label19.Text = "Lambda";
                    label19.Visible = true;
                    label18.Visible = false;
                    constante2_1.Visible = true;
                    constante2_2.Visible = false;
                    break;
                case 2:
                    label19.Text = "Desde";
                    label18.Text = "Hasta";
                    label19.Visible = true;
                    label18.Visible = true;
                    constante2_1.Visible = true;
                    constante2_2.Visible = true;
                    break;
                default:

                    label19.Visible = false;
                    label18.Visible = false;
                    constante2_1.Visible = false;
                    constante2_2.Visible = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int desde = int.Parse(txtDesde.Text);
            int hasta = int.Parse(txtHasta.Text);

            if (desde < hasta)
            {
                Simular(desde, hasta);
            }
            else
            {
                MessageBox.Show("El valor DESDE es mayor a HASTA ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void comboDist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist4.SelectedIndex)
            {
                case 0:
                    label27.Text = "Media";
                    label26.Text = "Desviación";
                    label27.Visible = true;
                    label26.Visible = true;
                    constante4_1.Visible = true;
                    constante4_2.Visible = true;
                    break;

                case 1:
                    label27.Text = "Lambda";
                    label27.Visible = true;
                    label26.Visible = false;
                    constante4_1.Visible = true;
                    constante4_2.Visible = false;
                    break;
                case 2:
                    label27.Text = "Desde";
                    label26.Text = "Hasta";
                    label27.Visible = true;
                    label26.Visible = true;
                    constante4_1.Visible = true;
                    constante4_2.Visible = true;
                    break;
                default:

                    label27.Visible = false;
                    label26.Visible = false;
                    constante4_1.Visible = false;
                    constante4_2.Visible = false;
                    break;
            }
        }

        private void comboDist5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist5.SelectedIndex)
            {
                case 0:
                    label31.Text = "Media";
                    label30.Text = "Desviación";
                    label31.Visible = true;
                    label30.Visible = true;
                    constante5_1.Visible = true;
                    constante5_2.Visible = true;
                    break;

                case 1:
                    label31.Text = "Lambda";
                    label31.Visible = true;
                    label30.Visible = false;
                    constante5_1.Visible = true;
                    constante5_2.Visible = false;
                    break;
                case 2:
                    label31.Text = "Desde";
                    label30.Text = "Hasta";
                    label31.Visible = true;
                    label30.Visible = true;
                    constante5_1.Visible = true;
                    constante5_2.Visible = true;
                    break;
                default:

                    label31.Visible = false;
                    label30.Visible = false;
                    constante5_1.Visible = false;
                    constante5_2.Visible = false;
                    break;
            }
        }

        private void Grafico_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_m_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_k_TextChanged(object sender, EventArgs e)
        {

        }

        private void constante1_TextChanged(object sender, EventArgs e)
        {

        }

        private void constante2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}


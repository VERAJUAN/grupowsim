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
        double picoTiempoDescarga = 0;
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

            //SETEO INICIAL EC DIFRENCIAL
            txtMinA.Text = "0,05";
            txtMaxA.Text = "2";
            txtB.Text = "10";
            txtC.Text = "5";
            txtH.Text = "0,05";
            txtX0.Text = "0";
            txtXder0.Text = "0";
            comboMetodo.SelectedIndex = 0;
            tablaEuler.Visible = false;
            tablaRK.Visible = false;
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

            SimularEcDif();

            if (val1 && val2 && val3 && val4 && val5) Simular();

        }

        private void SimularEcDif()
        {
            

            var primero = true;
            Random r = new Random();
            var a = Distribucion.Uniforme(r.NextDouble(), double.Parse(txtMinA.Text), double.Parse(txtMaxA.Text));
            var b = double.Parse(txtB.Text);
            var c = double.Parse(txtC.Text);
            var h = double.Parse(txtH.Text);
            var x0 = double.Parse(txtX0.Text);
            var xDeriv0 = double.Parse(txtXder0.Text);

            var metodo = comboMetodo.SelectedIndex;

            //// Genera Grafico 1
            Grafico.Series.Clear();
            if (Grafico.Titles.Count == 0)
                Grafico.Titles.Add("X'', X', X en funcion de t");

            Series g1Series1 = Grafico.Series.Add("X''");
            g1Series1.ChartType = SeriesChartType.Point;
            g1Series1.Points.Clear();

            Series g1Series2 = Grafico.Series.Add("X'");
            g1Series2.ChartType = SeriesChartType.Point;
            g1Series2.Points.Clear();

            Series g1Series3 = Grafico.Series.Add("X");
            g1Series3.ChartType = SeriesChartType.Point;
            g1Series3.Points.Clear();

            Grafico.ChartAreas[0].AxisX.Title = "tn";
            Grafico.ChartAreas[0].AxisY.Title = "x1";

            //// Genera Grafico 2
            Grafico2.Series.Clear();
            if (Grafico2.Titles.Count == 0)
                Grafico2.Titles.Add("X'' en funcion de X");

            Series g2Series = Grafico2.Series.Add("X''");
            g2Series.ChartType = SeriesChartType.Point;
            g2Series.Points.Clear();

            Grafico2.ChartAreas[0].AxisX.Title = "X''";
            Grafico2.ChartAreas[0].AxisY.Title = "X";

            //// Genera Grafico 3
            Grafico3.Series.Clear();
            if (Grafico3.Titles.Count == 0)
                Grafico3.Titles.Add("X' en funcion de X");

            Series g3Series = Grafico3.Series.Add("X'");
            g3Series.ChartType = SeriesChartType.Point;
            g3Series.Points.Clear();

            Grafico3.ChartAreas[0].AxisX.Title = "X'";
            Grafico3.ChartAreas[0].AxisY.Title = "X";

            //// Genera Grafico 4
            Grafico4.Series.Clear();
            if (Grafico4.Titles.Count == 0)
                Grafico4.Titles.Add("X'' en funcion de X'");

            Series g4Series = Grafico4.Series.Add("X''");
            g4Series.ChartType = SeriesChartType.Point;
            g4Series.Points.Clear();

            Grafico4.ChartAreas[0].AxisX.Title = "X''";
            Grafico4.ChartAreas[0].AxisY.Title = "X'";


            if (metodo == 0)
            {
                tablaEuler.Visible = false;
                tablaRK.Visible = true;
            }
            else
            {
                tablaEuler.Visible = true;
                tablaRK.Visible = false;
            }

            EcuacionDiferencial ecuacion = new EcuacionDiferencial();
            EcuacionDiferencial ecuacionAnterior = new EcuacionDiferencial();

            var picos = 0;
            do
            {
                if (primero)
                {
                    ecuacion = new EcuacionDiferencial(metodo, a, b, c, h, null, x0, xDeriv0);
                    primero = false;
                }
                else
                {
                    ecuacion = new EcuacionDiferencial(metodo, a, b, c, h, ecuacionAnterior);
                }

                if(metodo == 0)
                {
                    if (ecuacion.rk_x1 > ecuacionAnterior.rk_x1)
                    {
                        ecuacion.posiblePico = true;
                    }
                    else if (ecuacion.rk_x1 < ecuacionAnterior.rk_x1 && ecuacionAnterior.posiblePico)
                    {
                        picos++;
                        lblTn.Text = Math.Round(ecuacionAnterior.tn,3).ToString();
                        lblX1.Text = Math.Round(ecuacionAnterior.rk_x1,3).ToString();
                    }

                    tablaRK.Rows.Add(Math.Round(ecuacion.tn,3), Math.Round(ecuacion.rk_x1, 3), Math.Round(ecuacion.rk_k1, 3), Math.Round(ecuacion.rk_k2, 3), Math.Round(ecuacion.rk_k3, 3), Math.Round(ecuacion.rk_k4, 3),
                        Math.Round(ecuacion.rk_x2, 3), Math.Round(ecuacion.rk_l1, 3), Math.Round(ecuacion.rk_l2, 3), Math.Round(ecuacion.rk_l3, 3), Math.Round(ecuacion.rk_l4, 3));

                    g1Series1.Points.AddXY(ecuacion.tn, ecuacion.rk_l1 / h);
                    g1Series2.Points.AddXY(ecuacion.tn, ecuacion.rk_x2);
                    g1Series3.Points.AddXY(ecuacion.tn, ecuacion.rk_x1);

                    g2Series.Points.AddXY(Math.Round(ecuacion.rk_x1, 3), ecuacion.rk_l1 / h);
                    g3Series.Points.AddXY(Math.Round(ecuacion.rk_x1, 3), ecuacion.rk_x2);
                    g4Series.Points.AddXY(Math.Round(ecuacion.rk_x2, 3), ecuacion.rk_l1 / h);

                }
                else
                {
                    if (ecuacion.eu_x1 > ecuacionAnterior.eu_x1)
                    {
                        ecuacion.posiblePico = true;
                    }
                    else if (ecuacion.eu_x1 < ecuacionAnterior.eu_x1 && ecuacionAnterior.posiblePico)
                    {
                        picos++;

                        lblTn.Text = Math.Round(ecuacionAnterior.tn, 3).ToString();
                        lblX1.Text = Math.Round(ecuacionAnterior.eu_x1, 3).ToString();
                    }

                    tablaEuler.Rows.Add(Math.Round(ecuacion.tn, 3), Math.Round(ecuacion.eu_x1,3), Math.Round(ecuacion.dx1,3), Math.Round(ecuacion.dx2,3));
                   
                    g1Series1.Points.AddXY(ecuacion.tn, ecuacion.dx2);
                    g1Series2.Points.AddXY(ecuacion.tn, ecuacion.dx1);
                    g1Series3.Points.AddXY(ecuacion.tn, ecuacion.eu_x1);

                    g2Series.Points.AddXY(ecuacion.eu_x1, ecuacion.dx2);
                    g3Series.Points.AddXY(ecuacion.eu_x1, ecuacion.dx1);
                    g4Series.Points.AddXY(ecuacion.dx1, ecuacion.dx2);


                }

                ecuacionAnterior = ecuacion;

            } while (picos < 2);

            picoTiempoDescarga = double.Parse(lblTn.Text);

        }


        private void Simular(int desde = 0, int hasta = 0)
        {
            tablaVectorEstado.Rows.Clear();
            cantProyectos = int.Parse(txt_cantProy.Text);
            double SILO1, SILO2, SILO3, SILO4, tiempoAbasteciendoPlanta, tiempoCambioSilo;
            Random r = new Random();

            Vector vectorEstado = new Vector();
            Vector vectorEstadoMasUno = new Vector();

            for (int i = 0; i < cantProyectos; i++)
            {
                var numAleatorioLlegadaCamion = r.NextDouble();
                var tiempoEntreCamiones = GeneracionTiemposActividad(comboDist1.SelectedIndex, constante1_1.Text, constante1_2.Text, numAleatorioLlegadaCamion);

                var numAleatorio1 = r.NextDouble();
                SILO1 = GeneracionTiemposActividad(comboDist1.SelectedIndex, constante1_1.Text, constante1_2.Text, numAleatorio1);

                var numAleatorio2 = r.NextDouble();
                SILO2 = GeneracionTiemposActividad(comboDist2.SelectedIndex, constante2_1.Text, constante2_2.Text, numAleatorio2);

                var numAleatorio3 = r.NextDouble();
                SILO3 = GeneracionTiemposActividad(comboDist3.SelectedIndex, constante3_1.Text, constante3_2.Text, numAleatorio3);

                var numAleatorio4 = r.NextDouble();
                SILO4 = GeneracionTiemposActividad(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text, numAleatorio4);

                var numAleatorio5 = r.NextDouble();
                tiempoAbasteciendoPlanta = GeneracionTiemposActividad(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text, numAleatorio5);

                var numAleatorio6 = r.NextDouble();
                tiempoCambioSilo = GeneracionTiemposActividad(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text, numAleatorio6);

                if (i == 0)
                {
                    vectorEstado = new Vector(i + 1, tiempoEntreCamiones, picoTiempoDescarga, r);

                    if (0 <= desde)
                    {
                        tablaVectorEstado.Rows.Add(vectorEstado.nroEvento.ToString(), Math.Round(vectorEstado.reloj, 3).ToString(), (Evento)vectorEstado.evento, vectorEstado.camion == 0 ? "-" : vectorEstado.camion.ToString(),
                            vectorEstado.proxcamion.ToString(), ((Evento)vectorEstado.evento == Evento.LlegaCamion || (Evento)vectorEstado.evento == Evento.Inicio) ? Math.Round(numAleatorioLlegadaCamion, 3).ToString() : "-", ((Evento)vectorEstado.evento == Evento.LlegaCamion || (Evento)vectorEstado.evento == Evento.Inicio) ? Math.Round(vectorEstado.tiempoEntreCamiones, 3).ToString() : "-", Math.Round(vectorEstado.proxLlegada, 3).ToString(),
                            vectorEstado.rndTnCamion == 0 ? "-" : Math.Round(vectorEstado.rndTnCamion, 3).ToString(), vectorEstado.tnCamion == 0 ? "-" : Math.Round(vectorEstado.tnCamion, 3).ToString(), vectorEstado.ingresaASilo == 0 ? "-" : vectorEstado.ingresaASilo.ToString(), vectorEstado.siloAbasteciendoPlanta == 0 ? "-" : vectorEstado.siloAbasteciendoPlanta.ToString(), vectorEstado.rndTiempoAbasteciendoPlanta == 0 ? "-" : Math.Round(vectorEstado.rndTiempoAbasteciendoPlanta, 3).ToString(),
                            vectorEstado.tiempoAbasteciendoPlanta == 0 ? "-" : Math.Round(vectorEstado.tiempoAbasteciendoPlanta, 3).ToString(), (vectorEstado.proximoFinAbasteciendoPlanta == 0 || vectorEstado.proximoFinAbasteciendoPlanta == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.proximoFinAbasteciendoPlanta, 3).ToString(), (Estado)vectorEstado.estadoPlaya, vectorEstado.siloPlaya == 0 ? "-" : vectorEstado.siloPlaya.ToString(), vectorEstado.camionPlaya == 0 ? "-" : vectorEstado.camionPlaya.ToString(),
                            vectorEstado.sobraTnPlaya == 0 ? "-" : vectorEstado.sobraTnPlaya.ToString(), vectorEstado.siguienteSiloPlaya == 0 ? "-" : vectorEstado.siguienteSiloPlaya.ToString(), vectorEstado.tiempoPlaya == 0 ? "-" : Math.Round(vectorEstado.tiempoPlaya, 3).ToString(), (vectorEstado.proximoFinPlaya == 0 || vectorEstado.proximoFinPlaya == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.proximoFinPlaya, 3).ToString(), vectorEstado.colaPlaya.ToString(), toString(vectorEstado.clientesEnColaPlaya).ToString(),
                            (Estado)vectorEstado.estadoSilo1, vectorEstado.contenidoTnSilo1.ToString(), vectorEstado.camionSilo1 == 0 ? "-" : vectorEstado.camionSilo1.ToString(),
                            (Estado)vectorEstado.estadoSilo2, vectorEstado.contenidoTnSilo2.ToString(), vectorEstado.camionSilo2 == 0 ? "-" : vectorEstado.camionSilo2.ToString(),
                            (Estado)vectorEstado.estadoSilo3, vectorEstado.contenidoTnSilo3.ToString(), vectorEstado.camionSilo3 == 0 ? "-" : vectorEstado.camionSilo3.ToString(),
                            (Estado)vectorEstado.estadoSilo4, vectorEstado.contenidoTnSilo4.ToString(), vectorEstado.camionSilo4 == 0 ? "-" : vectorEstado.camionSilo4.ToString()); 
                    }

                    vectorEstadoMasUno = vectorEstado;
                }
                else
                {

                    vectorEstado = new Vector(i + 1, tiempoEntreCamiones, picoTiempoDescarga, r, 20,tiempoAbasteciendoPlanta, tiempoCambioSilo, SILO1, SILO2, SILO3, SILO4, vectorEstadoMasUno);

                    if ((hasta != 0
                        && vectorEstado.nroEvento >= desde && vectorEstado.nroEvento <= hasta)
                        ||
                        (desde == 0 && hasta == 0
                        ))
                    {
                        tablaVectorEstado.Rows.Add(vectorEstado.nroEvento.ToString(), Math.Round(vectorEstado.reloj, 3).ToString(), (Evento)vectorEstado.evento, vectorEstado.camion == 0 ? "-" : vectorEstado.camion.ToString(),
                            vectorEstado.proxcamion.ToString(), ((Evento)vectorEstado.evento == Evento.LlegaCamion || (Evento)vectorEstado.evento == Evento.Inicio) ? Math.Round(numAleatorioLlegadaCamion, 3).ToString() : "-", ((Evento)vectorEstado.evento == Evento.LlegaCamion || (Evento)vectorEstado.evento == Evento.Inicio) ? Math.Round(vectorEstado.tiempoEntreCamiones, 3).ToString() : "-", Math.Round(vectorEstado.proxLlegada, 3).ToString(),
                            vectorEstado.rndTnCamion == 0 ? "-" : Math.Round(vectorEstado.rndTnCamion, 3).ToString(), vectorEstado.tnCamion == 0 ? "-" : Math.Round(vectorEstado.tnCamion, 3).ToString(), vectorEstado.ingresaASilo == 0 ? "-" : vectorEstado.ingresaASilo.ToString(), vectorEstado.siloAbasteciendoPlanta == 0 ? "-" : vectorEstado.siloAbasteciendoPlanta.ToString(), vectorEstado.rndTiempoAbasteciendoPlanta == 0 ? "-" : Math.Round(vectorEstado.rndTiempoAbasteciendoPlanta, 3).ToString(),
                            vectorEstado.tiempoAbasteciendoPlanta == 0 ? "-" : Math.Round(vectorEstado.tiempoAbasteciendoPlanta, 3).ToString(), (vectorEstado.proximoFinAbasteciendoPlanta == 0 || vectorEstado.proximoFinAbasteciendoPlanta == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.proximoFinAbasteciendoPlanta, 3).ToString(), (Estado)vectorEstado.estadoPlaya, vectorEstado.siloPlaya == 0 ? "-" : vectorEstado.siloPlaya.ToString(), vectorEstado.camionPlaya == 0 ? "-" : vectorEstado.camionPlaya.ToString(),
                            vectorEstado.sobraTnPlaya == 0 ? "-" : vectorEstado.sobraTnPlaya.ToString(), vectorEstado.siguienteSiloPlaya == 0 ? "-" : vectorEstado.siguienteSiloPlaya.ToString(), vectorEstado.tiempoPlaya == 0 ? "-" : Math.Round(vectorEstado.tiempoPlaya, 3).ToString(), (vectorEstado.proximoFinPlaya == 0 || vectorEstado.proximoFinPlaya == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.proximoFinPlaya, 3).ToString(), vectorEstado.colaPlaya.ToString(), toString(vectorEstado.clientesEnColaPlaya).ToString(),
                            (Estado)vectorEstado.estadoSilo1, vectorEstado.contenidoTnSilo1.ToString(), vectorEstado.camionSilo1 == 0 ? "-" : vectorEstado.camionSilo1.ToString(),
                            (Estado)vectorEstado.estadoSilo2, vectorEstado.contenidoTnSilo2.ToString(), vectorEstado.camionSilo2 == 0 ? "-" : vectorEstado.camionSilo2.ToString(),
                            (Estado)vectorEstado.estadoSilo3, vectorEstado.contenidoTnSilo3.ToString(), vectorEstado.camionSilo3 == 0 ? "-" : vectorEstado.camionSilo3.ToString(),
                            (Estado)vectorEstado.estadoSilo4, vectorEstado.contenidoTnSilo4.ToString(), vectorEstado.camionSilo4 == 0 ? "-" : vectorEstado.camionSilo4.ToString());
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

        private string toString(Queue<int> queue)
        {
            return string.Join(",", queue.ToList());
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


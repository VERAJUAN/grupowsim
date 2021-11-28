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
        double picoTiempoEncastre = 0;
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
            //Grafico.Series.Clear();
            //if (Grafico.Titles.Count == 0)
            //    Grafico.Titles.Add("X'', X', X en funcion de t");

            //Series g1Series1 = Grafico.Series.Add("X''");
            //g1Series1.ChartType = SeriesChartType.Point;
            //g1Series1.Points.Clear();

            //Series g1Series2 = Grafico.Series.Add("X'");
            //g1Series2.ChartType = SeriesChartType.Point;
            //g1Series2.Points.Clear();

            //Series g1Series3 = Grafico.Series.Add("X");
            //g1Series3.ChartType = SeriesChartType.Point;
            //g1Series3.Points.Clear();

            //Grafico.ChartAreas[0].AxisX.Title = "tn";
            //Grafico.ChartAreas[0].AxisY.Title = "x1";

            ////// Genera Grafico 2
            //Grafico2.Series.Clear();
            //if (Grafico2.Titles.Count == 0)
            //    Grafico2.Titles.Add("X'' en funcion de X");

            //Series g2Series = Grafico2.Series.Add("X''");
            //g2Series.ChartType = SeriesChartType.Point;
            //g2Series.Points.Clear();

            //Grafico2.ChartAreas[0].AxisX.Title = "X''";
            //Grafico2.ChartAreas[0].AxisY.Title = "X";

            ////// Genera Grafico 3
            //Grafico3.Series.Clear();
            //if (Grafico3.Titles.Count == 0)
            //    Grafico3.Titles.Add("X' en funcion de X");

            //Series g3Series = Grafico3.Series.Add("X'");
            //g3Series.ChartType = SeriesChartType.Point;
            //g3Series.Points.Clear();

            //Grafico3.ChartAreas[0].AxisX.Title = "X'";
            //Grafico3.ChartAreas[0].AxisY.Title = "X";

            ////// Genera Grafico 4
            //Grafico4.Series.Clear();
            //if (Grafico4.Titles.Count == 0)
            //    Grafico4.Titles.Add("X'' en funcion de X'");

            //Series g4Series = Grafico4.Series.Add("X''");
            //g4Series.ChartType = SeriesChartType.Point;
            //g4Series.Points.Clear();

            //Grafico4.ChartAreas[0].AxisX.Title = "X''";
            //Grafico4.ChartAreas[0].AxisY.Title = "X'";


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

                    //g1Series1.Points.AddXY(ecuacion.tn, ecuacion.rk_l1 / h);
                    //g1Series2.Points.AddXY(ecuacion.tn, ecuacion.rk_x2);
                    //g1Series3.Points.AddXY(ecuacion.tn, ecuacion.rk_x1);

                    //g2Series.Points.AddXY(Math.Round(ecuacion.rk_x1, 3), ecuacion.rk_l1 / h);
                    //g3Series.Points.AddXY(Math.Round(ecuacion.rk_x1, 3), ecuacion.rk_x2);
                    //g4Series.Points.AddXY(Math.Round(ecuacion.rk_x2, 3), ecuacion.rk_l1 / h);

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
                   
                    //g1Series1.Points.AddXY(ecuacion.tn, ecuacion.dx2);
                    //g1Series2.Points.AddXY(ecuacion.tn, ecuacion.dx1);
                    //g1Series3.Points.AddXY(ecuacion.tn, ecuacion.eu_x1);

                    //g2Series.Points.AddXY(ecuacion.eu_x1, ecuacion.dx2);
                    //g3Series.Points.AddXY(ecuacion.eu_x1, ecuacion.dx1);
                    //g4Series.Points.AddXY(ecuacion.dx1, ecuacion.dx2);


                }

                ecuacionAnterior = ecuacion;

            } while (picos < 2);

            picoTiempoEncastre = double.Parse(lblTn.Text);

        }


        private void Simular(int desde = 0, int hasta = 0)
        {
            tablaVectorEstado.Rows.Clear();
            cantProyectos = int.Parse(txt_cantProy.Text);
            double QA, AA, L1, L2, A5;
            int pedidoACalcular = int.Parse(txt_nroEnsamblesProbabilidad.Text);
            //lblCompletarEnsambles.Text = $"Probabilidad de completar {pedidoACalcular} o más ensambles por hora:";
            //tablaVectorEstado.Columns[74].HeaderText = $"{pedidoACalcular} ENSAMBLES COMPLETADOS EN 1 HORA";
            //tablaVectorEstado.Columns[75].HeaderText = $"PROBABILIDAD DE COMPLETAR {pedidoACalcular} O MAS ENSAMBLES";
            Random r = new Random();

            VectorEstadoDinamico vectorEstado = new VectorEstadoDinamico();
            VectorEstadoDinamico vectorEstadoMasUno = new VectorEstadoDinamico();

            for (int i = 0; i < cantProyectos; i++)
            {
                var numAleatorioLlegadaPedido = r.NextDouble();
                var tiempoEntrePedidos = GeneracionTiemposActividad(1, txtLambdaPedidos.Text, "", numAleatorioLlegadaPedido);

                //var numAleatorio1 = r.NextDouble();
                QA = 2; //Siempre 2 minutos.

                var numAleatorio2 = r.NextDouble();
                AA = GeneracionTiemposActividad(comboDist2.SelectedIndex, constante2_1.Text, constante2_2.Text, numAleatorio2);

                var numAleatorio3 = r.NextDouble();
                L1 = GeneracionTiemposActividad(comboDist3.SelectedIndex, constante3_1.Text, constante3_2.Text, numAleatorio3);

                var numAleatorio4 = r.NextDouble();
                L2 = GeneracionTiemposActividad(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text, numAleatorio4);

                var numAleatorio5 = r.NextDouble();
                A5 = GeneracionTiemposActividad(comboDist5.SelectedIndex, constante5_1.Text, constante5_2.Text, numAleatorio5);

                if (i == 0)
                {
                    vectorEstado = new VectorEstadoDinamico(i + 1, tiempoEntrePedidos/*, pedidoACalcular, picoTiempoEncastre*/);

                    if (0 <= desde)
                    {
                        tablaVectorEstado.Rows.Add(vectorEstado.nroEvento.ToString(), Math.Round(vectorEstado.reloj, 3).ToString(), (Evento)vectorEstado.evento, vectorEstado.pedido == 0 ? "-" : vectorEstado.pedido.ToString(),
                            vectorEstado.proxPedido.ToString(), ((Evento)vectorEstado.evento == Evento.LlegaPedido || (Evento)vectorEstado.evento == Evento.Inicio) ? Math.Round(numAleatorioLlegadaPedido, 3).ToString() : "-", ((Evento)vectorEstado.evento == Evento.LlegaPedido || (Evento)vectorEstado.evento == Evento.Inicio) ? Math.Round(vectorEstado.tiempoEntrePedidos, 3).ToString() : "-", Math.Round(vectorEstado.proxLlegada, 3).ToString(),
                            (Estado)vectorEstado.qaEstado, vectorEstado.qaPedido == 0 ? "-" : vectorEstado.qaPedido.ToString(), (i != 0 && vectorEstado.qaPedido != vectorEstadoMasUno.qaPedido && vectorEstado.qaPedido != 0) ? Math.Round(vectorEstado.qaTiempo, 3).ToString() : "-", (vectorEstado.qaProxFin == 0 || vectorEstado.qaProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.qaProxFin, 3).ToString(), vectorEstado.qaCola.ToString(),
                            (Estado)vectorEstado.aaEstado, vectorEstado.aaPedido == 0 ? "-" : vectorEstado.aaPedido.ToString(), (i != 0 && vectorEstado.aaPedido != vectorEstadoMasUno.aaPedido && vectorEstado.aaPedido != 0) ? Math.Round(numAleatorio2, 3).ToString() : "-", (i != 0 && vectorEstado.aaPedido != vectorEstadoMasUno.aaPedido && vectorEstado.aaPedido != 0) ? Math.Round(vectorEstado.aaTiempo, 3).ToString() : "-", (vectorEstado.aaProxFin == 0 || vectorEstado.aaProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.aaProxFin, 3).ToString(), vectorEstado.aaCola.ToString(),
                            (Estado)vectorEstado.l1Estado, vectorEstado.l1Pedido == 0 ? "-" : vectorEstado.l1Pedido.ToString(), (i != 0 && vectorEstado.l1Pedido != vectorEstadoMasUno.l1Pedido && vectorEstado.l1Pedido != 0) ? Math.Round(numAleatorio3, 3).ToString() : "-", (i != 0 && vectorEstado.l1Pedido != vectorEstadoMasUno.l1Pedido && vectorEstado.l1Pedido != 0) ? Math.Round(vectorEstado.l1Tiempo, 3).ToString() : "-", (vectorEstado.l1ProxFin == 0 || vectorEstado.l1ProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.l1ProxFin, 3).ToString(), /*vectorEstado.l1Cola.ToString(),*/
                            (Estado)vectorEstado.l2Estado, vectorEstado.l2Pedido == 0 ? "-" : vectorEstado.l2Pedido.ToString(), (i != 0 && vectorEstado.l2Pedido != vectorEstadoMasUno.l2Pedido && vectorEstado.l2Pedido != 0) ? Math.Round(numAleatorio4, 3).ToString() : "-", (i != 0 && vectorEstado.l2Pedido != vectorEstadoMasUno.l2Pedido && vectorEstado.l2Pedido != 0) ? Math.Round(vectorEstado.l2Tiempo, 3).ToString() : "-", (vectorEstado.l2ProxFin == 0 || vectorEstado.l2ProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.l2ProxFin, 3).ToString() /*vectorEstado.l2Cola.ToString(),*/
                            //(Estado)vectorEstado.a5Estado, vectorEstado.a5Pedido == 0 ? "-" : vectorEstado.a5Pedido.ToString(), (i != 0 && vectorEstado.a5Pedido != vectorEstadoMasUno.a5Pedido && vectorEstado.a5Pedido != 0) ? Math.Round(numAleatorio5, 3).ToString() : "-", (i != 0 && vectorEstado.a5Pedido != vectorEstadoMasUno.a5Pedido && vectorEstado.a5Pedido != 0) ? Math.Round(vectorEstado.a5Tiempo, 3).ToString() : "-", (vectorEstado.a5ProxFin == 0 || vectorEstado.a5ProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.a5ProxFin, 3).ToString(), vectorEstado.a5Colal2.ToString(),
                            //vectorEstado.a5Colaaa.ToString(),
                            //(Estado)vectorEstado.encastreEstado, vectorEstado.encastrePedido == 0 ? "-" : vectorEstado.encastrePedido.ToString(), (i != 0 && vectorEstado.encastreTiempo != vectorEstadoMasUno.encastreTiempo && vectorEstado.encastreTiempo != 0) ? Math.Round(vectorEstado.encastreTiempo, 3).ToString() : "-", (vectorEstado.encastreProxFin == 0 || vectorEstado.encastreProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.encastreProxFin, 3).ToString(),vectorEstado.colaEncastrel1.ToString(), vectorEstado.colaEncastreA5.ToString(),
                            //vectorEstado.cantidadEnsamblesSolicitados.ToString(), vectorEstado.cantidadEnsamblesFinalizados.ToString(), Math.Round(vectorEstado.propEnsamRealSobreSolic, 3).ToString(), Math.Round(vectorEstado.duracionPromedioEnsamble, 3).ToString(), vectorEstado.maxColqa.ToString(), vectorEstado.maxColaa.ToString(), vectorEstado.maxColl1.ToString(), vectorEstado.maxColl2.ToString(),
                            //vectorEstado.maxCola5.ToString(), vectorEstado.maxColaEncastre.ToString(), Math.Round(vectorEstado.tiempoPromColqa, 3).ToString(), Math.Round(vectorEstado.tiempoPromColaa, 3).ToString(), Math.Round(vectorEstado.tiempoPromColl1, 3).ToString(), Math.Round(vectorEstado.tiempoPromColl2, 3).ToString(), Math.Round(vectorEstado.tiempoPromCola5, 3).ToString(), Math.Round(vectorEstado.tiempoPromColaEncastre, 3).ToString(),
                            //Math.Round(vectorEstado.cantPromedioProdEnCola, 3).ToString(), vectorEstado.cantPromedioProdEnSistema.ToString(), Math.Round(vectorEstado.porcOcupacionqa, 3).ToString(), Math.Round(vectorEstado.porcOcupacionaa, 3).ToString(), Math.Round(vectorEstado.porcOcupacionl1, 3).ToString(), Math.Round(vectorEstado.porcOcupacionl2, 3).ToString(), Math.Round(vectorEstado.porcOcupacionA5, 3).ToString(), Math.Round(vectorEstado.tiempoBloqueoColaA5, 3).ToString(), Math.Round(vectorEstado.propBloqueoSobreOcupacion, 3).ToString(), Math.Round(vectorEstado.tiempoBloqueoColaEncastrel1, 3).ToString(),
                            //Math.Round(vectorEstado.tiempoBloqueoColaEncastrel1, 3).ToString(),
                            //vectorEstado.cantEnsamblesXHora.ToString(), Math.Round(vectorEstado.cantProbEnsamblesXHora, 3).ToString(), vectorEstado.pedidosParametroCompletadosEnUnaHora.ToString(), Math.Round(vectorEstado.probPedidosParametroCompletadosEnUnaHora, 3).ToString()
                            );
                    }

                    vectorEstadoMasUno = vectorEstado;
                }
                else
                {

                    vectorEstado = new VectorEstadoDinamico(i + 1, tiempoEntrePedidos, /*pedidoACalcular, picoTiempoEncastre,*/ QA, AA, L1, L2, A5, vectorEstadoMasUno);

                    if ((hasta != 0
                        && vectorEstado.nroEvento >= desde && vectorEstado.nroEvento <= hasta)
                        ||
                        (desde == 0 && hasta == 0
                        //&& (vectorEstado.nroEvento < 20 || vectorEstado.nroEvento % 10000 == 0)
                        ))
                    {
                        tablaVectorEstado.Rows.Add(vectorEstado.nroEvento.ToString(), Math.Round(vectorEstado.reloj, 3).ToString(), (Evento)vectorEstado.evento, vectorEstado.pedido == 0 ? "-" : vectorEstado.pedido.ToString(),
                            vectorEstado.proxPedido.ToString(), ((Evento)vectorEstado.evento == Evento.LlegaPedido || (Evento)vectorEstado.evento == Evento.Inicio) ? Math.Round(numAleatorioLlegadaPedido, 3).ToString() : "-", ((Evento)vectorEstado.evento == Evento.LlegaPedido || (Evento)vectorEstado.evento == Evento.Inicio) ? Math.Round(vectorEstado.tiempoEntrePedidos, 3).ToString() : "-", Math.Round(vectorEstado.proxLlegada, 3).ToString(),
                            (Estado)vectorEstado.qaEstado, vectorEstado.qaPedido == 0 ? "-" : vectorEstado.qaPedido.ToString(), (i != 0 && vectorEstado.qaPedido != vectorEstadoMasUno.qaPedido && vectorEstado.qaPedido != 0) ? Math.Round(vectorEstado.qaTiempo, 3).ToString() : "-", (vectorEstado.qaProxFin == 0 || vectorEstado.qaProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.qaProxFin, 3).ToString(), vectorEstado.qaCola.ToString(),
                            (Estado)vectorEstado.aaEstado, vectorEstado.aaPedido == 0 ? "-" : vectorEstado.aaPedido.ToString(), (i != 0 && vectorEstado.aaPedido != vectorEstadoMasUno.aaPedido && vectorEstado.aaPedido != 0) ? Math.Round(numAleatorio2, 3).ToString() : "-", (i != 0 && vectorEstado.aaPedido != vectorEstadoMasUno.aaPedido && vectorEstado.aaPedido != 0) ? Math.Round(vectorEstado.aaTiempo, 3).ToString() : "-", (vectorEstado.aaProxFin == 0 || vectorEstado.aaProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.aaProxFin, 3).ToString(), vectorEstado.aaCola.ToString(),
                            (Estado)vectorEstado.l1Estado, vectorEstado.l1Pedido == 0 ? "-" : vectorEstado.l1Pedido.ToString(), (i != 0 && vectorEstado.l1Pedido != vectorEstadoMasUno.l1Pedido && vectorEstado.l1Pedido != 0) ? Math.Round(numAleatorio3, 3).ToString() : "-", (i != 0 && vectorEstado.l1Pedido != vectorEstadoMasUno.l1Pedido && vectorEstado.l1Pedido != 0) ? Math.Round(vectorEstado.l1Tiempo, 3).ToString() : "-", (vectorEstado.l1ProxFin == 0 || vectorEstado.l1ProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.l1ProxFin, 3).ToString(), /*vectorEstado.l1Cola.ToString(),*/
                            (Estado)vectorEstado.l2Estado, vectorEstado.l2Pedido == 0 ? "-" : vectorEstado.l2Pedido.ToString(), (i != 0 && vectorEstado.l2Pedido != vectorEstadoMasUno.l2Pedido && vectorEstado.l2Pedido != 0) ? Math.Round(numAleatorio4, 3).ToString() : "-", (i != 0 && vectorEstado.l2Pedido != vectorEstadoMasUno.l2Pedido && vectorEstado.l2Pedido != 0) ? Math.Round(vectorEstado.l2Tiempo, 3).ToString() : "-", (vectorEstado.l2ProxFin == 0 || vectorEstado.l2ProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.l2ProxFin, 3).ToString() /*vectorEstado.l2Cola.ToString(),*/
                            //(Estado)vectorEstado.a5Estado, vectorEstado.a5Pedido == 0 ? "-" : vectorEstado.a5Pedido.ToString(), (i != 0 && vectorEstado.a5Pedido != vectorEstadoMasUno.a5Pedido && vectorEstado.a5Pedido != 0) ? Math.Round(numAleatorio5, 3).ToString() : "-", (i != 0 && vectorEstado.a5Pedido != vectorEstadoMasUno.a5Pedido && vectorEstado.a5Pedido != 0) ? Math.Round(vectorEstado.a5Tiempo, 3).ToString() : "-", (vectorEstado.a5ProxFin == 0 || vectorEstado.a5ProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.a5ProxFin, 3).ToString(), vectorEstado.a5Colal2.ToString(),
                            //vectorEstado.a5Colaaa.ToString(),
                            //(Estado)vectorEstado.encastreEstado, vectorEstado.encastrePedido == 0 ? "-" : vectorEstado.encastrePedido.ToString(), (i != 0 && vectorEstado.encastreTiempo != vectorEstadoMasUno.encastreTiempo && vectorEstado.encastreTiempo != 0) ? Math.Round(vectorEstado.encastreTiempo, 3).ToString() : "-", (vectorEstado.encastreProxFin == 0 || vectorEstado.encastreProxFin == double.PositiveInfinity) ? "-" : Math.Round(vectorEstado.encastreProxFin, 3).ToString(), vectorEstado.colaEncastrel1.ToString(), vectorEstado.colaEncastreA5.ToString(),
                            //vectorEstado.cantidadEnsamblesSolicitados.ToString(), vectorEstado.cantidadEnsamblesFinalizados.ToString(), Math.Round(vectorEstado.propEnsamRealSobreSolic, 3).ToString(), Math.Round(vectorEstado.duracionPromedioEnsamble, 3).ToString(), vectorEstado.maxColqa.ToString(), vectorEstado.maxColaa.ToString(), vectorEstado.maxColl1.ToString(), vectorEstado.maxColl2.ToString(),
                            //vectorEstado.maxCola5.ToString(), vectorEstado.maxColaEncastre.ToString(), Math.Round(vectorEstado.tiempoPromColqa, 3).ToString(), Math.Round(vectorEstado.tiempoPromColaa, 3).ToString(), Math.Round(vectorEstado.tiempoPromColl1, 3).ToString(), Math.Round(vectorEstado.tiempoPromColl2, 3).ToString(), Math.Round(vectorEstado.tiempoPromCola5, 3).ToString(), Math.Round(vectorEstado.tiempoPromColaEncastre, 3).ToString(),
                            //Math.Round(vectorEstado.cantPromedioProdEnCola, 3).ToString(), vectorEstado.cantPromedioProdEnSistema.ToString(), Math.Round(vectorEstado.porcOcupacionqa, 3).ToString(), Math.Round(vectorEstado.porcOcupacionaa, 3).ToString(), Math.Round(vectorEstado.porcOcupacionl1, 3).ToString(), Math.Round(vectorEstado.porcOcupacionl2, 3).ToString(), Math.Round(vectorEstado.porcOcupacionA5, 3).ToString(), Math.Round(vectorEstado.tiempoBloqueoColaA5, 3).ToString(), Math.Round(vectorEstado.propBloqueoSobreOcupacion, 3).ToString(), Math.Round(vectorEstado.tiempoBloqueoColaEncastrel1, 3).ToString(),
                            //Math.Round(vectorEstado.tiempoBloqueoColaEncastrel1, 3).ToString(),
                            //vectorEstado.cantEnsamblesXHora.ToString(), Math.Round(vectorEstado.cantProbEnsamblesXHora, 3).ToString(), vectorEstado.pedidosParametroCompletadosEnUnaHora.ToString(), Math.Round(vectorEstado.probPedidosParametroCompletadosEnUnaHora, 3).ToString()
                            );
                    }

                    //if (i == (cantProyectos - 1))
                    //{
                    //    lblCantidadEventosSimulados.Text = vectorEstado.nroEvento.ToString();
                    //    lblCantMaxProductosEncastre.Text = vectorEstado.maxColaEncastre.ToString();
                    //    lblCantMaxProductosS1.Text = vectorEstado.maxColqa.ToString();
                    //    lblCantMaxProductosS2.Text = vectorEstado.maxColaa.ToString();
                    //    lblCantMaxProductosS3.Text = vectorEstado.maxColl1.ToString();
                    //    lblCantMaxProductosS4.Text = vectorEstado.maxColl2.ToString();
                    //    lblCantMaxProductosS5.Text = vectorEstado.maxCola5.ToString();
                    //    lblEnsamblesRealizados.Text = vectorEstado.cantidadEnsamblesFinalizados.ToString();
                    //    lblEnsamblesSolicitados.Text = vectorEstado.cantidadEnsamblesSolicitados.ToString();
                    //    lblPorcentajeOcupacionS1.Text = Math.Round(vectorEstado.porcOcupacionqa, 2).ToString() + "%";
                    //    lblPorcentajeOcupacionS2.Text = Math.Round(vectorEstado.porcOcupacionaa, 2).ToString() + "%";
                    //    lblPorcentajeOcupacionS3.Text = Math.Round(vectorEstado.porcOcupacionl1, 2).ToString() + "%";
                    //    lblPorcentajeOcupacionS4.Text = Math.Round(vectorEstado.porcOcupacionl2, 2).ToString() + "%";
                    //    lblPorcentajeOcupacionS5.Text = Math.Round(vectorEstado.porcOcupacionA5, 2).ToString() + "%";
                    //    lblProbCompletar3oMasEnsamblesXHora.Text = Math.Round(vectorEstado.probPedidosParametroCompletadosEnUnaHora, 2).ToString();
                    //    lblPromedioEnsamblesXHora.Text = Math.Round(vectorEstado.cantProbEnsamblesXHora, 2).ToString();
                    //    lblPromedioProductosEnSistema.Text = Math.Round(vectorEstado.cantPromedioProdEnSistema, 2).ToString();
                    //    lblProporcionEnsamblesRealizadosSolicitados.Text = Math.Round(vectorEstado.propEnsamRealSobreSolic, 2).ToString();
                    //    lblTiempoBloqueoTiempoOcupacion.Text = Math.Round(vectorEstado.propBloqueoSobreOcupacion, 2).ToString();
                    //    lblTiempoPromedioDuracionEnsamble.Text = Math.Round(vectorEstado.duracionPromedioEnsamble, 2).ToString();
                    //}

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


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

        double[] limiteInferior, limiteSuperior, frecuenciaObservada, frecuenciaEsperada, estadistico, estadisticoAcumulado;
        List<double> numerosAleatorios;
        int cantProyectos = 0;

        int a, c, m;
        double semilla, xiAnterior;


        private void cboSignificancia_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDist1.SelectedIndex = 0;
        }

        public Ejercicio__B()
        {
            InitializeComponent();
            //cboSignificancia.SelectedIndex = 0;
            //tbChi.Text = "";
            //txt_resul.Text = "";

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
            tablaaleatorios.Rows.Clear();
            tablaVectorEstado.Rows.Clear();
            Grafico.Series.Clear();
            //m = int.Parse(txt_m.Text);
            //a = int.Parse(txt_a.Text);
            //c = int.Parse(txt_c.Text);
            //semilla = double.Parse(txt_semilla.Text);
            cantProyectos = int.Parse(txt_cantProy.Text);
            double T1, T2, T3, T4, T5;
            VectorEstado vectorEstado = new VectorEstado();
            VectorEstado vectorEstadoMasUno;
            double numAleatorio;

            m = 918468;
            a = 5940215;
            c = 1951138;
            semilla = 584431597;
            xiAnterior = semilla;

            for (int i = 0; i < cantProyectos; i++)
            {
                numAleatorio = congruencialMixto(a, c, m, xiAnterior);
                tablaaleatorios.Rows.Add(i + 1, Math.Round(numAleatorio, 4));
                if (i == 0)
                {
                    T1 = GeneracionTiemposActividad(comboDist1.SelectedIndex, constante1_1.Text, constante1_2.Text, numAleatorio);
                    T2 = GeneracionTiemposActividad(comboDist2.SelectedIndex, constante2_1.Text, constante2_2.Text, numAleatorio);
                    T3 = GeneracionTiemposActividad(comboDist3.SelectedIndex, constante3_1.Text, constante3_2.Text, numAleatorio);
                    T4 = GeneracionTiemposActividad(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text, numAleatorio);
                    T5 = GeneracionTiemposActividad(comboDist5.SelectedIndex, constante5_1.Text, constante5_2.Text, numAleatorio);

                    vectorEstado = new VectorEstado(i + 1, T1, T2, T3, T4, T5, 0, 0, double.PositiveInfinity, 0);

                    tablaVectorEstado.Rows.Add(0.ToString());

                    tablaVectorEstado.Rows.Add(vectorEstado.nroProyecto.ToString(), vectorEstado.T1.ToString(), vectorEstado.T2.ToString(), vectorEstado.T3.ToString(), vectorEstado.T4.ToString(),
                                               vectorEstado.T5.ToString(), vectorEstado.DuracionEnsamble.ToString(), vectorEstado.AcumuladoEnsamble.ToString(), vectorEstado.PromedioDuracionEnsamble.ToString(),
                                               vectorEstado.MaxDuracion.ToString(), vectorEstado.MinDuracion.ToString(), vectorEstado.CantTareasMenor45Dias.ToString(), vectorEstado.ProbCompletarEn45Dias.ToString());
                }
                else
                {
                    T1 = GeneracionTiemposActividad(comboDist1.SelectedIndex, constante1_1.Text, constante1_2.Text, numAleatorio);
                    T2 = GeneracionTiemposActividad(comboDist2.SelectedIndex, constante2_1.Text, constante2_2.Text, numAleatorio);
                    T3 = GeneracionTiemposActividad(comboDist3.SelectedIndex, constante3_1.Text, constante3_2.Text, numAleatorio);
                    T4 = GeneracionTiemposActividad(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text, numAleatorio);
                    T5 = GeneracionTiemposActividad(comboDist5.SelectedIndex, constante5_1.Text, constante5_2.Text, numAleatorio);

                    vectorEstadoMasUno = new VectorEstado(i + 1, T1, T2, T3, T4, T5, vectorEstado.AcumuladoEnsamble, vectorEstado.MaxDuracion, vectorEstado.MinDuracion, vectorEstado.CantTareasMenor45Dias);
                    
                    tablaVectorEstado.Rows.Add(vectorEstadoMasUno.nroProyecto.ToString(), vectorEstadoMasUno.T1.ToString(), vectorEstadoMasUno.T2.ToString(), vectorEstadoMasUno.T3.ToString(), vectorEstadoMasUno.T4.ToString(),
                                               vectorEstadoMasUno.T5.ToString(), vectorEstadoMasUno.DuracionEnsamble.ToString(), vectorEstadoMasUno.AcumuladoEnsamble.ToString(), Math.Round(vectorEstadoMasUno.PromedioDuracionEnsamble, 4).ToString(),
                                               vectorEstadoMasUno.MaxDuracion.ToString(), vectorEstadoMasUno.MinDuracion.ToString(), vectorEstadoMasUno.CantTareasMenor45Dias.ToString(), Math.Round(vectorEstadoMasUno.ProbCompletarEn45Dias, 4).ToString());

                    vectorEstado = vectorEstadoMasUno;
                }
            }


            //Agregamos a tabla los aleatorios mixtos
            //for (int i = 0; i < cantProyectos; i++)
            //{
            //    tablaaleatorios.Rows.Add(i + 1, Math.Round(congruencialMixto(a, c, m, xiAnterior), 4));
            //}

            // Corroboramos que k sea mayor a 4
            //if (k > 4 && m >= k)
            //{
            //    realizarTest();
            //}
            //else
            //{
            //    MessageBox.Show("K debe ser mayor a 4 y se sugiere que sea raíz cuadrada de M. M debe ser igual o mayor a K", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        private double congruencialMixto(int a, int c, int m, double xi)
        {
            xiAnterior = ((a * xi) + c) % m; //Si es mixto
            
            return (xiAnterior + 0.5) / m; //(0;1)
        }

        private void realizarTest()
        {
            // Limpiamos Tablas y Grafico
            //tablaanalisis.Rows.Clear();
            tablaaleatorios.Rows.Clear();
            Grafico.Series.Clear();
            numerosAleatorios = new List<double>();

            // Tomamos los valores de m (cantidad de numeros aleatorios)
            // y k (cantidad de intervalos)
            int m = int.Parse(txt_m.Text);
            int k = int.Parse(txt_a.Text);


            // Asignamos k (cantidad de intervalos) a los vectores
            //limiteInferior = new double[k];
            //limiteSuperior = new double[k];
            //frecuenciaObservada = new double[k];
            //frecuenciaEsperada = new double[k];



            for (int i = 0; i < m; i++)
            {
                tablaaleatorios.Rows.Add(i + 1, numerosAleatorios.ElementAt(i));
            }

            ////Calculo maximo y minimo de los numeros aleatorios
            //double maximo = numerosAleatorios.Max();
            //double minimo = numerosAleatorios.Min();

            ////Calculo el paso de cada intervalo
            //double paso = Math.Round((maximo - minimo) / k, 4);

            ////Asigno valor a los limites
            //for (int i = 0; i < k; i++)
            //{
            //    //Primer limite inferior: valor minimo
            //    if (i == 0) limiteInferior[i] = Math.Round(minimo, 4);
            //    //Otros limites inferiores igual al limite superior anterior
            //    else limiteInferior[i] = Math.Round(limiteSuperior[i - 1], 4);
            //    //Si es el ultimo limite
            //    if(i == k-1) limiteSuperior[i] = Math.Round(maximo, 4);
            //    //Limite superior igual al inferior mas el paso
            //    else limiteSuperior[i] = Math.Round(limiteInferior[i] + paso, 4);
            //}

            //for (int i = 0; i < m; i++)
            //{
            //    // Calcula la cantidad de numeros por cada intervalo(frecuenciaObservada)
            //    int contador = 0;
            //    while (numerosAleatorios[i] > limiteSuperior[contador])
            //    {
            //        contador++;
            //    }
            //    frecuenciaObservada[contador] += 1;
            //}

            //// C
            //estadistico = new double[k];
            //// C Ac
            //estadisticoAcumulado = new double[k];

            //// Asigno valores a la tabla
            //for (int i = 0; i < k; i++)
            //{
            //    //Frecuencia esperada por distribución
            //    switch (comboDist.SelectedIndex)
            //    {
            //        case 0:
            //            //Normal

            //            frecuenciaEsperada[i] = Frecuencia.Normal(m, k, double.Parse(constante1.Text), double.Parse(constante2.Text), paso);
            //            break;
            //        case 1:
            //            //Exponencial
            //            frecuenciaEsperada[i] = Frecuencia.Exponencial(paso, m, double.Parse(constante1.Text));
            //            break;
            //        case 2:
            //            //Poisson
            //            frecuenciaEsperada[i] = Frecuencia.Poisson((int)paso, double.Parse(constante1.Text), (int)m);
            //            break;
            //        case 3:
            //            //Uniforme
            //            frecuenciaEsperada[i] = Frecuencia.Uniforme(m, k);
            //            break;
            //    }


            //    // Calculo del valor de C
            //    estadistico[i] = (double)Math.Pow(frecuenciaObservada[i] - frecuenciaEsperada[i], 2) / frecuenciaEsperada[i];

            //    // Calculo del valor de C Acumulado
            //    if (i == 0) // Primera vuelta guarda el mismo valor de c
            //    {
            //        estadisticoAcumulado[i] = estadistico[i];
            //    }
            //    else // acumula C
            //    {
            //        estadisticoAcumulado[i] = estadistico[i] + estadisticoAcumulado[i - 1];
            //    }

            //    // Agrego los valores a la tabla
            //    tablaanalisis.Rows.Add(limiteInferior[i], limiteSuperior[i], frecuenciaObservada[i], frecuenciaEsperada[i], estadistico[i], estadisticoAcumulado[i]);
            //}

            //// Genera Grafico
            //if (Grafico.Titles.Count == 0)
            //    Grafico.Titles.Add("Frecuencias observadas");

            //Series series = Grafico.Series.Add("Frecuencia Observada");
            //series.ChartType = SeriesChartType.Column;
            //series.Points.Clear();
            //Grafico.ChartAreas[0].AxisX.Title = "Datos obtenidos";
            //Grafico.ChartAreas[0].AxisY.Title = "Frecuencias";

            //// Cargo los intervalos con sus respectivos valores
            //for (int i = 0; i < limiteSuperior.Length; i++)
            //{
            //    series.Points.AddXY(limiteSuperior[i], frecuenciaObservada[i]);
            //}


            //// Calculo lambda y lo muestro
            //txt_resul.Text = Math.Round(estadisticoAcumulado[k - 1], 4).ToString();

            //// Calculo el valor y obtengo el valor tabulado.
            //var p = 1 - Convert.ToDouble(cboSignificancia.SelectedItem);
            //double chi = ChiSquared.InvCDF(k - 1, p);
            //tbChi.Text = Math.Round(chi, 4).ToString();

            //// Si el estadístico de prueba es menor o igual que el valor
            //// crítico, no se puede rechazar la hipótesis nula

        }

        private double GeneracionTiemposActividad(int comboDistrSelectedIndex, string constante1, string constante2, double xi)
        {
            switch (comboDistrSelectedIndex)
            {
                case 0:
                    //Normal
                    if (double.Parse(constante2) < 0)
                    {
                        MessageBox.Show("No puedes ingresar esos valores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    return Distribucion.Normal(xi, double.Parse(constante1), double.Parse(constante2));
                    break;
                case 1:
                    //Exponencial
                    if (double.Parse(constante1) <= 0)
                    {
                        MessageBox.Show("Lambda tiene que ser positivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    return Distribucion.Exponencial(xi, double.Parse(constante1));
                    break;
                case 2:
                    // uniforme 
                    if (double.Parse(constante1) > double.Parse(constante2))
                    {
                        MessageBox.Show("No puedes ingresar esos valores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    return Distribucion.Uniforme(xi, double.Parse(constante1), double.Parse(constante2));
                    break;
                default:
                    return -1;
                    //    label10.Visible = false;
                    //    label11.Visible = false;
                    //    constante1_1.Visible = false;
                    //    constante1_2.Visible = false;
                    //    break;
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
            //if (char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //    MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
        }
        private void constante2_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* if (char.IsDigit(e.KeyChar))
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

             }*/
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
    }
}

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

        double[] limiteInferior, limiteSuperior, frecuenciaObservada, estadistico, estadisticoAcumulado, numerosAleatorios;

        private void cboSignificancia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public Ejercicio__B()
        {
            InitializeComponent();
            cboSignificancia.SelectedIndex = 0;
            tbChi.Text = "";
            txt_resul.Text = "";
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            int m = int.Parse(txt_m.Text);
            int k = int.Parse(txt_k.Text);

            // Corroboramos que k sea mayor a 4
            if (k > 4)
            {
                realizarTest();
            }
            else
            {
                MessageBox.Show("K debe ser mayor a 4 y se sugiere que sea raíz cuadrada de M", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboDist_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboDist.SelectedIndex)
            {
                case 0:
                    label10.Text = "Media";
                    label11.Text = "Desviación";
                    label10.Visible = true;
                    label11.Visible = true;
                    constante1.Visible = true;
                    constante2.Visible = true;
                    break;

                case 1:
                    label10.Text = "Lambda";
                    //label11.Text = "Desviación";
                    label10.Visible = true;
                    label11.Visible = false;
                    constante1.Visible = true;
                    constante2.Visible = false;
                    break;
                case 2:
                    label10.Text = "Lambda";
                    //label11.Text = "Desviación";
                    label10.Visible = true;
                    label11.Visible = false;
                    constante1.Visible = true;
                    constante2.Visible = false;
                    break;
                case 3:
                    label10.Text = "Desde";
                    label11.Text = "Hasta";
                    label10.Visible = true;
                    label11.Visible = true;
                    constante1.Visible = true;
                    constante2.Visible = true;
                    break;
                default:

                    label10.Visible = false;
                    label11.Visible = false;
                    constante1.Visible = false;
                    constante2.Visible = false;
                    break;
            }

        }
        public void distUniforme(double desde, double hasta, int m)
        {
            Random random = new Random();
            numerosAleatorios = new double[m];
            double numAleatorios = 0, operacion = 0;



            for (int i = 0; i < numerosAleatorios.Length; i++)
            {
                numAleatorios = Math.Round(random.NextDouble(), 4);
                operacion = desde + (numAleatorios * (hasta - desde));
                numerosAleatorios[i] = operacion;
                tablaaleatorios.Rows.Add(i + 1, operacion);
                //// Calcula la cantidad de numeros por cada intervalo(frecuenciaObservada)
                // int contador = 0;
                //while (operacion > limiteSuperior[contador])
                //{
                //    contador++;
                //}
                //frecuenciaObservada[contador] += 1;
            }
        }
        private void realizarTest()
        {
            // Limpiamos Tablas y Grafico
            tablaanalisis.Rows.Clear();
            tablaaleatorios.Rows.Clear();
            Grafico.Series.Clear();
            //TODO: HAY QUE LIMPIAR EL ARRAY DE numerosAleatorios

            // Tomamos los valores de m (cantidad de numeros aleatorios)
            // y k (cantidad de intervalos)
            int m = int.Parse(txt_m.Text);
            int k = int.Parse(txt_k.Text);


            // Asignamos k (cantidad de intervalos) a los vectores
            limiteInferior = new double[k];
            limiteSuperior = new double[k];
            frecuenciaObservada = new double[k];

            //// Asigno los valores de los intervalos
            //for (int i = 0; i < k; i++)
            //{
            //    double paso = (double)(i + 1) / k; // Paso o longitud de cada intervalo
            //    if (i != k - 1)
            //    {
            //        limiteInferior[i + 1] = Math.Round(paso, 2);
            //    }
            //    limiteSuperior[i] = Math.Round(paso, 2);
            //}


            //GeneracionNrosAleatoreos(m);
            switch (comboDist.SelectedIndex)
            {
                case 0:
                    //distUniforme(double.Parse(constante1.Text), double.Parse(constante2.Text), m);
                    break;

                case 1:
                    label10.Text = "Lambda";
                    //label11.Text = "Desviación";
                    label10.Visible = true;
                    label11.Visible = false;
                    constante1.Visible = true;
                    constante2.Visible = false;
                    break;
                case 2:
                    label10.Text = "Lambda";
                    //label11.Text = "Desviación";
                    label10.Visible = true;
                    label11.Visible = false;
                    constante1.Visible = true;
                    constante2.Visible = false;
                    break;
                case 3:
                    distUniforme(double.Parse(constante1.Text), double.Parse(constante2.Text), m);
                    break;
                default:

                    label10.Visible = false;
                    label11.Visible = false;
                    constante1.Visible = false;
                    constante2.Visible = false;
                    break;
            }


            //Calculo maximo y minimo de los numeros aleatorios
            double maximo = numerosAleatorios.Max();
            double minimo = numerosAleatorios.Min();

            //Calculo el paso de cada intervalo
            double paso = Math.Round((maximo - minimo) / k, 2);

            //Asigno valor a los limites
            for (int i = 0; i < k; i++)
            {
                //Primer limite inferior: valor minimo
                if (i == 0) limiteInferior[i] = minimo;
                //Otros limites inferiores igual al limite superior anterior
                else limiteInferior[i] = limiteSuperior[i - 1];
                //Limite superior igual al inferior mas el paso
                limiteSuperior[i] = limiteInferior[i] + paso;
            }

            for (int i = 0; i < numerosAleatorios.Length; i++)
            {
                // Calcula la cantidad de numeros por cada intervalo(frecuenciaObservada)
                int contador = 0;
                while (numerosAleatorios[i] > limiteSuperior[contador])
                {
                    contador++;
                    if (contador == 5) contador = 0;
                }
                frecuenciaObservada[contador] += 1;
            }

            // C
            estadistico = new double[k];
            // C Ac
            estadisticoAcumulado = new double[k];

            // Asigno valores a la tabla
            for (int i = 0; i < k; i++)
            {
                // frecuenciaEsperada = cantidadNrosAleatorios / cantidadIntervalos
                double frecuenciaEsperada = m / k;

                // Calculo del valor de C
                estadistico[i] = (double)Math.Pow(frecuenciaObservada[i] - frecuenciaEsperada, 2) / frecuenciaEsperada;

                // Calculo del valor de C Acumulado
                if (i == 0) // Primera vuelta guarda el mismo valor de c
                {
                    estadisticoAcumulado[i] = estadistico[i];
                }
                else // acumula C
                {
                    estadisticoAcumulado[i] = estadistico[i] + estadisticoAcumulado[i - 1];
                }

                // Agrego los valores a la tabla
                tablaanalisis.Rows.Add(limiteInferior[i], limiteSuperior[i], frecuenciaObservada[i], frecuenciaEsperada, estadistico[i], estadisticoAcumulado[i]);
            }

            // Genera Grafico
            if (Grafico.Titles.Count == 0)
                Grafico.Titles.Add("Frecuencias observadas");

            Series series = Grafico.Series.Add("Frecuencia Observada");
            series.ChartType = SeriesChartType.Column;
            Grafico.ChartAreas[0].AxisX.Title = "Datos obtenidos";
            Grafico.ChartAreas[0].AxisY.Title = "Frecuencias";

            // Cargo los intervalos con sus respectivos valores
            for (int i = 0; i < limiteSuperior.Length; i++)
            {
                series.Points.AddXY(limiteSuperior[i], frecuenciaObservada[i]);
            }

            // Calculo lambda y lo muestro
            txt_resul.Text = Math.Round(estadisticoAcumulado[k - 1], 4).ToString();

            // Calculo el valor y obtengo el valor tabulado.
            var p = 1 - Convert.ToDouble(cboSignificancia.SelectedItem);
            double chi = ChiSquared.InvCDF(k - 1, p);
            tbChi.Text = Math.Round(chi, 4).ToString();

            // Si el estadístico de prueba es menor o igual que el valor
            // crítico, no se puede rechazar la hipótesis nula

        }

        // Generacion de los numeros aleatorios
        private void GeneracionNrosAleatoreos(int cant)
        {
            Random rnd = new Random();
            double numAleatorios;

            for (int i = 0; i < cant; i++)
            {
                // Genera los numeros y los agrega a la tabla
                numAleatorios = Math.Round(rnd.NextDouble(), 4);
                tablaaleatorios.Rows.Add(i + 1, numAleatorios);
                // Calcula la cantidad de numeros por cada intervalo (frecuenciaObservada)
                int contador = 0;
                while (numAleatorios > limiteSuperior[contador])
                {
                    contador++;
                }
                frecuenciaObservada[contador] += 1;
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

    }
}

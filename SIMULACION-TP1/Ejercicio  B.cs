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

        double[] limiteInferior, limiteSuperior, frecuenciaObservada, estadistico, estadisticoAcumulado;

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

            // Corroboramos que k sea menor o igual a m
            if (k <= m)
            {
                realizarTest();
            }
            else
            {
                MessageBox.Show("K debe ser menor o igual a M", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void realizarTest()
        {
            // Limpiamos Tablas y Grafico
            tablaanalisis.Rows.Clear();
            tablaaleatorios.Rows.Clear();
            Grafico.Series.Clear();

            // Tomamos los valores de m (cantidad de numeros aleatorios)
            // y k (cantidad de intervalos)
            int m = int.Parse(txt_m.Text);
            int k = int.Parse(txt_k.Text);

            // Asignamos k (cantidad de intervalos) a los vectores
            limiteInferior = new double[k];
            limiteSuperior = new double[k];
            frecuenciaObservada = new double[k];

            // Asigno los valores de los intervalos
            for (int i = 0; i < k; i++)
            {
                double doble = (double)(i + 1) / k;
                try { limiteInferior[i + 1] = Math.Round(doble, 2); } catch { }
                limiteSuperior[i] = Math.Round(doble, 2);
            }

            GeneracionNrosAleatoreos(m);

            estadistico = new double[k];
            estadisticoAcumulado = new double[k];

            // Asigno valores a la tabla
            for (int i = 0; i < k; i++)
            {
                // frecuenciaEsperada = cantidadNrosAleatorios / cantidadIntervalos
                double frecuenciaEsperada = m / k;

                // Calculo del valor de C
                estadistico[i] = (double)Math.Pow(frecuenciaObservada[i] - frecuenciaEsperada, 2) / frecuenciaEsperada;

                // Calculo del valor de C Acumulado
                try { estadisticoAcumulado[i] = estadistico[i] + estadisticoAcumulado[i - 1]; } catch { }

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

            for (int i = 0; i < cant; i++) { 
            
                numAleatorios = Math.Round(rnd.NextDouble(), 4);
                tablaaleatorios.Rows.Add(i+1, numAleatorios);

                int contador = 0;
                while (numAleatorios > limiteSuperior[contador])
                {
                    contador++;
                }
                frecuenciaObservada[contador] += 1;
            }
        }
    }
}

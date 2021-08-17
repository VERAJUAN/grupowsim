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

/*donde
 X es la secuencia de números pseudoaleatorios, y
 a = es la constante multiplicativa.
 c = es la constante aditiva.
 m = es la magnitud del módulo.
 X0 = es la semilla.*/

namespace SIMULACION_TP1
{
    public partial class Ejercicio__C : System.Windows.Forms.Form
    {
        // DataTable tablaDatos, tablaAleatorio;
        double[] limiteInferior, limiteSuperior, frecuenciaObservada, estadistico, estadisticoAcumulado;

        public Ejercicio__C()
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
            int semilla = int.Parse(txt_semilla.Text);

            ///int cantidad, decimal semilla, int constanteAditiva, int constanteMultiplicativa,int magnitudModulo
            int constanteAditiva = int.Parse(txt_cA.Text);
            int constatnteMultiplicativa = int.Parse(txt_cM.Text);
            int magModulo = int.Parse(txt_mag.Text);

            // magModulo mayor a todo lo demás
            if (
                //magModulo > m && magModulo > k
                //&& magModulo > constanteAditiva
                //&& magModulo > semilla &&
                magModulo > 0
                && m > 0
                && semilla > 0
                && constanteAditiva > 0
                && k > 0)
            {

                // Asignamos k (cantidad de intervalos) a los vectores
                limiteInferior = new double[k];
                limiteSuperior = new double[k];
                frecuenciaObservada = new double[k];

                // Asigno los valores de los intervalos
                for (int i = 0; i < k; i++)
                {
                    double doble = (double)(i + 1) / k;
                    if (i != k - 1)
                    {
                        limiteInferior[i + 1] = Math.Round(doble, 2);
                    }
                    limiteSuperior[i] = Math.Round(doble, 2);
                }

                GenenerarMetodoCongruencialMixto(m, semilla, constanteAditiva, constatnteMultiplicativa, magModulo);

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
            else
            {
                MessageBox.Show("Todos deben positivos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void GenenerarMetodoCongruencialMixto(int cantidad, decimal semilla, int constanteAditiva, int constanteMultiplicativa, int magnitudModulo)
        {   //𝑥𝑛+1 ≡ (𝑎 ∙ 𝑥𝑛 + 𝑐)𝑚𝑜𝑑 𝑚 0 ≤ 𝑥𝑛 ≤ m
            //valoresX = secuencia Valores Numeros Pseudoaleatorios
            int[] valoresX = new int[cantidad];
            decimal valorSemilla = semilla;
            //c
            int constAditiva = constanteAditiva;
            //a
            int constMultiplicativa = constanteMultiplicativa;
            //m
            int magModulo = magnitudModulo;

            //Realiza calculo del metodo congruencial Mixto
            for (int i = 0; i < cantidad; i++)
            {
                decimal xi = 0;
                decimal xi1 = 0;

                if (i == 0)
                {
                    xi1 = valorSemilla;
                }
                else
                // calcula el valor con respecto al numero anterior
                {
                    xi1 = decimal.Parse(valoresX[i - 1].ToString());
                }

                //calculo del termino (𝑎 ∙ 𝑥𝑛 + 𝑐)

                xi = (constMultiplicativa * xi1) + constanteAditiva;
                //calcular termino X(i+1) reemplaza a valor semilla
                xi1 = Convert.ToInt32(xi % magModulo);

                // Calcula el termino (Xi+1)/(m-1) y toma  4 decimales

                decimal numAleat = Math.Truncate((xi1 / (magModulo - 1)) * 10000) / 10000;

                // TODO: Preguntar si dejamos 0.9999 en vez de 1.
                //if (numAleat == 1)
                //{
                //    numAleat = (decimal)0.9999;
                //}

                valoresX[i] = Convert.ToInt32(xi1);

                // Mostrar los valores en la tabla
                tablaaleatorios.Rows.Add(i + 1, numAleat);
                double aux1 = Convert.ToDouble(numAleat);
                int aux = 0;
                while (aux1 > limiteSuperior[aux])
                {
                    aux++;
                }
                frecuenciaObservada[aux] += 1;
            }

            valoresX = null;

        }

        // Keypress
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

        private void txt_cA_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_cM_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_mag_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_semilla_KeyPress(object sender, KeyPressEventArgs e)
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
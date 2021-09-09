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

        private void cboSignificancia_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDist.SelectedIndex = 0;
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
            if (k > 4 && m >= k)
            {
                realizarTest();
            }
            else
            {
                MessageBox.Show("K debe ser mayor a 4 y se sugiere que sea raíz cuadrada de M. M debe ser igual o mayor a K", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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
                    label10.Visible = true;
                    label11.Visible = false;
                    constante1.Visible = true;
                    constante2.Visible = false;
                    break;
                case 2:
                    label10.Text = "Lambda";
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

        private void realizarTest()
        {
            // Limpiamos Tablas y Grafico
            tablaanalisis.Rows.Clear();
            tablaaleatorios.Rows.Clear();
            Grafico.Series.Clear();
            numerosAleatorios = new List<double>();

            // Tomamos los valores de m (cantidad de numeros aleatorios)
            // y k (cantidad de intervalos)
            int m = int.Parse(txt_m.Text);
            int k = int.Parse(txt_k.Text);


            // Asignamos k (cantidad de intervalos) a los vectores
            limiteInferior = new double[k];
            limiteSuperior = new double[k];
            frecuenciaObservada = new double[k];
            frecuenciaEsperada = new double[k];

            //GeneracionNrosAleatoreos(m);
            switch (comboDist.SelectedIndex)
            {
                case 0:
                    //Normal
                   if ( double.Parse(constante2.Text) < 0)
                    {
                        MessageBox.Show("No puedes ingresar esos valores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        // constante1.Text = "1"; 
                        //constante2.Text = "2" ;
                    }
                    numerosAleatorios = Distribucion.Normal(m, double.Parse(constante1.Text), double.Parse(constante2.Text));
                    break;
                case 1:
                    //Exponencial
                    if (double.Parse(constante1.Text) <= 0)
                    {
                        MessageBox.Show("Lambda tiene que ser positivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        //constante1.Text = "1"; 
                        //constante2.Text = "2" ;
                    }
                    numerosAleatorios = Distribucion.Exponencial(m, double.Parse(constante1.Text));
                    break;
                case 2:
                    //Poisson
                     if (double.Parse(constante1.Text) <= 0)
                    {
                        MessageBox.Show("Lambda tiene que ser positivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        //constante1.Text = "1";
                        //constante2.Text = "2" ;
                    }
                    numerosAleatorios = Distribucion.Poisson(m, double.Parse(constante1.Text));
                    break;
                case 3:
                    // uniforme 
                     if (double.Parse(constante1.Text) > double.Parse(constante2.Text) )
                    {
                        MessageBox.Show("No puedes ingresar esos valores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        // constante1.Text = "1"; 
                        //constante2.Text = "2" ;
                    }
                    numerosAleatorios = Distribucion.Uniforme(
                        double.Parse(constante1.Text), double.Parse(constante2.Text), m);
                    break;
                default:
                    label10.Visible = false;
                    label11.Visible = false;
                    constante1.Visible = false;
                    constante2.Visible = false;
                    break;
            }

            for(int i = 0; i < m; i++)
            {
                tablaaleatorios.Rows.Add(i + 1, numerosAleatorios.ElementAt(i));
            }

            //Calculo maximo y minimo de los numeros aleatorios
            double maximo = numerosAleatorios.Max();
            double minimo = numerosAleatorios.Min();

            //Calculo el paso de cada intervalo
            double paso = Math.Round((maximo - minimo) / k, 4);

            //Asigno valor a los limites
            for (int i = 0; i < k; i++)
            {
                //Primer limite inferior: valor minimo
                if (i == 0) limiteInferior[i] = Math.Round(minimo, 4);
                //Otros limites inferiores igual al limite superior anterior
                else limiteInferior[i] = Math.Round(limiteSuperior[i - 1], 4);
                //Si es el ultimo limite
                if(i == k-1) limiteSuperior[i] = Math.Round(maximo, 4);
                //Limite superior igual al inferior mas el paso
                else limiteSuperior[i] = Math.Round(limiteInferior[i] + paso, 4);
            }

            for (int i = 0; i < m; i++)
            {
                // Calcula la cantidad de numeros por cada intervalo(frecuenciaObservada)
                int contador = 0;
                while (numerosAleatorios[i] > limiteSuperior[contador])
                {
                    contador++;
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
                //Frecuencia esperada por distribución
                switch (comboDist.SelectedIndex)
                {
                    case 0:
                        //Normal
                       
                        frecuenciaEsperada[i] = Frecuencia.Normal(m, k, double.Parse(constante1.Text), double.Parse(constante2.Text), paso);
                        break;
                    case 1:
                        //Exponencial
                        frecuenciaEsperada[i] = Frecuencia.Exponencial(paso, m, double.Parse(constante1.Text));
                        break;
                    case 2:
                        //Poisson
                        frecuenciaEsperada[i] = Frecuencia.Poisson((int)paso, double.Parse(constante1.Text), (int)m);
                        break;
                    case 3:
                        //Uniforme
                        frecuenciaEsperada[i] = Frecuencia.Uniforme(m, k);
                        break;
                }


                // Calculo del valor de C
                estadistico[i] = (double)Math.Pow(frecuenciaObservada[i] - frecuenciaEsperada[i], 2) / frecuenciaEsperada[i];

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
                tablaanalisis.Rows.Add(limiteInferior[i], limiteSuperior[i], frecuenciaObservada[i], frecuenciaEsperada[i], estadistico[i], estadisticoAcumulado[i]);
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

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
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

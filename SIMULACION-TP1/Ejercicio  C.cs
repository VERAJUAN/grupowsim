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
        double [] limiteInferior, limiteSuperior, frecuenciaObservada, estadistico, estadisticoAcumulado;

      
        public Ejercicio__C()
        {
            InitializeComponent();
            cboSignificancia.SelectedIndex = 0;
            tbChi.Text = "";
            txt_resul.Text = "";
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            // Limpiamos Tablas y Grafico
            tablaanalisis.Rows.Clear();
            tablaaleatorios.Rows.Clear();
            Grafico.Series.Clear();

            // Tomamos los valores de m (cantidad de numeros aleatorios)
            // y k (cantidad de intervalos)
            int m = int.Parse(txt_m.Text);
            int k = int.Parse(txt_k.Text);

            ///int cantidad, decimal semilla, int constanteAditiva, int constanteMultiplicativa,int magnitudModulo
            int constanteAditiva = int.Parse(txt_cA.Text);
            int constatnteMultiplicativa = int.Parse(txt_cM.Text);
            int magModulo = int.Parse(txt_mag.Text);
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

            GenenerarMetodoCongruencialMixto(k, m, constanteAditiva, constatnteMultiplicativa, magModulo);

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
            Series series = Grafico.Series.Add("Frecuencia Observada");
            series.ChartType = SeriesChartType.Column;

            // Cargo los intervalos con sus respectivos valores
            for (int i = 0; i < limiteSuperior.Length; i++)
            {
                series.Points.AddXY(limiteSuperior[i], frecuenciaObservada[i]);
            }

            // Calculo lambda y lo muestro
            txt_resul.Text = Math.Round(estadisticoAcumulado[k - 1], 4).ToString();

            // Calculo el valor y obtengo el valor tabulado.
            double chi = ChiSquared.InvCDF(k - 1, Convert.ToDouble(cboSignificancia.SelectedItem));
            tbChi.Text = Math.Round(chi, 2).ToString();

            // Si el estadístico de prueba es menor o igual que el valor
            // crítico, no se puede rechazar la hipótesis nula
     
        }
      

        private void GenenerarMetodoCongruencialMixto(int cantidad, decimal semilla, int constanteAditiva, int constanteMultiplicativa,int magnitudModulo)
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
            for(int i = 0; i < cantidad; i++)
            {
                decimal xi = 0;
                decimal xi1 = 0;

                if(i == 0)
                {
                    xi1 = valorSemilla;
                }
                else
                // calcula el valor con respecto al numero anterior
                {
                    xi1 = decimal.Parse(valoresX[i-1].ToString());
                }

                //calculo del termino (𝑎 ∙ 𝑥𝑛 + 𝑐)

                xi = (constMultiplicativa * xi1) + constanteAditiva;
                //calcular termino X(i+1) reemplza a valor semilla
                xi1 = Convert.ToInt32(xi % magModulo);

                // Calcula el termino (Xi+1)/(m-1) y toma  4 decimales
                
                decimal numAleat = Math.Truncate((xi1 / magModulo)* 10000)/ 10000;

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
        
        
        
    }
}

/*
 *  private void GeneracionCongruenteMixto(int cant, decimal semilla, int cteC, int cteA, double cteM)
        {
            int[] valoresXi1 = new int[cant];
            decimal valorXo = semilla;
            int valorC = cteC;

            int valorA = cteA;
            double valorM = cteM;
            //inputModulo.Text = valorM.ToString();

            // Ciclo for para realizar el cálculo del metodo
            for (int i = 0; i < cant; i++)
            {
                int Xi, Xi1 = 0;

                if (i == 0)
                {
                    Xi1 = Convert.ToInt32(valorXo);
                }
                else
                {
                    int ans = i - 1;
                    Xi1 = int.Parse(valoresXi1[ans].ToString());
                }

                // Calcular el termino a.Xi + c
                Xi = (valorA * Xi1) + valorC;

                // Calcular el valor del termino X(i+1) que reemplaza a Xo (raiz)
                Xi1 = Convert.ToInt32(Xi % valorM);

                // Calcular el termino (Xi+1)/(m-1) y redondear a 4 decimales
                double numAleatorio = Math.Round((Xi1 / valorM), 4);
                valoresXi1[i] = Xi1;

                // Mostrar los valores en la tabla
                tablaAleatorio.Rows.Add(i+1, numAleatorio);

                int aux = 0;
                while (numAleatorio > limSup[aux])
                {
                    aux++;
                }
                fo[aux] += 1;
            }

            valoresXi1 = null;
        }
 * 
 * */

/*using MathNet.Numerics.Distributions;
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
        public Ejercicio__B()
        {
            InitializeComponent();
            cboSignificancia.SelectedIndex = 0;
            tbChi.Text = "";
            txt_resul.Text = "";
        }

        private void btn_generar_Click(object sender, EventArgs e)
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
            Series series = Grafico.Series.Add("Frecuencia Observada");
            series.ChartType = SeriesChartType.Column;

            // Cargo los intervalos con sus respectivos valores
            for (int i = 0; i < limiteSuperior.Length; i++)
            {
                series.Points.AddXY(limiteSuperior[i], frecuenciaObservada[i]);
            }

            // Calculo lambda y lo muestro
            txt_resul.Text = Math.Round(estadisticoAcumulado[k - 1], 4).ToString();

            // Calculo el valor y obtengo el valor tabulado.
            double chi = ChiSquared.InvCDF(k - 1, Convert.ToDouble(cboSignificancia.SelectedItem));
            tbChi.Text = Math.Round(chi,2).ToString();

            // Si el estadístico de prueba es menor o igual que el valor
            // crítico, no se puede rechazar la hipótesis nula


        }

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

 * 
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULACION_TP1.Libreria
{
    public static class Distribucion
    {
        public static List<double> Normal()
        {
            List<double> listado = new List<double>();




            return listado;
        }

        public static List<double> Exponencial()
        {
            List<double> listado = new List<double>();




            return listado;
        }

        public static List<double> Poisson()
        {
            List<double> listado = new List<double>();




            return listado;
        }

        public static List<double> Uniforme(double desde, double hasta, int m)
        {
            List<double> listado = new List<double>();

            Random random = new Random();
            // numerosAleatorios = new double[m];
            double numAleatorio = 0, operacion = 0;

            for (int i = 0; i < m; i++)
            {
                numAleatorio = Math.Round(random.NextDouble(), 4);
                operacion = Math.Round(desde + (numAleatorio * (hasta - desde)), 4);
                listado.Add(operacion); //Agregamos a la lista

                //// Calcula la cantidad de numeros por cada intervalo(frecuenciaObservada)
                // int contador = 0;
                //while (operacion > limiteSuperior[contador])
                //{
                //    contador++;
                //}
                //frecuenciaObservada[contador] += 1;
            }


            return listado;
        }


    }
}

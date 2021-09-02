using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuciones
{
    public static class Distribucion
    {
        public static List<double> Normal(int m, double media, double varianza)
        {
            List<double> listado = new List<double>();
            Random random = new Random();
            double numAleatorio = 0, operacion = 0;
            media = m / 2;
            varianza = m / 12;


            for (int i = 0; i < m; i++)
            {
                numAleatorio = 0;
                for (int j = 0; j < m; j++)
                {
                    numAleatorio += random.NextDouble();
                }
                operacion = Math.Round(((numAleatorio - 6 ) * varianza) + media, 4);
                listado.Add(operacion); //Agregamos a la lista
            }

            return listado;
        }

        public static List<double> Exponencial(int m, double lambda)
        {
            List<double> listado = new List<double>();
            Random random = new Random();
            double numAleatorio = 0, operacion = 0;
            double mediaNegativa = (1 / lambda) * -1;

            for (int i = 0; i < m; i++)
            {
                numAleatorio = random.NextDouble();
                operacion = Math.Round(mediaNegativa * Math.Log(1 - numAleatorio), 4);
                listado.Add(operacion); //Agregamos a la lista
            }

            return listado;
        }

        public static List<double> Poisson(int m, double lambda)
        {
            List<double> listado = new List<double>();
            Random random = new Random();
            double a = Math.Exp(-lambda);

            for (int i = 0; i < m; i++)
            {
                double p = 1;
                int operacion = -1;
                do
                {
                    double numAleatorio = random.NextDouble();
                    p = p * numAleatorio;
                    operacion++;
                } while (p >= a);

                listado.Add(operacion); //Agregamos a la lista
            }
                
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
            }


            return listado;
        }


    }
}

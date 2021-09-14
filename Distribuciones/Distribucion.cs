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
                // Sumatoria de los numeros aleatorios generados por el lenguaje
                for (int j = 0; j < m; j++)
                {
                    numAleatorio += random.NextDouble();
                }
                // (la sumatoria de los numeros aleatorios - 6) * varianza + media
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
                // Generamos el numero con el lenguaje
                numAleatorio = random.NextDouble();
                // mediaNegativa * ln(1-numeroAleatorio)
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
                    //Generamos el aleatorio
                    double numAleatorio = random.NextDouble();
                    // multiplicamos p por el numero aleatorio
                    p = p * numAleatorio;
                    operacion++;
                } while (p >= a); //cuando p sea mayor o igual a 'a' (-lambda)

                listado.Add(operacion); //Agregamos a la lista
            }
                
            return listado;
        }

        public static List<double> Uniforme(double desde, double hasta, int m)
        {
            List<double> listado = new List<double>();

            Random random = new Random();
            double numAleatorio = 0, operacion = 0;

            for (int i = 0; i < m; i++)
            {
                //generamos el numAleatorio
                numAleatorio = Math.Round(random.NextDouble(), 4);
                // el numAleatorio final va ser (desde + (numAleatorio * (hasta - desde))
                operacion = Math.Round(desde + (numAleatorio * (hasta - desde)), 4);
                listado.Add(operacion); //Agregamos a la lista
            }

            return listado;
        }


    }
}

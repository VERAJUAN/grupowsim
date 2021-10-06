using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuciones
{
    public static class Distribucion
    {

        public static double Normal(double xi, double media, double desviacion)
        {
            Random r = new Random();
            double RND1 = r.NextDouble();
            double RND2 = r.NextDouble();

            // Aplicar la formula de Box-Muller
            double N1 = ((Math.Sqrt(-2 * Math.Log(RND1, 2))) * Math.Cos(2 * Math.PI * RND2)) * desviacion + media;
            double N2 = ((Math.Sqrt(-2 * Math.Log(RND1, 2))) * Math.Sin(2 * Math.PI * RND2)) * desviacion + media;

            return N1;

        }

        public static double Exponencial(double xi, double lambda)
        {
            double mediaNegativa = (1 / lambda) * -1;

            return Math.Round(mediaNegativa * Math.Log(1 - xi), 4);
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

        public static double Uniforme(double xi, double desde, double hasta)
        {
            // el numAleatorio final va ser (desde + (numAleatorio * (hasta - desde)) 
            return Math.Round(desde + (xi * (hasta - desde)), 4);
        }


    }
}

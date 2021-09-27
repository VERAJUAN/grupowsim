using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuciones
{
    public static class Distribucion
    {



       
        public static double Normal(int m, double media, double desviacion)
        {


            Random r = new Random();
            // List<double> listado = new List<double>();
       

            //for (int i = 0; i < m; i++)
            //{
                // Obtener dos nros aleatorios de entrada
                double RND1 = r.NextDouble();
                double RND2 = r.NextDouble();

                // Aplicar la formula de Box-Muller
                double N1 = ((Math.Sqrt(-2 * Math.Log(RND1, 2))) * Math.Cos(2 * Math.PI * RND2)) * desviacion + media;
                double N2 = ((Math.Sqrt(-2 * Math.Log(RND1, 2))) * Math.Sin(2 * Math.PI * RND2)) * desviacion + media;

                // Guardar los valores, controlando que no sean mas de los que se piden debido que este metodo genera dos nros aleatorios, en la lista intermedia
            //    if (!(listado.Count == m))
            //    {
            //        listado.Add(Math.Round(N1,4));
                    

            //        if (!(listado.Count == m))
            //        {
            //            listado.Add(Math.Round(N2,4));
                       

            //        }
            //    }
            //}
            return N1;
           
        }

        public static double Exponencial(int m, double lambda)
        {
            //List<double> listado = new List<double>();
            Random random = new Random();
            double numAleatorio = 0, operacion = 0;
            double mediaNegativa = (1 / lambda) * -1;

            //for (int i = 0; i < m; i++)
            //{
                // Generamos el numero con el lenguaje
                numAleatorio = random.NextDouble();
                // mediaNegativa * ln(1-numeroAleatorio)
                operacion = Math.Round(mediaNegativa * Math.Log(1 - numAleatorio), 4);
                //listado.Add(operacion); //Agregamos a la lista
            //}

            return operacion;
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

        public static double Uniforme(double desde, double hasta, int m)
        {
            //List<double> listado = new List<double>();

            Random random = new Random();
            double numAleatorio = 0, operacion = 0;

            //for (int i = 0; i < m; i++)
            //{
                //generamos el numAleatorio
                numAleatorio = Math.Round(random.NextDouble(), 4);
                // el numAleatorio final va ser (desde + (numAleatorio * (hasta - desde))
                operacion = Math.Round(desde + (numAleatorio * (hasta - desde)), 4);
                //listado.Add(operacion); //Agregamos a la lista
            //}

            return operacion;
        }


    }
}

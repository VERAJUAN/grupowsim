using System;
using System.Collections.Generic;
using System.Text;

namespace Distribuciones
{
    public static class Frecuencia
    {
        public static double Normal(double m, double k, double media, double desv, double paso)
        {
            double numerador = Math.Exp(-0.5 * Math.Pow((k - media) / desv, 2));
            double denominador = (desv * Math.Sqrt(2 * Math.PI));
            double fe = (numerador / denominador) * m * paso;
            return fe;
        }

        public static double Exponencial(double paso, double m, double lambda)
        {
            double fe = (lambda * Math.Pow(Math.E, - lambda * paso  )) * m;

            return Math.Round(fe,3);
        }

        public static double Uniforme(double m, double k)
        {
            double fe = m / k;
            return Math.Round(fe, 3);
        }

        public static double Poisson(int paso, double lambda, int m)
        {
            double fe = ((Math.Pow(Math.E , lambda * -1) * Math.Pow(lambda, paso)) / Factorial(paso)) * m;
            return Math.Round(fe, 3);
        }

        private static double Factorial(double f)
        {
            if (f == 0)
                return 1;
            else
                return f * Factorial(f - 1);
        }
    }
}
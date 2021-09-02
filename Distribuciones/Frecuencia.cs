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

        public static double Exponencial(double k, double m, double lambda)
        {
            double fe = (lambda * Math.Pow(Math.E, lambda * k * -1)) * m;
            return Math.Round(fe, 3);
        }

        public static double Uniforme(double m, double k)
        {
            double fe = m / k;
            return Math.Round(fe, 3);
        }

        public static double Poisson(double m, double k, double lambda)
        {
            double fe = ((Math.Pow(lambda, k) * Math.Pow(Math.E, lambda * -1)) / Factorial(k)) * m;
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
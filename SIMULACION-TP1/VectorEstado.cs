using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULACION_TP1
{
    public class VectorEstado
    {
        public double Tmax(double t1, double t2, double t3)
        {
            return t1 > t2 && t1 > t3 ? t1 : (t2 > t3 ? t2 : t3);
        }

        public double Tmin(double t1, double t2, double t3)
        {
            return t1 < t2 && t1 < t3 ? t1 : (t2 < t3 ? t2 : t3);
        }

        public double diasA4deMas(double t4, double tmax, double t1)
        {
            return t4 - (tmax - t1);
        }

        public double sumaA1aA4(double tmax, double diasA4deMas)
        {
            return tmax + (diasA4deMas > 0 ? diasA4deMas : 0);
        }

        public double maxT2yT4(double t2, double t4)
        {
            return t2 > t4 ? t2 : t4;
        }

        public double diasA5deMas(double maxT2yT4, double t5, double sumaA1aA4)
        {
            return maxT2yT4 < sumaA1aA4 ? (maxT2yT4 + t5 - sumaA1aA4) : t5;
        }

        public double duracionEnsamble(double sumaA1aA4, double diasA5deMas)
        {
            return sumaA1aA4 + diasA5deMas;
        }

        public double acumuladoEnsamble(double acumAnterior, double duracionEnsamble)
        {
            return acumAnterior + duracionEnsamble;
        }

        public double promedioDuracionEnsamble(double acumulado, double dia)
        {
            return acumulado / dia;
        }

        public double maxDuracion(double maxAnterior, double duracionEnsamble)
        {
            return maxAnterior > duracionEnsamble ? maxAnterior : duracionEnsamble;
        }

        public double minDuracion(double minAnterior, double duracionEnsamble)
        {
            return minAnterior < duracionEnsamble ? minAnterior : duracionEnsamble;
        }

        public double cantTareasMenor45Dias(double duracionEnsamble, double cantAnterior)
        {
            return duracionEnsamble < 45 ? cantAnterior + 1 : cantAnterior;
        }

        public double probCompletarEn45Dias(double cantTareasMenor45Dias, double dia)
        {
            return cantTareasMenor45Dias / dia;
        }
    }
}

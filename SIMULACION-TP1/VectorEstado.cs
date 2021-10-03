using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace SIMULACION_TP1
{
    public class VectorEstado
    {
        public int nroProyecto { get; set; }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double T3 { get; set; }
        public double TMax => Tmax(T1, T2, T3);
        public double TMin => Tmin(T1, T2, T3);
        public double T4 { get; set; }
        public double DiasA4deMas => diasA4deMas(T4, TMax, T1);
        public double SumaA1aA4 => sumaA1aA4(TMax, DiasA4deMas);
        public double T5 { get; set; }
        public double MaxEntreT2yT4 => maxT2yT4(T2, T4);
        public double DiasA5deMas => diasA5deMas(MaxEntreT2yT4, T5, SumaA1aA4);
        public double DuracionEnsamble => duracionEnsamble(SumaA1aA4, DiasA5deMas);
        public double AcumAnterior { get; set; } //Ver q onda
        public double AcumuladoEnsamble => acumuladoEnsamble(AcumAnterior, DuracionEnsamble);
        public double PromedioDuracionEnsamble => promedioDuracionEnsamble(AcumuladoEnsamble, nroProyecto);
        public double MaxAnterior { get; set; } //Ver q onda
        public double MaxDuracion => maxDuracion(MaxAnterior, DuracionEnsamble);
        public double MinAnterior { get; set; } //Ver q onda
        public double MinDuracion => minDuracion(MinAnterior, DuracionEnsamble);
        public double CantTareasMenor45DiasAnterior { get; set; } //Ver q onda
        public double CantTareasMenor45Dias => cantTareasMenor45Dias(DuracionEnsamble, CantTareasMenor45DiasAnterior);
        public double ProbCompletarEn45Dias => probCompletarEn45Dias(CantTareasMenor45Dias, nroProyecto);
        public double VarianzaAnterior { get; set; } //Ver q onda
        public double Varianza => varianza(nroProyecto, DuracionEnsamble, PromedioDuracionEnsamble, VarianzaAnterior);
        public double Desviacion => desviacion(Varianza);
        public double FechaNc90 => fechaNc90(nroProyecto, PromedioDuracionEnsamble, Desviacion);

        public VectorEstado() { }

        public VectorEstado(int nroProyecto, double t1, double t2, double t3, double t4, double t5, double acumAnterior, double maxAnterior, double minAnterior, double cantTareasMenor45DiasAnterior)
        {
            this.nroProyecto = nroProyecto;
            T1 = t1;
            T2 = t2;
            T3 = t3;
            T4 = t4;
            T5 = t5;
            AcumAnterior = acumAnterior;
            MaxAnterior = maxAnterior;
            MinAnterior = minAnterior;
            CantTareasMenor45DiasAnterior = cantTareasMenor45DiasAnterior;
        }

        private double Tmax(double t1, double t2, double t3)
        {
            return t1 > t2 && t1 > t3 ? t1 : (t2 > t3 ? t2 : t3);
        }

        private double Tmin(double t1, double t2, double t3)
        {
            return t1 < t2 && t1 < t3 ? t1 : (t2 < t3 ? t2 : t3);
        }

        private double diasA4deMas(double t4, double tmax, double t1)
        {
            return t4 - (tmax - t1);
        }

        private double sumaA1aA4(double tmax, double diasA4deMas)
        {
            return tmax + (diasA4deMas > 0 ? diasA4deMas : 0);
        }

        private double maxT2yT4(double t2, double t4)
        {
            return t2 > t4 ? t2 : t4;
        }

        private double diasA5deMas(double maxT2yT4, double t5, double sumaA1aA4)
        {
            return maxT2yT4 < sumaA1aA4 ? (maxT2yT4 + t5 - sumaA1aA4) : t5;
        }

        private double duracionEnsamble(double sumaA1aA4, double diasA5deMas)
        {
            return sumaA1aA4 + diasA5deMas;
        }

        private double acumuladoEnsamble(double acumAnterior, double duracionEnsamble)
        {
            return acumAnterior + duracionEnsamble;
        }

        private double promedioDuracionEnsamble(double acumulado, double nroProyecto)
        {
            return acumulado / nroProyecto;
        }

        private double maxDuracion(double maxAnterior, double duracionEnsamble)
        {
            return maxAnterior > duracionEnsamble ? maxAnterior : duracionEnsamble;
        }

        private double minDuracion(double minAnterior, double duracionEnsamble)
        {
            return minAnterior < duracionEnsamble ? minAnterior : duracionEnsamble;
        }

        private double cantTareasMenor45Dias(double duracionEnsamble, double cantAnterior)
        {
            return duracionEnsamble < 45 ? cantAnterior + 1 : cantAnterior;
        }

        private double probCompletarEn45Dias(double cantTareasMenor45Dias, double nroProyecto)
        {
            return cantTareasMenor45Dias / nroProyecto;
        }

        private double varianza(int nroProyecto, double duracionEnsamble, double promedioDuracionEnsamble, double varianzaAnterior)
        {
            return nroProyecto == 0 ? 0 : (1 / (nroProyecto - 1)) * (((nroProyecto - 2) * varianzaAnterior) + ((nroProyecto / (nroProyecto - 1)) * Math.Sqrt(promedioDuracionEnsamble - duracionEnsamble)));
        }

        private double desviacion(double varianza)
        {
            return Math.Sqrt(varianza);
        }

        private double fechaNc90(int nroProyecto, double promedioDuracionEnsamble, double desviacion)
        {
            Chart statisticFormula = new Chart();

            return nroProyecto == 0 ? 0 : promedioDuracionEnsamble + (statisticFormula.DataManipulator.Statistics.InverseTDistribution((1 - 0.9) / 2, (nroProyecto - 1)) * desviacion / Math.Sqrt(nroProyecto));
        }
    }
}

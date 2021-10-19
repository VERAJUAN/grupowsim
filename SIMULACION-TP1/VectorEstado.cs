using System;
using System.Collections;
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
        public double TMax { get; set; }
        public double TMin { get; set; }
        public double T4 { get; set; }
        public double DiasA4deMas { get; set; }
        public double SumaA1aA4 { get; set; }
        public double T5 { get; set; }
        public double MaxEntreT2yT4 { get; set; }
        public double DiasA5deMas { get; set; }
        public double DuracionEnsamble { get; set; }
        public double AcumAnterior { get; set; } //Ver q onda
        public double AcumuladoEnsamble { get; set; }
        public double PromedioDuracionEnsamble { get; set; }
        public double MaxAnterior { get; set; } //Ver q onda
        public double MaxDuracion { get; set; }
        public double MinAnterior { get; set; } //Ver q onda
        public double MinDuracion { get; set; }
        public double CantTareasMenor45DiasAnterior { get; set; } //Ver q onda
        public double CantTareasMenor45Dias { get; set; }
        public double ProbCompletarEn45Dias { get; set; }
        public double VarianzaAnterior { get; set; } //Ver q onda
        public double Varianza { get; set; }
        public double Desviacion { get; set; }
        public double FechaNc90 { get; set; }
        public double C1 { get; set; }
        public double C2 { get; set; }
        public double C3 { get; set; }
        public double CCritico { get; set; }
        public string CCriticoString { get; set; }
        public double ProbA1CriticoAnterior { get; set; }
        public double ProbA1Critico { get; set; }
        public double ProbA2CriticoAnterior { get; set; }
        public double ProbA2Critico { get; set; }
        public double ProbA3CriticoAnterior { get; set; }
        public double ProbA3Critico { get; set; }
        public double ProbA4CriticoAnterior { get; set; }
        public double ProbA4Critico { get; set; }
        public double ProbA5CriticoAnterior { get; set; }
        public double ProbA5Critico { get; set; }
        public double A1MasTardio { get; set; }
        public double A2MasTardio { get; set; }
        public double A3MasTardio { get; set; }
        public double A4MasTardio { get; set; }
        public double A5MasTardio { get; set; }
        public List<double> ListaIntervalosAnterior { get; set; }
        public List<double> ListaIntervalos = new List<double>();
        public double ProbIntervalo1Anterior { get; set; }
        public double ProbIntervalo1 { get; set; }
        public double ProbIntervalo2Anterior { get; set; }
        public double ProbIntervalo2 { get; set; }
        public double ProbIntervalo3Anterior { get; set; }
        public double ProbIntervalo3 { get; set; }
        public double ProbIntervalo4Anterior { get; set; }
        public double ProbIntervalo4 { get; set; }
        public double ProbIntervalo5Anterior { get; set; }
        public double ProbIntervalo5 { get; set; }
        public double ProbIntervalo6Anterior { get; set; }
        public double ProbIntervalo6 { get; set; }
        public double ProbIntervalo7Anterior { get; set; }
        public double ProbIntervalo7 { get; set; }
        public double ProbIntervalo8Anterior { get; set; }
        public double ProbIntervalo8 { get; set; }
        public double ProbIntervalo9Anterior { get; set; }
        public double ProbIntervalo9 { get; set; }
        public double ProbIntervalo10Anterior { get; set; }
        public double ProbIntervalo10 { get; set; }
        public double ProbIntervalo11Anterior { get; set; }
        public double ProbIntervalo11 { get; set; }
        public double ProbIntervalo12Anterior { get; set; }
        public double ProbIntervalo12 { get; set; }
        public double ProbIntervalo13Anterior { get; set; }
        public double ProbIntervalo13 { get; set; }
        public double ProbIntervalo14Anterior { get; set; }
        public double ProbIntervalo14 { get; set; }
        public double ProbIntervalo15Anterior { get; set; }
        public double ProbIntervalo15 { get; set; }

        private double Intervalo(int intervaloLista, int nroProyecto, double probIntervaloAnterior, double duracionEnsamble)
        {
            return nroProyecto >= 15 ? ListaIntervalos.FindLastIndex(x => x < duracionEnsamble) == intervaloLista ? (((probIntervaloAnterior*(nroProyecto-1)) + 1) / nroProyecto) : (((probIntervaloAnterior * (nroProyecto - 1)) + 0) / nroProyecto) : probIntervaloAnterior;
        }

        public VectorEstado() { }

        public VectorEstado(int nroProyecto, double t1, double t2, double t3, double t4, double t5, double acumAnterior, double maxAnterior, double minAnterior, double cantTareasMenor45DiasAnterior,
            double varianzaAnterior, double probA1CriticoAnterior, double probA2CriticoAnterior, double probA3CriticoAnterior, double probA4CriticoAnterior, double probA5CriticoAnterior,
            List<double> listaIntervalosAnterior, double probIntervalo1Anterior, double probIntervalo2Anterior, double probIntervalo3Anterior, double probIntervalo4Anterior, double probIntervalo5Anterior,
            double probIntervalo6Anterior, double probIntervalo7Anterior, double probIntervalo8Anterior, double probIntervalo9Anterior, double probIntervalo10Anterior, double probIntervalo11Anterior,
            double probIntervalo12Anterior, double probIntervalo13Anterior, double probIntervalo14Anterior, double probIntervalo15Anterior)
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
            VarianzaAnterior = varianzaAnterior;
            ProbA1CriticoAnterior = probA1CriticoAnterior;
            ProbA2CriticoAnterior = probA2CriticoAnterior;
            ProbA3CriticoAnterior = probA3CriticoAnterior;
            ProbA4CriticoAnterior = probA4CriticoAnterior;
            ProbA5CriticoAnterior = probA5CriticoAnterior;
            ListaIntervalosAnterior = listaIntervalosAnterior;
            ProbIntervalo1Anterior = probIntervalo1Anterior;
            ProbIntervalo2Anterior = probIntervalo2Anterior;
            ProbIntervalo3Anterior = probIntervalo3Anterior;
            ProbIntervalo4Anterior = probIntervalo4Anterior;
            ProbIntervalo5Anterior = probIntervalo5Anterior;
            ProbIntervalo6Anterior = probIntervalo6Anterior;
            ProbIntervalo7Anterior = probIntervalo7Anterior;
            ProbIntervalo8Anterior = probIntervalo8Anterior;
            ProbIntervalo9Anterior = probIntervalo9Anterior;
            ProbIntervalo10Anterior = probIntervalo10Anterior;
            ProbIntervalo11Anterior = probIntervalo11Anterior;
            ProbIntervalo12Anterior = probIntervalo12Anterior;
            ProbIntervalo13Anterior = probIntervalo13Anterior;
            ProbIntervalo14Anterior = probIntervalo14Anterior;
            ProbIntervalo15Anterior = probIntervalo15Anterior;
            ListaIntervalos = listaIntervalosAnterior;
            //Tmax(t1, t2, t3);
            //Tmin(t1, t2, t3);
            //diasA4deMas(t4, TMax, t1);
            //sumaA1aA4(TMax, DiasA4deMas);
            //maxT2yT4(t2, t4);
            //diasA5deMas(MaxEntreT2yT4, t5, SumaA1aA4);
            c1(t1, t4, t5);
            c2(t2, t5);
            C3 = t3;
            duracionEnsamble(C1, C2, C3);
            acumuladoEnsamble(AcumAnterior, DuracionEnsamble);
            promedioDuracionEnsamble(AcumuladoEnsamble, nroProyecto);
            maxDuracion(maxAnterior, DuracionEnsamble);
            minDuracion(minAnterior, DuracionEnsamble);
            cantTareasMenor45Dias(DuracionEnsamble, cantTareasMenor45DiasAnterior);
            probCompletarEn45Dias(CantTareasMenor45Dias, nroProyecto);
            varianza(nroProyecto, DuracionEnsamble, PromedioDuracionEnsamble, varianzaAnterior);
            desviacion(Varianza);
            fechaNc90(nroProyecto, PromedioDuracionEnsamble, Desviacion);
            cCritico(C1, C2, C3);
            cCriticoString(CCritico, C1, C2, C3);
            ProbA1Critico = probACritico(C1, CCritico, ProbA1CriticoAnterior, nroProyecto);
            ProbA2Critico = probACritico(C2, CCritico, ProbA2CriticoAnterior, nroProyecto);
            ProbA3Critico = probACritico(C3, CCritico, ProbA3CriticoAnterior, nroProyecto);
            ProbA4Critico = probACritico(C1, CCritico, ProbA4CriticoAnterior, nroProyecto);
            ProbA5Critico = probA5Critico(C1, C2, CCritico, ProbA5CriticoAnterior, nroProyecto);
            A1MasTardio = A4MasTardio - T1;
            A2MasTardio = A5MasTardio - T2;
            A3MasTardio = CCritico - T3;
            A4MasTardio = A5MasTardio - T4;
            A5MasTardio = CCritico - T5;
            ProbIntervalo1 = Intervalo(0, nroProyecto, ProbIntervalo1Anterior, DuracionEnsamble);
            ProbIntervalo2 = Intervalo(1, nroProyecto, ProbIntervalo2Anterior, DuracionEnsamble);
            ProbIntervalo3 = Intervalo(2, nroProyecto, ProbIntervalo3Anterior, DuracionEnsamble);
            ProbIntervalo4 = Intervalo(3, nroProyecto, ProbIntervalo4Anterior, DuracionEnsamble);
            ProbIntervalo5 = Intervalo(4, nroProyecto, ProbIntervalo5Anterior, DuracionEnsamble);
            ProbIntervalo6 = Intervalo(5, nroProyecto, ProbIntervalo6Anterior, DuracionEnsamble);
            ProbIntervalo7 = Intervalo(6, nroProyecto, ProbIntervalo7Anterior, DuracionEnsamble);
            ProbIntervalo8 = Intervalo(7, nroProyecto, ProbIntervalo8Anterior, DuracionEnsamble);
            ProbIntervalo9 = Intervalo(8, nroProyecto, ProbIntervalo9Anterior, DuracionEnsamble);
            ProbIntervalo10 = Intervalo(9, nroProyecto, ProbIntervalo10Anterior, DuracionEnsamble);
            ProbIntervalo11 = Intervalo(10, nroProyecto, ProbIntervalo11Anterior, DuracionEnsamble);
            ProbIntervalo12 = Intervalo(11, nroProyecto, ProbIntervalo12Anterior, DuracionEnsamble);
            ProbIntervalo13 = Intervalo(12, nroProyecto, ProbIntervalo13Anterior, DuracionEnsamble);
            ProbIntervalo14 = Intervalo(13, nroProyecto, ProbIntervalo14Anterior, DuracionEnsamble);
            ProbIntervalo15 = Intervalo(14, nroProyecto, ProbIntervalo15Anterior, DuracionEnsamble);
            if (this.nroProyecto < 15) ListaIntervalos.Add(DuracionEnsamble);
            if (this.nroProyecto == 15) ListaIntervalos.Sort();
        }

        private double probA5Critico(double c1, double c2, double cCritico, double probA5CriticoAnterior, int nroProyecto)
        {
            return (c1 == cCritico || c2 == cCritico) ? ((probA5CriticoAnterior * (nroProyecto - 1)) + 1) / nroProyecto : ((probA5CriticoAnterior * (nroProyecto - 1)) + 0) / nroProyecto;
        }

        private double probACritico(double c, double cCritico, double probACriticoAnterior, int nroProyecto)
        {
            return c == cCritico ? ((probACriticoAnterior * (nroProyecto - 1)) + 1) / nroProyecto : ((probACriticoAnterior * (nroProyecto - 1)) + 0) / nroProyecto;
        }

        private void cCriticoString(double cCritico, double c1, double c2, double c3)
        {
            CCriticoString = cCritico == c1 ? "C1" : cCritico == c2 ? "C2" : "C3";
        }

        private void cCritico(double c1, double c2, double c3)
        {
            var maxC1C2 = Math.Max(C1, C2);
            CCritico = Math.Max(maxC1C2, c3);
        }

        private void c2(double t2, double t5)
        {
            C2 = t2 + t5;
        }

        private void c1(double t1, double t4, double t5)
        {
            C1 = t1 + t4 + t5;
        }

        private void duracionEnsamble(double camino1, double camino2, double camino3)
        {
            DuracionEnsamble = camino1 > camino2 && camino1 > camino3 ? camino1 : (camino2 > camino3 ? camino2 : camino3);
        }

        private void acumuladoEnsamble(double acumAnterior, double duracionEnsamble)
        {
            AcumuladoEnsamble = acumAnterior + duracionEnsamble;
        }

        private void promedioDuracionEnsamble(double acumulado, double nroProyecto)
        {
            PromedioDuracionEnsamble = acumulado / nroProyecto;
        }

        private void maxDuracion(double maxAnterior, double duracionEnsamble)
        {
            MaxDuracion = maxAnterior > duracionEnsamble ? maxAnterior : duracionEnsamble;
        }

        private void minDuracion(double minAnterior, double duracionEnsamble)
        {
            MinDuracion = minAnterior < duracionEnsamble ? minAnterior : duracionEnsamble;
        }

        private void cantTareasMenor45Dias(double duracionEnsamble, double cantAnterior)
        {
            CantTareasMenor45Dias = duracionEnsamble < 45 ? cantAnterior + 1 : cantAnterior;
        }

        private void probCompletarEn45Dias(double cantTareasMenor45Dias, double nroProyecto)
        {
            ProbCompletarEn45Dias = cantTareasMenor45Dias / nroProyecto;
        }

        private void varianza(int nroProyecto, double duracionEnsamble, double promedioDuracionEnsamble, double varianzaAnterior)
        {
            Varianza = nroProyecto > 1 ? (1 / ((double)nroProyecto - 1)) * (((nroProyecto - 2) * varianzaAnterior) + (((double)nroProyecto / ((double)nroProyecto - 1)) * Math.Pow((promedioDuracionEnsamble - duracionEnsamble), 2))) : 0;        
        }

        private void desviacion(double varianza)
        {
            Desviacion = Math.Sqrt(varianza);
        }

        private void fechaNc90(int nroProyecto, double promedioDuracionEnsamble, double desviacion)
        {
            Chart statisticFormula = new Chart();

            FechaNc90 = nroProyecto > 1 ? promedioDuracionEnsamble + (statisticFormula.DataManipulator.Statistics.InverseTDistribution((1 - 0.9) / 2, (nroProyecto - 1)) * desviacion / Math.Sqrt(nroProyecto)) : 0;
        }

        //private void Tmax(double t1, double t2, double t3)
        //{
        //    TMax = t1 > t2 && t1 > t3 ? t1 : (t2 > t3 ? t2 : t3);
        //}

        //private void Tmin(double t1, double t2, double t3)
        //{
        //    TMin = t1 < t2 && t1 < t3 ? t1 : (t2 < t3 ? t2 : t3);
        //}

        //private void diasA4deMas(double t4, double tmax, double t1)
        //{
        //    DiasA4deMas = t4 - (tmax - t1);
        //}

        //private void sumaA1aA4(double tmax, double diasA4deMas)
        //{
        //    SumaA1aA4 = tmax + (diasA4deMas > 0 ? diasA4deMas : 0);
        //}

        //private void maxT2yT4(double t2, double t4)
        //{
        //    MaxEntreT2yT4 = t2 > t4 ? t2 : t4;
        //}

        //private void diasA5deMas(double maxT2yT4, double t5, double sumaA1aA4)
        //{
        //    DiasA5deMas = maxT2yT4 < sumaA1aA4 ? (maxT2yT4 + t5 - sumaA1aA4) : t5;
        //}
    }
}

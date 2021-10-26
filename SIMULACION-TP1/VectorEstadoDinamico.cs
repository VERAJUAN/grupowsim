using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULACION_TP1
{
    public class VectorEstadoDinamico
    {
        //EVENTO
        public int nroEvento { get; set; }
        public double reloj { get; set; }
        public int evento { get; set; }
        public int pedido { get; set; }

        //PEDIDO
        public int proxPedido { get; set; }
        public double tiempoEntrePedidos { get; set; }
        public double proxLlegada { get; set; }

        //A1
        public int a1Estado { get; set; }
        public int a1Pedido { get; set; }
        public double a1Tiempo { get; set; }
        public double a1ProxFin { get; set; }
        public int a1Cola { get; set; }

        //A2
        public int a2Estado { get; set; }
        public int a2Pedido { get; set; }
        public double a2Tiempo { get; set; }
        public double a2ProxFin { get; set; }
        public int a2Cola { get; set; }

        //A3
        public int a3Estado { get; set; }
        public int a3Pedido { get; set; }
        public double a3Tiempo { get; set; }
        public double a3ProxFin { get; set; }
        public int a3Cola { get; set; }

        //A4
        public int a4Estado { get; set; }
        public int a4Pedido { get; set; }
        public double a4Tiempo { get; set; }
        public double a4ProxFin { get; set; }
        public int a4Cola { get; set; }

        //A5
        public int a5Estado { get; set; }
        public int a5Pedido { get; set; }
        public double a5Tiempo { get; set; }
        public double a5ProxFin { get; set; }
        public int a5ColaA4 { get; set; }
        public int a5ColaA2 { get; set; }

        //ENCASTRE
        public int colaEncastreA3 { get; set; }
        public int colaEncastreA5 { get; set; }

        //ENSAMBLE
        public int cantidadEnsamblesSolicitados { get; set; }
        public int cantidadEnsamblesFinalizados { get; set; }
        public double propEnsamRealSobreSolic { get; set; }

        //CANTIDAD MAXIMA EN COLA
        public int maxCola1 { get; set; }
        public int maxCola2 { get; set; }
        public int maxCola3 { get; set; }
        public int maxCola4 { get; set; }
        public int maxCola5 { get; set; }
        public int maxColaEncastre { get; set; }

        //TIEMPOS PROMEDIOS
        public double tiempoPromCola1 { get; set; }
        public double tiempoPromCola2 { get; set; }
        public double tiempoPromCola3 { get; set; }
        public double tiempoPromCola4 { get; set; }
        public double tiempoPromCola5 { get; set; }
        public double tiempoPromColaEncastre { get; set; }

        //CANTIDAD PROMEDIO
        public double cantPromedioProdEnCola { get; set; }
        public double cantPromedioProdEnSistema { get; set; }

        //OCUPACION
        public double tiempoOcupado { get; set; }
        public double porcOcupacionServidor { get; set; }


        public VectorEstadoDinamico()
        {

        }
    }
}

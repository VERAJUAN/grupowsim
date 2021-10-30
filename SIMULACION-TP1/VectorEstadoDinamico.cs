using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULACION_TP1
{
    public class VectorEstadoDinamico
    {
        //NRO PEDIDO A CALCULAR
        public int pedidoACalcular { get; set; }

        //EVENTO
        public int nroEvento { get; set; }
        public double reloj { get; set; }
        public int evento { get; set; }
        public int pedido { get; set; }

        //PEDIDO
        public int proxPedido { get; set; }
        public double tiempoEntrePedidos { get; set; }
        public double proxLlegada { get; set; }

        //HORA
        public double proxFinHora { get; set; }

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
        public double tiempoLlegada { get; set; }
        public double tiempoInicioAtencionA1 { get; set; }
        public double tiempoPromCola1 { get; set; }
        public double tiempoInicioAtencionA2 { get; set; }
        public double tiempoPromCola2 { get; set; }
        public double tiempoInicioAtencionA3 { get; set; }
        public double tiempoPromCola3 { get; set; }
        public double tiempoInicioAtencionA4 { get; set; }
        public double tiempoPromCola4 { get; set; }
        public double tiempoInicioAtencionA5 { get; set; }
        public double tiempoPromCola5 { get; set; }
        public double tiempoInicioAtencionEncastre { get; set; }
        public double tiempoPromColaEncastre { get; set; }

        //CANTIDAD PROMEDIO
        public double cantPromedioProdEnCola { get; set; }
        public double cantPromedioProdEnSistema { get; set; }

        //OCUPACION
        public double tiempoOcupadoA1 { get; set; }
        public double acumuladoTiempoOcupadoA1 { get; set; }
        public double porcOcupacionA1 { get; set; }

        public double tiempoOcupadoA2 { get; set; }
        public double acumuladoTiempoOcupadoA2 { get; set; }
        public double porcOcupacionA2 { get; set; }

        public double tiempoOcupadoA3 { get; set; }
        public double acumuladoTiempoOcupadoA3 { get; set; }
        public double porcOcupacionA3 { get; set; }

        public double tiempoOcupadoA4 { get; set; }
        public double acumuladoTiempoOcupadoA4 { get; set; }
        public double porcOcupacionA4 { get; set; }

        public double tiempoOcupadoA5 { get; set; }
        public double acumuladoTiempoOcupadoA5 { get; set; }
        public double porcOcupacionA5 { get; set; }

        //ENSAMBLES X HORA
        public int cantEnsamblesXHora { get; set; }
        public double cantProbEnsamblesXHora { get; set; }

        //PEDIDOS POR PARAMETROS COMPLETADOS EN UNA HORA
        public int pedidosParametroCompletadosEnUnaHora { get; set; }
        public double probPedidosParametroCompletadosEnUnaHora { get; set; }

        VectorEstadoDinamico vectorAnterior { get; set; }
        public VectorEstadoDinamico()
        {

        }

        public VectorEstadoDinamico(int nroEvento,
            double tiempoEntrePedidos, int pedidoACalcular, double A1 = 0, double A2 = 0, double A3 = 0, double A4 = 0, double A5 = 0, VectorEstadoDinamico vectorAnterior = null)
        {
            this.vectorAnterior = vectorAnterior;

            this.pedidoACalcular = pedidoACalcular;

            this.nroEvento = nroEvento;
            Reloj(); //0
            Evento(); //0
            Pedido();  //0

            ProxPedido(); //1
            this.tiempoEntrePedidos = tiempoEntrePedidos;
            ProximaLlegada();

            ProxFinHora();

            A1Estado();
            A1Pedido();
            a1Tiempo = A1Tiempo(A1);
            A1ProxFin();
            A1Cola();

            A2Estado();
            A2Pedido();
            a2Tiempo = A2Tiempo(A2);
            A2ProxFin();
            A2Cola();

            A3Estado();
            A3Pedido();
            a3Tiempo = A3Tiempo(A3);
            A3ProxFin();
            A3Cola();

            A4Estado();
            A4Pedido();
            a4Tiempo = A4Tiempo(A4);
            A4ProxFin();
            A4Cola();

            A5Estado();
            A5Pedido();
            a5Tiempo = A5Tiempo(A5);
            A5ProxFin();
            A5ColaA4();
            A5ColaA2();

            ColaEncastreA3();
            ColaEncastreA5();

            CantidadEnsamblesSolicitados();
            CantidadEnsamblesFinalizados();
            PropEnsamRealSobreSolic();

            if (vectorAnterior != null)
            {  
                maxCola1 = Math.Max(a1Cola, vectorAnterior.maxCola1);
                maxCola2 = Math.Max(a2Cola, vectorAnterior.maxCola2);
                maxCola3 = Math.Max(a3Cola, vectorAnterior.maxCola3);
                maxCola4 = Math.Max(a4Cola, vectorAnterior.maxCola4);
                maxCola5 = Math.Max(a5ColaA2+a5ColaA4, vectorAnterior.maxCola5);
                maxColaEncastre = Math.Max(colaEncastreA3+colaEncastreA5, vectorAnterior.maxColaEncastre);
            }
            TiempoLlegada();
            TiempoInicioAtencionA1();
            TiempoPromCola1();
            TiempoInicioAtencionA2();
            TiempoPromCola2();
            TiempoInicioAtencionA3();
            TiempoPromCola3();
            TiempoInicioAtencionA4();
            TiempoPromCola4();
            TiempoInicioAtencionA5();
            TiempoPromCola5();
            TiempoInicioAtencionEncastre();
            TiempoPromColaEncastre();

            CantPromedioProdEnCola();
            CantPromedioProdEnSistema();

            TiempoOcupadoA1();
            AcumuladoTiempoOcupadoA1();
            PorcOcupacionA1();

            TiempoOcupadoA2();
            AcumuladoTiempoOcupadoA2();
            PorcOcupacionA2();

            TiempoOcupadoA3();
            AcumuladoTiempoOcupadoA3();
            PorcOcupacionA3();

            TiempoOcupadoA4();
            AcumuladoTiempoOcupadoA4();
            PorcOcupacionA4();

            TiempoOcupadoA5();
            AcumuladoTiempoOcupadoA5();
            PorcOcupacionA5();

            CantEnsamblesXHora();
            CantProbEnsamblesXHora();

            PedidosParametroCompletadosEnUnaHora();
            ProbPedidosParametroCompletadosEnUnaHora();
        }

        #region EVENTO 

        private void Reloj()
        {
            if (vectorAnterior == null)
            {
                reloj = 0;
            }
            else
            {
                reloj = Math.Min(vectorAnterior.proxLlegada,
                    Math.Min(vectorAnterior.a1ProxFin,
                    Math.Min(vectorAnterior.a2ProxFin,
                    Math.Min(vectorAnterior.a3ProxFin,
                    Math.Min(vectorAnterior.a4ProxFin, 
                    Math.Min(vectorAnterior.a5ProxFin, vectorAnterior.proxFinHora
                    ))))));
            }
        }

        private void Evento()
        {
            if (vectorAnterior == null)
            {
                evento = 0;
            }
            else
            {
                if(reloj == vectorAnterior.proxLlegada){
                    evento = 1;
                }else if(reloj == vectorAnterior.a1ProxFin)
                {
                    evento = 2;
                }
                else if (reloj == vectorAnterior.a2ProxFin)
                {
                    evento = 3;
                }
                else if (reloj == vectorAnterior.a3ProxFin)
                {
                    evento = 4;
                }
                else if (reloj == vectorAnterior.a4ProxFin)
                {
                    evento = 5;
                }
                else if (reloj == vectorAnterior.a5ProxFin)
                {
                    evento = 6;
                }
                else if (reloj == vectorAnterior.proxFinHora)
                {
                    evento = 8;
                }
                else
                {
                    evento = 7;
                }
            }
        }

        private void Pedido()
        {
            if (vectorAnterior == null)
            {
                pedido = 0;
            }
            else
            {
                if(evento == 1)
                {
                    pedido = vectorAnterior.proxPedido;
                }else if (evento == 2) {
                    pedido = vectorAnterior.a1Pedido;
                }
                else if (evento == 3)
                {
                    pedido = vectorAnterior.a2Pedido;
                }
                else if (evento == 4)
                {
                    pedido = vectorAnterior.a3Pedido;
                }
                else if (evento == 5)
                {
                    pedido = vectorAnterior.a4Pedido;
                }
                else if (evento == 6)
                {
                    pedido = vectorAnterior.a5Pedido;
                }
                else if (evento == 8)
                {
                    pedido = 0;
                }
                else
                {
                    pedido = 0;
                }

            }
        }
        #endregion

        #region PEDIDO
        private void ProxPedido()
        {
            if (vectorAnterior == null)
            {
                proxPedido = 1;
            }
            else
            {
                if(evento == 1)
                {
                    proxPedido = vectorAnterior.proxPedido + 1;
                }
                else
                {
                    proxPedido = vectorAnterior.proxPedido;
                }
            }
        }

        private void ProximaLlegada()
        {
            if (evento == 0 || evento == 1)
            {
                proxLlegada = reloj + tiempoEntrePedidos;
            }
            else
            {
                proxLlegada = vectorAnterior.proxLlegada;
            }
        }
        #endregion

        #region HORA
        private void ProxFinHora()
        {
            if (vectorAnterior == null)
            {
                proxFinHora = 60;
            }
            else if (reloj < vectorAnterior.proxFinHora)
            {
                proxFinHora = vectorAnterior.proxFinHora;
            }
            else
            {
                proxFinHora = vectorAnterior.proxFinHora + 60;
            }
            
        }
        #endregion

        #region A1
        private void A1Estado()
        {
            if (vectorAnterior == null)
            {
                a1Estado = 0;
            }
            else
            {
                if (evento == 1 && vectorAnterior.a1Estado == 1)
                {
                    a1Estado = 1;
                }
                else if (evento == 2 && vectorAnterior.a1Cola == 0)
                {
                    a1Estado = 0;
                }
                else
                {
                    a1Estado = 1;
                }
            }
        }

        private void A1Pedido()
        {
            if (vectorAnterior == null)
            {
                a1Pedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (vectorAnterior.a1Estado == 0 && evento == 1)
                {
                    a1Pedido = pedido;
                }
                else if (vectorAnterior.a1Estado == 1 && evento != 2)
                {
                    a1Pedido = vectorAnterior.a1Pedido;
                }
                else if (evento == 2 && vectorAnterior.a1Cola > 0)
                {
                    a1Pedido = pedido + 1;
                }
            }
        }

        private double A1Tiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (a1Pedido != vectorAnterior.a1Pedido && a1Pedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        private void A1ProxFin()
        {
            if (vectorAnterior == null)
            {
                a1ProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (a1Estado == 1)
                {
                    if (a1Tiempo != 0)
                    {
                        a1ProxFin = reloj + a1Tiempo;
                    }
                    else
                    {
                        a1ProxFin = vectorAnterior.a1ProxFin;
                    }
                }
                else
                {
                    a1ProxFin = 0;
                }
            }
        }

        private void A1Cola()
        {
            if (vectorAnterior == null)
            {
                a1Cola = 0;
            }
            else
            {
                if (evento == 1 && vectorAnterior.a1Estado == 1)
                {
                    a1Cola = vectorAnterior.a1Cola + 1;
                }
                else if (evento == 2 && vectorAnterior.a1Cola > 0)
                {
                    a1Cola = vectorAnterior.a1Cola - 1;
                }
                else
                {
                    a1Cola = vectorAnterior.a1Cola;
                }
            }
        }
        #endregion

        #region A2
        private void A2Estado()
        {
            if (vectorAnterior == null)
            {
                a2Estado = 0;
            }
            else
            {
                if (evento == 1 && vectorAnterior.a2Estado == 1)
                {
                    a2Estado = 1;
                }
                else if (evento == 3 && vectorAnterior.a2Cola == 0)
                {
                    a2Estado = 0;
                }
                else
                {
                    a2Estado = 1;
                }
            }
        }

        private double A2Tiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (a2Pedido != vectorAnterior.a2Pedido && a2Pedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        private void A2Pedido()
        {
            if (vectorAnterior == null)
            {
                a2Pedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (vectorAnterior.a2Estado == 0 && evento == 1)
                {
                    a2Pedido = pedido;
                }
                else if (vectorAnterior.a2Estado == 1 && evento != 3)
                {
                    a2Pedido = vectorAnterior.a2Pedido;
                }
                else if (evento == 3 && vectorAnterior.a2Cola > 0)
                {
                    a2Pedido = pedido + 1;
                }
            }
        }

        private void A2ProxFin()
        {
            if (vectorAnterior == null)
            {
                a2ProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (a2Estado == 1)
                {
                    if (a2Tiempo != 0)
                    {
                        a2ProxFin = reloj + a2Tiempo;
                    }
                    else
                    {
                        a2ProxFin = vectorAnterior.a2ProxFin;
                    }
                }
                else
                {
                    a2ProxFin = 0;
                }
            }
        }

        private void A2Cola()
        {
            if (vectorAnterior == null)
            {
                a2Cola = 0;
            }
            else
            {
                if (evento == 1 && vectorAnterior.a2Estado == 1)
                {
                    a2Cola = vectorAnterior.a2Cola + 1;
                }
                else if (evento == 3 && vectorAnterior.a2Cola > 0)
                {
                    a2Cola = vectorAnterior.a2Cola - 1;
                }
                else
                {
                    a2Cola = vectorAnterior.a2Cola;
                }
            }
        }

        #endregion

        #region A3
        private void A3Estado()
        {
            if (vectorAnterior == null)
            {
                a3Estado = 0;
            }
            else
            {
                if (evento == 1 && vectorAnterior.a3Estado == 1)
                {
                    a3Estado = 1;
                }
                else if (evento == 4 && vectorAnterior.a3Cola == 0)
                {
                    a3Estado = 0;
                }
                else
                {
                    a3Estado = 1;
                }
            }
        }

        private double A3Tiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (a3Pedido != vectorAnterior.a3Pedido && a3Pedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        private void A3Pedido()
        {
            if (vectorAnterior == null)
            {
                a3Pedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (vectorAnterior.a3Estado == 0 && evento == 1)
                {
                    a3Pedido = pedido;
                }
                else if (vectorAnterior.a3Estado == 1 && evento != 4)
                {
                    a3Pedido = vectorAnterior.a3Pedido;
                }
                else if (evento == 4 && vectorAnterior.a3Cola > 0)
                {
                    a3Pedido = pedido + 1;
                }
            }
        }

        private void A3ProxFin()
        {
            if (vectorAnterior == null)
            {
                a3ProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (a3Estado == 1)
                {
                    if (a3Tiempo != 0)
                    {
                        a3ProxFin = reloj + a3Tiempo;
                    }
                    else
                    {
                        a3ProxFin = vectorAnterior.a3ProxFin;
                    }
                }
                else
                {
                    a3ProxFin = 0;
                }
            }
        }

        private void A3Cola()
        {
            if (vectorAnterior == null)
            {
                a3Cola = 0;
            }
            else
            {
                if (evento == 1 && vectorAnterior.a3Estado == 1)
                {
                    a3Cola = vectorAnterior.a3Cola + 1;
                }
                else if (evento == 4 && vectorAnterior.a3Cola > 0)
                {
                    a3Cola = vectorAnterior.a3Cola - 1;
                }
                else
                {
                    a3Cola = vectorAnterior.a3Cola;
                }
            }
        }

        #endregion

        #region A4
        private void A4Estado()
        {
            if (vectorAnterior == null)
            {
                a4Estado = 0;
            }
            else
            {
                if (evento == 5 && vectorAnterior.a4Cola == 0)
                {
                    a4Estado = 0;
                }
                else if (evento != 2 && vectorAnterior.a4Cola == 0 && vectorAnterior.a4Estado == 0)
                {
                    a4Estado = 0;
                }
                else
                {
                    a4Estado = 1;
                }
            }
        }

        private double A4Tiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (a4Pedido != vectorAnterior.a4Pedido && a4Pedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }
        private void A4Pedido()
        {
            if (vectorAnterior == null)
            {
                a4Pedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (vectorAnterior.a4Estado == 0 && evento == 2)
                {
                    a4Pedido = pedido;
                }
                else if (vectorAnterior.a4Estado == 1 && evento != 5)
                {
                    a4Pedido = vectorAnterior.a4Pedido;
                }
                else if (evento == 5 && vectorAnterior.a4Cola > 0)
                {
                    a4Pedido = pedido + 1;
                }
            }
        }

        private void A4ProxFin()
        {
            if (vectorAnterior == null)
            {
                a4ProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (a4Estado == 1)
                {
                    if (a4Tiempo != 0)
                    {
                        a4ProxFin = reloj + a4Tiempo;
                    }
                    else
                    {
                        a4ProxFin = vectorAnterior.a4ProxFin;
                    }
                }
                else
                {
                    a4ProxFin = double.PositiveInfinity;
                }
            }
        }

        private void A4Cola()
        {
            if (vectorAnterior == null)
            {
                a4Cola = 0;
            }
            else
            {
                if (evento == 2 && vectorAnterior.a4Estado == 1)
                {
                    a4Cola = vectorAnterior.a4Cola + 1;
                }
                else if (evento == 5 && vectorAnterior.a4Cola > 0)
                {
                    a4Cola = vectorAnterior.a4Cola - 1;
                }
                else
                {
                    a4Cola = vectorAnterior.a4Cola;
                }
            }
        }

        #endregion

        #region A5
        private void A5Estado()
        {
            if (vectorAnterior == null)
            {
                a5Estado = 0;
            }
            else
            {
                if (evento == 6 && (vectorAnterior.a5ColaA4 == 0 || vectorAnterior.a5ColaA2 == 0))
                {
                    a5Estado = 0;
                }
                else if (evento == 5 && vectorAnterior.a5ColaA2 > 0)
                {
                    a5Estado = 1;
                }
                else if(evento == 3 && vectorAnterior.a5ColaA4 > 0)
                {
                    a5Estado = 1;
                }
                else
                {
                    a5Estado = vectorAnterior.a5Estado;
                }
            }
        }

        private double A5Tiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (a5Pedido != vectorAnterior.a5Pedido && a5Pedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        private void A5Pedido()
        {
            if (vectorAnterior == null)
            {
                a5Pedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (vectorAnterior.a5Estado == 0 && evento == 5 && vectorAnterior.a5ColaA2 > 0)
                {
                    a5Pedido = pedido;
                }
                else if (vectorAnterior.a5Estado == 0 && evento == 3 && vectorAnterior.a5ColaA4 > 0)
                {
                    a5Pedido = pedido;
                }
                else if (vectorAnterior.a5Estado == 1 && evento != 6)
                {
                    a5Pedido = vectorAnterior.a5Pedido;
                }
                else if (evento == 6 && vectorAnterior.a5ColaA4 > 0 && vectorAnterior.a5ColaA2 > 0)
                {
                    a5Pedido = pedido + 1;
                }
            }
        }

        private void A5ProxFin()
        {
            if (vectorAnterior == null)
            {
                a5ProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (a5Estado == 1)
                {
                    if (a5Tiempo != 0)
                    {
                        a5ProxFin = reloj + a5Tiempo;
                    }
                    else
                    {
                        a5ProxFin = vectorAnterior.a5ProxFin;
                    }
                }
                else
                {
                    a5ProxFin = double.PositiveInfinity;
                }
            }
        }

        private void A5ColaA4()
        {
            if (vectorAnterior == null)
            {
                a5ColaA4 = 0;
            }
            else
            {
                if (evento == 5 && vectorAnterior.a5Estado == 1)
                {
                    a5ColaA4 = vectorAnterior.a5ColaA4 + 1;
                }
                else if (evento == 5 && vectorAnterior.a5Estado == 0 && vectorAnterior.a5ColaA2 == 0)
                {
                    a5ColaA4 = vectorAnterior.a5ColaA4 + 1;
                }
                else if (evento == 6 && vectorAnterior.a5ColaA4 > 0)
                {
                    a5ColaA4 = vectorAnterior.a5ColaA4 - 1;
                }
                else
                {
                    a5ColaA4 = vectorAnterior.a5ColaA4;
                }
            }
        }

        private void A5ColaA2()
        {
            if (vectorAnterior == null)
            {
                a5ColaA2 = 0;
            }
            else
            {
                if (evento == 3 && vectorAnterior.a5Estado == 1)
                {
                    a5ColaA2 = vectorAnterior.a5ColaA2 + 1;
                }
                else if (evento == 3 && vectorAnterior.a5Estado == 0 && vectorAnterior.a5ColaA4 == 0)
                {
                    a5ColaA2 = vectorAnterior.a5ColaA2 + 1;
                }
                else if (evento == 6 && vectorAnterior.a5ColaA2 > 0)
                {
                    a5ColaA2 = vectorAnterior.a5ColaA2 - 1;
                }
                else
                {
                    a5ColaA2 = vectorAnterior.a5ColaA2;
                }
            }
        }

        #endregion

        #region COLASENCASTRE
        private void ColaEncastreA3()
        {
            if (vectorAnterior == null)
            {
                colaEncastreA3 = 0;
            }
            else if (evento == 4 && vectorAnterior.colaEncastreA5 == 0)
            {
                colaEncastreA3 = vectorAnterior.colaEncastreA3 + 1;
            }
            else if (evento == 6 && vectorAnterior.colaEncastreA3 > 0)
            {
                colaEncastreA3 = vectorAnterior.colaEncastreA3 - 1;
            }
            else
            {
                colaEncastreA3 = vectorAnterior.colaEncastreA3;
            }
        }

        private void ColaEncastreA5()
        {
            if (vectorAnterior == null)
            {
                colaEncastreA5 = 0;
            }
            else if (evento == 6 && vectorAnterior.colaEncastreA3 == 0)
            {
                colaEncastreA5 = vectorAnterior.colaEncastreA5 + 1;
            }
            else if (evento == 4 && vectorAnterior.colaEncastreA5 > 0)
            {
                colaEncastreA5 = vectorAnterior.colaEncastreA5 - 1;
            }
            else
            {
                colaEncastreA5 = vectorAnterior.colaEncastreA5;
            }
        }
        #endregion

        #region ProporcionEnsamblesRealizadosSobreSolicitados
        private void CantidadEnsamblesSolicitados()
        {
            if (vectorAnterior == null)
            {
                cantidadEnsamblesSolicitados = 0;
            }
            else if (evento == 1)
            {
                cantidadEnsamblesSolicitados = vectorAnterior.cantidadEnsamblesSolicitados + 1;
            }
            else
            {
                cantidadEnsamblesSolicitados = vectorAnterior.cantidadEnsamblesSolicitados;
            }
        }

        private void CantidadEnsamblesFinalizados()
        {
            if (vectorAnterior == null)
            {
                cantidadEnsamblesFinalizados = 0;
            }
            else if (evento == 4 && colaEncastreA5 < vectorAnterior.colaEncastreA5)
            {
                cantidadEnsamblesFinalizados = vectorAnterior.cantidadEnsamblesFinalizados + 1;
            }
            else if(evento == 6 && colaEncastreA3 < vectorAnterior.colaEncastreA3) 
            {
                cantidadEnsamblesFinalizados = vectorAnterior.cantidadEnsamblesFinalizados + 1;
            } 
            else
            {
                cantidadEnsamblesFinalizados = vectorAnterior.cantidadEnsamblesFinalizados;
            }
        }

        private void PropEnsamRealSobreSolic()
        {
            if (vectorAnterior == null)
            {
                propEnsamRealSobreSolic = 0;
            }
            else if(cantidadEnsamblesFinalizados == 0) 
            {
                propEnsamRealSobreSolic = vectorAnterior.propEnsamRealSobreSolic;
            }
            else
            {
                propEnsamRealSobreSolic = cantidadEnsamblesFinalizados / cantidadEnsamblesSolicitados;
            }
        }
        #endregion

        #region TIEMPOS PROMEDIOS 
        private void TiempoLlegada()
        {
            if (vectorAnterior == null)
            {
                tiempoLlegada = 0;
            }
            else if (evento == 1 && pedido == pedidoACalcular)
            {
                tiempoLlegada = reloj;
            }
            else
            {
                tiempoLlegada = vectorAnterior.tiempoLlegada;
            }
        }

        private void TiempoInicioAtencionA1()
        {
            if (vectorAnterior == null)
            {
                tiempoInicioAtencionA1 = 0;
            }
            else if (a1Tiempo > 0 && a1Pedido == pedidoACalcular)
            {
                tiempoInicioAtencionA1 = reloj;
            }
            else
            {
                tiempoInicioAtencionA1 = vectorAnterior.tiempoInicioAtencionA1;
            }
        }
        private void TiempoPromCola1()
        {
            if (vectorAnterior == null)
            {
                tiempoPromCola1 = 0;
            }
            else if (tiempoInicioAtencionA1 >= tiempoLlegada)
            {
                tiempoPromCola1 = tiempoInicioAtencionA1 - tiempoLlegada;
            } 
            else
            {
                tiempoPromCola1 = vectorAnterior.tiempoPromCola1;
            }
        }
        private void TiempoInicioAtencionA2()
        {
            if (vectorAnterior == null)
            {
                tiempoInicioAtencionA2 = 0;
            }
            else if (a2Tiempo > 0 && a2Pedido == pedidoACalcular)
            {
                tiempoInicioAtencionA2 = reloj;
            }
            else
            {
                tiempoInicioAtencionA2 = vectorAnterior.tiempoInicioAtencionA2;
            }
        }
        private void TiempoPromCola2()
        {
            if (vectorAnterior == null)
            {
                tiempoPromCola2 = 0;
            }
            else if (tiempoInicioAtencionA2 >= tiempoLlegada)
            {
                tiempoPromCola2 = tiempoInicioAtencionA2 - tiempoLlegada;
            }
            else
            {
                tiempoPromCola2 = vectorAnterior.tiempoPromCola2;
            }
        }
        private void TiempoInicioAtencionA3()
        {
            if (vectorAnterior == null)
            {
                tiempoInicioAtencionA3 = 0;
            }
            else if (a3Tiempo > 0 && a3Pedido == pedidoACalcular)
            {
                tiempoInicioAtencionA3 = reloj;
            }
            else
            {
                tiempoInicioAtencionA3 = vectorAnterior.tiempoInicioAtencionA3;
            }
        }
        private void TiempoPromCola3()
        {
            if (vectorAnterior == null)
            {
                tiempoPromCola3 = 0;
            }
            else if (tiempoInicioAtencionA3 >= tiempoLlegada)
            {
                tiempoPromCola3 = tiempoInicioAtencionA3 - tiempoLlegada;
            }
            else
            {
                tiempoPromCola3 = vectorAnterior.tiempoPromCola3;
            }
        }
        private void TiempoInicioAtencionA4()
        {
            if (vectorAnterior == null)
            {
                tiempoInicioAtencionA4 = 0;
            }
            else if (a4Tiempo > 0 && a4Pedido == pedidoACalcular)
            {
                tiempoInicioAtencionA4 = reloj;
            }
            else
            {
                tiempoInicioAtencionA4 = vectorAnterior.tiempoInicioAtencionA4;
            }
        }
        private void TiempoPromCola4()
        {
            if (vectorAnterior == null)
            {
                tiempoPromCola4 = 0;
            }
            else if (tiempoInicioAtencionA4 >= tiempoLlegada)
            {
                tiempoPromCola4 = tiempoInicioAtencionA4 - tiempoLlegada;
            }
            else
            {
                tiempoPromCola4 = vectorAnterior.tiempoPromCola4;
            }
        }
        private void TiempoInicioAtencionA5()
        {
            if (vectorAnterior == null)
            {
                tiempoInicioAtencionA5 = 0;
            }
            else if (a5Tiempo > 0 && a5Pedido == pedidoACalcular)
            {
                tiempoInicioAtencionA5 = reloj;
            }
            else
            {
                tiempoInicioAtencionA5 = vectorAnterior.tiempoInicioAtencionA5;
            }
        }
        private void TiempoPromCola5()
        {
            if (vectorAnterior == null)
            {
                tiempoPromCola5 = 0;
            }
            else if (tiempoInicioAtencionA5 >= tiempoLlegada)
            {
                tiempoPromCola5 = tiempoInicioAtencionA5 - tiempoLlegada;
            }
            else
            {
                tiempoPromCola5 = vectorAnterior.tiempoPromCola5;
            }
        }
        private void TiempoInicioAtencionEncastre()
        {
            tiempoInicioAtencionEncastre = 0;
        }
        private void TiempoPromColaEncastre()
        {
            tiempoPromColaEncastre = 0;
        }
        #endregion

        #region CANTIDAD PROMEDIO      
        private void CantPromedioProdEnCola()
        {
            if (vectorAnterior == null)
            {
                cantPromedioProdEnCola = 0;
            }
            else
            {
                cantPromedioProdEnCola = (a1Cola + a2Cola + a3Cola + a4Cola + a5ColaA2 + a5ColaA4 + colaEncastreA3 + colaEncastreA5) / 6;
            }
        }

        private void CantPromedioProdEnSistema()
        {
            if (vectorAnterior == null)
            {
                cantPromedioProdEnSistema = 0;
            }
            else
            {
                cantPromedioProdEnSistema = (a1Estado + a2Estado + a3Estado + a4Estado + a5Estado +
                                                a1Cola + a2Cola + a3Cola + a4Cola + a5ColaA2 + a5ColaA4 + colaEncastreA3 + colaEncastreA5) / 6;
            }
        }
        #endregion

        #region PORCENTAJE DE OCUPACION
        private void TiempoOcupadoA1()
        {
            if (vectorAnterior == null)
            {
                tiempoOcupadoA1 = 0;
            }
            else if (a1Estado == 1 && vectorAnterior.a1Estado == 0)
            {
                tiempoOcupadoA1 = 1;
            }
            else if (a1Estado == 0 && vectorAnterior.a1Estado == 1)
            {
                tiempoOcupadoA1 = 0;
            }
            else
            {
                tiempoOcupadoA1 = vectorAnterior.tiempoOcupadoA1;
            }
        }
        private void AcumuladoTiempoOcupadoA1()
        {
            if (vectorAnterior == null)
            {
                acumuladoTiempoOcupadoA1 = 0;
            }
            else if (tiempoOcupadoA1 == 0 && vectorAnterior.tiempoOcupadoA1 == 0)
            {
                acumuladoTiempoOcupadoA1 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA1;
            }
            else
            {
                acumuladoTiempoOcupadoA1 = vectorAnterior.acumuladoTiempoOcupadoA1;
            }
        }

        private void PorcOcupacionA1()
        {
            if (vectorAnterior == null)
            {
                porcOcupacionA1 = 0;
            }
            else if (porcOcupacionA1 == 0 && vectorAnterior.porcOcupacionA1 == 0)
            {
                porcOcupacionA1 = (acumuladoTiempoOcupadoA1 * 100) / reloj;
            }
            else
            {
                porcOcupacionA1 = vectorAnterior.porcOcupacionA1;
            }
        }

        private void TiempoOcupadoA2()
        {
            if (vectorAnterior == null)
            {
                tiempoOcupadoA2 = 0;
            }
            else if (a2Estado == 1 && vectorAnterior.a2Estado == 0)
            {
                tiempoOcupadoA2 = 1;
            }
            else if (a2Estado == 0 && vectorAnterior.a2Estado == 1)
            {
                tiempoOcupadoA2 = 0;
            }
            else
            {
                tiempoOcupadoA2 = vectorAnterior.tiempoOcupadoA2;
            }
        }

        private void AcumuladoTiempoOcupadoA2()
        {
            if (vectorAnterior == null)
            {
                acumuladoTiempoOcupadoA2 = 0;
            }
            else if (tiempoOcupadoA2 == 0 && vectorAnterior.tiempoOcupadoA2 == 0)
            {
                acumuladoTiempoOcupadoA2 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA2;
            }
            else
            {
                acumuladoTiempoOcupadoA2 = vectorAnterior.acumuladoTiempoOcupadoA2;
            }
        }

        private void PorcOcupacionA2()
        {
            if (vectorAnterior == null)
            {
                porcOcupacionA2 = 0;
            }
            else if (porcOcupacionA2 == 0 && vectorAnterior.porcOcupacionA2 == 0)
            {
                porcOcupacionA2 = (acumuladoTiempoOcupadoA2 * 100) / reloj;
            }
            else
            {
                porcOcupacionA2 = vectorAnterior.porcOcupacionA2;
            }
        }

        private void TiempoOcupadoA3()
        {
            if (vectorAnterior == null)
            {
                tiempoOcupadoA3 = 0;
            }
            else if (a3Estado == 1 && vectorAnterior.a3Estado == 0)
            {
                tiempoOcupadoA3 = 1;
            }
            else if (a3Estado == 0 && vectorAnterior.a3Estado == 1)
            {
                tiempoOcupadoA3 = 0;
            }
            else
            {
                tiempoOcupadoA3 = vectorAnterior.tiempoOcupadoA3;
            }
        }

        private void AcumuladoTiempoOcupadoA3()
        {
            if (vectorAnterior == null)
            {
                acumuladoTiempoOcupadoA3 = 0;
            }
            else if (tiempoOcupadoA3 == 0 && vectorAnterior.tiempoOcupadoA3 == 0)
            {
                acumuladoTiempoOcupadoA3 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA3;
            }
            else
            {
                acumuladoTiempoOcupadoA3 = vectorAnterior.acumuladoTiempoOcupadoA3;
            }
        }

        private void PorcOcupacionA3()
        {
            if (vectorAnterior == null)
            {
                porcOcupacionA3 = 0;
            }
            else if (porcOcupacionA3 == 0 && vectorAnterior.porcOcupacionA3 == 0)
            {
                porcOcupacionA3 = (acumuladoTiempoOcupadoA3 * 100) / reloj;
            }
            else
            {
                porcOcupacionA3 = vectorAnterior.porcOcupacionA3;
            }
        }

        private void TiempoOcupadoA4()
        {
            if (vectorAnterior == null)
            {
                tiempoOcupadoA4 = 0;
            }
            else if (a4Estado == 1 && vectorAnterior.a4Estado == 0)
            {
                tiempoOcupadoA4 = 1;
            }
            else if (a4Estado == 0 && vectorAnterior.a4Estado == 1)
            {
                tiempoOcupadoA4 = 0;
            }
            else
            {
                tiempoOcupadoA4 = vectorAnterior.tiempoOcupadoA4;
            }
        }

        private void AcumuladoTiempoOcupadoA4()
        {
            if (vectorAnterior == null)
            {
                acumuladoTiempoOcupadoA4 = 0;
            }
            else if (tiempoOcupadoA4 == 0 && vectorAnterior.tiempoOcupadoA4 == 0)
            {
                acumuladoTiempoOcupadoA4 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA4;
            }
            else
            {
                acumuladoTiempoOcupadoA4 = vectorAnterior.acumuladoTiempoOcupadoA4;
            }
        }

        private void PorcOcupacionA4()
        {
            if (vectorAnterior == null)
            {
                porcOcupacionA4 = 0;
            }
            else if (porcOcupacionA4 == 0 && vectorAnterior.porcOcupacionA4 == 0)
            {
                porcOcupacionA4 = (acumuladoTiempoOcupadoA4 * 100) / reloj;
            }
            else
            {
                porcOcupacionA4 = vectorAnterior.porcOcupacionA4;
            }
        }

        private void TiempoOcupadoA5()
        {
            if (vectorAnterior == null)
            {
                tiempoOcupadoA5 = 0;
            }
            else if (a5Estado == 1 && vectorAnterior.a5Estado == 0)
            {
                tiempoOcupadoA5 = 1;
            }
            else if (a5Estado == 0 && vectorAnterior.a5Estado == 1)
            {
                tiempoOcupadoA5 = 0;
            }
            else
            {
                tiempoOcupadoA5 = vectorAnterior.tiempoOcupadoA5;
            }
        }
        private void AcumuladoTiempoOcupadoA5()
        {
            if (vectorAnterior == null)
            {
                acumuladoTiempoOcupadoA5 = 0;
            }
            else if (tiempoOcupadoA5 == 0 && vectorAnterior.tiempoOcupadoA5 == 0)
            {
                acumuladoTiempoOcupadoA5 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA5;
            }
            else
            {
                acumuladoTiempoOcupadoA5 = vectorAnterior.acumuladoTiempoOcupadoA5;
            }
        }

        private void PorcOcupacionA5()
        {
            if (vectorAnterior == null)
            {
                porcOcupacionA5 = 0;
            }
            else if (porcOcupacionA5 == 0 && vectorAnterior.porcOcupacionA5 == 0)
            {
                porcOcupacionA5 = (acumuladoTiempoOcupadoA5 * 100) / reloj;
            }
            else
            {
                porcOcupacionA5 = vectorAnterior.porcOcupacionA5;
            }
        }
        #endregion

        #region CANTIDAD ENSAMBLES X HORA
        private void CantEnsamblesXHora()
        {
            if (vectorAnterior == null)
            {
                cantEnsamblesXHora = 0;
            }
            else if (evento == 4 && colaEncastreA5 < vectorAnterior.colaEncastreA5)
            {
                if (evento != 8)
                {
                    cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora + 1;
                } 
                else
                {
                    cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora;
                }
            }
            else if (evento == 6 && colaEncastreA3 < vectorAnterior.colaEncastreA3)
            {
                if (evento != 8)
                {
                    cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora + 1;
                }
                else
                {
                    cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora;
                }
            }
            else if (evento == 8)
            {
                cantEnsamblesXHora = 0;
            }
            else
            {
                cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora;
            }
        }

        private void CantProbEnsamblesXHora()
        {
            if (vectorAnterior == null)
            {
                cantProbEnsamblesXHora = 0;
            }
            else if(cantidadEnsamblesFinalizados > 0)
            {
                cantProbEnsamblesXHora = cantEnsamblesXHora / cantidadEnsamblesFinalizados;
            }
            else
            {
                cantProbEnsamblesXHora = 0;
            }
        }
        #endregion

        #region PEDIDOS POR PARAMETROS COMPLETADOS EN UNA HORA
        private void PedidosParametroCompletadosEnUnaHora()
        {
            if (vectorAnterior == null)
            {
                pedidosParametroCompletadosEnUnaHora = 0;
            }
            else if (cantEnsamblesXHora > pedidoACalcular)
            {
                pedidosParametroCompletadosEnUnaHora = vectorAnterior.pedidosParametroCompletadosEnUnaHora + 1;
            }
            else
            {
                pedidosParametroCompletadosEnUnaHora = vectorAnterior.pedidosParametroCompletadosEnUnaHora;
            }
        }

        private void ProbPedidosParametroCompletadosEnUnaHora()
        {
            if (vectorAnterior == null)
            {
                probPedidosParametroCompletadosEnUnaHora = 0;
            }
            else if (cantidadEnsamblesFinalizados > 0)
            {
                probPedidosParametroCompletadosEnUnaHora = ((double)pedidosParametroCompletadosEnUnaHora / (double)cantidadEnsamblesFinalizados);
            }
            else
            {
                probPedidosParametroCompletadosEnUnaHora = 0;
            }
        }
        #endregion
    }
}

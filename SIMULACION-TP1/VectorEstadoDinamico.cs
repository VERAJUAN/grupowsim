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

        //CAMINO 1

        //QA
        public int qaEstado { get; set; }
        public int qaPedido { get; set; }
        public double qaTiempo { get; set; }
        public double qaProxFin { get; set; }
        public int qaCola { get; set; }

        //AA
        public int aaEstado { get; set; }
        public int aaPedido { get; set; }
        public double aaTiempo { get; set; }
        public double aaProxFin { get; set; }
        public int aaCola { get; set; }


        //CAMINO 2

        public List<int> colaParaLavar;
        //public List<int> colaParaSecar;

        //L1
        public int l1Estado { get; set; }
        public int l1Pedido { get; set; }
        public double l1Tiempo { get; set; }
        public double l1ProxFin { get; set; }
        //public int l1Cola { get; set; }

        //L2
        public int l2Estado { get; set; }
        public int l2Pedido { get; set; }
        public double l2Tiempo { get; set; }
        public double l2ProxFin { get; set; }
        //public int l2Cola { get; set; }

        //S
        public int sEstado { get; set; }
        public int sPedido { get; set; }
        public double sTiempo { get; set; }
        public double sProxFin { get; set; }
        public int sCola { get; set; }

        //PA
        public int paEstado { get; set; }
        public double paTiempo { get; set; }
        public double paProxFin { get; set; }
        public List<int> colaPaAA { get; set; }
        public List<int> colaPaS { get; set; }
        public int paPedido { get; set; }

        //ENSAMBLE
        public int cantidadEnsamblesSolicitados { get; set; }
        public int cantidadEnsamblesFinalizados { get; set; }
        public double propEnsamRealSobreSolic { get; set; }
        public double duracionPromedioEnsamble { get; set; }

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

        //BLOQUEO
        public double tiempoBloqueoColaA5 { get; set; }
        public double tiempoBloqueoColaEncastreA3 { get; set; }
        public double tiempoBloqueoColaEncastreA5 { get; set; }
        public double propBloqueoSobreOcupacion { get; set; }


        //ENSAMBLES X HORA
        public int cantEnsamblesXHora { get; set; }
        public double cantProbEnsamblesXHora { get; set; }

        //PEDIDOS POR PARAMETROS COMPLETADOS EN UNA HORA
        public int pedidosParametroCompletadosEnUnaHora { get; set; }
        public double probPedidosParametroCompletadosEnUnaHora { get; set; }

        //PICO ED
        public double picoTiempoEncastre { get; set; }

        //HELPER
        public bool banderaFinHora { get; set; }

        VectorEstadoDinamico vectorAnterior { get; set; }
        public VectorEstadoDinamico()
        {

        }

        public VectorEstadoDinamico(int nroEvento,
            double tiempoEntrePedidos,/* int pedidoACalcular, double picoTiempoEncastre,*/ double QA = 0, double AA = 0, double L1 = 0, double L2 = 0, double S = 0, double PA = 0, VectorEstadoDinamico vectorAnterior = null)
        {
            if (nroEvento == 1)
            {
                banderaFinHora = false;
            }
            else
            {
                banderaFinHora = vectorAnterior.banderaFinHora;
            }

            this.colaParaLavar = new List<int>();
            //this.colaParaSecar = new List<int>();
            this.colaPaAA = new List<int>();
            this.colaPaS = new List<int>();

            this.vectorAnterior = vectorAnterior;

            //this.pedidoACalcular = pedidoACalcular;

            //this.picoTiempoEncastre = picoTiempoEncastre;

            this.nroEvento = nroEvento;
            Reloj(); //0
            Evento(); //0
            Pedido();  //0

            //if(evento == 8)
            //{
            //    banderaFinHora = false;
            //}

            ProxPedido(); //1
            this.tiempoEntrePedidos = tiempoEntrePedidos;
            ProximaLlegada();

            ProxFinHora();

            QAEstado();
            QAPedido();
            qaTiempo = QATiempo(QA);
            QAProxFin();
            QACola();

            AAEstado();
            AAPedido();
            aaTiempo = AATiempo(AA);
            AAProxFin();
            AACola();


            L1Estado();
            L1Pedido();
            l1Tiempo = L1Tiempo(L1);
            L1ProxFin();
            //L1Cola();

            L2Estado();
            L2Pedido();
            l2Tiempo = L2Tiempo(L2);
            L2ProxFin();
            //L2Cola();

            

            SEstado();
            SPedido();
            sTiempo = STiempo(S); //Cambiar S por el tiempo de humedad
            SProxFin();
            //SCola();


            ColaParaLavar();
            //ColaParaSecar();

            PAEstado();
            PAPedido();
            paTiempo = PATiempo(PA);
            PAProxFin();
            ColaPA_AA();
            ColaPA_S();

            //CantidadEnsamblesSolicitados();
            //CantidadEnsamblesFinalizados();
            //PropEnsamRealSobreSolic();
            //TiempoPromedioDuracionEnsamble();

            //if (vectorAnterior != null)
            //{
            //    maxCola1 = Math.Max(a1Cola, vectorAnterior.maxCola1);
            //    maxCola2 = Math.Max(a2Cola, vectorAnterior.maxCola2);
            //    maxCola3 = Math.Max(a3Cola, vectorAnterior.maxCola3);
            //    maxCola4 = Math.Max(a4Cola, vectorAnterior.maxCola4);
            //    maxCola5 = Math.Max(a5ColaA2 + a5ColaA4, vectorAnterior.maxCola5);
            //    maxColaEncastre = Math.Max(colaEncastreA3 + colaEncastreA5, vectorAnterior.maxColaEncastre);
            //}

            //TiempoLlegada();
            //TiempoInicioAtencionA1();
            //TiempoPromCola1();
            //TiempoInicioAtencionA2();
            //TiempoPromCola2();
            //TiempoInicioAtencionA3();
            //TiempoPromCola3();
            //TiempoInicioAtencionA4();
            //TiempoPromCola4();
            //TiempoInicioAtencionA5();
            //TiempoPromCola5();
            //TiempoInicioAtencionEncastre();
            //TiempoPromColaEncastre();

            //CantPromedioProdEnCola();
            //CantPromedioProdEnSistema();

            //TiempoOcupadoA1();
            //AcumuladoTiempoOcupadoA1();
            //PorcOcupacionA1();

            //TiempoOcupadoA2();
            //AcumuladoTiempoOcupadoA2();
            //PorcOcupacionA2();

            //TiempoOcupadoA3();
            //AcumuladoTiempoOcupadoA3();
            //PorcOcupacionA3();

            //TiempoOcupadoA4();
            //AcumuladoTiempoOcupadoA4();
            //PorcOcupacionA4();

            //TiempoOcupadoA5();
            //AcumuladoTiempoOcupadoA5();
            //PorcOcupacionA5();

            //TiempoBloqueoColaA5();
            //TiempoBloqueoColaEncastre();
            //PropBloqueoSobreOcupacion();

            //CantEnsamblesXHora();
            //CantProbEnsamblesXHora();

            //PedidosParametroCompletadosEnUnaHora();
            //ProbPedidosParametroCompletadosEnUnaHora();
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
                    Math.Min(vectorAnterior.qaProxFin,
                    Math.Min(vectorAnterior.aaProxFin,
                    Math.Min(vectorAnterior.l1ProxFin,
                    Math.Min(vectorAnterior.l2ProxFin,
                    Math.Min(vectorAnterior.sProxFin,
                    vectorAnterior.paProxFin))))));
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
                if (reloj == vectorAnterior.proxLlegada)
                {
                    evento = 1;
                }
                else if (reloj == vectorAnterior.qaProxFin)
                {
                    evento = 2;
                }
                else if (reloj == vectorAnterior.aaProxFin)
                {
                    evento = 3;
                }
                else if (reloj == vectorAnterior.l1ProxFin)
                {
                    evento = 4;
                }
                else if (reloj == vectorAnterior.l2ProxFin)
                {
                    evento = 5;
                }
                else if (reloj == vectorAnterior.sProxFin)
                {
                    evento = 6;
                }
                else if (reloj == vectorAnterior.paProxFin)
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
                if (evento == 1)
                {
                    pedido = vectorAnterior.proxPedido;
                }
                else if (evento == 2)
                {
                    pedido = vectorAnterior.qaPedido;
                }
                else if (evento == 3)
                {
                    pedido = vectorAnterior.aaPedido;
                }
                else if (evento == 4)
                {
                    pedido = vectorAnterior.l1Pedido;
                }
                else if (evento == 5)
                {
                    pedido = vectorAnterior.l2Pedido;
                }
                else if (evento == 6)
                {
                    pedido = vectorAnterior.sPedido;
                }
                else if (evento == 7)
                {
                    pedido = vectorAnterior.paPedido;
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
                if (evento == 1)
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

        #region QA
        private void QAEstado()
        {
            if (vectorAnterior == null)
            {
                qaEstado = 0;
            }
            else
            {
                if (evento == 1 && vectorAnterior.qaEstado == 1)
                {
                    qaEstado = 1;
                }
                else if (evento == 2 && vectorAnterior.qaCola == 0)
                {
                    qaEstado = 0;
                }
                else if (vectorAnterior.qaCola == 0 && evento != 1 && vectorAnterior.qaEstado == 0)
                {
                    qaEstado = 0;
                }
                else
                {
                    qaEstado = 1;
                }
            }
        }

        private void QAPedido()
        {
            if (vectorAnterior == null)
            {
                qaPedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (vectorAnterior.qaEstado == 0 && evento == 1)
                {
                    qaPedido = pedido;
                }
                else if (vectorAnterior.qaEstado == 1 && evento != 2)
                {
                    qaPedido = vectorAnterior.qaPedido;
                }
                else if (evento == 2 && vectorAnterior.qaCola > 0)
                {
                    qaPedido = pedido + 1;
                }
            }
        }

        private double QATiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (qaPedido != vectorAnterior.qaPedido && qaPedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        private void QAProxFin()
        {
            if (vectorAnterior == null)
            {
                qaProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (qaEstado == 1)
                {
                    if (qaTiempo != 0)
                    {
                        qaProxFin = reloj + qaTiempo;
                    }
                    else
                    {
                        qaProxFin = vectorAnterior.qaProxFin;
                    }
                }
                else
                {
                    qaProxFin = double.PositiveInfinity;
                }
            }
        }

        private void QACola()
        {
            if (vectorAnterior == null)
            {
                qaCola = 0;
            }
            else
            {
                if (evento == 1 && vectorAnterior.qaEstado == 1)
                {
                    qaCola = vectorAnterior.qaCola + 1;
                }
                else if (evento == 2 && vectorAnterior.qaCola > 0)
                {
                    qaCola = vectorAnterior.qaCola - 1;
                }
                else
                {
                    qaCola = vectorAnterior.qaCola;
                }
            }
        }
        #endregion

        #region AA
        private void AAEstado()
        {
            if (vectorAnterior == null)
            {
                aaEstado = 0;
            }
            else
            {
                if (evento == 3 && vectorAnterior.aaCola == 0)
                {
                    aaEstado = 0;
                }
                else if (evento != 2 && vectorAnterior.aaCola == 0 && vectorAnterior.aaEstado == 0)
                {
                    aaEstado = 0;
                }
                else
                {
                    aaEstado = 1;
                }


            }
        }

        private double AATiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (aaPedido != vectorAnterior.aaPedido && aaPedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        private void AAPedido()
        {
            if (vectorAnterior == null)
            {
                aaPedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (vectorAnterior.aaEstado == 0 && evento == 2)
                {
                    aaPedido = pedido;
                }
                else if (vectorAnterior.aaEstado == 1 && evento != 3)
                {
                    aaPedido = vectorAnterior.aaPedido;
                }
                else if (evento == 3 && vectorAnterior.aaCola > 0)
                {
                    aaPedido = pedido + 1;
                }
            }
        }

        private void AAProxFin()
        {
            if (vectorAnterior == null)
            {
                aaProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (aaEstado == 1)
                {
                    if (aaTiempo != 0)
                    {
                        aaProxFin = reloj + aaTiempo;
                    }
                    else
                    {
                        aaProxFin = vectorAnterior.aaProxFin;
                    }
                }
                else
                {
                    aaProxFin = double.PositiveInfinity;
                }
            }
        }

        private void AACola()
        {
            if (vectorAnterior == null)
            {
                aaCola = 0;
            }
            else
            {
                if (evento == 1 && vectorAnterior.aaEstado == 1)
                {
                    aaCola = vectorAnterior.aaCola + 1;
                }
                else if (evento == 3 && vectorAnterior.aaCola > 0)
                {
                    aaCola = vectorAnterior.aaCola - 1;
                }
                else
                {
                    aaCola = vectorAnterior.aaCola;
                }
            }
        }

        #endregion

        private void ColaParaLavar()
        {
            if (vectorAnterior != null)
            {
                colaParaLavar = vectorAnterior.colaParaLavar;

                if (evento == 2 && vectorAnterior.l1Estado > 0 && vectorAnterior.l2Estado > 0)
                {
                    colaParaLavar.Add(pedido);
                }
                else if (evento == 6 && colaParaLavar.Count > 0)
                {
                    colaParaLavar.RemoveAt(0);
                }
            }
        }

        public string ColaParaLavarToString()
        {
            string cola = "-";
            foreach (var auto in colaParaLavar)
            {
                cola += auto.ToString() + "-";
            }
            return cola;
        }


        #region L1
        private void L1Estado()
        {
            if (vectorAnterior == null)
            {
                l1Estado = 0;
            }
            else
            {
                if (evento == 4 && vectorAnterior.sEstado == 0)
                {
                    l1Estado = 3;
                }
                else if (evento == 4 && vectorAnterior.sEstado == 1)
                {
                    l1Estado = 2;
                }
                else if(evento == 6 && vectorAnterior.l1Estado == 2)
                {
                    l1Estado = 3;
                }
                else if(evento == 6 && vectorAnterior.l1Pedido == pedido && vectorAnterior.colaParaLavar.Count > 0)
                {
                    l1Estado = 1;
                }
                else if (evento == 6 && vectorAnterior.l1Pedido == pedido && vectorAnterior.colaParaLavar.Count == 0)
                {
                    l1Estado = 0;
                }
                else if (evento != 2 && vectorAnterior.colaParaLavar.Count == 0 && vectorAnterior.l1Estado == 0)
                {
                    l1Estado = 0;
                }
                else if (evento == 2 && vectorAnterior.l1Estado == 0)
                {
                    l1Estado = 1;
                }
                else
                {
                    l1Estado = vectorAnterior.l1Estado;
                }
            }
        }

        private double L1Tiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (l1Pedido != vectorAnterior.l1Pedido && l1Pedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        private void L1Pedido()
        {
            if (vectorAnterior == null)
            {
                l1Pedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                //if (colaParaSecar.Count == 2 || (evento != 6 && vectorAnterior.colaParaSecar.Count == 1 &&
                //     evento != 5 && vectorAnterior.l2Estado == 1))
                //{
                //    l1Pedido = vectorAnterior.l1Pedido;
                //}
                //else 
                if (vectorAnterior.l1Estado == 0 && evento == 2)
                {
                    l1Pedido = pedido;
                }
                else if(vectorAnterior.l1Estado == 2)
                {
                    l1Pedido = vectorAnterior.l1Pedido;
                }
                else if(vectorAnterior.l1Estado == 3 && evento != 6)
                {
                    l1Pedido = vectorAnterior.l1Pedido;
                }
                else if (vectorAnterior.l1Estado == 3 && evento == 6 && vectorAnterior.l1Pedido == pedido
                    && vectorAnterior.colaParaLavar.Count > 0)
                {
                    l1Pedido = vectorAnterior.colaParaLavar.ElementAt(0);
                }
                else if (vectorAnterior.l1Estado == 3 && evento == 6 && vectorAnterior.l1Pedido != pedido)
                {
                    l1Pedido = vectorAnterior.l1Pedido;
                }
                else if(l1Estado > 0)
                {
                    l1Pedido = vectorAnterior.l1Pedido;
                }
                //else if (vectorAnterior.l1Estado == 1 && evento != 4)
                //{
                //    l1Pedido = vectorAnterior.l1Pedido;
                //}
                //else if (evento == 4 && vectorAnterior.colaParaLavar.Count > 0)
                //{
                //    l1Pedido = vectorAnterior.colaParaLavar.ElementAt(0);
                //}
            }
        }

        private void L1ProxFin()
        {
            if (vectorAnterior == null)
            {
                l1ProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (l1Estado == 1)
                {
                    if (l1Tiempo != 0)
                    {
                        l1ProxFin = reloj + l1Tiempo;
                    }
                    else
                    {
                        l1ProxFin = vectorAnterior.l1ProxFin;
                    }
                }
                else
                {
                    l1ProxFin = double.PositiveInfinity;
                }
            }
        }

        //private void L1Cola()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        a3Cola = 0;
        //    }
        //    else
        //    {
        //        if (evento == 1 && vectorAnterior.a3Estado == 1)
        //        {
        //            a3Cola = vectorAnterior.a3Cola + 1;
        //        }
        //        else if (evento == 4 && vectorAnterior.a3Cola > 0)
        //        {
        //            a3Cola = vectorAnterior.a3Cola - 1;
        //        }
        //        else
        //        {
        //            a3Cola = vectorAnterior.a3Cola;
        //        }
        //    }
        //}

        #endregion

        #region L2
        private void L2Estado()
        {
            if (vectorAnterior == null)
            {
                l2Estado = 0;
            }
            else
            {
                if (evento == 5 && vectorAnterior.sEstado == 0)
                {
                    l2Estado = 3;
                }
                else if (evento == 5 && vectorAnterior.sEstado == 1)
                {
                    l2Estado = 2;
                }
                else if (evento == 6 && vectorAnterior.l2Estado == 2)
                {
                    l2Estado = 3;
                }
                else if (evento != 2 && vectorAnterior.colaParaLavar.Count == 0 && vectorAnterior.l2Estado == 0)
                {
                    l2Estado = 0;
                }
                else
                {
                    l2Estado = vectorAnterior.l1Estado;
                }
            }
        }

        private double L2Tiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (l2Pedido != vectorAnterior.l2Pedido && l2Pedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        private void L2Pedido()
        {
            if (vectorAnterior == null)
            {
                l2Pedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                //if (colaParaSecar.Count == 2 || (evento != 6 && vectorAnterior.colaParaSecar.Count == 1 &&
                //     evento != 4 && vectorAnterior.l1Estado == 1))
                //{
                //    l2Pedido = vectorAnterior.l2Pedido;
                //}
                //else 
                if (vectorAnterior.l2Estado == 0 && evento == 2)
                {
                    l2Pedido = pedido;
                }
                else if (vectorAnterior.l2Estado == 2)
                {
                    l2Pedido = vectorAnterior.l2Pedido;
                }
                else if (vectorAnterior.l2Estado == 3 && evento != 6)
                {
                    l2Pedido = vectorAnterior.l2Pedido;
                }
                else if (vectorAnterior.l2Estado == 3 && evento == 6 && vectorAnterior.l2Pedido == pedido
                    && vectorAnterior.colaParaLavar.Count > 0)
                {
                    l2Pedido = vectorAnterior.colaParaLavar.ElementAt(0);
                }
                else if (vectorAnterior.l2Estado == 3 && evento == 6 && vectorAnterior.l2Pedido != pedido)
                {
                    l2Pedido = vectorAnterior.l2Pedido;
                }
                //if (vectorAnterior.l2Estado == 0 && evento == 2 && l1Pedido != pedido)
                //{
                //    l2Pedido = pedido;
                //}
                //else if (vectorAnterior.l2Estado == 1 && evento != 5)
                //{
                //    l2Pedido = vectorAnterior.l2Pedido;
                //}
                //else if (evento == 5 && vectorAnterior.colaParaLavar.Count > 0)
                //{
                //    l2Pedido = vectorAnterior.colaParaLavar.ElementAt(0);
                //}
            }
        }

        private void L2ProxFin()
        {
            if (vectorAnterior == null)
            {
                l2ProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (l2Estado == 1)
                {
                    if (l2Tiempo != 0)
                    {
                        l2ProxFin = reloj + l2Tiempo;
                    }
                    else
                    {
                        l2ProxFin = vectorAnterior.l2ProxFin;
                    }
                }
                else
                {
                    l2ProxFin = double.PositiveInfinity;
                }
            }
        }

        //private void L2Cola()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        l2Cola = 0;
        //    }
        //    else
        //    {
        //        if (evento == 2 && vectorAnterior.l2Estado == 1)
        //        {
        //            l2Cola = vectorAnterior.l2Cola + 1;
        //        }
        //        else if (evento == 5 && vectorAnterior.l2Cola > 0)
        //        {
        //            l2Cola = vectorAnterior.l2Cola - 1;
        //        }
        //        else
        //        {
        //            l2Cola = vectorAnterior.l2Cola;
        //        }
        //    }
        //}

        #endregion

        //public void ColaParaSecar()
        //{
        //    if (vectorAnterior != null)
        //    {
        //        colaParaSecar = vectorAnterior.colaParaSecar;

        //        if (evento == 4 && vectorAnterior.sEstado == 1)
        //        {
        //            colaParaSecar.Add(pedido);
        //        }
        //        else if (evento == 5 && vectorAnterior.sEstado == 1)
        //        {
        //            colaParaSecar.Add(pedido);
        //        }
        //        else if (evento == 6 && colaParaSecar.Count > 0)  
        //        {
        //            colaParaSecar.RemoveAt(0);
        //        }
        //    }
        //}

        //public string ColaParaSecarToString()
        //{
        //    string cola = "-";
        //    foreach (var auto in colaParaSecar)
        //    {
        //        cola += auto.ToString() + "-";
        //    }
        //    return cola;
        //}

        #region S
        private void SEstado()
        {
            if (vectorAnterior == null)
            {
                sEstado = 0;
            }
            else
            {
                if (evento == 6 && l1Estado != 2 && l2Estado != 2)
                {
                    sEstado = 0;
                }
                else if (evento != 4 && evento != 5 && vectorAnterior.l1Estado != 2 && vectorAnterior.l2Estado != 2
                    && vectorAnterior.sEstado == 0)
                {
                    sEstado = 0;
                }
                else
                {
                    sEstado = 1;
                }


            }
        }

        private double STiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (sPedido != vectorAnterior.sPedido && sPedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        private void SPedido()
        {
            if (vectorAnterior == null)
            {
                sPedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (evento == 6 && vectorAnterior.l1Estado == 2)
                {
                    sPedido = vectorAnterior.l1Pedido;
                }
                else if (evento == 6 && vectorAnterior.l2Estado == 2)
                {
                    sPedido = vectorAnterior.l2Pedido;
                }
                else if ((evento == 4 || evento == 5) && vectorAnterior.sEstado == 0)
                {
                    sPedido = pedido;
                }
                else if (vectorAnterior.sEstado == 1 && evento != 6)
                {
                    sPedido = vectorAnterior.sPedido;
                }
            }
        }

        private void SProxFin()
        {
            if (vectorAnterior == null)
            {
                sProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (sEstado == 1)
                {
                    if (sTiempo != 0)
                    {
                        sProxFin = reloj + sTiempo;
                    }
                    else
                    {
                        sProxFin = vectorAnterior.sProxFin;
                    }
                }
                else
                {
                    sProxFin = double.PositiveInfinity;
                }
            }
        }

        //private void SCola()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        sColaA4 = 0;
        //    }
        //    else
        //    {
        //        if (evento == 5 && vectorAnterior.sEstado == 1)
        //        {
        //            sColaA4 = vectorAnterior.sColaA4 + 1;
        //        }
        //        else if (evento == 5 && vectorAnterior.sEstado == 0 && vectorAnterior.sColaA2 == 0)
        //        {
        //            sColaA4 = vectorAnterior.sColaA4 + 1;
        //        }
        //        else if (evento == 6 && vectorAnterior.sColaA4 > 0)
        //        {
        //            sColaA4 = vectorAnterior.sColaA4 - 1;
        //        }
        //        else
        //        {
        //            sColaA4 = vectorAnterior.sColaA4;
        //        }
        //    }
        //}

        #endregion

        #region PA
        private void PAEstado()
        {
            if (vectorAnterior == null)
            {
                paEstado = 0;
            }
            else
            {
                if (evento == 7 && (vectorAnterior.colaPaAA.Count == 0 || vectorAnterior.colaPaS.Count == 0))
                {
                    paEstado = 0;
                }
                else if (evento == 3 && vectorAnterior.colaPaS.Contains(pedido)) // si termina alfombra y esta ya terminado carroceria
                {
                    paEstado = 1;
                }
                else if (evento == 6 && vectorAnterior.colaPaAA.Contains(pedido)) // si termina carroceria y esta ya terminado alfombra
                {
                    paEstado = 1;
                }
                else
                {
                    paEstado = vectorAnterior.paEstado;
                }
            }
        }
        private double PATiempo(double A)
        {
            double atiempo = 0;
            if (vectorAnterior == null)
            {
                atiempo = 0;
            }
            else if (sPedido != vectorAnterior.sPedido && sPedido != 0)
            {
                atiempo = A;
            }
            return atiempo;
        }

        //private void EncastreTiempo()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        encastreTiempo = 0;
        //    }
        //    else if (encastrePedido != vectorAnterior.encastrePedido && encastrePedido != 0)
        //    {
        //        encastreTiempo = picoTiempoEncastre;
        //    }
        //}

        private void PAPedido()
        {
            if (vectorAnterior == null)
            {
                paPedido = 0; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (vectorAnterior.paEstado == 0 && evento == 3 && vectorAnterior.colaPaS.Contains(pedido))
                {
                    paPedido = pedido;
                }
                else if (vectorAnterior.paEstado == 0 && evento == 6 && vectorAnterior.colaPaAA.Contains(pedido))
                {
                    paPedido = pedido;
                }
                else if (vectorAnterior.paEstado == 1 && evento != 7)
                {
                    paPedido = vectorAnterior.paPedido;
                }
                else if (evento == 7 && vectorAnterior.colaPaAA.Count > 0 && vectorAnterior.colaPaS.Count > 0)
                {
                    foreach (var aa in vectorAnterior.colaPaAA)
                    {
                        if (vectorAnterior.colaPaS.Contains(aa))
                        {
                            paPedido = aa;
                            break;
                        }
                    }
                }
            }
        }

        private void PAProxFin()
        {
            if (vectorAnterior == null)
            {
                paProxFin = double.PositiveInfinity; //SE REEMPLAZA CON "-"
            }
            else
            {
                if (paEstado == 1)
                {
                    if (paTiempo != 0)
                    {
                        paProxFin = reloj + paTiempo;
                    }
                    else
                    {
                        paProxFin = vectorAnterior.paProxFin;
                    }
                }
                else
                {
                    paProxFin = double.PositiveInfinity;
                }
            }
        }

        private void ColaPA_AA()
        {
            if (vectorAnterior != null)
            {
                colaPaAA = vectorAnterior.colaPaAA;

                if (evento == 3 && vectorAnterior.paEstado == 1)
                {
                    colaPaAA.Add(pedido);
                }
                else if (evento == 3 && !vectorAnterior.colaPaS.Contains(pedido))
                {
                    colaPaAA.Add(pedido);
                }
                else if (evento == 3 && vectorAnterior.colaPaS.Contains(pedido))
                {
                    colaPaAA.Remove(pedido);
                }
                //else if (evento == 7)
                //{
                //    colaPaAA.Remove(paPedido);
                //}
                if (paPedido != 0)
                {
                    colaPaAA.Remove(paPedido);
                }
            }
        }

        private void ColaPA_S()
        {
            if (vectorAnterior != null)
            {
                colaPaS = vectorAnterior.colaPaS;

                if (evento == 6 && vectorAnterior.paEstado == 1)
                {
                    colaPaS.Add(pedido);
                }
                else if (evento == 6 && !vectorAnterior.colaPaAA.Contains(pedido))
                {
                    colaPaS.Add(pedido);
                }
                //else if (evento == 6 && vectorAnterior.colaPaAA.Contains(pedido))
                //{
                //    colaPaS.Remove(pedido);
                //}
                if (paPedido != 0)
                {
                    colaPaS.Remove(paPedido);
                }
            }
        }

        public string ColaPaAAToString()
        {
            string cola = "-";
            foreach (var item in colaPaAA)
            {
                cola += item.ToString() + "-";
            }
            return cola;
        }

        public string ColaPaSToString()
        {
            string cola = "-";
            foreach (var item in colaPaS)
            {
                cola += item.ToString() + "-";
            }
            return cola;
        }
        #endregion

        //#region ProporcionEnsamblesRealizadosSobreSolicitados
        //private void CantidadEnsamblesSolicitados()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        cantidadEnsamblesSolicitados = 0;
        //    }
        //    else if (evento == 1)
        //    {
        //        cantidadEnsamblesSolicitados = vectorAnterior.cantidadEnsamblesSolicitados + 1;
        //    }
        //    else
        //    {
        //        cantidadEnsamblesSolicitados = vectorAnterior.cantidadEnsamblesSolicitados;
        //    }
        //}

        //private void CantidadEnsamblesFinalizados()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        cantidadEnsamblesFinalizados = 0;
        //    }
        //    else if (evento == 9)
        //    {
        //        cantidadEnsamblesFinalizados = vectorAnterior.cantidadEnsamblesFinalizados + 1;
        //    }
        //    else if (evento == 9)
        //    {
        //        cantidadEnsamblesFinalizados = vectorAnterior.cantidadEnsamblesFinalizados + 1;
        //    }
        //    else
        //    {
        //        cantidadEnsamblesFinalizados = vectorAnterior.cantidadEnsamblesFinalizados;
        //    }
        //}

        //private void PropEnsamRealSobreSolic()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        propEnsamRealSobreSolic = 0;
        //    }
        //    else if (cantidadEnsamblesFinalizados == 0)
        //    {
        //        propEnsamRealSobreSolic = vectorAnterior.propEnsamRealSobreSolic;
        //    }
        //    else
        //    {
        //        propEnsamRealSobreSolic = (double)cantidadEnsamblesFinalizados / (double)cantidadEnsamblesSolicitados;
        //    }
        //}

        //private void TiempoPromedioDuracionEnsamble()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        duracionPromedioEnsamble = 0;
        //    }
        //    else
        //    {
        //        if(cantidadEnsamblesFinalizados != 0)
        //        {
        //            duracionPromedioEnsamble = reloj / cantidadEnsamblesFinalizados;
        //        }
        //        else
        //        {
        //            duracionPromedioEnsamble = cantidadEnsamblesFinalizados;
        //        }
        //    }
        //}

        //#endregion

        //#region TIEMPOS PROMEDIOS 
        //private void TiempoLlegada()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoLlegada = 0;
        //    }
        //    else if (evento == 1 && pedido == pedidoACalcular)
        //    {
        //        tiempoLlegada = reloj;
        //    }
        //    else
        //    {
        //        tiempoLlegada = vectorAnterior.tiempoLlegada;
        //    }
        //}

        //private void TiempoInicioAtencionA1()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoInicioAtencionA1 = 0;
        //    }
        //    else if (a1Tiempo > 0 && a1Pedido == pedidoACalcular)
        //    {
        //        tiempoInicioAtencionA1 = reloj;
        //    }
        //    else
        //    {
        //        tiempoInicioAtencionA1 = vectorAnterior.tiempoInicioAtencionA1;
        //    }
        //}
        //private void TiempoPromCola1()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoPromCola1 = 0;
        //    }
        //    else if (tiempoInicioAtencionA1 >= tiempoLlegada)
        //    {
        //        tiempoPromCola1 = tiempoInicioAtencionA1 - tiempoLlegada;
        //    }
        //    else
        //    {
        //        tiempoPromCola1 = vectorAnterior.tiempoPromCola1;
        //    }
        //}
        //private void TiempoInicioAtencionA2()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoInicioAtencionA2 = 0;
        //    }
        //    else if (a2Tiempo > 0 && a2Pedido == pedidoACalcular)
        //    {
        //        tiempoInicioAtencionA2 = reloj;
        //    }
        //    else
        //    {
        //        tiempoInicioAtencionA2 = vectorAnterior.tiempoInicioAtencionA2;
        //    }
        //}
        //private void TiempoPromCola2()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoPromCola2 = 0;
        //    }
        //    else if (tiempoInicioAtencionA2 >= tiempoLlegada)
        //    {
        //        tiempoPromCola2 = tiempoInicioAtencionA2 - tiempoLlegada;
        //    }
        //    else
        //    {
        //        tiempoPromCola2 = vectorAnterior.tiempoPromCola2;
        //    }
        //}
        //private void TiempoInicioAtencionA3()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoInicioAtencionA3 = 0;
        //    }
        //    else if (a3Tiempo > 0 && a3Pedido == pedidoACalcular)
        //    {
        //        tiempoInicioAtencionA3 = reloj;
        //    }
        //    else
        //    {
        //        tiempoInicioAtencionA3 = vectorAnterior.tiempoInicioAtencionA3;
        //    }
        //}
        //private void TiempoPromCola3()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoPromCola3 = 0;
        //    }
        //    else if (tiempoInicioAtencionA3 >= tiempoLlegada)
        //    {
        //        tiempoPromCola3 = tiempoInicioAtencionA3 - tiempoLlegada;
        //    }
        //    else
        //    {
        //        tiempoPromCola3 = vectorAnterior.tiempoPromCola3;
        //    }
        //}
        //private void TiempoInicioAtencionA4()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoInicioAtencionA4 = 0;
        //    }
        //    else if (a4Tiempo > 0 && a4Pedido == pedidoACalcular)
        //    {
        //        tiempoInicioAtencionA4 = reloj;
        //    }
        //    else
        //    {
        //        tiempoInicioAtencionA4 = vectorAnterior.tiempoInicioAtencionA4;
        //    }
        //}
        //private void TiempoPromCola4()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoPromCola4 = 0;
        //    }
        //    else if (tiempoInicioAtencionA4 >= tiempoLlegada)
        //    {
        //        tiempoPromCola4 = tiempoInicioAtencionA4 - tiempoLlegada;
        //    }
        //    else
        //    {
        //        tiempoPromCola4 = vectorAnterior.tiempoPromCola4;
        //    }
        //}
        //private void TiempoInicioAtencionA5()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoInicioAtencionA5 = 0;
        //    }
        //    else if (a5Tiempo > 0 && a5Pedido == pedidoACalcular)
        //    {
        //        tiempoInicioAtencionA5 = reloj;
        //    }
        //    else
        //    {
        //        tiempoInicioAtencionA5 = vectorAnterior.tiempoInicioAtencionA5;
        //    }
        //}
        //private void TiempoPromCola5()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoPromCola5 = 0;
        //    }
        //    else if (tiempoInicioAtencionA5 >= tiempoLlegada)
        //    {
        //        tiempoPromCola5 = tiempoInicioAtencionA5 - tiempoLlegada;
        //    }
        //    else
        //    {
        //        tiempoPromCola5 = vectorAnterior.tiempoPromCola5;
        //    }
        //}
        //private void TiempoInicioAtencionEncastre()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoInicioAtencionEncastre = 0;
        //    }
        //    else
        //    {
        //        if(colaEncastreA3 > vectorAnterior.colaEncastreA3 || colaEncastreA5 > vectorAnterior.colaEncastreA5)
        //        {
        //            tiempoInicioAtencionEncastre = reloj;
        //        }
        //        else
        //        {
        //            tiempoInicioAtencionEncastre = vectorAnterior.tiempoInicioAtencionEncastre;
        //        }
        //    }
        //}
        //private void TiempoPromColaEncastre()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoPromColaEncastre = 0;
        //    }
        //    else if (tiempoInicioAtencionEncastre >= tiempoLlegada)
        //    {
        //        tiempoPromColaEncastre = tiempoInicioAtencionEncastre - tiempoLlegada;
        //    }
        //    else
        //    {
        //        tiempoPromColaEncastre = vectorAnterior.tiempoPromColaEncastre;
        //    }
        //}
        //#endregion

        //#region CANTIDAD PROMEDIO      
        //private void CantPromedioProdEnCola()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        cantPromedioProdEnCola = 0;
        //    }
        //    else
        //    {
        //        cantPromedioProdEnCola = (double)(a1Cola + a2Cola + a3Cola + a4Cola + a5ColaA2 + a5ColaA4 + colaEncastreA3 + colaEncastreA5) / 6;
        //    }
        //}

        //private void CantPromedioProdEnSistema()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        cantPromedioProdEnSistema = 0;
        //    }
        //    else
        //    {
        //        cantPromedioProdEnSistema = (double)(a1Estado + a2Estado + a3Estado + a4Estado + a5Estado +
        //                                        a1Cola + a2Cola + a3Cola + a4Cola + a5ColaA2 + a5ColaA4 + colaEncastreA3 + colaEncastreA5) / 6;
        //    }
        //}
        //#endregion

        //#region PORCENTAJE DE OCUPACION
        //private void TiempoOcupadoA1()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoOcupadoA1 = 0;
        //    }
        //    else if (a1Estado == 1 && vectorAnterior.a1Estado == 0)
        //    {
        //        tiempoOcupadoA1 = 3; //"x"
        //    }
        //    else 
        //    {
        //        if (a1Estado == 0 && vectorAnterior.a1Estado == 1)
        //            tiempoOcupadoA1 = 0;
        //        else
        //            tiempoOcupadoA1 = vectorAnterior.tiempoOcupadoA1;
        //    }

        //}
        //private void AcumuladoTiempoOcupadoA1()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        acumuladoTiempoOcupadoA1 = 0;
        //    }
        //    else if (tiempoOcupadoA1 == 3 && vectorAnterior.tiempoOcupadoA1 == 0)
        //    {
        //        acumuladoTiempoOcupadoA1 = 0;
        //    }
        //    else if(tiempoOcupadoA1 == 3 && vectorAnterior.tiempoOcupadoA1 == 3)
        //    {
        //        acumuladoTiempoOcupadoA1 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA1;
        //    } 
        //    else
        //    {
        //        acumuladoTiempoOcupadoA1 = vectorAnterior.acumuladoTiempoOcupadoA1;
        //    }
        //}

        //private void PorcOcupacionA1()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        porcOcupacionA1 = 0;
        //    }
        //    else if (tiempoOcupadoA1 == 3 && vectorAnterior.tiempoOcupadoA1 == 3)
        //    {
        //        porcOcupacionA1 = (acumuladoTiempoOcupadoA1 * 100) / reloj;
        //    }
        //    else
        //    {
        //        porcOcupacionA1 = vectorAnterior.porcOcupacionA1;
        //    }
        //}

        //private void TiempoOcupadoA2()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoOcupadoA2 = 0;
        //    }
        //    else if (a2Estado == 1 && vectorAnterior.a2Estado == 0)
        //    {
        //        tiempoOcupadoA2 = 3; //"x"
        //    }
        //    else
        //    {
        //        if (a2Estado == 0 && vectorAnterior.a2Estado == 1)
        //            tiempoOcupadoA2 = 0;
        //        else
        //            tiempoOcupadoA2 = vectorAnterior.tiempoOcupadoA2;
        //    }
        //}

        //private void AcumuladoTiempoOcupadoA2()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        acumuladoTiempoOcupadoA2 = 0;
        //    }
        //    else if (tiempoOcupadoA2 == 3 && vectorAnterior.tiempoOcupadoA2 == 0)
        //    {
        //        acumuladoTiempoOcupadoA2 = 0;
        //    }
        //    else if (tiempoOcupadoA2 == 3 && vectorAnterior.tiempoOcupadoA2 == 3)
        //    {
        //        acumuladoTiempoOcupadoA2 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA2;
        //    }
        //    else
        //    {
        //        acumuladoTiempoOcupadoA2 = vectorAnterior.acumuladoTiempoOcupadoA2;
        //    }
        //}

        //private void PorcOcupacionA2()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        porcOcupacionA2 = 0;
        //    }
        //    else if (tiempoOcupadoA2 == 3 && vectorAnterior.tiempoOcupadoA2 == 3)
        //    {
        //        porcOcupacionA2 = (acumuladoTiempoOcupadoA2 * 100) / reloj;
        //    }
        //    else
        //    {
        //        porcOcupacionA2 = vectorAnterior.porcOcupacionA2;
        //    }
        //}

        //private void TiempoOcupadoA3()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoOcupadoA3 = 0;
        //    }
        //    else if (a3Estado == 1 && vectorAnterior.a3Estado == 0)
        //    {
        //        tiempoOcupadoA3 = 3; //"x"
        //    }
        //    else
        //    {
        //        if (a3Estado == 0 && vectorAnterior.a3Estado == 1)
        //            tiempoOcupadoA3 = 0;
        //        else
        //            tiempoOcupadoA3 = vectorAnterior.tiempoOcupadoA3;
        //    }
        //}

        //private void AcumuladoTiempoOcupadoA3()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        acumuladoTiempoOcupadoA3 = 0;
        //    }
        //    else if (tiempoOcupadoA3 == 3 && vectorAnterior.tiempoOcupadoA3 == 0)
        //    {
        //        acumuladoTiempoOcupadoA3 = 0;
        //    }
        //    else if (tiempoOcupadoA3 == 3 && vectorAnterior.tiempoOcupadoA3 == 3)
        //    {
        //        acumuladoTiempoOcupadoA3 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA3;
        //    }
        //    else
        //    {
        //        acumuladoTiempoOcupadoA3 = vectorAnterior.acumuladoTiempoOcupadoA3;
        //    }
        //}

        //private void PorcOcupacionA3()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        porcOcupacionA3 = 0;
        //    }
        //    else if (tiempoOcupadoA3 == 3 && vectorAnterior.tiempoOcupadoA3 == 3)
        //    {
        //        porcOcupacionA3 = (acumuladoTiempoOcupadoA3 * 100) / reloj;
        //    }
        //    else
        //    {
        //        porcOcupacionA3 = vectorAnterior.porcOcupacionA3;
        //    }
        //}

        //private void TiempoOcupadoA4()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoOcupadoA4 = 0;
        //    }
        //    else if (a4Estado == 1 && vectorAnterior.a4Estado == 0)
        //    {
        //        tiempoOcupadoA4 = 3; //"x"
        //    }
        //    else
        //    {
        //        if (a4Estado == 0 && vectorAnterior.a4Estado == 1)
        //            tiempoOcupadoA4 = 0;
        //        else
        //            tiempoOcupadoA4 = vectorAnterior.tiempoOcupadoA4;
        //    }
        //}

        //private void AcumuladoTiempoOcupadoA4()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        acumuladoTiempoOcupadoA4 = 0;
        //    }
        //    else if (tiempoOcupadoA4 == 3 && vectorAnterior.tiempoOcupadoA4 == 0)
        //    {
        //        acumuladoTiempoOcupadoA4 = 0;
        //    }
        //    else if (tiempoOcupadoA4 == 3 && vectorAnterior.tiempoOcupadoA4 == 3)
        //    {
        //        acumuladoTiempoOcupadoA4 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA4;
        //    }
        //    else
        //    {
        //        acumuladoTiempoOcupadoA4 = vectorAnterior.acumuladoTiempoOcupadoA4;
        //    }
        //}

        //private void PorcOcupacionA4()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        porcOcupacionA4 = 0;
        //    }
        //    else if (tiempoOcupadoA4 == 3 && vectorAnterior.tiempoOcupadoA4 == 3)
        //    {
        //        porcOcupacionA4 = (acumuladoTiempoOcupadoA4 * 100) / reloj;
        //    }
        //    else
        //    {
        //        porcOcupacionA4 = vectorAnterior.porcOcupacionA4;
        //    }
        //}

        //private void TiempoOcupadoA5()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoOcupadoA5 = 0;
        //    }
        //    else if (a5Estado == 1 && vectorAnterior.a5Estado == 0)
        //    {
        //        tiempoOcupadoA5 = 3; //"x"
        //    }
        //    else
        //    {
        //        if (a5Estado == 0 && vectorAnterior.a5Estado == 1)
        //            tiempoOcupadoA5 = 0;
        //        else
        //            tiempoOcupadoA5 = vectorAnterior.tiempoOcupadoA5;
        //    }
        //}
        //private void AcumuladoTiempoOcupadoA5()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        acumuladoTiempoOcupadoA5 = 0;
        //    }
        //    else if (tiempoOcupadoA5 == 3 && vectorAnterior.tiempoOcupadoA5 == 0)
        //    {
        //        acumuladoTiempoOcupadoA5 = 0;
        //    }
        //    else if (tiempoOcupadoA5 == 3 && vectorAnterior.tiempoOcupadoA5 == 3)
        //    {
        //        acumuladoTiempoOcupadoA5 = reloj - vectorAnterior.reloj + vectorAnterior.acumuladoTiempoOcupadoA5;
        //    }
        //    else
        //    {
        //        acumuladoTiempoOcupadoA5 = vectorAnterior.acumuladoTiempoOcupadoA5;
        //    }
        //}

        //private void PorcOcupacionA5()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        porcOcupacionA5 = 0;
        //    }
        //    else if (tiempoOcupadoA5 == 3 && vectorAnterior.tiempoOcupadoA5 == 3)
        //    {
        //        porcOcupacionA5 = (acumuladoTiempoOcupadoA5 * 100) / reloj;
        //    }
        //    else
        //    {
        //        porcOcupacionA5 = vectorAnterior.porcOcupacionA5;
        //    }
        //}
        //#endregion

        //#region CANTIDAD ENSAMBLES X HORA
        //private void CantEnsamblesXHora()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        cantEnsamblesXHora = 0;
        //    }
        //    else if (evento == 4 && colaEncastreA5 < vectorAnterior.colaEncastreA5)
        //    {
        //        if (evento != 8)
        //        {
        //            cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora + 1;
        //        }
        //        else
        //        {
        //            cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora;
        //        }
        //    }
        //    else if (evento == 6 && colaEncastreA3 < vectorAnterior.colaEncastreA3)
        //    {
        //        if (evento != 8)
        //        {
        //            cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora + 1;
        //        }
        //        else
        //        {
        //            cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora;
        //        }
        //    }
        //    else if (evento == 8)
        //    {
        //        cantEnsamblesXHora = 0;
        //    }
        //    else
        //    {
        //        cantEnsamblesXHora = vectorAnterior.cantEnsamblesXHora;
        //    }
        //}

        //private void CantProbEnsamblesXHora()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        cantProbEnsamblesXHora = 0;
        //    }
        //    else if(cantidadEnsamblesFinalizados > 0)
        //    {
        //        cantProbEnsamblesXHora = cantidadEnsamblesFinalizados / (reloj / 60);
        //    }
        //    else
        //    {
        //        cantProbEnsamblesXHora = (vectorAnterior.cantProbEnsamblesXHora * (nroEvento - 1)) / nroEvento;
        //    }
        //}
        //#endregion

        //#region PEDIDOS POR PARAMETROS COMPLETADOS EN UNA HORA
        //private void PedidosParametroCompletadosEnUnaHora()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        pedidosParametroCompletadosEnUnaHora = 0;
        //    }
        //    else if (cantEnsamblesXHora >= pedidoACalcular && !vectorAnterior.banderaFinHora)
        //    {
        //        pedidosParametroCompletadosEnUnaHora = vectorAnterior.pedidosParametroCompletadosEnUnaHora + 1;
        //        banderaFinHora = true;
        //    }
        //    else
        //    {
        //        pedidosParametroCompletadosEnUnaHora = vectorAnterior.pedidosParametroCompletadosEnUnaHora;
        //    }
        //}

        //private void ProbPedidosParametroCompletadosEnUnaHora()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        probPedidosParametroCompletadosEnUnaHora = 0;
        //    }
        //    else
        //    {
        //        probPedidosParametroCompletadosEnUnaHora = pedidosParametroCompletadosEnUnaHora / (reloj/60);
        //    }
        //}
        //#endregion

        //#region TIEMPOS BLOQUEO

        //private void TiempoBloqueoColaA5()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoBloqueoColaA5 = 0;
        //    }
        //    else if (a5Estado == 0 && a4Cola == 0 && a2Cola > 0)
        //    {
        //        tiempoBloqueoColaA5 = reloj - vectorAnterior.reloj + vectorAnterior.tiempoBloqueoColaA5;
        //    }
        //    else if (a5Estado == 0 && a4Cola > 0 && a2Cola == 0)
        //    {
        //        tiempoBloqueoColaA5 = reloj - vectorAnterior.reloj + vectorAnterior.tiempoBloqueoColaA5;
        //    }
        //    else
        //    {
        //        tiempoBloqueoColaA5 = 0;
        //    }
        //}

        //private void TiempoBloqueoColaEncastre()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        tiempoBloqueoColaEncastreA3 = 0;
        //        tiempoBloqueoColaEncastreA5 = 0;
        //    }
        //    else if (colaEncastreA3 == 0 && colaEncastreA5 > 0)
        //    {
        //        tiempoBloqueoColaEncastreA5 = reloj - vectorAnterior.reloj + vectorAnterior.tiempoBloqueoColaEncastreA5;
        //        tiempoBloqueoColaEncastreA3 = 0;
        //    }
        //    else if (colaEncastreA3 > 0 && colaEncastreA5 == 0)
        //    {
        //        tiempoBloqueoColaEncastreA3 = reloj - vectorAnterior.reloj + vectorAnterior.tiempoBloqueoColaEncastreA3;
        //        tiempoBloqueoColaEncastreA5 = 0;
        //    }
        //    else
        //    {
        //        tiempoBloqueoColaEncastreA3 = 0;
        //        tiempoBloqueoColaEncastreA5 = 0;
        //    }
        //}

        //private void PropBloqueoSobreOcupacion()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        propBloqueoSobreOcupacion = 0;
        //    }
        //    else if (acumuladoTiempoOcupadoA5 > 0)
        //    {
        //        propBloqueoSobreOcupacion = tiempoBloqueoColaA5 / acumuladoTiempoOcupadoA5;
        //    } 
        //    else
        //    {
        //        propBloqueoSobreOcupacion = 0;
        //    }
        //}
        //#endregion
    }
}

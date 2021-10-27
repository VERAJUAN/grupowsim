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

        VectorEstadoDinamico vectorAnterior { get; set; }
        public VectorEstadoDinamico()
        {

        }

        public VectorEstadoDinamico(int nroEvento,
            double tiempoEntrePedidos, double A1 = 0, double A2 = 0, double A3 = 0, double A4 = 0, double A5 = 0, VectorEstadoDinamico vectorAnterior = null)
        {
            this.vectorAnterior = vectorAnterior;

            this.nroEvento = nroEvento;
            Reloj(tiempoEntrePedidos); //0
            Evento(); //0
            Pedido();  //0

            ProxPedido(); //1
            this.tiempoEntrePedidos = Math.Round(tiempoEntrePedidos, 3);
            ProximaLlegada();

            A1Estado();
            A1Pedido();
            a1Tiempo = Math.Round(A1,3);
            A1ProxFin();
            A1Cola();

            A2Estado();
            A2Pedido();
            a2Tiempo = Math.Round(A2, 3);
            A2ProxFin();
            A2Cola();

            A3Estado();
            A3Pedido();
            a3Tiempo = Math.Round(A3, 3);
            A3ProxFin();
            A3Cola();

            A4Estado();
            A4Pedido();
            a4Tiempo = Math.Round(A4, 3);
            A4ProxFin();
            A4Cola();

            A5Estado();
            A5Pedido();
            a5Tiempo = Math.Round(A5, 3);
            A5ProxFin();
            A5ColaA4();
            A5ColaA2();

        }

        #region EVENTO 

        private void Reloj(double tiempoEntrePedidos)
        {
            if (vectorAnterior == null)
            {
                reloj = 0;
            }
            else
            {
                reloj = Math.Round(Math.Min(vectorAnterior.proxLlegada,
                    Math.Min(vectorAnterior.a1ProxFin,
                    Math.Min(vectorAnterior.a2ProxFin,
                    Math.Min(vectorAnterior.a3ProxFin,
                    Math.Min(vectorAnterior.a4ProxFin, vectorAnterior.a5ProxFin
                    ))))), 3);

                //VER COMO HACER LA COLUMNA QUE SUMA 60 MINUTOS
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

                //AGREGAR LOS DEMAS EVENTOS
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

                //COMPLETEAR CON LOS EVENTOS QUE FALTAN
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
    }
}

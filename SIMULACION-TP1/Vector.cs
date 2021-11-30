using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULACION_TP1
{
    public class Vector
    {
        //EVENTO
        public int nroEvento { get; set; }
        public double reloj { get; set; }
        public int evento { get; set; }
        public int camion { get; set; }

        //PEDIDO
        public int proxcamion { get; set; }
        public double tiempoEntreCamiones { get; set; }
        public double proxLlegada { get; set; }

        Vector vectorAnterior { get; set; }

        public double rndTnCamion { get; set; }
        public double tnCamion { get; set; }
        public int ingresaASilo { get; set; }

        //Abastecimiento Planta
        public int siloAbasteciendoPlanta { get; set; }
        public double rndTiempoAbasteciendoPlanta { get; set; }
        public double tiempoAbasteciendoPlanta { get; set; }
        public double proximoFinAbasteciendoPlanta { get; set; }

        //Cambio de Silo
        public double sobraTnCambioSilo { get; set; }
        public double siloCambioSilo { get; set; }
        public int camionCambioSilo { get; set; }
        public int siguienteSiloCambioSilo { get; set; }
        public double tiempoCambioSilo { get; set; }
        public double proximoFinCambioSilo { get; set; }

        //Silo 1
        public int estadoSilo1 { get; set; }
        public double contenidoTnSilo1 { get; set; }
        public int camionSilo1 { get; set; }
        public double tiempoSilo1 { get; set; }
        public double proximoFinSilo1 { get; set; }
        public int colaFinSilo1 { get; set; }
        public Queue<int> clientesEnColaSilo1 { get; set; }

        //Silo 2
        public int estadoSilo2 { get; set; }
        public double contenidoTnSilo2 { get; set; }
        public int camionSilo2 { get; set; }
        public double tiempoSilo2 { get; set; }
        public double proximoFinSilo2 { get; set; }
        public int colaFinSilo2 { get; set; }
        public Queue<int> clientesEnColaSilo2 { get; set; }

        //Silo 3
        public int estadoSilo3 { get; set; }
        public double contenidoTnSilo3 { get; set; }
        public int camionSilo3 { get; set; }
        public double tiempoSilo3 { get; set; }
        public double proximoFinSilo3 { get; set; }
        public int colaFinSilo3 { get; set; }
        public Queue<int> clientesEnColaSilo3 { get; set; }

        //Silo 4
        public int estadoSilo4 { get; set; }
        public double contenidoTnSilo4 { get; set; }
        public int camionSilo4 { get; set; }
        public double tiempoSilo4 { get; set; }
        public double proximoFinSilo4 { get; set; }
        public int colaFinSilo4 { get; set; }
        public Queue<int> clientesEnColaSilo4 { get; set; }


        public int parametroCapacidadSilo { get; set; }


        public Vector()
        {

        }

        public Vector(int nroEvento,
            double tiempoEntreCamiones, double picoTiempoDescarga, int parametroCapacidadSilo = 20, double tiempoAbasteciendoPlanta = 0, double tiempoCambioSilo = 0, double TiempoSilo1 = 0, double TiempoSilo2 = 0, double TiempoSilo3 = 0, double TiempoSilo4 = 0, Vector vectorAnterior = null)
        {
            this.vectorAnterior = vectorAnterior;
            this.tiempoEntreCamiones = tiempoEntreCamiones;
            this.nroEvento = nroEvento;
            this.parametroCapacidadSilo = parametroCapacidadSilo;

            Reloj(); //0
            Evento(); //0
            Pedido();  //0

            ProxCamion(); //1
            this.tiempoEntreCamiones = tiempoEntreCamiones;
            ProximaLlegada();
            RndTnCamion();
            TnCamion();
            IngresaASilo();

            //SiloAbasteciendoPlanta();
            //RndTiempoAbasteciendoPlanta();
            //this.tiempoAbasteciendoPlanta = TiempoAbasteciendoPlanta(tiempoAbasteciendoPlanta);
            //this.proximoFinAbasteciendoPlanta = ProximoFinAbasteciendoPlanta(this.tiempoAbasteciendoPlanta);

            //SobraTnCambioSilo();
            //SiloCambioSilo();
            //CamionCambioSilo();
            //SiguienteSiloCambioSilo();
            //this.tiempoCambioSilo = TiempoCambioSilo(tiempoCambioSilo);
            //this.proximoFinCambioSilo = ProximoFinCambioSilo(this.tiempoCambioSilo);

            //estadoSilo1 = EstadoSilo(1, vectorAnterior.estadoSilo1, 2, vectorAnterior.colaFinSilo1);
            //estadoSilo2 = EstadoSilo(2, vectorAnterior.estadoSilo2, 3, vectorAnterior.colaFinSilo2);
            //estadoSilo3 = EstadoSilo(3, vectorAnterior.estadoSilo3, 4, vectorAnterior.colaFinSilo3);
            //estadoSilo4 = EstadoSilo(4, vectorAnterior.estadoSilo4, 5, vectorAnterior.colaFinSilo4);

            //contenidoTnSilo1 = ContenidoTnSilo(1, vectorAnterior.contenidoTnSilo1);
            //contenidoTnSilo2 = ContenidoTnSilo(2, vectorAnterior.contenidoTnSilo2);
            //contenidoTnSilo3 = ContenidoTnSilo(3, vectorAnterior.contenidoTnSilo3);
            //contenidoTnSilo4 = ContenidoTnSilo(4, vectorAnterior.contenidoTnSilo4);

            //camionSilo1 = CamionSilo(estadoSilo1, vectorAnterior.camionSilo1, 2, vectorAnterior.colaFinSilo1, clientesEnColaSilo1);
            //camionSilo2 = CamionSilo(estadoSilo2, vectorAnterior.camionSilo2, 3, vectorAnterior.colaFinSilo2, clientesEnColaSilo2);
            //camionSilo3 = CamionSilo(estadoSilo3, vectorAnterior.camionSilo3, 4, vectorAnterior.colaFinSilo3, clientesEnColaSilo3);
            //camionSilo4 = CamionSilo(estadoSilo4, vectorAnterior.camionSilo4, 5, vectorAnterior.colaFinSilo4, clientesEnColaSilo4);

            //tiempoSilo1 = TiempoSilo(TiempoSilo1, camionSilo1, vectorAnterior.camionSilo1);
            //tiempoSilo2 = TiempoSilo(TiempoSilo2, camionSilo2, vectorAnterior.camionSilo2);
            //tiempoSilo3 = TiempoSilo(TiempoSilo3, camionSilo3, vectorAnterior.camionSilo3);
            //tiempoSilo4 = TiempoSilo(TiempoSilo4, camionSilo4, vectorAnterior.camionSilo4);

            //proximoFinSilo1 = ProximoFinSilo(tiempoSilo1, estadoSilo1, vectorAnterior.proximoFinSilo1);
            //proximoFinSilo2 = ProximoFinSilo(tiempoSilo2, estadoSilo2, vectorAnterior.proximoFinSilo2);
            //proximoFinSilo3 = ProximoFinSilo(tiempoSilo3, estadoSilo3, vectorAnterior.proximoFinSilo3);
            //proximoFinSilo4 = ProximoFinSilo(tiempoSilo4, estadoSilo4, vectorAnterior.proximoFinSilo4);

            //colaFinSilo1 = ColaFinSilo(1, ingresaASilo, estadoSilo1, vectorAnterior.colaFinSilo1);
            //colaFinSilo2 = ColaFinSilo(2, ingresaASilo, estadoSilo2, vectorAnterior.colaFinSilo2);
            //colaFinSilo3 = ColaFinSilo(3, ingresaASilo, estadoSilo3, vectorAnterior.colaFinSilo3);
            //colaFinSilo4 = ColaFinSilo(4, ingresaASilo, estadoSilo4, vectorAnterior.colaFinSilo4);

            //clientesEnColaSilo1 = ClientesEnColaSilo(vectorAnterior.clientesEnColaSilo1, colaFinSilo1, vectorAnterior.colaFinSilo1, camion);
            //clientesEnColaSilo2 = ClientesEnColaSilo(vectorAnterior.clientesEnColaSilo2, colaFinSilo2, vectorAnterior.colaFinSilo2, camion);
            //clientesEnColaSilo3 = ClientesEnColaSilo(vectorAnterior.clientesEnColaSilo3, colaFinSilo3, vectorAnterior.colaFinSilo3, camion);
            //clientesEnColaSilo4 = ClientesEnColaSilo(vectorAnterior.clientesEnColaSilo4, colaFinSilo4, vectorAnterior.colaFinSilo4, camion);

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
                        Math.Min(vectorAnterior.proximoFinSilo1,
                        Math.Min(vectorAnterior.proximoFinSilo2,
                        Math.Min(vectorAnterior.proximoFinSilo3,
                        Math.Min(vectorAnterior.proximoFinSilo4,
                        Math.Min(vectorAnterior.proximoFinAbasteciendoPlanta, vectorAnterior.proximoFinCambioSilo
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
                if (reloj == vectorAnterior.proxLlegada)
                {
                    evento = 1;
                }
                else if (reloj == vectorAnterior.proximoFinSilo1)
                {
                    evento = 2;
                }
                else if (reloj == vectorAnterior.proximoFinSilo2)
                {
                    evento = 3;
                }
                else if (reloj == vectorAnterior.proximoFinSilo3)
                {
                    evento = 4;
                }
                else if (reloj == vectorAnterior.proximoFinSilo3)
                {
                    evento = 5;
                }
                else if (reloj == vectorAnterior.proximoFinAbasteciendoPlanta)
                {
                    evento = 6;
                }
                else if (reloj == vectorAnterior.proximoFinCambioSilo)
                {
                    evento = 7;
                }
                else
                {
                    evento = 0;
                }
            }
        }

        private void Pedido()
        {
            if (vectorAnterior == null)
            {
                camion = 0;
            }
            else
            {
                if (evento == 1)
                {
                    camion = vectorAnterior.proxcamion;
                }
                else if (evento == 2)
                {
                    camion = vectorAnterior.camionSilo1;
                }
                else if (evento == 3)
                {
                    camion = vectorAnterior.camionSilo2;
                }
                else if (evento == 4)
                {
                    camion = vectorAnterior.camionSilo3;
                }
                else if (evento == 5)
                {
                    camion = vectorAnterior.camionSilo4;
                }
                else if (evento == 7)
                {
                    camion = vectorAnterior.camionCambioSilo;
                }
                else
                {
                    camion = 0;
                }

            }
        }
        #endregion

        #region CAMION
        private void ProxCamion()
        {
            if (vectorAnterior == null)
            {
                proxcamion = 1;
            }
            else
            {
                if (evento == 1)
                {
                    proxcamion = vectorAnterior.proxcamion + 1;
                }
                else
                {
                    proxcamion = vectorAnterior.proxcamion;
                }
            }
        }

        private void ProximaLlegada()
        {
            if (evento == 0 || evento == 1)
            {
                proxLlegada = reloj + tiempoEntreCamiones;
            }
            else
            {
                proxLlegada = vectorAnterior.proxLlegada;
            }
        }

        private void RndTnCamion()
        {
            if (vectorAnterior == null)
            {
                rndTnCamion = 0;
            }
            else if (evento == 1)
            {
                Random rnd = new Random();

                rndTnCamion = rnd.NextDouble();
            }
            else
            {
                rndTnCamion = 0;
            }
        }

        private void TnCamion()
        {
            if (vectorAnterior == null)
            {
                tnCamion = 0;
            }
            else if (rndTnCamion != 0)
            {
                tnCamion = rndTnCamion < 0.5 ? 10 : 12; 
            }
            else
            {
                tnCamion = 0;
            }
        }

        private void IngresaASilo()
        {
            if (vectorAnterior == null)
            {
                ingresaASilo = 0;
            }
            else if (rndTnCamion != 0)
            {
                ingresaASilo = contenidoTnSilo1 < parametroCapacidadSilo ? 1 :
                                contenidoTnSilo2 < parametroCapacidadSilo ? 2 : contenidoTnSilo3 < parametroCapacidadSilo ? 3 : contenidoTnSilo4 < parametroCapacidadSilo ? 4 : 0;
            }
            else
            {
                ingresaASilo = 0;
            }
        }
        #endregion

        //#region Abastecimiento Planta
        //private void SiloAbasteciendoPlanta()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        siloAbasteciendoPlanta = 0;
        //    }
        //    else if(evento == 6)
        //    {
        //        siloAbasteciendoPlanta = 0;
        //    }
        //    else if (contenidoTnSilo1 == parametroCapacidadSilo)
        //    {
        //        siloAbasteciendoPlanta = 1;
        //    }
        //    else if (contenidoTnSilo2 == parametroCapacidadSilo)
        //    {
        //        siloAbasteciendoPlanta = 2;
        //    }
        //    else if (contenidoTnSilo3 == parametroCapacidadSilo)
        //    {
        //        siloAbasteciendoPlanta = 3;
        //    }
        //    else if (contenidoTnSilo1 == parametroCapacidadSilo)
        //    {
        //        siloAbasteciendoPlanta = 4;
        //    }
        //    else
        //    {
        //        siloAbasteciendoPlanta = 0;
        //    }
        //}

        //private void RndTiempoAbasteciendoPlanta()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        rndTiempoAbasteciendoPlanta = 0;
        //    }
        //    else if(siloAbasteciendoPlanta != 0 && vectorAnterior.siloAbasteciendoPlanta != siloAbasteciendoPlanta)
        //    {
        //        Random rnd = new Random();

        //        rndTiempoAbasteciendoPlanta = rnd.NextDouble();
        //    }
        //    else
        //    {
        //        rndTiempoAbasteciendoPlanta = 0;
        //    }

        //}

        //private double TiempoAbasteciendoPlanta(double tiempoAbasteciendoPlanta)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return 0;
        //    }
        //    else if(siloAbasteciendoPlanta != 0)
        //    {
        //        return tiempoAbasteciendoPlanta;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //private double ProximoFinAbasteciendoPlanta(double TiempoSilo1)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return double.PositiveInfinity;
        //    }
        //    else if(siloAbasteciendoPlanta != 0)
        //    {
        //        if(rndTiempoAbasteciendoPlanta != 0)
        //        {
        //            return reloj + TiempoSilo1;
        //        }
        //        else
        //        {
        //            return vectorAnterior.proximoFinAbasteciendoPlanta;
        //        }
        //    }
        //    else
        //    {
        //        return double.PositiveInfinity;
        //    }
        //}

        //#endregion

        //#region Cambio Silos

        //private void SobraTnCambioSilo()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        sobraTnCambioSilo = 0;
        //    }
        //    else if(ingresaASilo != 0)
        //    {
        //        sobraTnCambioSilo = ingresaASilo == 1 ? (contenidoTnSilo1 + tnCamion) > parametroCapacidadSilo ? contenidoTnSilo1 + tnCamion - parametroCapacidadSilo : 0 :
        //                            ingresaASilo == 2 ? (contenidoTnSilo2 + tnCamion) > parametroCapacidadSilo ? contenidoTnSilo2 + tnCamion - parametroCapacidadSilo : 0 :
        //                            ingresaASilo == 3 ? (contenidoTnSilo3 + tnCamion) > parametroCapacidadSilo ? contenidoTnSilo3 + tnCamion - parametroCapacidadSilo : 0 :
        //                            ingresaASilo == 4 ? (contenidoTnSilo4 + tnCamion) > parametroCapacidadSilo ? contenidoTnSilo4 + tnCamion - parametroCapacidadSilo : 0 : 0;
        //    }
        //    else
        //    {
        //        sobraTnCambioSilo = evento == 7 ? 0 : vectorAnterior.sobraTnCambioSilo; 
        //    }
        //}

        //private void SiloCambioSilo()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        siloCambioSilo = 0;
        //    }
        //    else if (sobraTnCambioSilo != 0)
        //    {
        //        siloCambioSilo = siloCambioSilo != vectorAnterior.siloCambioSilo ? ingresaASilo : vectorAnterior.siloCambioSilo;
        //    }
        //    else
        //    {
        //        siloCambioSilo = 0;
        //    }
        //}

        //private void CamionCambioSilo()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        camionCambioSilo = 0;
        //    }
        //    else if (siloCambioSilo != 0 && vectorAnterior.camionCambioSilo != 0)
        //    {
        //        camionCambioSilo = vectorAnterior.camionCambioSilo;
        //    }
        //    else if(siloCambioSilo != 0)
        //    {
        //        camionCambioSilo = contenidoTnSilo1 == parametroCapacidadSilo ? camionSilo1 :
        //                           contenidoTnSilo2 == parametroCapacidadSilo ? camionSilo2 :
        //                           contenidoTnSilo3 == parametroCapacidadSilo ? camionSilo3 :
        //                           contenidoTnSilo4 == parametroCapacidadSilo ? camionSilo4 : 0;
                                   
        //    }
        //    else
        //    {
        //        camionCambioSilo = 0;
        //    }
        //}

        //private void SiguienteSiloCambioSilo()
        //{
        //    if (vectorAnterior == null)
        //    {
        //        siguienteSiloCambioSilo = 0;
        //    }
        //    else if (siloCambioSilo != 0)
        //    {
        //        siguienteSiloCambioSilo = siloCambioSilo == 1 && contenidoTnSilo2 <= sobraTnCambioSilo ? 2 :
        //                                  siloCambioSilo == 2 && contenidoTnSilo3 <= sobraTnCambioSilo ? 3 :
        //                                  siloCambioSilo == 3 && contenidoTnSilo4 <= sobraTnCambioSilo ? 4 : 1;
        //    }
        //    else
        //    {
        //        siguienteSiloCambioSilo = 0;
        //    }
        //}

        //private double TiempoCambioSilo(double tiempoCambioSilo)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return 0;
        //    }
        //    else if (sobraTnCambioSilo != 0)
        //    {
        //        return tiempoCambioSilo;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //private double ProximoFinCambioSilo(double proxtiempoCambioSilo)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return double.PositiveInfinity;
        //    }
        //    else if (sobraTnCambioSilo != 0)
        //    {
        //        if (tiempoCambioSilo != 0)
        //        {
        //            return reloj + tiempoCambioSilo;
        //        }
        //        else
        //        {
        //            return vectorAnterior.proximoFinAbasteciendoPlanta;
        //        }
        //    }
        //    else
        //    {
        //        return double.PositiveInfinity;
        //    }
        //}
        //#endregion

        //#region Silos
        //private int EstadoSilo(int nroSilo, int estadoAnterior, int eventoSilo, int colaAnterior)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return 0;
        //    }
        //    else if(ingresaASilo == nroSilo || (proximoFinAbasteciendoPlanta != 0 && siloAbasteciendoPlanta == nroSilo))
        //    {
        //        return 1;
        //    }
        //    else if(evento != eventoSilo && evento != 6)
        //    {
        //        return estadoAnterior;
        //    }
        //    else if(evento == eventoSilo && colaAnterior > 0)
        //    {
        //        return 1;
        //    }
        //    else if(colaAnterior > 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //private double ContenidoTnSilo(int nroSilo, double contenidoTnSiloAnterior)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return 0;
        //    }
        //    else if(evento == 1 && ingresaASilo == nroSilo)
        //    {
        //        return (contenidoTnSiloAnterior + tnCamion) > parametroCapacidadSilo ? parametroCapacidadSilo : contenidoTnSiloAnterior + tnCamion;
        //    }
        //    else if(evento == 6 && vectorAnterior.siloAbasteciendoPlanta == nroSilo)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return contenidoTnSiloAnterior;
        //    }
        //}

        //private int CamionSilo(int estadoSilo, int camionAnterior, int eventoSilo, int colaAnterior, Queue<int> primeroEnCola)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return 0;
        //    }
        //    else if (estadoSilo == 0)
        //    {
        //        return 0;
        //    }
        //    else if ((evento == eventoSilo || vectorAnterior.evento == 6) && colaAnterior > 0)
        //    {
        //        return primeroEnCola.Peek();
        //    }
        //    else
        //    {
        //        return camionAnterior;
        //    }
        //}

        //private double TiempoSilo(double tiempoSilo, int camionSilo, int camionSiloAnterior)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return 0;
        //    }
        //    else if (camionSilo != camionSiloAnterior && camionSiloAnterior != 0)
        //    {
        //        return tiempoSilo;
        //    }
        //    return 0;
        //}

        //private double ProximoFinSilo(double tiempoSilo, int estadoSilo, double proxFinSiloAnterior)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return double.PositiveInfinity;
        //    }
        //     else
        //    {
        //        if (estadoSilo == 1)
        //        {
        //            if (tiempoSilo != 0)
        //            {
        //                return reloj + tiempoSilo;
        //            }
        //            else
        //            {
        //                return proxFinSiloAnterior;
        //            }
        //        }
        //        else
        //        {
        //            return double.PositiveInfinity;
        //        }
        //    }
        //}

        //private int ColaFinSilo(int nroSilo, int ingresaASilo, int estadoSilo, int colaAnterior)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return 0;
        //    }
        //    else if (ingresaASilo == nroSilo && estadoSilo == 1)
        //    {
        //        return colaAnterior + 1;
        //    }
        //    else if (evento == 6 && colaAnterior > 0)
        //    {
        //        return colaAnterior - 1;
        //    }
        //    else
        //    {
        //        return colaAnterior;
        //    }
        //}

        //private Queue<int>  ClientesEnColaSilo(Queue<int> clientesEnColaSilo, int colaSilo, int colaSiloAnterior, int camionEvento)
        //{
        //    if (vectorAnterior == null)
        //    {
        //        return new Queue<int>();
        //    }
        //    else if (colaSilo == colaSiloAnterior)
        //    {
        //        return clientesEnColaSilo;
        //    }
        //    else if (colaSilo > colaSiloAnterior)
        //    {
        //        clientesEnColaSilo.Enqueue(camionEvento);
        //        return clientesEnColaSilo;
        //    }
        //    else
        //    {
        //        clientesEnColaSilo.Dequeue();
        //        return clientesEnColaSilo;
        //    }
        //}
        //#endregion

    }
}

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

        //Playa
        public int estadoPlaya { get; set; }
        public int siloPlaya { get; set; }
        public int camionPlaya { get; set; }
        public double sobraTnPlaya { get; set; }
        public int siguienteSiloPlaya { get; set; }
        public double tiempoPlaya { get; set; }
        public double proximoFinPlaya { get; set; }
        public int colaPlaya { get; set; }
        public Queue<int> clientesEnColaPlaya { get; set; }

        //Silo 1
        public int estadoSilo1 { get; set; }
        public double contenidoTnSilo1 { get; set; }
        public int camionSilo1 { get; set; }

        //Silo 2
        public int estadoSilo2 { get; set; }
        public double contenidoTnSilo2 { get; set; }
        public int camionSilo2 { get; set; }

        //Silo 3
        public int estadoSilo3 { get; set; }
        public double contenidoTnSilo3 { get; set; }
        public int camionSilo3 { get; set; }

        //Silo 4
        public int estadoSilo4 { get; set; }
        public double contenidoTnSilo4 { get; set; }
        public int camionSilo4 { get; set; }


        public int parametroCapacidadSilo { get; set; }
        public double tiempoDescarga { get; set; }
        public double tiempoCambioSilo { get; set; }
        Random rnd { get; set; }

        public Vector()
        {

        }

        public Vector(int nroEvento,
            double tiempoEntreCamiones, double tiempoDescarga, Random rnd,int parametroCapacidadSilo = 20, double tiempoAbasteciendoPlanta = 0, double tiempoCambioSilo = 0, Vector vectorAnterior = null)
        {
            this.vectorAnterior = vectorAnterior;
            this.tiempoEntreCamiones = tiempoEntreCamiones;
            this.nroEvento = nroEvento;
            this.parametroCapacidadSilo = parametroCapacidadSilo;
            this.tiempoDescarga = tiempoDescarga;
            this.tiempoCambioSilo = tiempoCambioSilo;
            this.rnd = rnd;

            Reloj(); //0
            Evento(); //0
            Pedido();  //0

            ProxCamion(); //1
            this.tiempoEntreCamiones = tiempoEntreCamiones;
            ProximaLlegada();

            RndTnCamion();
            TnCamion();
            IngresaASilo();

            SiloAbasteciendoPlanta();
            RndTiempoAbasteciendoPlanta();
            this.tiempoAbasteciendoPlanta = TiempoAbasteciendoPlanta(tiempoAbasteciendoPlanta);
            this.proximoFinAbasteciendoPlanta = ProximoFinAbasteciendoPlanta(this.tiempoAbasteciendoPlanta);

            EstadoPlaya();
            CamionPlaya();
            SiloPlaya();
            SobraTnPlaya();
            SiguienteSiloPlaya();
            TiempoPlaya();
            ProximoFinPlaya();
            ColaPlaya();
            ClientesEnColaPlaya();

            estadoSilo1 = EstadoSilo(1);
            estadoSilo2 = EstadoSilo(2);
            estadoSilo3 = EstadoSilo(3);
            estadoSilo4 = EstadoSilo(4);

            if (vectorAnterior == null)
            {
                contenidoTnSilo1 = ContenidoTnSilo(1, 0);
                contenidoTnSilo2 = ContenidoTnSilo(2, 0);
                contenidoTnSilo3 = ContenidoTnSilo(3, 0);
                contenidoTnSilo4 = ContenidoTnSilo(4, 0);
            }
            else
            {
                contenidoTnSilo1 = ContenidoTnSilo(1, vectorAnterior.contenidoTnSilo1);
                contenidoTnSilo2 = ContenidoTnSilo(2, vectorAnterior.contenidoTnSilo2);
                contenidoTnSilo3 = ContenidoTnSilo(3, vectorAnterior.contenidoTnSilo3);
                contenidoTnSilo4 = ContenidoTnSilo(4, vectorAnterior.contenidoTnSilo4);
            }

            camionSilo1 = CamionSilo(1, estadoSilo1);
            camionSilo2 = CamionSilo(2, estadoSilo2);
            camionSilo3 = CamionSilo(3, estadoSilo3);
            camionSilo4 = CamionSilo(4, estadoSilo4);

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
                        Math.Min(vectorAnterior.proximoFinPlaya, vectorAnterior.proximoFinAbasteciendoPlanta
                        ));
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
                else if (reloj == vectorAnterior.proximoFinPlaya && vectorAnterior.sobraTnPlaya != 0 && 
                                        (vectorAnterior.evento == 2 || vectorAnterior.evento == 3 || vectorAnterior.evento == 4 || vectorAnterior.evento == 5))
                {
                    evento = 7;
                }
                else if (reloj == vectorAnterior.proximoFinPlaya && vectorAnterior.siloPlaya == 1)
                {
                    evento = 2;
                }
                else if (reloj == vectorAnterior.proximoFinPlaya && vectorAnterior.siloPlaya == 2)
                {
                    evento = 3;
                }
                else if (reloj == vectorAnterior.proximoFinPlaya && vectorAnterior.siloPlaya == 3)
                {
                    evento = 4;
                }
                else if (reloj == vectorAnterior.proximoFinPlaya && vectorAnterior.siloPlaya == 4)
                {
                    evento = 5;
                }
                else if (reloj == vectorAnterior.proximoFinAbasteciendoPlanta)
                {
                    evento = 6;
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
                    camion = vectorAnterior.camionPlaya;
                }
                else if (evento == 3)
                {
                    camion = vectorAnterior.camionPlaya;
                }
                else if (evento == 4)
                {
                    camion = vectorAnterior.camionPlaya;
                }
                else if (evento == 5)
                {
                    camion = vectorAnterior.camionPlaya;
                }
                else if (evento == 7)
                {
                    camion = vectorAnterior.camionPlaya;
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
            else if ((evento == 1 || evento == 2 || evento == 3 || evento == 4 || evento == 5) && (vectorAnterior.colaPlaya > 0 || nroEvento == 2 || vectorAnterior.estadoPlaya == 0))
            {
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
            else if (evento == 7)
            {
                tnCamion = vectorAnterior.sobraTnPlaya;
            }
            else if ((evento == 2 || evento == 3 || evento == 4 || evento == 5) && vectorAnterior.sobraTnPlaya != 0)
            {
                tnCamion = vectorAnterior.sobraTnPlaya;
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
            else if (evento == 7)
            {
                ingresaASilo = vectorAnterior.siguienteSiloPlaya;
            }
            else if (tnCamion != 0)
            {
                if (vectorAnterior.siguienteSiloPlaya != 0)
                {
                    ingresaASilo = vectorAnterior.siguienteSiloPlaya;
                }
                else if(vectorAnterior.ingresaASilo != 0) 
                {
                    if (vectorAnterior.ingresaASilo == 1)
                    {
                        ingresaASilo = vectorAnterior.contenidoTnSilo2 < parametroCapacidadSilo ? 2 : vectorAnterior.contenidoTnSilo3 < parametroCapacidadSilo ? 3 : vectorAnterior.contenidoTnSilo4 < parametroCapacidadSilo ? 4 : vectorAnterior.contenidoTnSilo1 < parametroCapacidadSilo ? 1 : 0;
                    }
                    else if (vectorAnterior.ingresaASilo == 2)
                    {
                        ingresaASilo = vectorAnterior.contenidoTnSilo3 < parametroCapacidadSilo ? 3 : vectorAnterior.contenidoTnSilo4 < parametroCapacidadSilo ? 4 : vectorAnterior.contenidoTnSilo2 < parametroCapacidadSilo ? 2 : vectorAnterior.contenidoTnSilo1 < parametroCapacidadSilo ? 1 : 0;
                    }
                    else if (vectorAnterior.ingresaASilo == 3)
                    {
                        ingresaASilo = contenidoTnSilo4 < parametroCapacidadSilo ? 4 : vectorAnterior.contenidoTnSilo3 < parametroCapacidadSilo ? 3 : vectorAnterior.contenidoTnSilo2 < parametroCapacidadSilo ? 2 : vectorAnterior.contenidoTnSilo1 < parametroCapacidadSilo ? 1 : 0;
                    }
                    else if (vectorAnterior.ingresaASilo == 4)
                    {
                        ingresaASilo = contenidoTnSilo1 < parametroCapacidadSilo ? 1 :vectorAnterior.contenidoTnSilo2 < parametroCapacidadSilo ? 2 : vectorAnterior.contenidoTnSilo3 < parametroCapacidadSilo ? 3 : vectorAnterior.contenidoTnSilo4 < parametroCapacidadSilo ? 4 : 0;
                    }
                    else
                    {
                        ingresaASilo = 0;
                    }
                }
                else
                {
                    ingresaASilo = vectorAnterior.contenidoTnSilo1 < parametroCapacidadSilo ? 1 : vectorAnterior.contenidoTnSilo2 < parametroCapacidadSilo ? 2 : vectorAnterior.contenidoTnSilo3 < parametroCapacidadSilo ? 3 : vectorAnterior.contenidoTnSilo4 < parametroCapacidadSilo ? 4 : 1;

                }

            }
            else if(vectorAnterior.colaPlaya > 0 || evento == 1 || evento == 7)
            {
                ingresaASilo = vectorAnterior.contenidoTnSilo1 < parametroCapacidadSilo ? 1 : vectorAnterior.contenidoTnSilo2 < parametroCapacidadSilo ? 2 : vectorAnterior.contenidoTnSilo3 < parametroCapacidadSilo ? 3 : vectorAnterior.contenidoTnSilo4 < parametroCapacidadSilo ? 4 : 1;
            }
            else
            {
                ingresaASilo = 0;
            }
        }
        #endregion

        #region Abastecimiento Planta
        private void SiloAbasteciendoPlanta()
        {
            if (vectorAnterior == null)
            {
                siloAbasteciendoPlanta = 0;
            }
            else if (vectorAnterior.siloAbasteciendoPlanta == 0)
            {
                if (vectorAnterior.estadoSilo1 == 0 && vectorAnterior.contenidoTnSilo1 == parametroCapacidadSilo)
                {
                    siloAbasteciendoPlanta = 1;
                }
                else if (vectorAnterior.estadoSilo2 == 0 && vectorAnterior.contenidoTnSilo2 == parametroCapacidadSilo)
                {
                    siloAbasteciendoPlanta = 2;
                }
                else if (vectorAnterior.estadoSilo3 == 0 && vectorAnterior.contenidoTnSilo3 == parametroCapacidadSilo)
                {
                    siloAbasteciendoPlanta = 3;
                }
                else if (vectorAnterior.estadoSilo4 == 0 && vectorAnterior.contenidoTnSilo4 == parametroCapacidadSilo)
                {
                    siloAbasteciendoPlanta = 4;
                }
            }
            else if(reloj != vectorAnterior.proximoFinAbasteciendoPlanta)
            {
                siloAbasteciendoPlanta = vectorAnterior.siloAbasteciendoPlanta;
            }
            else
            {
                siloAbasteciendoPlanta = 0;
            }
        }

        private void RndTiempoAbasteciendoPlanta()
        {
            if (vectorAnterior == null)
            {
                rndTiempoAbasteciendoPlanta = 0;
            }
            else if (siloAbasteciendoPlanta != 0 && vectorAnterior.siloAbasteciendoPlanta != siloAbasteciendoPlanta)
            {
                rndTiempoAbasteciendoPlanta = rnd.NextDouble();
            }
            else
            {
                rndTiempoAbasteciendoPlanta = 0;
            }

        }

        private double TiempoAbasteciendoPlanta(double tiempoAbasteciendoPlanta)
        {
            if (vectorAnterior == null)
            {
                return 0;
            }
            else if (siloAbasteciendoPlanta != 0)
            {
                return tiempoAbasteciendoPlanta;
            }
            else
            {
                return 0;
            }
        }

        private double ProximoFinAbasteciendoPlanta(double TiempoSilo1)
        {
            if (vectorAnterior == null)
            {
                return double.PositiveInfinity;
            }
            else if (siloAbasteciendoPlanta != 0)
            {
                if (rndTiempoAbasteciendoPlanta != 0)
                {
                    return reloj + TiempoSilo1;
                }
                else
                {
                    return vectorAnterior.proximoFinAbasteciendoPlanta;
                }
            }
            else
            {
                return double.PositiveInfinity;
            }
        }

        #endregion

        #region Silos
        private int EstadoSilo(int nroSilo)
        {
            if (vectorAnterior == null)
            {
                return 0;
            }
            else if (siloPlaya == nroSilo || siloAbasteciendoPlanta == nroSilo)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private double ContenidoTnSilo(int nroSilo, double contenidoTnSiloAnterior)
        {
            if (vectorAnterior == null)
            {
                return 0;
            }
            else if ((evento == 1 || evento == 2 || evento == 3 || evento == 4 || evento == 5) && siloPlaya == nroSilo && vectorAnterior.camionPlaya != camionPlaya)
            {
                return (contenidoTnSiloAnterior + tnCamion) > parametroCapacidadSilo ? parametroCapacidadSilo : contenidoTnSiloAnterior + tnCamion;
            }
            else if (evento == 7 && siloPlaya == nroSilo && vectorAnterior.siloPlaya != siloPlaya)
            {
                return sobraTnPlaya;
            }
            else if(evento == 6 && vectorAnterior.siloAbasteciendoPlanta == nroSilo)
            {
                return 0;
            }
            else
            {
                return contenidoTnSiloAnterior;
            }
        }

        private int CamionSilo(int nroSilo, int estadoSilo)
        {
            if (vectorAnterior == null)
            {
                return 0;
            }
            else if (estadoSilo == 0)
            {
                return 0;
            }
            else if (siloPlaya == nroSilo)
            {
                return camionPlaya;
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region Playa
        private void EstadoPlaya()
        {
            if (vectorAnterior == null)
            {
                estadoPlaya = 0;
            }
            else if (evento == 1 || evento == 7 || vectorAnterior.colaPlaya > 0 || vectorAnterior.siguienteSiloPlaya != 0)
            {
                estadoPlaya = 1;
            }
            else
            {
                estadoPlaya = 0;
            }
        }

        private void CamionPlaya()
        {
            if (vectorAnterior == null)
            {
                camionPlaya = 0;
            }
            else if (estadoPlaya == 1 && vectorAnterior.camionPlaya != camion && vectorAnterior.camionPlaya != 0)
            {
                camionPlaya = vectorAnterior.camionPlaya;
            }
            else if (vectorAnterior.estadoPlaya == 0 && (vectorAnterior.contenidoTnSilo1 < parametroCapacidadSilo || vectorAnterior.contenidoTnSilo2 < parametroCapacidadSilo ||
                                          vectorAnterior.contenidoTnSilo3 < parametroCapacidadSilo || vectorAnterior.contenidoTnSilo4 < parametroCapacidadSilo))
            {
                camionPlaya = camion;
            }
            else if ((evento == 7) && vectorAnterior.estadoPlaya == 1 && vectorAnterior.colaPlaya > 0)
            {
                camionPlaya = vectorAnterior.camionPlaya;
            }
            else if (((evento == 1 || evento == 2 || evento == 3 || evento == 4 || evento == 5) && estadoPlaya == 1 && vectorAnterior.colaPlaya > 0) && 
                                          (vectorAnterior.contenidoTnSilo1 < parametroCapacidadSilo || vectorAnterior.contenidoTnSilo2 < parametroCapacidadSilo ||
                                          vectorAnterior.contenidoTnSilo3 < parametroCapacidadSilo || vectorAnterior.contenidoTnSilo4 < parametroCapacidadSilo))
            {
                if (vectorAnterior.clientesEnColaPlaya.Count > 0)
                    camionPlaya = vectorAnterior.clientesEnColaPlaya.Peek();
                else
                {
                    Console.WriteLine("Dequeue: " + nroEvento);
                    camionPlaya = 0;
                }
            }
            else if (vectorAnterior.sobraTnPlaya != 0 && vectorAnterior.camionPlaya == camion && vectorAnterior.camionPlaya != 0)
            {
                camionPlaya = vectorAnterior.camion;
            }
            else
            {
                Console.WriteLine("else: " + nroEvento);
                camionPlaya = 0;
            }
        }

        
        private void SiloPlaya()
        {
            if (vectorAnterior == null)
            {
                siloPlaya = 0;
            }
            else if (estadoPlaya == 1 && (vectorAnterior.contenidoTnSilo1 < parametroCapacidadSilo || vectorAnterior.contenidoTnSilo2 < parametroCapacidadSilo ||
                                          vectorAnterior.contenidoTnSilo3 < parametroCapacidadSilo || vectorAnterior.contenidoTnSilo4 < parametroCapacidadSilo))
            {
                if (camion == vectorAnterior.camionPlaya)
                {
                    if (evento == 1)
                    {
                        siloPlaya = ingresaASilo;
                    }
                    else if (evento == 7)
                    {
                        siloPlaya = vectorAnterior.siguienteSiloPlaya;
                    }
                    else
                    {
                        siloPlaya = ingresaASilo;
                    }
                }
                else if (vectorAnterior.siloPlaya == 0)
                {
                    siloPlaya = ingresaASilo;
                }
                else
                {
                    siloPlaya = vectorAnterior.siloPlaya;
                }
            }
            else
            {
                siloPlaya = 0;
            }

        }

        private void SobraTnPlaya()
        {
            if (vectorAnterior == null)
            {
                sobraTnPlaya = 0;
            }
            else if (estadoPlaya == 1)
            {
                if ((camionPlaya != vectorAnterior.camionPlaya))
                {
                    if (evento == 1)
                    {
                        if ((vectorAnterior.contenidoTnSilo1 + tnCamion) > parametroCapacidadSilo && siloPlaya == 1)
                            sobraTnPlaya = vectorAnterior.contenidoTnSilo1 + tnCamion - parametroCapacidadSilo;

                        else if ((vectorAnterior.contenidoTnSilo2 + tnCamion) > parametroCapacidadSilo && siloPlaya == 2)
                            sobraTnPlaya = vectorAnterior.contenidoTnSilo2 + tnCamion - parametroCapacidadSilo;

                        else if ((vectorAnterior.contenidoTnSilo3 + tnCamion) > parametroCapacidadSilo && siloPlaya == 3)
                            sobraTnPlaya = vectorAnterior.contenidoTnSilo3 + tnCamion - parametroCapacidadSilo;

                        else if ((vectorAnterior.contenidoTnSilo4 + tnCamion) > parametroCapacidadSilo && siloPlaya == 4)
                            sobraTnPlaya = vectorAnterior.contenidoTnSilo4 + tnCamion - parametroCapacidadSilo;

                        else
                        {
                            sobraTnPlaya = 0;
                        }
                    }
                    else
                    {
                        sobraTnPlaya = vectorAnterior.sobraTnPlaya;
                    }
                }
                else if (camionPlaya == vectorAnterior.camionPlaya && vectorAnterior.sobraTnPlaya != 0)
                {
                    if (evento == 2 || evento == 3 || evento == 4 || evento == 5)
                    {
                        sobraTnPlaya = vectorAnterior.sobraTnPlaya;
                    }
                }
            }
            else
            {
                sobraTnPlaya = 0;
            }

        }

        private void SiguienteSiloPlaya()
        {
            if (vectorAnterior == null)
            {
                siguienteSiloPlaya = 0;
            }
            else if (sobraTnPlaya != 0)
            {
                if ((vectorAnterior.contenidoTnSilo1 + tnCamion) >= parametroCapacidadSilo && siloPlaya == 1)
                    siguienteSiloPlaya = 2;

                else if ((vectorAnterior.contenidoTnSilo2 + tnCamion) >= parametroCapacidadSilo && siloPlaya == 2)
                    siguienteSiloPlaya = 3;

                else if ((vectorAnterior.contenidoTnSilo3 + tnCamion) >= parametroCapacidadSilo && siloPlaya == 3)
                    siguienteSiloPlaya = 4;

                else if ((vectorAnterior.contenidoTnSilo4 + tnCamion) >= parametroCapacidadSilo && siloPlaya == 4)
                    siguienteSiloPlaya = 1;
                else
                {
                    siguienteSiloPlaya = vectorAnterior.siguienteSiloPlaya;
                }
            }
            else 
            {
                siguienteSiloPlaya = 0;
            }
        }

        private void TiempoPlaya()
        {
            if (vectorAnterior == null)
            {
                tiempoPlaya = 0;
            }
            else if (estadoPlaya == 1)
            {
                if (camionPlaya != vectorAnterior.camionPlaya && camionPlaya != 0)
                {
                    tiempoPlaya = tiempoDescarga;
                }
                else if((evento == 2 || evento == 3 || evento == 4 || evento == 5) && vectorAnterior.sobraTnPlaya != 0)
                {
                    tiempoPlaya = tiempoCambioSilo;
                }
                else if (evento == 7)
                {
                    tiempoPlaya = tiempoPlaya = tiempoDescarga;
                }
                else
                {
                    tiempoPlaya = 0;
                }
            }
            else
            {
                tiempoPlaya = 0;
            }
        }

        private void ProximoFinPlaya()
        {
            if (vectorAnterior == null)
            {
                proximoFinPlaya = double.PositiveInfinity;
            }
            else if (siloPlaya != 0)
            {
                if(siloPlaya != vectorAnterior.siloPlaya || camionPlaya != vectorAnterior.camionPlaya)
                {
                    proximoFinPlaya = tiempoPlaya + reloj;
                } 
                else if (evento == 7)
                {
                    proximoFinPlaya = tiempoPlaya + reloj;
                }
                else
                {
                    proximoFinPlaya = vectorAnterior.proximoFinPlaya;
                }
            }
            else
            {
                proximoFinPlaya = double.PositiveInfinity;
            }
            
        }

        private void ColaPlaya()
        {
            if (vectorAnterior == null)
            {
                colaPlaya = 0;
            }
            else if ((vectorAnterior.estadoPlaya == 1 && (evento == 1 )) ||  (estadoPlaya != 0 && (evento == 1 || evento == 7) && vectorAnterior.contenidoTnSilo1 == parametroCapacidadSilo && vectorAnterior.contenidoTnSilo2 == parametroCapacidadSilo &&
                                          vectorAnterior.contenidoTnSilo3 == parametroCapacidadSilo && vectorAnterior.contenidoTnSilo4 == parametroCapacidadSilo))
            {
                colaPlaya = vectorAnterior.colaPlaya + 1;
            }
            else if ((evento == 2 || evento == 3 || evento == 4 || evento == 5) && vectorAnterior.colaPlaya > 0)
            {
                colaPlaya = vectorAnterior.colaPlaya - 1;
            }
            else
            {
                colaPlaya = vectorAnterior.colaPlaya;
            }

        }

        private void ClientesEnColaPlaya()
        {
            if (vectorAnterior == null)
            {
                clientesEnColaPlaya = new Queue<int>();
            }
            else if (colaPlaya == vectorAnterior.colaPlaya)
            {
                clientesEnColaPlaya = vectorAnterior.clientesEnColaPlaya;
            }
            else if (colaPlaya > vectorAnterior.colaPlaya)
            {
                vectorAnterior.clientesEnColaPlaya.Enqueue(camion);

                clientesEnColaPlaya = vectorAnterior.clientesEnColaPlaya;
            }
            else if (colaPlaya < vectorAnterior.colaPlaya)
            {
                if(vectorAnterior.clientesEnColaPlaya.Count > 0)
                    vectorAnterior.clientesEnColaPlaya.Dequeue();

                clientesEnColaPlaya = vectorAnterior.clientesEnColaPlaya;
            }
            else
            {
                clientesEnColaPlaya = vectorAnterior.clientesEnColaPlaya;
            }
        }
        #endregion

    }
}

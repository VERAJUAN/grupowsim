using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULACION_TP1
{
    public class EcuacionDiferencial
    {
        //RUNGE KUTTA
        public double tn { get; set; }
        public double rk_x1 { get; set; }
        public double rk_k1 { get; set; }
        public double rk_k2 { get; set; }
        public double rk_k3 { get; set; }
        public double rk_k4 { get; set; }
        public double rk_x2 { get; set; }
        public double rk_l1 { get; set; }
        public double rk_l2 { get; set; }
        public double rk_l3 { get; set; }
        public double rk_l4 { get; set; }

        //EULER
        public double eu_x1 { get; set; }
        public double dx1 { get; set; }
        public double dx2 { get; set; }

        //HELPER
        public bool posiblePico { get; set; }

        public EcuacionDiferencial()
        {

        }

        public EcuacionDiferencial(int metodo, double h, EcuacionDiferencial ecuacionAnterior, double x1 = 0)
        {
            if (ecuacionAnterior == null) //SIGNIFICA QUE ES LA PRIMERA FILA
            {
                tn = 0;

                if (metodo == 0)
                {
                    //RUNGE KUTTA
                    rk_x1 = x1;
                }
                else
                {
                    //EULER
                    eu_x1 = x1;
                }
            }
            else
            {
                tn = ecuacionAnterior.tn + h;

                if (metodo == 0)
                {
                    //RUNGE KUTTA
                    rk_x1 = ecuacionAnterior.rk_x1 + (ecuacionAnterior.rk_k1 + 2 * ecuacionAnterior.rk_k2 + 2 * ecuacionAnterior.rk_k3 + ecuacionAnterior.rk_k4) / 6;
                }
                else
                {
                    //EULER
                    eu_x1 = ecuacionAnterior.eu_x1 + h * ecuacionAnterior.dx1;
                }

            }

            if (metodo == 0)
            {
                //RUNGE KUTTA
                rk_k1 = h * (-5 * Math.Pow(tn, 2) + 2 * rk_x1 - 200);

                rk_k2 = h * (-5 * Math.Pow(tn+0.5*h, 2) + 2 * (rk_x1 + 0.5* rk_k1) - 200);

                rk_k3 = h * (-5 * Math.Pow(tn+0.5*h, 2) + 2 * (rk_x1 + 0.5* rk_k2) - 200);

                rk_k4 = h * (-5 * Math.Pow(tn+h, 2) + 2 * (rk_x1 + rk_k3) - 200);
            }
            else
            {
                //EULER
                dx1 = -5 * Math.Pow(tn,2) + 2 * eu_x1 - 200;
            }



        }

    }
}

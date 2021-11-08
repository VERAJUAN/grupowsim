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
        double tn { get; set; }
        double rk_x1 { get; set; }
        double rk_k1 { get; set; }
        double rk_k2 { get; set; }
        double rk_k3 { get; set; }
        double rk_k4 { get; set; }
        double rk_x2 { get; set; }
        double rk_l1 { get; set; }
        double rk_l2 { get; set; }
        double rk_l3 { get; set; }
        double rk_l4 { get; set; }

        //EULER
        double x1 { get; set; }
        double dx1 { get; set; }
        double dx2 { get; set; }


        public EcuacionDiferencial()
        {

        }

        public EcuacionDiferencial(double a, double b, double c, double h, EcuacionDiferencial ecuacionAnterior, double x1 = 0, double x2 = 0)
        {
            if(ecuacionAnterior == null) //SIGNIFICA QUE ES LA PRIMERA FILA
            {
                tn = 0;

                //RUNGE KUTTA
                rk_x1 = x1;
                rk_x2 = x2;
            }
            else
            {
                tn = ecuacionAnterior.tn + h;

                //RUNGE KUTTA
                rk_x1 = ecuacionAnterior.rk_x1 + (ecuacionAnterior.rk_k1 + 2* ecuacionAnterior.rk_k2 + 2 * ecuacionAnterior.rk_k3 + ecuacionAnterior.rk_k4) / 6;
                rk_x2 = ecuacionAnterior.rk_x2 + (ecuacionAnterior.rk_l1 + 2* ecuacionAnterior.rk_l2 + 2 * ecuacionAnterior.rk_l3 + ecuacionAnterior.rk_l4) / 6;
            }

            //RUNGE KUTTA
            //rk_l1 = h * (Math.Exp())


        }

    }
}

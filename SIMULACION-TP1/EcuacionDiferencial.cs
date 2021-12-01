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

        public EcuacionDiferencial(int metodo, double h, EcuacionDiferencial ecuacionAnterior, double a, double x1 = 0, double x2 = 0, double b = 10, double c = 5)
        {
            if (ecuacionAnterior == null) //SIGNIFICA QUE ES LA PRIMERA FILA
            {
                tn = 0;

                if (metodo == 0)
                {
                    //RUNGE KUTTA
                    rk_x1 = x1;
                    rk_x2 = x2;
                }
                else
                {
                    //EULER
                    eu_x1 = x1;
                    dx1 = x2;
                }
            }
            else
            {
                tn = ecuacionAnterior.tn + h;

                if (metodo == 0)
                {
                    //RUNGE KUTTA
                    rk_x1 = ecuacionAnterior.rk_x1 + (ecuacionAnterior.rk_k1 + 2 * ecuacionAnterior.rk_k2 + 2 * ecuacionAnterior.rk_k3 + ecuacionAnterior.rk_k4) / 6;
                    rk_x2 = ecuacionAnterior.rk_x2 + (ecuacionAnterior.rk_l1 + 2 * ecuacionAnterior.rk_l2 + 2 * ecuacionAnterior.rk_l3 + ecuacionAnterior.rk_l4) / 6;
                }
                else
                {
                    //EULER
                    eu_x1 = ecuacionAnterior.eu_x1 + h * ecuacionAnterior.dx1;
                    dx1 = ecuacionAnterior.dx1 + h * ecuacionAnterior.dx2;
                }

            }

            #region TP7
            //if (metodo == 0)
            //{
            //    //RUNGE KUTTA 4 * (x2)^2 + 6 * x1 + 8 * t
            //    rk_l1 = h * ((4 * Math.Pow(rk_x2, 2)) + (6 * rk_x1) + (8 * tn));
            //    rk_k1 = h * rk_x2;

            //    rk_l2 = h * ((4 * Math.Pow((rk_x2 + 0.5 * rk_l1), 2)) + (6 * (rk_x1 + 0.5 * rk_k1)) + (8 * (tn + 0.5 * h)));
            //    rk_k2 = h * (rk_x2 + 0.5 * rk_l1);

            //    rk_l3 = h * ((4 * Math.Pow((rk_x2 + 0.5 * rk_l2), 2)) + (6 * (rk_x1 + 0.5 * rk_k2)) + (8 * (tn + 0.5 * h)));
            //    rk_k3 = h * (rk_x2 + 0.5 * rk_l2);

            //    rk_l4 = h * ((4 * Math.Pow((rk_x2 + rk_l3), 2)) + (6 * (rk_x1 + rk_k3)) + (8 * (tn + h)));
            //    rk_k4 = h * (rk_x2 + 0.5 * rk_l3);


            //}
            //else
            //{
            //    //EULER
            //    dx2 = h * ((4 * Math.Pow(dx1, 2)) + (6 * eu_x1) + (8 * tn));
            //}
            #endregion

            #region TP6
            if (metodo == 0)
            {
                //RUNGE KUTTA
                rk_l1 = h * ((Math.Exp(-c * tn)) - (a * rk_x2) - (b * rk_x1));
                rk_k1 = h * rk_x2;

                rk_l2 = h * ((Math.Exp(-c * (tn + 0.5 * h))) - (a * (rk_x2 + 0.5 * rk_l1)) - (b * (rk_x1 + 0.5 * rk_k1)));
                rk_k2 = h * (rk_x2 + 0.5 * rk_l1);

                rk_l3 = h * ((Math.Exp(-c * (tn + 0.5 * h))) - (a * (rk_x2 + 0.5 * rk_l2)) - (b * (rk_x1 + 0.5 * rk_k2)));
                rk_k3 = h * (rk_x2 + 0.5 * rk_l2);

                rk_l4 = h * ((Math.Exp(-c * (tn + h))) - (a * (rk_x2 + rk_l3)) - (b * (rk_x1 + rk_k3)));
                rk_k4 = h * (rk_x2 + 0.5 * rk_l3);


            }
            else
            {
                //EULER
                dx2 = h * ((Math.Exp(-c * tn)) - (a * dx1) - (b * eu_x1));
            }

            #endregion


        }

    }
}

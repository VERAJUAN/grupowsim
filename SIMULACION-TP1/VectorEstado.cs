using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULACION_TP1
{
    public class VectorEstado
    {
        public decimal Tmax(decimal t1, decimal t2, decimal t3)
        {
            return t1 > t2 && t1 > t3 ? t1 : (t2 > t3 ? t2 : t3);
        }

        public decimal Tmin(decimal t1, decimal t2, decimal t3)
        {
            return t1 < t2 && t1 < t3 ? t1 : (t2 < t3 ? t2 : t3);
        }

        public decimal diasA4deMas(decimal t4, decimal tmax, decimal t1)
        {
            return t4 - (tmax - t1);
        }

        public decimal sumaA1aA4(decimal tmax, decimal diasA4deMas)
        {
            return tmax + (diasA4deMas > 0 ? diasA4deMas : 0);
        }

        public decimal maxT2yT4(decimal t2, decimal t4)
        {
            return t2 > t4 ? t2 : t4;
        }

        public decimal diasA5deMas(decimal maxT2yT4, decimal t5, decimal sumaA1aA4)
        {
            return maxT2yT4 < sumaA1aA4 ? (maxT2yT4 + t5 - sumaA1aA4) : t5;
        }

        public decimal duracionEnsamble(decimal sumaA1aA4, decimal diasA5deMas)
        {
            return sumaA1aA4 + diasA5deMas;
        }
    }
}

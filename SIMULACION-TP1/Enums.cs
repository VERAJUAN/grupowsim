using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULACION_TP1
{
    public enum Estado
    {
        Libre = 0,
        Ocupado = 1
    }

    public enum Evento
    {
        Inicio = 0,
        LlegaPedido = 1,
        FinQA = 2,
        FinAA = 3,
        FinL1 = 4,
        FinL2 = 5,
        FinS = 6,
        FinPA = 7,
    }
}

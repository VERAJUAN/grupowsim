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
        FinA1 = 2,
        FinA2 = 3,
        FinA3 = 4,
        FinA4 = 5,
        FinA5 = 6,
        FinJornada = 7,
        FinHora = 8
    }
}

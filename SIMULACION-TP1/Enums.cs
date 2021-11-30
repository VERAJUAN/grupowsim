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
        LlegaCamion = 1,
        FinDescarcaSilo1 = 2,
        FinDescarcaSilo2 = 3,
        FinDescarcaSilo3 = 4,
        FinDescarcaSilo4 = 5,
        FinAbastPlantSilo = 6,
        TuboAspCambioSilo = 7
    }
}

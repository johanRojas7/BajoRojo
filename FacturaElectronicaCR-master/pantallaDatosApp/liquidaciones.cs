using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pantallaDatosApp
{
  public  class liquidaciones
    {
        public string embarcacion { get; set; }
        public string detalle { get; set; }
        public string procedencia { get; set; }
        public string monto { get; set; }


        public liquidaciones(string pEmbarcacion, string pDetalle,string pProcedencia,string pMonto)
        {
            embarcacion = pEmbarcacion;
            detalle = pDetalle;
            procedencia = pProcedencia;
            monto = pMonto;
            
        }
    }
}

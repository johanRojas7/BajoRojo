using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pantallaDatosApp
{
   public class pesas
    {
        //Comit prueba
        public string embarcacion { get; set; }
        public string tipoPescado{ get; set; }
        public string pesa { get; set; }

        public pesas(string pEmbarcacion, string pDetalle, string pPesa)
        {
            embarcacion = pEmbarcacion;
            tipoPescado = pDetalle;
            pesa = pPesa;
        

        }

    }
}

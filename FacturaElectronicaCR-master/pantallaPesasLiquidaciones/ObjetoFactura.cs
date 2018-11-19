using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pantallaPesasLiquidaciones
{
   public class ObjetoFactura
    {
        public string pez { get; set; }

        public string pesa { get; set; }
        public string precio { get; set; }
        public string totalLinea { get; set; }


        public ObjetoFactura(string _pez, string _pesa,string _precio, string _totalLinea)
        {
            pez = _pez;
            pesa = _pesa;
            precio = _precio;
            totalLinea = _totalLinea;


        }
    }
}

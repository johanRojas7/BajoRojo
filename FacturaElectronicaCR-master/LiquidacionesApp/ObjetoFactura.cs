using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidacionesApp
{
    public class ObjetoFactura
    {
        public string procedencia { get; set; }

        public string descripcion { get; set; }
        public string monto { get; set; }



        public ObjetoFactura(string _procedencia, string _descripcion, string _monto)
        {
            procedencia = _procedencia;
            descripcion = _descripcion;
            monto = _monto;



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pantallaPesasLiquidaciones
{
    public class objeto
    {

        public string pez { get; set; }
       
        public double monto { get; set; }


        public objeto(string _pez, double _monto)
        {
            pez = _pez;
            monto = _monto;
           

        }
    }
}

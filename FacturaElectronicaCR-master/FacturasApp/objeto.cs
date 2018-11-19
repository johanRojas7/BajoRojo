using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasApp
{
    public class objeto
    {
        public string embarca { get; set; }
     

        public double monto { get; set; }


        public objeto(string embarcacion,double _monto)
        {
            embarca = embarcacion;
          
            monto = _monto;


        }
    }
}

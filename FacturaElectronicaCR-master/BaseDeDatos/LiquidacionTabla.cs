using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeDatos
{
   public class LiquidacionTabla
    {


        public void insertar(string embarca, string detalle, string monto, string proce) {
            liquidacion nuevaLiquidacion = new liquidacion();
            nuevaLiquidacion.detalle = detalle;
            nuevaLiquidacion.embarcacion = embarca;
            nuevaLiquidacion.monto = monto;
            nuevaLiquidacion.procedencia = proce;
            DataClassDataContext dbCtx = new DataClassDataContext();
            dbCtx.liquidacion.InsertOnSubmit(nuevaLiquidacion);

            try
            {
                dbCtx.SubmitChanges();
         
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error a la hora de insertar la liquidacion");
            }


        }

    
        public void eliminar(string embarcacion) {
            //eliminar
            DataClassDataContext dbCtx = new DataClassDataContext();
            var getData = (

                from x in dbCtx.liquidacion
                where x.embarcacion == embarcacion
                select x

                ).ToList().Last();

            dbCtx.liquidacion.DeleteOnSubmit(getData);

            try
            {
                dbCtx.SubmitChanges();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error");

            }

            

        }


        public void mostrar(string embarcacion) {
            DataClassDataContext dbCtx = new DataClassDataContext();


            var getData = (

                from x in dbCtx.liquidacion
                where x.embarcacion== embarcacion
               
                select x

               

                ).ToList();

            foreach (var x in getData) {
                



            }

            

          


           
            


        }
       

    }
}

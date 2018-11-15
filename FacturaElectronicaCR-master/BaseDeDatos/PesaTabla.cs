using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeDatos
{
   public class PesaTabla
    {
       

        public void insertar(string embarca, string tipoPescado, string pesas)
        {
           
            pesa nuevaPesa = new pesa();

           

            nuevaPesa.embarcacion = embarca;
            nuevaPesa.tipoPescado = tipoPescado;
            nuevaPesa.pesa1= pesas;
            DataClassDataContext dbCtx = new DataClassDataContext();
            dbCtx.pesa.InsertOnSubmit(nuevaPesa);

            try
            {
                dbCtx.SubmitChanges();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error a la hora de insertar");
                MessageBox.Show("El error es: " + ex);
            }


        }

        public void eliminar(string embarcacion)
        {
            //eliminar
            DataClassDataContext dbCtx = new DataClassDataContext();
            var getData = (

                from x in dbCtx.pesa
                where x.embarcacion == embarcacion
                select x

                ).ToList().Last();

            dbCtx.pesa.DeleteOnSubmit(getData);

            try
            {
                dbCtx.SubmitChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error");

            }



        }

        public List<pesa> mostrar(string embarcacion)
        {
            DataClassDataContext dbCtx = new DataClassDataContext();


            var getData = (

                from x in dbCtx.pesa
                where x.embarcacion  == embarcacion 

                select x



                ).ToList();





            return getData;
        }


    }
}

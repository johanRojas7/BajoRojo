using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDeDatos
{
   public class PesaCalculadaTabla
    {

        public void insertar(string embarca, string tipoPescado, string totalPesa, string fecha, string montoTotalPesa, string precio , int id)
        {
            pesaCalculada nuevaPesa = new pesaCalculada();

            nuevaPesa.embarcacion = embarca;
            nuevaPesa.tipoPescado = tipoPescado;
            nuevaPesa.ToatlPesa = totalPesa;
            nuevaPesa.fecha = fecha;
            nuevaPesa.montoTotalPesa = montoTotalPesa;
            nuevaPesa.precio = precio;
            nuevaPesa.id = id;
            DataClassDataContext dbCtx = new DataClassDataContext();
            dbCtx.pesaCalculada.InsertOnSubmit(nuevaPesa);

            try
            {
                dbCtx.SubmitChanges();

            }
            catch (Exception ex)
            {

                MessageBox.Show("ocurrio un error");
            }


        }

        public void mostrar(string embarcacion)
        {
            DataClassDataContext dbCtx = new DataClassDataContext();


            var getData = (

                from x in dbCtx.pesaCalculada
                where x.embarcacion == embarcacion

                select x



                ).ToList();

            foreach (var x in getData)
            {



            }




        }

    }
}

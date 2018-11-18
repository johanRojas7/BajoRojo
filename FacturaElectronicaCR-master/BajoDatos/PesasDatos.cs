using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BajoDatos
{
  public  class PesasDatos
    {

        private SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-RSSABEQP; Initial Catalog = BajoRojo; Integrated Security = true");
        private DataSet ds;

      

        public DataTable Buscar(string embarcacion)
        {
            List<String> Users = new List<String>();
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Pesas where Embarcacion like '%{0}%'", embarcacion), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public bool Insertar(string Embarcacion, string TipoPescado, string Pesa)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into Pesas values ('{0}', '{1}', '{2}')", new string[] { Embarcacion, TipoPescado, Pesa }), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool Eliminar(string embarcacion)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("delete from Pesas where Embarcacion like '%{0}%'", embarcacion), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

     
    }
}

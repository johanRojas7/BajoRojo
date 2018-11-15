using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BajoDatos
{
   public  class FacturasDatos
    {


        private SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-RSSABEQP; Initial Catalog = BajoRojo; Integrated Security = true");
        private DataSet ds;



        public DataTable Buscar(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from faturas where embarcacion like '%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public bool Insertar(string fecha, string embarcacion, string leyenda)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into faturas values ('{1}', '{2}','{3}')", new string[] { "",fecha, embarcacion,leyenda }), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
    }
}

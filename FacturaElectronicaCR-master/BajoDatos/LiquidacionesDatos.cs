using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BajoDatos
{
  public  class LiquidacionesDatos
    {
        private SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-RSSABEQP; Initial Catalog = BajoRojo; Integrated Security = true");
        private DataSet ds;



        public DataTable Buscar(string nombre, string fecha)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Liquidaciones where (embarcacion like '%{0}%') AND ( fecha like '%{1}%')", new string[] { nombre, fecha }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        

        public DataTable BuscarRegistro(string embarcacion)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from liquidacionRegistro where embarcacion like '%{0}%' ", embarcacion), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }




        public bool Insertar(string Embarcacion, string fecha,string Detalle, string Procedencia, string Monto)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into Liquidaciones values ('{0}', '{1}', '{2}','{3}','{4}')", new string[] { Embarcacion,fecha ,Detalle, Procedencia,Monto }), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool InsertarRegistro(string Embarcacion, string fecha)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into liquidacionRegistro values ('{0}', '{1}')", new string[] { Embarcacion, fecha}), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool InsertarAbono(string Embarcacion, string fecha, string monto)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into abonos values ('{0}', '{1}','{2}')", new string[] { Embarcacion, fecha,monto }), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }


        public DataTable BuscarAbono(string nombre, string fecha)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from abonos where (embarcacion like '%{0}%') AND ( fecha like '%{1}%')", new string[] { nombre, fecha }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
    }
}

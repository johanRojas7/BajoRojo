﻿using System;
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

        public DataTable BuscarConsecutivo(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Consecutivos where embarcacion like '%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public bool ActualizarConsecutivo(string embarcacion, string numero)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE into Consecutivos values ('{1}', '{2}')", new string[] { "", embarcacion,numero }), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public DataTable Buscar(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from estadistica where embarcacion like '%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable BuscarTodos()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from estadistica"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public bool Insertar(string embarcacion, string pez, string pesa)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into estadistica values ('{1}', '{2}','{3}')", new string[] { "", embarcacion,pez,pesa }), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool Eliminar()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("delete from estadistica"), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
    }
}

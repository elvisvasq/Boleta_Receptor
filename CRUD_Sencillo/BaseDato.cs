using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Sencillo
{
    public class BaseDato
    {
        private SqlConnection con;
        private SqlDataAdapter da;
        static DataTable dt;
        private SqlCommand cmd;

        public void Conectar()
        {
            con = new SqlConnection("server=192.168.0.5;user=CARGAROLES;pwd=w2003ejf103;initial catalog=EJFDES");
            con.Open();
        }

        public void Desconectar()
        {
            con.Close();
        }

        public void CrearComando(string consulta)
        {
            cmd = new SqlCommand(consulta, con);
        }

        public void AsignarParametro(string param, SqlDbType tipo, object val)
        {
            cmd.Parameters.Add(param, tipo).Value = val;
        }

        public int EjecutarConsulta()
        {
            return cmd.ExecuteNonQuery();
        }

        public DataTable EjecutarDataTable()
        {
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}

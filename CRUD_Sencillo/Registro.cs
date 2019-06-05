using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CRUD_Sencillo
{
    public class Registro
    {
        bool ejecuto;
        BaseDato bd = new BaseDato();
        public DataTable Consultar()
        {
            DataTable dt;
            bd.Conectar();
            bd.CrearComando("exec SP_EncargoReceptor");
            dt = bd.EjecutarDataTable();
            bd.Desconectar();
            return dt;
        }
        public bool InsertEncargo(string mandante, string rut,  string rol )
        {
            bd.Conectar();
            bd.CrearComando("INSERT INTO DigitacionEncargoReceptor(Idmandante,Rut,Rol) VALUES (@Idmandante, @Rut, @Rol)");

            bd.AsignarParametro("@Rut", SqlDbType.VarChar, rut);
            bd.AsignarParametro("@Idmandante", SqlDbType.VarChar, mandante);
            bd.AsignarParametro("@Rol", SqlDbType.VarChar, rol);
            if (bd.EjecutarConsulta() > 0)
            {
                ejecuto = true;
            }
            else
            {
                ejecuto = false;
            }
            return ejecuto;
        }
        public DataTable Consultar_Mandantes()
        {
            DataTable dt;
            bd.Conectar();
            bd.CrearComando("select distinct (NombreMandante) FROM mandante where idmandante in(181,216) order by NombreMandante asc");
           
            dt = bd.EjecutarDataTable();
            bd.Desconectar();
            return dt;
        }
        public DataTable Consultar_idMandantes(string mandante)
        {
            DataTable dt;
            bd.Conectar();
            bd.CrearComando("select idmandante FROM mandante WHERE VIGENTE = 1 and nombremandante = @mandante ");
            bd.AsignarParametro("@mandante", SqlDbType.VarChar, mandante);
            dt = bd.EjecutarDataTable();
            bd.Desconectar();
            return dt;
        }
        public DataTable Consultar_idResponsable(string responsable)
        {
            DataTable dt;
            bd.Conectar();
            bd.CrearComando("select idResponsable FROM Responsable WHERE NombreResponsable = @responsable ");
            bd.AsignarParametro("@responsable", SqlDbType.VarChar, responsable);
            dt = bd.EjecutarDataTable();
            bd.Desconectar();
            return dt;
        }
        public DataTable Consultar_idEstadoJ(string estadoJ)
        {
            DataTable dt;
            bd.Conectar();
            bd.CrearComando("select IdEstado from ManEstadoGestion WHERE Descripcion = @estadoJ ");
            bd.AsignarParametro("@estadoJ", SqlDbType.VarChar, estadoJ);
            dt = bd.EjecutarDataTable();
            bd.Desconectar();
            return dt;
        }
        public DataTable Consultar_Responsable()
        {
            DataTable dt;
            bd.Conectar();
            bd.CrearComando("select NombreResponsable FROM Responsable order by NombreResponsable asc");

            dt = bd.EjecutarDataTable();
            bd.Desconectar();
            return dt;
        }
        public DataTable Consultar_EstadoJudicial()
        {
            DataTable dt;
            bd.Conectar();
            bd.CrearComando("select Descripcion from ManEstadoGestion where Etapa = 'Judicial' order by Descripcion asc");

            dt = bd.EjecutarDataTable();
            bd.Desconectar();
            return dt;
        }
        public DataTable Consultar_ArbolGestion()
        {
            DataTable dt;
            bd.Conectar();
            bd.CrearComando("SELECT dbo.Ext_Excusa.Descripcion AS Excusa FROM(dbo.Ext_Excusa INNER JOIN dbo.Ext_LugContacto ON(dbo.Ext_Excusa.idLugar = dbo.Ext_LugContacto.cod) AND(dbo.Ext_Excusa.idMandante = dbo.Ext_LugContacto.idMandante)) INNER JOIN dbo.Ext_Contacto ON(dbo.Ext_Excusa.idContacto = dbo.Ext_Contacto.cod) AND(dbo.Ext_Excusa.idMandante = dbo.Ext_Contacto.idMandante) GROUP BY dbo.Ext_Excusa.idMandante, dbo.Ext_LugContacto.cod, dbo.Ext_LugContacto.Descripcion, dbo.Ext_Contacto.cod, dbo.Ext_Contacto.Descripcion, dbo.Ext_Excusa.cod, dbo.Ext_Excusa.Descripcion, dbo.Ext_Excusa.estado HAVING((dbo.Ext_LugContacto.Descripcion = 'JUDICIAL') AND(dbo.Ext_Excusa.estado = 'V') AND dbo.Ext_Excusa.idMandante = 181); ");
            dt = bd.EjecutarDataTable();
            bd.Desconectar();
            return dt;
        }
        public DataTable Consultar_idArbolJ(string idarbol,string idman)
        {
            DataTable dt;
            bd.Conectar();
            bd.CrearComando("select cod FROM Ext_Excusa WHERE idMandante = @idman and Descripcion = @idarbol ");
            bd.AsignarParametro("@idarbol", SqlDbType.VarChar, idarbol);
            bd.AsignarParametro("@idman", SqlDbType.VarChar, idman);
            dt = bd.EjecutarDataTable();
            bd.Desconectar();
            return dt;
        }
        public bool InsertObsMasiva(string IDMandante, string trut, string tpagare, string IDEstadoJ, string IDResponsable, string IDArbolJ, string ObsJ)
        {
            bd.Conectar();
            bd.CrearComando("INSERT INTO CargaMasivaObservaciones(IDMandante, trut, tpagare, IDEstadoJ, IDResponsable, IDArbolJ, ObsJ) VALUES (@IDMandante, @trut, @tpagare, @IDEstadoJ, @IDResponsable, @IDArbolJ, @ObsJ)");

            bd.AsignarParametro("@IDMandante", SqlDbType.VarChar, IDMandante);
            bd.AsignarParametro("@trut", SqlDbType.VarChar, trut);
            bd.AsignarParametro("@tpagare", SqlDbType.VarChar, tpagare);
            bd.AsignarParametro("@IDEstadoJ", SqlDbType.VarChar, IDEstadoJ);
            bd.AsignarParametro("@IDResponsable", SqlDbType.VarChar, IDResponsable);
            bd.AsignarParametro("@IDArbolJ", SqlDbType.VarChar, IDArbolJ);
            bd.AsignarParametro("@ObsJ", SqlDbType.VarChar, ObsJ);
            if (bd.EjecutarConsulta() > 0)
            {
                ejecuto = true;
            }
            else
            {
                ejecuto = false;
            }
            return ejecuto;
        }
    }

}
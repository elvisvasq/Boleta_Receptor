using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Data.OleDb;
using System.IO;



namespace CRUD_Sencillo
{
    public partial class Default : System.Web.UI.Page
    {
        
        Registro reg = new Registro();
        string html = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cbxusuario.DataSource = reg.Consultar_responsable();
                cbxusuario.DataTextField = "NombreResponsable";
                cbxusuario.DataValueField = "NombreResponsable";
                cbxusuario.DataBind();
                cbxusuario.Items.Insert(0, "Seleccione Responsable");

            }

            //if (!IsPostBack)
            //{ 
            //cbxtribunales.DataSource = reg.Consultar_tribunales();
            //cbxtribunales.DataTextField = "tribunales";
            //cbxtribunales.DataValueField = "tribunales";
            //cbxtribunales.DataBind();
            //cbxtribunales.Items.Insert(0, "");

            //}


            if (!IsPostBack)
            {
                cbxmandante.DataSource = reg.Consultar_Mandantes();
                cbxmandante.DataTextField = "NombreMandante";
                cbxmandante.DataValueField = "NombreMandante";
                cbxmandante.DataBind();
                cbxmandante.Items.Insert(0, "Seleccione Mandante");

            }

            if (!IsPostBack)
            {
                btncargarxls.Visible = false;
            }


                //if (!IsPostBack)
                //{
                //    cbxreceptor.DataSource = reg.Consultar_Receptores();
                //    cbxreceptor.DataTextField = "NombreReceptor";
                //    cbxreceptor.DataValueField = "NombreReceptor";
                //    cbxreceptor.DataBind();
                //    cbxreceptor.Items.Insert(0, "Seleccione Receptor");

                //}


            }

        protected void BtnGuardar_Click(object sender, EventArgs e)

        {

            if (reg.Consultar(TxtNombre.Text).Rows.Count > 0)
            {
                GridView2.DataSource = reg.Consultar(TxtNombre.Text);
                GridView2.DataBind();
           
            }

            else
            {
                LblGuardar.Text = "No se encuentran registros para el rut consultado";
            }
            

        }



        //protected void  cbxmandante_TextChanged(object sender, EventArgs e)
        //    {
        //        grcbxpagare.DataSource = reg.Consultar_Pagare(TxtNombre.Text.Replace(".",""), cbxmandante.SelectedItem.Text);
        //        cbxpagare.DataTextField = "folio 1";
        //        cbxpagare.DataValueField = "folio 1";
        //        cbxpagare.DataBind();
        //        cbxpagare.Items.Insert(0, "Seleccione Pagare");

        //    }

        protected void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }



        public void btncargarxls_Click(object sender, EventArgs e)
        {
            string rut0;
            string rut1;
            string rut2;
            string rut3;
            string rut4;
            string rut5;
            string rut6;
            string rut7;
            string rut8;
            string rut9;
            

            if (Path.GetFileName(FileUpload1.FileName) == "")
                {
                LblGuardar.Text = "No ha seleccionado ningun archivo excel";
            }

            else
            { 

            string path = Path.GetFileName(FileUpload1.FileName);
            path = path.Replace(" ", "");
            FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
            String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select Rut,nombre, Rol,Operacion,Cuantia,Tribunal,Diligencia,fecha_dilig,monto_dilig  from [Hoja1$] order by rut", mycon);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            mycon.Close();

            int Conteo = 0;
            while(GridView1.Rows.Count > Conteo)
            {
                if (Conteo == 0)
                {
                  rut0 = GridView1.Rows[Conteo].Cells[0].Text;
                  Label0.Text = rut0;
                }

                if (Conteo == 1)
                {
                    rut1 = GridView1.Rows[Conteo].Cells[0].Text;
                    Label1.Text = rut1;
                }

                if (Conteo == 2)
                {
                    rut2 = GridView1.Rows[Conteo].Cells[0].Text;
                    Label2.Text = rut2;
                }
                if (Conteo == 3)
                {
                    rut3 = GridView1.Rows[Conteo].Cells[0].Text;
                    Label3.Text = rut3;
                }
                if (Conteo == 4)
                {
                    rut4 = GridView1.Rows[Conteo].Cells[0].Text;
                    Label4.Text = rut4;
                }
                if (Conteo == 5)
                {
                    rut5 = GridView1.Rows[Conteo].Cells[0].Text;
                    Label5.Text = rut5;
                }
                if (Conteo == 6)
                {
                    rut6 = GridView1.Rows[Conteo].Cells[0].Text;
                    Label6.Text = rut6;
                }
                if (Conteo == 7)
                {
                    rut7 = GridView1.Rows[Conteo].Cells[0].Text;
                    Label7.Text = rut7;
                }
                if (Conteo == 8)
                {
                    rut8 = GridView1.Rows[Conteo].Cells[0].Text;
                    Label8.Text = rut8;
                }

                if (Conteo == 9)
                {
                    rut9 = GridView1.Rows[Conteo].Cells[0].Text;
                    Label9.Text = rut9;
                }


                Conteo = Conteo + 1; 
            }

            if (reg.Consultarvarios(Label0.Text, Label1.Text, Label2.Text, Label3.Text, Label4.Text, Label5.Text, Label6.Text, Label7.Text, Label8.Text, Label9.Text, Labelidm.Text).Rows.Count > 0)
            {
                GridView2.DataSource = reg.Consultarvarios(Label0.Text, Label1.Text, Label2.Text, Label3.Text, Label4.Text, Label5.Text, Label6.Text, Label7.Text, Label8.Text, Label9.Text, Labelidm.Text);
                GridView2.DataBind();

              
                
            }

            else

            {
                LblGuardar.Text = "No se encuentran registros para los ruts consultados";
            }


           





                //Label1.Text = Conteo.ToString();

                //rut1 = GridView1.Rows[0].Cells[0].Text;
                //rut2 = GridView1.Rows[1].Cells[0].Text;
                //rut3 = GridView1.Rows[2].Cells[0].Text;
                //rut4 = GridView1.Rows[3].Cells[0].Text;
                //rut5 = GridView1.Rows[4].Cells[0].Text;
                //rut6 = GridView1.Rows[5].Cells[0].Text;
                //rut7 = GridView1.Rows[6].Cells[0].Text;
                //rut8 = GridView1.Rows[7].Cells[0].Text;











                //    html += "<table class='table' style='color:black'>";
                //    html += "<thead ><tr style='font-weight: bolder' class='table-primary'><td>RUT</td><td>Nombre Mandante</td><td>Folio</td><td>Nombre Deudor</td><td>Fecha ultimo Abono</td><td>Monto ult Abono</td><td>Saldo_Inicial</td><td>Pagos</td><td>Saldo Deuda</td><td>Rol</td><td>Oficina</td><td>Descripcion</td></tr></thead>";
                //    html += "<tbody>";
                //    foreach (DataRow dbRow in reg.Consultarvarios(rut1, rut2, rut3, rut4, rut5, rut6, rut7, rut8).Rows)
                //    {
                //        html += "<tr>";
                //        html += "<thead class='thead - dark'>";
                //        html += "<td class='table-light' scope='col' style='text-align:left'>" + dbRow["Rut"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col'>" + dbRow["NombreMandante"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col'>" + dbRow["pagare"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col'>" + dbRow["NombreGirador"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col' style='text-align:left '>" + dbRow["Fecha_Ultimo_Pago"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col' style='text-align:left '>" + dbRow["Monto_ultimo_abono"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col'>" + dbRow["Saldo_Inicial"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col'>" + dbRow["Total_Pagado"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col'>" + dbRow["Total_Adeudado"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col'>" + dbRow["rol"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col'>" + dbRow["Facultad"].ToString() + "</td>";
                //        html += "<td class='table-light' scope='col'>" + dbRow["Descripcion"].ToString() + "</td>";
                //        html += "</tbody>";
                //        html += "</tr>";
                //    }
                //    html += "</tbody>";
                //    html += "</table>";
                //}
                //else
                //{
                //    html += "<table class='table table-striped table-bordered'>";
                //    html += "<tr><td>No hay registros</td></tr>";
                //    html += "</table>";
                //}

                //    //Literal1.Text = html;
            }
        }



       

  
        protected void BtnGrabar_Click(object sender, EventArgs e)
        {


            //for get record
            //protected void btnGetRecord_Click(object sender, EventArgs e)
               
                    string str = string.Empty;
                    string strname = string.Empty;
                    foreach (GridViewRow gvrow in GridView1.Rows)
                    {
                        System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox)gvrow.FindControl("chbxprocesar");
                        if (chk != null & chk.Checked)
                        {

                            reg.insertboleta(gvrow.Cells[0].Text, Labelidm.Text,cbxcargo.SelectedItem.Text,cbxusuario.SelectedItem.Text, gvrow.Cells[6].Text, gvrow.Cells[8].Text, gvrow.Cells[7].Text, gvrow.Cells[5].Text, gvrow.Cells[2].Text);


                            //str += "<b>Rut : </b>" + gvrow.Cells[0].Text + ", ";
                            //str += "<b>Deudor : </b>" + gvrow.Cells[1].Text + ", ";
                            //str += "<b>Operacion : </b>" + gvrow.Cells[2].Text + ", ";
                            //str += "<b>Cuantia : </b>" + gvrow.Cells[3].Text + " , ";
                            //str += "<b>Rol : </b>" + gvrow.Cells[5].Text + " , ";
                            //str += "<b>Diligencia : </b>" + gvrow.Cells[6].Text + " , ";
                            //str += "<b>Fecha_dilig : </b>" + gvrow.Cells[7].Text + " , ";
                            //str += "<b>Monto_dilig : </b>" + gvrow.Cells[8].Text;
                            //str += "<br />";
                        }
                    }
                            LblGuardar.ForeColor = Color.Red;
                            LblGuardar.Text = "Gestion grabada exitosamente!";
                

}

        protected void cbxmandante_TextChanged(object sender, EventArgs e)
        {
            Labelidm.Text  = reg.Consultar_idMandantes(cbxmandante.SelectedItem.Text).Rows[0]["idmandante"].ToString();
            
            btncargarxls.Visible = true;
        }


        protected void onclick_ingrol(object sender, EventArgs e)
        {


        }




















        //protected void cbxtext_pagare(object sender, EventArgs e)

        //{
        //    cbxrol.DataSource = reg.Consultar_rol(TxtNombre.Text.Replace(".", ""),cbxpagare.SelectedItem.Text ,cbxmandante.SelectedItem.Text);
        //    cbxrol.DataTextField = "rol";
        //    cbxrol.DataValueField = "rol";
        //    cbxrol.DataBind();
        //    cbxrol.Items.Insert(0, "Seleccione Rol");

        //}
        /* protected void BtnEliminar_Click(object sender, EventArgs e)
         {
             if (CmbRegistro.Text != "")
             {
                 if (reg.Eliminar(CmbRegistro.Text))
                 {
                     LblEliminar.Text = "El registro se elimino correctamente";
                     CmbRegistro.DataSource = reg.Consultar();
                     CmbRegistro.DataTextField = "FOLIO_PAGARE";
                     CmbRegistro.DataValueField = "FOLIO_PAGARE";
                     CmbRegistro.DataBind();
                 }
                 else
                 {
                     LblEliminar.Text = "El registro no se pudo eliminar";
                 }
             }
         }*/





    }
}
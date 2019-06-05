using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace CRUD_Sencillo
{
    public partial class EncargoR : System.Web.UI.Page
    {
        Registro reg = new Registro();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                FileUpload1.Visible = false;
                btncargarxls.Visible = false;
                btnGuardarExcel.Visible = false;
                //btnCargaMasiva.Visible = false;
            }

            if (!IsPostBack)
            {
                cbxResponsable.DataSource = reg.Consultar_Responsable();
                cbxResponsable.DataTextField = "NombreResponsable";
                cbxResponsable.DataValueField = "NombreResponsable";
                cbxResponsable.DataBind();
                cbxResponsable.Items.Insert(0, "Seleccione Responsable");
            }


            if (!IsPostBack)
            {
                cbxEstadoJudicial.DataSource = reg.Consultar_EstadoJudicial();
                cbxEstadoJudicial.DataTextField = "Descripcion";
                cbxEstadoJudicial.DataValueField = "Descripcion";
                cbxEstadoJudicial.DataBind();
                cbxEstadoJudicial.Items.Insert(0, "Seleccione Estado Judicial");
            }
            if (!IsPostBack)
            {
                cbxArbolGes.DataSource = reg.Consultar_ArbolGestion();
                cbxArbolGes.DataTextField = "Excusa";
                cbxArbolGes.DataValueField = "Excusa";
                cbxArbolGes.DataBind();
                cbxArbolGes.Items.Insert(0, "Seleccione El Arbol de la Gestion");
            }
            if (!IsPostBack)
            {
                RBNo.Checked = true;
            }
             
        }
        public void btnCargaExcel_Click(object sender, EventArgs e)
        {
            
            string path = Path.GetFileName(FileUpload1.FileName);
            if (path.Length < 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Seleccionar Archivo')", true);
            }
            else
            {

                path = path.Replace(" ", "");
                FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
                String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
                OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
                mycon.Open();
                OleDbCommand cmd = new OleDbCommand("select * from [Hoja1$]", mycon);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                mycon.Close();
                GridView1.Visible = true;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    string trut = row.Cells[0].Text;
                    string trol = row.Cells[1].Text;
                    reg.InsertEncargo(Labelidm.Text, trut, trol);
                }
                GridView2.DataSource = reg.Consultar();
                GridView2.DataBind();

                if (GridView2.Rows.Count > 1)
                {
                    GridView1.Visible = false;
                    btnGuardarExcel.Visible = true;
                    FileUpload1.Visible = false;
                    btncargarxls.Visible = false;
                    cbxmandante.SelectedIndex = 0;
                    btncargamasiva.Visible = true;
                    btncargarxls.Visible = false;
                    btnNewConsulta.Visible = true;
                    cbxmandante.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sin Datos Para Mostrar')", true);
                    GridView1.Visible = false;
                    btnGuardarExcel.Visible = false;
                    FileUpload1.Visible = false;
                    btncargarxls.Visible = false;
                    cbxmandante.SelectedIndex = 0;
                    Response.Redirect(Request.RawUrl, true);

                }
            }
        }
        protected void cbxmandante_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileUpload1.Visible = true;
            btncargarxls.Visible = true;
            Labelidm.Text = reg.Consultar_idMandantes(cbxmandante.SelectedItem.Text).Rows[0]["idmandante"].ToString();
            lblMandante.Text = cbxmandante.SelectedItem.Text;
            GridView2.DataSource = null;
            GridView2.DataBind();
            btnGuardarExcel.Visible = false;
            btncargamasiva.Visible = false;
            btnNewConsulta.Visible = false;
        }
        protected void btnGuardarExcel_Click1(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        private void ExportGridToExcel()
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachmant;filename={0}", "excel.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView2.AllowPaging = false;
            GridView2.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            Response.Redirect(Request.RawUrl, true);
        }        
        protected void RBSi_CheckedChanged(object sender, EventArgs e)

        {
            if (RBNo.Checked)
            {
                cbxEstadoJudicial.Visible = false;
                lblEstadoJ.Visible = false;
            }
            if (RBSi.Checked)
            {
                cbxEstadoJudicial.Visible = true;
                lblEstadoJ.Visible = true;
            }

        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
                                 
            if (GridView2.Rows.Count > 1)
            {
                if (cbxResponsable.SelectedItem.Value == "Seleccione Responsable")
                {
                    lblError.Visible = true;
                    lblError.Attributes.Add("style", "Color:red;");
                    lblError.Style["font-weight"] = "bold";
                    lblError.Text = "Completar el nombre del Responsable";
                }
                else
                {
                    lblError.Visible = false;
                }
                if (cbxEstadoJudicial.SelectedItem.Value == "Seleccione Estado Judicial" & RBSi.Checked == true)
                {
                    lblError3.Visible = true;
                    lblError3.Attributes.Add("style", "Color:red;");
                    lblError3.Style["font-weight"] = "bold";
                    lblError3.Text = "Completar el Estado Judicial";
                }
                else
                {
                    lblError3.Visible = false;
                }
                if (cbxArbolGes.SelectedItem.Value == "Seleccione El Arbol de la Gestion")
                {
                    lblError4.Visible = true;
                    lblError4.Attributes.Add("style", "Color:red;");
                    lblError4.Style["font-weight"] = "bold";
                    lblError4.Text = "Completar el Arbol de la Gestion";
                }
                else
                {
                    lblError4.Visible = false;
                }
                if (this.TextareaObs.Text.Equals(""))
                {
                    lblError2.Visible = true;
                    lblError2.Attributes.Add("style", "Color:red;");
                    lblError2.Style["font-weight"] = "bold";
                    lblError2.Text = "Completar Observaciones";
                }
                else
                {
                    lblError2.Visible = false;
                }



                foreach (GridViewRow row in GridView2.Rows)
                {
                    //campos de la gridview
                    string trut = row.Cells[0].Text;
                    string tpagare = row.Cells[1].Text;
                    string IDMandante = Labelidm.ToString();
                    string IDResponsable = LabelidR.ToString();
                    string IDArbolJ = LabelIdArbol.ToString();
                    string ObsJ = TextareaObs.ToString();



                    if (RBSi.Checked)
                    {
                        string IDEstadoJ = LabelIdEstadoJ.ToString();
                        reg.InsertObsMasiva(IDMandante, trut, tpagare, IDEstadoJ, IDResponsable, IDArbolJ, ObsJ);
                    }
                    else
                    {
                        string IDEstadoJ = row.Cells[2].Text;
                        reg.InsertObsMasiva(IDMandante, trut, tpagare, IDEstadoJ, IDResponsable, IDArbolJ, ObsJ);
                    }
                }


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sin Datos Para Mostrar')", true);
            }

        }
        protected void cbxResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
                LabelidR.Text = reg.Consultar_idResponsable(cbxResponsable.SelectedItem.Text).Rows[0]["idResponsable"].ToString();
        }
        protected void cbxArbolGes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = Server.HtmlEncode(Labelidm.Text);
            LabelIdArbol.Text = reg.Consultar_idArbolJ(cbxArbolGes.SelectedItem.Text, Label1.Text).Rows[0]["cod"].ToString();
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            btnPopUp_ModalPopupExtender.Hide();
        }
        protected void btnNewConsulta_Click(object sender, EventArgs e)
        {
            cbxmandante.Visible = true;
            lblMandante.Text = "";
            btncargamasiva.Visible = false;
            btnGuardarExcel.Visible = false;
            GridView2.Visible = false;
            btnNewConsulta.Visible = false;
        }
        protected void cbxEstadoJudicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!IsPostBack)
                LabelIdEstadoJ.Text = reg.Consultar_idEstadoJ(cbxEstadoJudicial.SelectedItem.Text).Rows[0]["IdEstado"].ToString();
        }
    }
}


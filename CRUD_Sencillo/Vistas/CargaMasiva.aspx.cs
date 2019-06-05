using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRUD_Sencillo.Vistas
{
    public partial class CargaMasiva : System.Web.UI.Page
    {
        Registro reg = new Registro();

        protected void Page_Load(object sender, EventArgs e)
        {

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
            // RBNo.Checked = true;
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




            GridVieworg.DataBind();

            if (GridVieworg.Rows.Count > 1)
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


                
                foreach (GridViewRow row in GridVieworg.Rows) ;

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sin Datos Para Mostrar')", true);
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Redirect("~/EncargoR.aspx", true);
            Response.End();
        }

        protected void cbxResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LabelidR.Text = reg.Consultar_idResponsable(cbxResponsable.SelectedItem.Text).Rows[0]["idResponsable"].ToString();
        }

        protected void cbxArbolGes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

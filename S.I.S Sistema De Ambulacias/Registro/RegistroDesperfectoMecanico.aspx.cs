using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibSIS;
using System.Configuration;  

namespace S.I.S_Sistema_De_Ambulacias.Registro
{
    public partial class RegistroDesperfectoMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            ObjSIS.DesperfectoMecanico ObjDesperfectoMecanico = new ObjSIS.DesperfectoMecanico();

        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjDesperfectoMecanico.IDMedioTransporte = Convert.ToInt16(TxBoxIDMedioTrasporte.Text);
            ObjDesperfectoMecanico.Fecha = TxBoxFecha.Text;
            ObjDesperfectoMecanico.Descripcion= TxBoxDescripcion.Text;

            string strError1 = ObjDesperfectoMecanico.InsertarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();

        }
        private void cargar()
        {
            datatablesSimple.DataSource = ObjDesperfectoMecanico.VerificarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
        protected void datatablesSimple_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar();
            }
        }

        protected void datatablesSimple_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void datatablesSimple_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ObjDesperfectoMecanico.IDDesperfectoMecanico = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjDesperfectoMecanico.EliminarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();
        }

        protected void datatablesSimple_RowEditing(object sender, GridViewEditEventArgs e)
        {
            datatablesSimple.EditIndex = e.NewEditIndex;
            cargar();
        }

        protected void datatablesSimple_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = datatablesSimple.Rows[e.RowIndex];
            ObjDesperfectoMecanico.IDDesperfectoMecanico = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjDesperfectoMecanico.IDMedioTransporte = Convert.ToInt32((fila.FindControl("txtIDMedioTransporte") as TextBox).Text);
            ObjDesperfectoMecanico.Fecha = (Convert.ToDateTime((fila.FindControl("txtFecha") as TextBox).Text).Date).ToString();
            ObjDesperfectoMecanico.Descripcion = (fila.FindControl("txtDescripcion") as TextBox).Text;

            //ACTUALIZAR
            ObjDesperfectoMecanico.ActualizarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }
    }
}
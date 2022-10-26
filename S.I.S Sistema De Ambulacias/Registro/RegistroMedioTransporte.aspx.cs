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
    public partial class RegistroMedioTrasporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInsertarClienteDireccion_Click(object sender, EventArgs e)
        {

        }

            ObjSIS.MedioTransporte ObjMedioTransporte = new ObjSIS.MedioTransporte();
        protected void BtnInsertarMedioTransporte_Click(object sender, EventArgs e)
        {
            ObjMedioTransporte.TipoCombustible = TxBoxTipoCombustible.Text;
            ObjMedioTransporte.TipoTransporte = TxBoxTipoTransporte.Text;
            ObjMedioTransporte.idChofer = Convert.ToInt32(TxBoxIDChofer.Text);
            string strError1 = ObjMedioTransporte.InsertarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();

        }
        private void cargar()
        {
            datatablesSimple.DataSource = ObjMedioTransporte.VerificarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjMedioTransporte.IDMedioTransporte = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjMedioTransporte.EliminarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjMedioTransporte.IDMedioTransporte = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjMedioTransporte.TipoCombustible = (fila.FindControl("txtTipoCombustible") as TextBox).Text;
            ObjMedioTransporte.TipoTransporte = (fila.FindControl("txtTipoTransporte") as TextBox).Text;
            ObjMedioTransporte.idChofer = Convert.ToInt32((fila.FindControl("txtidChofer") as TextBox).Text);

            //ACTUALIZAR
            ObjMedioTransporte.ActualizarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }
    }
}
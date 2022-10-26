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
    public partial class RegistroTraslado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TxBoxEstatus_TextChanged(object sender, EventArgs e)
        {
        }
        private void cargar()
        {
            datatablesSimple.DataSource = ObjTraslado.VerificarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
        ObjSIS.Traslado ObjTraslado = new ObjSIS.Traslado();
        protected void BtnInsertarTraslado_Click(object sender, EventArgs e)
        {
            ObjTraslado.FechaProgramada= TxBoxFechaProgramada.Text;
            ObjTraslado.FechaRealizado = TxBoxFechaRealizado.Text;
            ObjTraslado.Costo = Convert.ToSingle(TxBoxCosto.Text);
            ObjTraslado.idMedioTransporte = Convert.ToInt32(TxBoxIDMedioTransporte.Text);
            ObjTraslado.idClienteDireccion = Convert.ToInt32(TxBoxIDClienteDireccion.Text);
            ObjTraslado.Estatus = Convert.ToInt32(TxBoxEstatus.Text);
            string strError1 = ObjTraslado.InsertarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);


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
            ObjTraslado.IDTraslado = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjTraslado.EliminarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjTraslado.IDTraslado = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjTraslado.FechaProgramada= (fila.FindControl("txtFechaProgramada") as TextBox).Text;
            ObjTraslado.FechaRealizado = (fila.FindControl("txtFechaRealizado") as TextBox).Text;
            ObjTraslado.Costo = Convert.ToSingle( (fila.FindControl("txtCosto") as TextBox).Text);
            ObjTraslado.idMedioTransporte =Convert.ToInt32( (fila.FindControl("txtidMedioTransporte") as TextBox).Text);
            ObjTraslado.idClienteDireccion = Convert.ToInt32((fila.FindControl("txtidClienteDireccion") as TextBox).Text);
            ObjTraslado.Estatus = Convert.ToInt32((fila.FindControl("txtEstatus") as TextBox).Text);

            //ACTUALIZAR
            ObjTraslado.ActualizarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }
    }
}
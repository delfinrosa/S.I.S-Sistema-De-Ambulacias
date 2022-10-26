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
    public partial class RegistroClienteDirecciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            ObjSIS.ClienteDirecciones ObjClienteDireccion = new ObjSIS.ClienteDirecciones();

        protected void BtnInsertarClienteDireccion_Click(object sender, EventArgs e)
        {
            ObjClienteDireccion.IDClienteDirecciones = Convert.ToInt32(TxBoxID.Text);
            ObjClienteDireccion.idCliente = Convert.ToInt32(TxBoxIDCliente.Text) ;
            ObjClienteDireccion.idDireccion = Convert.ToInt32(TxBoxIDDireccion.Text);
            string strError1 = ObjClienteDireccion.InsertarClienteDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();

        }
        private void cargar()
        {
            datatablesSimple.DataSource = ObjClienteDireccion.VerificarClienteDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjClienteDireccion.IDClienteDirecciones = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjClienteDireccion.EliminarClienteDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjClienteDireccion.IDClienteDirecciones = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjClienteDireccion.idCliente = Convert.ToInt32((fila.FindControl("txtIdCliente") as TextBox).Text);
            ObjClienteDireccion.idDireccion = Convert.ToInt32((fila.FindControl("txtIdDireccion") as TextBox).Text);

            //ACTUALIZAR
            ObjClienteDireccion.ActualizarClienteDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }
    }
}
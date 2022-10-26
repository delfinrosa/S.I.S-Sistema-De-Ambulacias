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
    public partial class RegistroDirreccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void cargar()
        {
            datatablesSimple.DataSource = ObjDireccion.VerificarDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
        ObjSIS.Direcciones ObjDireccion= new ObjSIS.Direcciones();
        protected void BtnInsertarDireccion_Click(object sender, EventArgs e)
        {
            ObjDireccion.Direccion = TxBoxDireccion.Text;
            ObjDireccion.CodigoPostal = TxBoxCodigoPostal.Text;
            string strError1 = ObjDireccion.InsertarDireccion(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();

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
            ObjDireccion.IDDireccion = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjDireccion.EliminarDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjDireccion.IDDireccion = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjDireccion.Direccion = (fila.FindControl("txtDireccion") as TextBox).Text;
            ObjDireccion.CodigoPostal = (fila.FindControl("txtCodigoPostal") as TextBox).Text;

            //ACTUALIZAR
            ObjDireccion.ActualizarDireccion(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }
    }
}
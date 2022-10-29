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
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void cargar()
        {
            datatablesSimple.DataSource = ObjCliente.VerificarCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
             ObjSIS.Cliente ObjCliente= new ObjSIS.Cliente();
        ObjSIS.Direcciones ObjDirecciones = new ObjSIS.Direcciones();
        ObjSIS.ClienteDirecciones ObjClienteDirecciones = new ObjSIS.ClienteDirecciones();

        protected void BtnInsertarCliente_Click(object sender, EventArgs e)
        {

            ObjCliente.Nombre = TxBoxNombre.Text;
            ObjCliente.ApellidoPaterno = TxBoxApellidoPaterno.Text;
            ObjCliente.ApellidoMaterno = TxBoxApellidoMaterno.Text;
            ObjCliente.Telefono = TxBoxTelefono.Text;
            string strError1 = ObjCliente.InsertarCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjDirecciones.Direccion = TxBoxDireccion.Text;
            ObjDirecciones.CodigoPostal = TxBoxCodigoPostal.Text;
            string strError2 = ObjDirecciones.InsertarDireccion(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            string strError3 = ObjClienteDirecciones.InsertarULTIMAClienteDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

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
            ObjCliente.IDCliente = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjCliente.EliminarCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjCliente.IDCliente = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjCliente.Nombre = (fila.FindControl("txtNombre") as TextBox).Text;
            ObjCliente.ApellidoPaterno = (fila.FindControl("txtApellidoPaterno") as TextBox).Text;
            ObjCliente.ApellidoMaterno = (fila.FindControl("txtApellidoMaterno") as TextBox).Text;
            ObjCliente.Telefono = (fila.FindControl("txtTelefono") as TextBox).Text;

            ObjDirecciones.IDDireccion = Convert.ToInt32((fila.FindControl("txtIDDIR") as TextBox).Text);

            ObjDirecciones.Direccion = (fila.FindControl("txtDireccion") as TextBox).Text;
            ObjDirecciones.CodigoPostal = (fila.FindControl("txtCodigoPostal") as TextBox).Text;

            //ACTUALIZAR
            ObjDirecciones.ActualizarDireccion(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

            ObjCliente.ActualizarCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }
    }
}
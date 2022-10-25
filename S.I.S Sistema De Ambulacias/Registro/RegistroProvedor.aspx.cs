using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibSIS;
using System.Configuration;
using System.Data;
namespace S.I.S_Sistema_De_Ambulacias.Reportes
{
    public partial class ReportesProvedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            cargar();
            }
        }

        ObjSIS.Proveedor ObjProveedor = new ObjSIS.Proveedor();
        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {

            ObjProveedor.razonSocial = TxBoxRazonSocial.Text;
            ObjProveedor.Telefono = TxBoxTelefono.Text;
            ObjProveedor.email = TxBoxEmail.Text;
            ObjProveedor.sitioWeb = TxBoxSitioWeb.Text;
            string strError1 = ObjProveedor.InsertarProvedor(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }

    
        protected void seleccionar(object sender, EventArgs e)
        {
            GridViewRow row = datatablesSimple.SelectedRow;
            Label1.Text = row.Cells[0].Text;
        }

      
        private void cargar(){
            datatablesSimple.DataSource = ObjProveedor.VerificarProveedor(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();        
        }
        protected void datatablesSimple_Load(object sender, EventArgs e)
        {
            
        }

        protected void datatablesSimple_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            datatablesSimple.EditIndex = -1;
            cargar();

        }

        protected void datatablesSimple_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ObjProveedor.IDProvedor = Convert.ToInt32( datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjProveedor.EliminarProveedor(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjProveedor.IDProvedor = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjProveedor.razonSocial = (fila.FindControl("txtrazonSocial") as TextBox).Text;
            ObjProveedor.Telefono = (fila.FindControl("txtTelefono") as TextBox).Text;
            ObjProveedor.email = (fila.FindControl("txtemail") as TextBox).Text;
            ObjProveedor.sitioWeb = (fila.FindControl("txtsitioWeb") as TextBox).Text;

            //ACTUALIZAR
            ObjProveedor.ActualizarProveedor(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }


    }
}
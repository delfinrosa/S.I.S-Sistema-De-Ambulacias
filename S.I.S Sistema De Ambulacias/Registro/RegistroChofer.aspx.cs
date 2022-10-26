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
    public partial class RegistroChofer : System.Web.UI.Page
    {

        private void cargar()
        {
            datatablesSimple.DataSource = ObjChofer.VerificarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            ObjSIS.Chofer ObjChofer = new ObjSIS.Chofer();

        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjChofer.Nombre = TxBoxNombre.Text;
            ObjChofer.Apellido = TxBoxApellido.Text;
            ObjChofer.RFC= TxBoxRFC.Text;
            ObjChofer.Salario= Convert.ToDecimal(TxBoxIdSalario.Text);

            string strError1 = ObjChofer.InsertarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjChofer.IDChofer = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjChofer.EliminarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjChofer.IDChofer = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjChofer.Nombre = (fila.FindControl("txtNombre") as TextBox).Text;
            ObjChofer.Apellido = (fila.FindControl("txtApellido") as TextBox).Text;
            ObjChofer.RFC = (fila.FindControl("txtRFC") as TextBox).Text;
            ObjChofer.Salario = Convert.ToDecimal((fila.FindControl("txtSalario") as TextBox).Text);

            //ACTUALIZAR
            ObjChofer.ActualizarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }
    }
}
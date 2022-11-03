using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibSIS;
using System.Configuration;

namespace S.I.S_Sistema_De_Ambulacias.Reportes
{
    public partial class RegistroArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        ObjSIS.Articulo ObjArticulo = new ObjSIS.Articulo();

        private void cargar()
        {
            datatablesSimple.DataSource = ObjArticulo.VerificarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
            ObjSIS.ArticuloTransporte ObjArticuloTransporte = new ObjSIS.ArticuloTransporte();
        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjArticulo.Descripcion = TxBoxDescripcion.Text;
            ObjArticulo.precioUnitario = Convert.ToDecimal( TxBoxPrecioUnitario.Text );
            ObjArticulo.stockActual= Convert.ToInt32( TxBoxStockActual.Text );
            ObjArticulo.IdProveedor = Convert.ToInt32( TxBoxIdProvedor.Text );
            ObjArticulo.stockMinimo = Convert.ToInt32( TxBoxStockMinimo.Text );

            ObjArticuloTransporte.idTransporte = Convert.ToInt32(TxBoxIDTransporte.Text);

            string strError1 = ObjArticulo.InsertarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            string strError2 = ObjArticuloTransporte.InsertarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();

        }

        protected void datatablesSimple_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = datatablesSimple.Rows[e.RowIndex];
            ObjArticulo.IDArticulo = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjArticulo.Descripcion = (fila.FindControl("txtDescripcion") as TextBox).Text;
            ObjArticulo.precioUnitario = Convert.ToDecimal((fila.FindControl("txtprecioUnitario") as TextBox).Text);
            ObjArticulo.stockActual = Convert.ToInt32( (fila.FindControl("txtstockActual") as TextBox).Text);
            ObjArticulo.IdProveedor =Convert.ToInt32( (fila.FindControl("txtIdProveedor") as TextBox).Text);
            ObjArticulo.stockMinimo =Convert.ToInt32( (fila.FindControl("txtstockMinimo") as TextBox).Text);

            //ACTUALIZAR
            ObjArticulo.ActualizarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void datatablesSimple_RowEditing(object sender, GridViewEditEventArgs e)
        {
            datatablesSimple.EditIndex = e.NewEditIndex;
            cargar();
        }

        protected void datatablesSimple_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ObjArticulo.IDArticulo = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjArticulo.EliminarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();
        }

        protected void datatablesSimple_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void datatablesSimple_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar();
            }
        }
    }
}
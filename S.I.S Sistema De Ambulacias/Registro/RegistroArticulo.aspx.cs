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

        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjSIS.Articulo ObjArticulo = new ObjSIS.Articulo();
            ObjArticulo.Descripcion = TxBoxDescripcion.Text;
            ObjArticulo.precioUnitario = Convert.ToDecimal( TxBoxPrecioUnitario.Text );
            ObjArticulo.stockActual= Convert.ToInt32( TxBoxStockActual.Text );
            ObjArticulo.IdProveedor = Convert.ToInt32( TxBoxIdProvedor.Text );
            ObjArticulo.stockMinimo = Convert.ToInt32( TxBoxStockMinimo.Text );


            string strError1 = ObjArticulo.InsertarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
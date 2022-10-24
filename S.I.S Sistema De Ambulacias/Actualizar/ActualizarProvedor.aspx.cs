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
    public partial class ReportesProvedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {

            ObjSIS.Proveedor ObjProveedor = new ObjSIS.Proveedor();
            ObjProveedor.razonSocial = TxBoxRazonSocial.Text;
            ObjProveedor.Telefono = TxBoxTelefono.Text;
            ObjProveedor.email = TxBoxEmail.Text;
            ObjProveedor.sitioWeb = TxBoxSitioWeb.Text;

            string strError1 = ObjProveedor.InsertarProvedor(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
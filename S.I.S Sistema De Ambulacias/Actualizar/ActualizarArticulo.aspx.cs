using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibSIS;
using System.Configuration; 

namespace S.I.S_Sistema_De_Ambulacias.Actualizar
{
    public partial class ActualizarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnBuscarID_Click(object sender, EventArgs e)
        {
            ObjSIS.Articulo ObjArticulo = new ObjSIS.Articulo();
            ObjArticulo.IDBusqueda = Convert.ToInt32(TxBoxBuscarID.Text);
            string strError1 = ObjArticulo.VerificarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
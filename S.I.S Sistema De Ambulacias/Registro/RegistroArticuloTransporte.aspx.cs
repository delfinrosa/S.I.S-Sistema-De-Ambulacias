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
    public partial class RegistroArticuloTransporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInsertarArticuloTransporte_Click(object sender, EventArgs e)
        {
            ObjSIS.ArticuloTransporte ObjArticuloTransporte = new ObjSIS.ArticuloTransporte();
            ObjArticuloTransporte.idArticulo = Convert.ToInt32(TxBoxIDArticulo.Text);
            ObjArticuloTransporte.idTransporte = Convert.ToInt32(TxBoxIDTransporte.Text);
            string strError1 = ObjArticuloTransporte.InsertarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
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

        protected void BtnInsertarClienteDireccion_Click(object sender, EventArgs e)
        {
            ObjSIS.ClienteDirecciones ObjClienteDireccion = new ObjSIS.ClienteDirecciones();
            ObjClienteDireccion.ID = Convert.ToInt32(TxBoxID.Text);
            ObjClienteDireccion.idCliente = Convert.ToInt32(TxBoxIDCliente.Text) ;
            ObjClienteDireccion.idDireccion = Convert.ToInt32(TxBoxIDDireccion.Text);
            string strError1 = ObjClienteDireccion.InsertarClienteDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
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

        protected void BtnInsertarDireccion_Click(object sender, EventArgs e)
        {
            ObjSIS.Direcciones ObjDireccion= new ObjSIS.Direcciones();
            ObjDireccion.Direccion = TxBoxDireccion.Text;
            ObjDireccion.CodigoPostal = TxBoxCodigoPostal.Text;
            string strError1 = ObjDireccion.InsertarDireccion(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
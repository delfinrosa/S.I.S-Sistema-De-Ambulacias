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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjSIS.Chofer ObjChofer = new ObjSIS.Chofer();
            ObjChofer.Nombre = TxBoxNombre.Text;
            ObjChofer.Apellido = TxBoxApellido.Text;
            ObjChofer.RFC= TxBoxRFC.Text;
            ObjChofer.Salario= Convert.ToDecimal(TxBoxIdSalario.Text);

            string strError1 = ObjChofer.InsertarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
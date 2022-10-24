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
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInsertarCliente_Click(object sender, EventArgs e)
        {
            ObjSIS.Cliente ObjCliente= new ObjSIS.Cliente();
            ObjCliente.Nombre = TxBoxNombre.Text;
            ObjCliente.ApellidoPaterno = TxBoxApellidoPaterno.Text;
            ObjCliente.ApellidoMaterno = TxBoxApellidoMaterno.Text;
            ObjCliente.Telefono = TxBoxTelefono.Text;
            string strError1 = ObjCliente.InsertarCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
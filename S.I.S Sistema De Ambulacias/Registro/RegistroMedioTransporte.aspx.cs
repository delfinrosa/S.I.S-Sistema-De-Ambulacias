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
    public partial class RegistroMedioTrasporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInsertarClienteDireccion_Click(object sender, EventArgs e)
        {

        }

        protected void BtnInsertarMedioTransporte_Click(object sender, EventArgs e)
        {
            ObjSIS.MedioTransporte ObjMedioTransporte = new ObjSIS.MedioTransporte();
            ObjMedioTransporte.TipoCombustible = TxBoxTipoCombustible.Text;
            ObjMedioTransporte.TipoTransporte = TxBoxTipoTransporte.Text;
            ObjMedioTransporte.idChofer = Convert.ToInt32(TxBoxIDChofer.Text);
            string strError1 = ObjMedioTransporte.InsertarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
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
    public partial class RegistroTraslado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TxBoxEstatus_TextChanged(object sender, EventArgs e)
        {
        }

        protected void BtnInsertarTraslado_Click(object sender, EventArgs e)
        {
            ObjSIS.Traslado ObjTraslado = new ObjSIS.Traslado();
            ObjTraslado.FechaProgramada= TxBoxFechaProgramada.Text;
            ObjTraslado.FechaRealizado = TxBoxFechaRealizado.Text;
            ObjTraslado.Costo = Convert.ToSingle(TxBoxCosto.Text);
            ObjTraslado.idMedioTransporte = Convert.ToInt32(TxBoxIDMedioTransporte.Text);
            ObjTraslado.idClienteDireccion = Convert.ToInt32(TxBoxIDClienteDireccion.Text);
            ObjTraslado.Estatus = Convert.ToInt32(TxBoxEstatus.Text);
            string strError1 = ObjTraslado.InsertarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);


        }
    }
}
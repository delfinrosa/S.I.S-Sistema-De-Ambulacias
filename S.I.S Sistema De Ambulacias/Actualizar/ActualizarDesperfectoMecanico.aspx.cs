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
    public partial class RegistroDesperfectoMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjSIS.DesperfectoMecanico ObjDesperfectoMecanico = new ObjSIS.DesperfectoMecanico();
            ObjDesperfectoMecanico.IDMedioTransporte = Convert.ToInt16(TxBoxIDMedioTrasporte.Text);
            ObjDesperfectoMecanico.Fecha = TxBoxFecha.Text;
            ObjDesperfectoMecanico.Descripcion= TxBoxDescripcion.Text;

            string strError1 = ObjDesperfectoMecanico.InsertarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

        }
    }
}
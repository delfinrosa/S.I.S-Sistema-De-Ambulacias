using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibSIS;
using System.Configuration;
using System.Data;
namespace S.I.S_Sistema_De_Ambulacias
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string graficaArea()
        {
            DataTable dt = new DataTable();
            ObjSIS.MedioTransporte ObjMedioTransporte = new ObjSIS.MedioTransporte();
            string strDatos = "[";
            strDatos = "[['Transporte','Traslado' ],";
            switch (DropDownGraficaTraslados.SelectedValue)
            {
                case "Historico":
                    dt = ObjMedioTransporte.GraficaMedioTransporteHistorico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                    break;
                case "Anual":
                    dt = ObjMedioTransporte.GraficaMedioTransporteAnual(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                    break;
                case "Mensual":
                    dt = ObjMedioTransporte.GraficaMedioTransporteMensual(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                    break;
                default:
                    break;
            }
            foreach (DataRow dr in dt.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return strDatos;
        }
        protected string graficaBarras()
        {
            DataTable dt = new DataTable();
            ObjSIS.Traslado ObjTraslado = new ObjSIS.Traslado();
            string strDatos = "[";
            strDatos = "[['MES','$$' ],";
            switch (DropDownGraficaBarras.SelectedValue)
            {
                case "Historico":
                    dt = ObjTraslado.GraficaCostosHistorico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                    foreach (DataRow dr in dt.Rows)
                    {
                        strDatos = strDatos + "[";
                        strDatos = strDatos + "'" + dr[0] + "/" + dr[1] + "'" + "," + dr[2];
                        strDatos = strDatos + "],";
                    }
                    break;
                case "Anual":
                    dt = ObjTraslado.GraficaCostosAnual(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                    foreach (DataRow dr in dt.Rows)
                    {
                        strDatos = strDatos + "[";
                        strDatos = strDatos + "'" + numeroAmes(Convert.ToInt32(dr[0])) + "'" + "," + dr[1];
                        strDatos = strDatos + "],";
                    }
                    break;
                case "Mensual":
                    dt = ObjTraslado.GraficaCostosMensual(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                    foreach (DataRow dr in dt.Rows)
                    {
                        strDatos = strDatos + "[";
                        strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                        strDatos = strDatos + "],";
                    }
                    break;
                default:
                    break;
            }
            strDatos = strDatos + "]";
            return strDatos;
        }

        protected string graficaAreaDespefecto()
        {
            ObjSIS.DesperfectoMecanico ObjDesperfectoMecanico = new ObjSIS.DesperfectoMecanico();
            DataTable dt = new DataTable();
            string strDatos = "[";
            strDatos = "[['Desperfecto','Veces' ],";
            switch (DropDownGraficaDesperfectos.SelectedValue)
            {
                case "Historico":
                    dt = ObjDesperfectoMecanico.GraficaDesperfectosHistorico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                    break;
                case "Anual":
                    dt = ObjDesperfectoMecanico.GraficaDesperfectosAnual(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                    break;
                case "Mensual":
                    dt = ObjDesperfectoMecanico.GraficaDesperfectosMensual(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                    break;
                default:
                    break;
            }
            foreach (DataRow dr in dt.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return strDatos;
        }
        protected string numeroAmes(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Nomviembre";
                case 12:
                    return "Diciembre";
            }
            return "";
        }
        protected void DropDownGraficaTraslados_Load(object sender, EventArgs e)
        {

        }
        protected void DropDownGraficaDesperfectos_Load(object sender, EventArgs e)
        {

        }
        protected void DropDownGraficaBarras_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
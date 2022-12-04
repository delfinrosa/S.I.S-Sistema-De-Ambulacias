using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibSIS;
using System.Configuration;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace S.I.S_Sistema_De_Ambulacias.Registro
{
    public partial class RegistroDesperfectoMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ObjSIS.DesperfectoMecanico ObjDesperfectoMecanico = new ObjSIS.DesperfectoMecanico();
        string idMedioTransporte = "";
        bool aver;
        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjMedioTransporte.TipoTransporte = DropDownMedioTransporteINSERTAR.SelectedValue.ToString();
            DataTable idTransporte = ObjMedioTransporte.VerificarIDMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjDesperfectoMecanico.IDMedioTransporte = Convert.ToInt32(idTransporte.Rows[0][0].ToString());
            ObjDesperfectoMecanico.Fecha = CalendarInsertarFecha.SelectedDate.ToShortDateString();
            ObjDesperfectoMecanico.Descripcion = TxBoxDescripcion.Text;

            string strError1 = ObjDesperfectoMecanico.InsertarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();

        }
        private void cargar()
        {
            datatablesSimple.DataSource = ObjDesperfectoMecanico.VerificarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
        protected void datatablesSimple_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar();
            }
        }

        protected void datatablesSimple_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void datatablesSimple_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (!IsPostBack)
            {
                ObjDesperfectoMecanico.IDDesperfectoMecanico = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
                ObjDesperfectoMecanico.EliminarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                cargar();
            }
        }

        protected void datatablesSimple_RowEditing(object sender, GridViewEditEventArgs e)
        {
            aver = true;
            GridViewRow fila = datatablesSimple.Rows[e.NewEditIndex];
            idMedioTransporte = (fila.FindControl("LabelIDMedioTransporte") as Label).Text;

            datatablesSimple.EditIndex = e.NewEditIndex;
            cargar();
        }

        protected void datatablesSimple_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ObjSIS.MedioTransporte ObjMedioTransporte = new ObjSIS.MedioTransporte();
            GridViewRow fila = datatablesSimple.Rows[e.RowIndex];
            ObjDesperfectoMecanico.IDDesperfectoMecanico = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);

            ObjMedioTransporte.TipoTransporte = (fila.FindControl("DropDownMedioTransporteTABLA") as DropDownList).SelectedValue.ToString();
            DataTable idTransporte = ObjMedioTransporte.VerificarIDMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjDesperfectoMecanico.IDMedioTransporte = Convert.ToInt32(idTransporte.Rows[0][0].ToString());

            ObjDesperfectoMecanico.Fecha = (fila.FindControl("CalendarFecha") as Calendar).SelectedDate.ToShortDateString();
            ObjDesperfectoMecanico.Descripcion = (fila.FindControl("txtDescripcion") as TextBox).Text;

            //ACTUALIZAR
            ObjDesperfectoMecanico.ActualizarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt = ObjDesperfectoMecanico.VerificarDesperfectoMecanico(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font fontTitle = FontFactory.GetFont(FontFactory.TIMES, 25);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);

                PdfPTable table = new PdfPTable(dt.Columns.Count);

                document.Add(new Paragraph(20, "Reporte Desperfecto Mecanico", fontTitle) { Alignment = Element.ALIGN_CENTER });

                document.Add(new Chunk("\n"));

                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    widths[i] = 4f;
                }
                table.SetWidths(widths);
                table.WidthPercentage = 90;
                PdfPCell cell = new PdfPCell(new Phrase("columns"));
                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font9));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt.Columns.Count; h++)
                        {
                            table.AddCell(new Phrase(r[h].ToString(), font9));
                        }
                    }
                }
                document.Add(table);

            }
            document.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=ReporteDesperfectoMecanico" + ".pdf");
            HttpContext.Current.Response.Write(document);
            Response.Flush();
            Response.End();

        }
        ObjSIS.MedioTransporte ObjMedioTransporte = new ObjSIS.MedioTransporte();

        protected void DropDownMedioTransporteTABLA_Load(object sender, EventArgs e)
        {
            if (aver)
            {
                DropDownList dropDownList = (DropDownList)sender;
                dropDownList.DataSource = ObjMedioTransporte.VerificarTODOSMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                dropDownList.DataTextField = "TipoTransporte";
                dropDownList.DataBind();
                if (idMedioTransporte != "" && idMedioTransporte != null)
                {

                    dropDownList.SelectedValue = idMedioTransporte;
                }
            }
        }

        protected void DropDownMedioTransporteINSERTAR_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList dropDownList = (DropDownList)sender;
                dropDownList.DataSource = ObjMedioTransporte.VerificarTODOSMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                dropDownList.DataTextField = "TipoTransporte";
                dropDownList.DataBind();
            }
        }

        protected void CalendarInsertarFecha_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CalendarInsertarFecha.SelectedDate = DateTime.Today;
            }
        }
    }
}
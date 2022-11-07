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
    public partial class RegistroTraslado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TxBoxEstatus_TextChanged(object sender, EventArgs e)
        {
        }
        private void cargar()
        {
            datatablesSimple.DataSource = ObjTraslado.VerificarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
            
        }
        ObjSIS.Traslado ObjTraslado = new ObjSIS.Traslado();
        protected void BtnInsertarTraslado_Click(object sender, EventArgs e)
        {
            
            ObjTraslado.FechaProgramada = CalendarInsertarFechaProgramada.SelectedDate.ToShortDateString();
            ObjTraslado.FechaRealizado = CalendarInsertarFechaRealizado.SelectedDate.ToShortDateString();
            ObjTraslado.Costo = Convert.ToSingle(TxBoxCosto.Text);
            ObjTraslado.idMedioTransporte = Convert.ToInt32(TxBoxIDMedioTransporte.Text);
            ObjTraslado.idClienteDireccion = Convert.ToInt32(TxBoxIDClienteDireccion.Text);
            //ObjTraslado.Estatus = CheckBoxInsertarEstatus.Checked;
            //if (CheckBoxInsertarEstatus.Checked)
            //{
            //    ObjTraslado.Estatus = 0;
            //}
            //else
            //{
            //    ObjTraslado.Estatus = 1;
            //}
            string strError1 = ObjTraslado.InsertarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

            cargar();

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
            ObjTraslado.IDTraslado = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjTraslado.EliminarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();
        }

        protected void datatablesSimple_RowEditing(object sender, GridViewEditEventArgs e)
        {
            datatablesSimple.EditIndex = e.NewEditIndex;
            cargar();
            
        }

        protected void datatablesSimple_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            GridViewRow fila = datatablesSimple.Rows[e.RowIndex];
            ObjTraslado.IDTraslado = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjTraslado.FechaProgramada = (fila.FindControl("CalendarFechaProgramada") as Calendar).SelectedDate.ToShortDateString();
            ObjTraslado.FechaRealizado = (fila.FindControl("CalendarFechaRealizado") as Calendar).SelectedDate.ToShortDateString();
            ObjTraslado.Costo = Convert.ToSingle((fila.FindControl("txtCosto") as TextBox).Text);
            ObjTraslado.idMedioTransporte = Convert.ToInt32((fila.FindControl("txtidMedioTransporte") as TextBox).Text);
            ObjTraslado.idClienteDireccion = Convert.ToInt32((fila.FindControl("txtidClienteDireccion") as TextBox).Text);
            ObjTraslado.Estatus = (fila.FindControl("CheckBoxEstatus") as CheckBox).Checked ;


            //ACTUALIZAR
            ObjTraslado.ActualizarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt = ObjTraslado.VerificarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font fontTitle = FontFactory.GetFont(FontFactory.TIMES, 25);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);

                PdfPTable table = new PdfPTable(dt.Columns.Count);




                document.Add(new Paragraph(20, "Reporte Medio Transporte", fontTitle) { Alignment = Element.ALIGN_CENTER });

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
                foreach (DataRow i in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            table.AddCell(new Phrase(i[j].ToString(), font9));
                        }
                    }
                    document.Add(table);
                }
                document.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=ReporteArticulos" + ".pdf");
                HttpContext.Current.Response.Write(document);
                Response.Flush();
                Response.End();

            }
        }
    }
}
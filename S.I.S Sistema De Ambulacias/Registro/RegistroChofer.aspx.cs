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
    public partial class RegistroChofer : System.Web.UI.Page
    {

        private void cargar()
        {
            datatablesSimple.DataSource = ObjChofer.VerificarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            ObjSIS.Chofer ObjChofer = new ObjSIS.Chofer();

        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjChofer.Nombre = TxBoxNombre.Text;
            ObjChofer.Apellido = TxBoxApellido.Text;
            ObjChofer.RFC= TxBoxRFC.Text;
            ObjChofer.Salario= Convert.ToDecimal(TxBoxIdSalario.Text);

            string strError1 = ObjChofer.InsertarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjChofer.IDChofer = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjChofer.EliminarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjChofer.IDChofer = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjChofer.Nombre = (fila.FindControl("txtNombre") as TextBox).Text;
            ObjChofer.Apellido = (fila.FindControl("txtApellido") as TextBox).Text;
            ObjChofer.RFC = (fila.FindControl("txtRFC") as TextBox).Text;
            ObjChofer.Salario = Convert.ToDecimal((fila.FindControl("txtSalario") as TextBox).Text);

            //ACTUALIZAR
            ObjChofer.ActualizarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt =ObjChofer.VerificarChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font fontTitle = FontFactory.GetFont(FontFactory.TIMES, 25);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);

                PdfPTable table = new PdfPTable(dt.Columns.Count);




                document.Add(new Paragraph(20, "Reporte Chofer", fontTitle) { Alignment = Element.ALIGN_CENTER });

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
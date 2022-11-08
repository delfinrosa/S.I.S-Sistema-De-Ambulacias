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

namespace S.I.S_Sistema_De_Ambulacias.Reportes
{
    public partial class RegistroArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        ObjSIS.Articulo ObjArticulo = new ObjSIS.Articulo();

        private void cargar()
        {
            datatablesSimple.DataSource = ObjArticulo.VerificarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
        ObjSIS.ArticuloTransporte ObjArticuloTransporte = new ObjSIS.ArticuloTransporte();
        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjArticulo.Descripcion = TxBoxDescripcion.Text;
            ObjArticulo.precioUnitario = Convert.ToDecimal(TxBoxPrecioUnitario.Text);
            ObjArticulo.stockActual = Convert.ToInt32(TxBoxStockActual.Text);
            ObjArticulo.IdProveedor = Convert.ToInt32(TxBoxIdProvedor.Text);
            ObjArticulo.stockMinimo = Convert.ToInt32(TxBoxStockMinimo.Text);

            ObjArticuloTransporte.idTransporte = Convert.ToInt32(TxBoxIDTransporte.Text);

            string strError1 = ObjArticulo.InsertarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            string strError2 = ObjArticuloTransporte.InsertarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();

        }

        protected void datatablesSimple_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = datatablesSimple.Rows[e.RowIndex];
            ObjArticulo.IDArticulo = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjArticulo.Descripcion = (fila.FindControl("txtDescripcion") as TextBox).Text;
            ObjArticulo.precioUnitario = Convert.ToDecimal((fila.FindControl("txtprecioUnitario") as TextBox).Text);
            ObjArticulo.stockActual = Convert.ToInt32((fila.FindControl("txtstockActual") as TextBox).Text);
            ObjArticulo.IdProveedor = Convert.ToInt32((fila.FindControl("txtIdProveedor") as TextBox).Text);
            ObjArticulo.stockMinimo = Convert.ToInt32((fila.FindControl("txtstockMinimo") as TextBox).Text);

            //ACTUALIZAR
            ObjArticulo.ActualizarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void datatablesSimple_RowEditing(object sender, GridViewEditEventArgs e)
        {
            datatablesSimple.EditIndex = e.NewEditIndex;
            cargar();
        }

        protected void datatablesSimple_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ObjArticulo.IDArticulo = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjArticulo.EliminarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();
        }

        protected void datatablesSimple_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void datatablesSimple_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar();
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Document document = new Document();
            dt.Columns.Add("a");
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt = ObjArticulo.VerificarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font fontTitle = FontFactory.GetFont(FontFactory.TIMES, 25);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);

                PdfPTable table = new PdfPTable(dt.Columns.Count);




                document.Add(new Paragraph(20, "Reporte Articulo", fontTitle) { Alignment = Element.ALIGN_CENTER });
                
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
                DataRow a = new DataRow["texto", "otro texto"];
                table.AddCell(new Phrase(a, font9)) ;
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
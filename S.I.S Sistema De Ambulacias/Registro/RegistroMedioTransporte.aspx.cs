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
    public partial class RegistroMedioTrasporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInsertarClienteDireccion_Click(object sender, EventArgs e)
        {

        }
        string Chofer;
        ObjSIS.MedioTransporte ObjMedioTransporte = new ObjSIS.MedioTransporte();
        ObjSIS.Chofer ObjChofer = new ObjSIS.Chofer();
        protected void BtnInsertarMedioTransporte_Click(object sender, EventArgs e)
        {
            ObjMedioTransporte.TipoCombustible = TxBoxTipoCombustible.Text;
            ObjMedioTransporte.TipoTransporte = TxBoxTipoTransporte.Text;


            ObjChofer.Nombre = DropInsertChofer.SelectedItem.ToString();
            DataTable idchofer = ObjChofer.VerificaridNombreChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjMedioTransporte.idChofer = Convert.ToInt32(idchofer.Rows[0][0].ToString());

            string strError1 = ObjMedioTransporte.InsertarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();

        }
        private void cargar()
        {
            datatablesSimple.DataSource = ObjMedioTransporte.VerificarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
            ObjMedioTransporte.IDMedioTransporte = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjMedioTransporte.EliminarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();
        }

        protected void datatablesSimple_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow fila = datatablesSimple.Rows[e.NewEditIndex];
            Chofer = (fila.FindControl("LabelChofer") as Label).Text;
            datatablesSimple.EditIndex = e.NewEditIndex;
            cargar();
        }

        protected void datatablesSimple_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = datatablesSimple.Rows[e.RowIndex];
            ObjMedioTransporte.IDMedioTransporte = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjMedioTransporte.TipoCombustible = (fila.FindControl("txtTipoCombustible") as TextBox).Text;
            ObjMedioTransporte.TipoTransporte = (fila.FindControl("txtTipoTransporte") as TextBox).Text;

            ObjChofer.Nombre = (fila.FindControl("DropDownChoferTABLA") as DropDownList).SelectedValue.ToString();
            DataTable idChofer = ObjChofer.VerificaridNombreChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

            ObjMedioTransporte.idChofer = Convert.ToInt32(idChofer.Rows[0][0].ToString());


            //ACTUALIZAR
            ObjMedioTransporte.ActualizarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt = ObjMedioTransporte.VerificarMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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
                Response.AddHeader("content-disposition", "attachment;filename=ReporteMedioTransporte" + ".pdf");
                HttpContext.Current.Response.Write(document);
                Response.Flush();
                Response.End();

            
        }

        protected void DropDownChoferTABLA_Load(object sender, EventArgs e)
        {
            if (Chofer != "" && Chofer != null)
            {
                ObjSIS.Chofer ObjChofer = new ObjSIS.Chofer();
                DropDownList dropDownList = (DropDownList)sender;
                dropDownList.DataSource = ObjChofer.VerificarNombreChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                dropDownList.DataTextField = "Nombre";
                dropDownList.SelectedValue = Chofer;
            }
        }

        protected void DropInsertChofer_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObjSIS.Chofer ObjChofer = new ObjSIS.Chofer();
                DropInsertChofer.DataSource = ObjChofer.VerificarNombreChofer(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                DropInsertChofer.DataTextField = "Nombre";
                DropInsertChofer.DataBind();
            }
        }
    }
}
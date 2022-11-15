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
        ObjSIS.MedioTransporte ObjMedioTransporte = new ObjSIS.MedioTransporte();
        ObjSIS.ArticuloTransporte ObjArticuloTransporte = new ObjSIS.ArticuloTransporte();
        ObjSIS.Articulo ObjArticulo = new ObjSIS.Articulo();
        string idProvedorTabla = "";
        string idtransporteTabla = "";


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void cargar()
        {
            datatablesSimple.DataSource = ObjArticulo.VerificarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.DataBind();
        }
      
        protected void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            ObjSIS.Proveedor ObjProveedor = new ObjSIS.Proveedor();
            ObjArticulo.Descripcion = TxBoxDescripcion.Text;
            ObjArticulo.precioUnitario = Convert.ToDecimal(TxBoxPrecioUnitario.Text);
            ObjArticulo.stockActual = Convert.ToInt32(TxBoxStockActual.Text);
            ObjArticulo.stockMinimo = Convert.ToInt32(TxBoxStockMinimo.Text);

            ObjProveedor.razonSocial = DropDownListIdProvedor.SelectedItem.ToString();
            DataTable idProvedor = ObjProveedor.VerificarIDProveedor(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjArticulo.IdProveedor = Convert.ToInt32(idProvedor.Rows[0][0].ToString());


            ObjMedioTransporte.TipoTransporte = DropInsertTransporte.SelectedItem.ToString();
            DataTable idTransporte = ObjMedioTransporte.VerificarIDMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjArticuloTransporte.idTransporte = Convert.ToInt32(idProvedor.Rows[0][0].ToString());


            string strError1 = ObjArticulo.InsertarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            string strError2 = ObjArticuloTransporte.InsertarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            cargar();

        }
 
        protected void datatablesSimple_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ObjSIS.Proveedor ObjProveedor = new ObjSIS.Proveedor();
            GridViewRow fila = datatablesSimple.Rows[e.RowIndex];
            ObjArticulo.IDArticulo = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);
            ObjArticulo.Descripcion = (fila.FindControl("txtDescripcion") as TextBox).Text;
            ObjArticulo.precioUnitario = Convert.ToDecimal((fila.FindControl("txtprecioUnitario") as TextBox).Text);
            ObjArticulo.stockActual = Convert.ToInt32((fila.FindControl("txtstockActual") as TextBox).Text);
            ObjArticulo.stockMinimo = Convert.ToInt32((fila.FindControl("txtstockMinimo") as TextBox).Text);

            ObjProveedor.razonSocial = (fila.FindControl("DropDownList1") as DropDownList).SelectedValue.ToString();
            DataTable idProvedor = ObjProveedor.VerificarIDProveedor(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjArticulo.IdProveedor = Convert.ToInt32(idProvedor.Rows[0][0].ToString());

            ObjMedioTransporte.TipoTransporte = (fila.FindControl("DropDownIDTransporte") as DropDownList).SelectedValue.ToString();
            DataTable idTrasporte = ObjMedioTransporte.VerificarIDMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

            ObjArticuloTransporte.idTransporte = Convert.ToInt32(idTrasporte.Rows[0][0].ToString());

            ObjArticuloTransporte.idarticulo = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);

            ObjMedioTransporte.TipoTransporte = LBLGUARDAR.Text ;
            DataTable idTrasportOOO = ObjMedioTransporte.VerificarIDMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjArticuloTransporte.idAntiguoTransporte = Convert.ToInt32(idTrasportOOO.Rows[0][0].ToString());

            //ACTUALIZAR
            ObjArticuloTransporte.EditarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);

            ObjArticulo.ActualizarArticulo(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            datatablesSimple.EditIndex = -1;
            cargar();
        }

        protected void datatablesSimple_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewRow fila = datatablesSimple.Rows[e.NewEditIndex];
            idProvedorTabla = (fila.FindControl("LabelIdProveedor") as Label).Text;
            idtransporteTabla = (fila.FindControl("LabelidTransporte") as Label).Text;
            datatablesSimple.EditIndex = e.NewEditIndex;
            cargar();
            if (idtransporteTabla != null )
            {
                LBLGUARDAR.Text = idtransporteTabla;
            }

        }

        protected void datatablesSimple_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow fila = datatablesSimple.Rows[e.RowIndex];

            ObjArticulo.IDArticulo = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);

            ObjArticuloTransporte.idarticulo = Convert.ToInt32(datatablesSimple.DataKeys[e.RowIndex].Values[0]);

            ObjMedioTransporte.TipoTransporte = (fila.FindControl("LabelidTransporte") as Label).Text;
            DataTable idTrasporte = ObjMedioTransporte.VerificarIDMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjArticuloTransporte.idTransporte = Convert.ToInt32(idTrasporte.Rows[0][0].ToString());

            ObjArticuloTransporte.EliminarArticuloTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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

        public void cargarDropDownPROVEDOR(DropDownList lista, string IDDrop)
        {
            ObjSIS.Proveedor ObjProveedor = new ObjSIS.Proveedor();
            if (IDDrop == "IDProvedor")
            {
                lista.DataSource = ObjProveedor.VerificarTODOSProveedor(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                lista.DataTextField = "razonSocial";
            }
            if (IDDrop == "IDTransporte")
            {
                lista.DataSource = ObjMedioTransporte.VerificarTODOSMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                lista.DataTextField = "TipoTransporte";
            }
            lista.DataBind();

        }


        protected void DropDownListIdProvedor_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDropDownPROVEDOR(DropDownListIdProvedor, "IDProvedor");
            }
        }

        protected void DropDownList1_Load(object sender, EventArgs e)
        {
            if (idProvedorTabla != "" && idProvedorTabla != null)
            {
                DropDownList dropDownList = (DropDownList)sender;
                cargarDropDownPROVEDOR(dropDownList, "IDProvedor");
                dropDownList.SelectedValue = idProvedorTabla;

            }


        }


        protected void DropDownIDTransporte_Load(object sender, EventArgs e)
        {
            if (idtransporteTabla != "" && idtransporteTabla != null)
            {
                DropDownList dropDownList = (DropDownList)sender;
                cargarDropDownPROVEDOR(dropDownList, "IDTransporte");
                dropDownList.SelectedValue = idtransporteTabla;

            }
        }

        protected void DropInsertTransporte_load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDropDownPROVEDOR(DropInsertTransporte, "IDTransporte");
            }
        }
    }

}
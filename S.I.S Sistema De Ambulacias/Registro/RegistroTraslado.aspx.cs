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
        bool cargoNumero;
        ObjSIS.MedioTransporte ObjMedioTransporte = new ObjSIS.MedioTransporte();
        ObjSIS.Proveedor ObjProveedor = new ObjSIS.Proveedor();
        ObjSIS.Cliente ObjCliente = new ObjSIS.Cliente();
        ObjSIS.Direcciones ObjDirecciones = new ObjSIS.Direcciones();
        ObjSIS.Traslado ObjTraslado = new ObjSIS.Traslado();            
        ObjSIS.ClienteDirecciones ObjClienteDireccion= new ObjSIS.ClienteDirecciones();

        string idtransporteTabla;
        string NumeroTelefono;
        string DirecionCliente;
        object dropDireccion;
        object dropDireccionINSERTAR;

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
        protected void BtnInsertarTraslado_Click(object sender, EventArgs e)
        {

            ObjTraslado.FechaProgramada = CalendarInsertarFechaProgramada.SelectedDate.ToShortDateString();
            ObjTraslado.FechaRealizado = CalendarInsertarFechaRealizado.SelectedDate.ToShortDateString();
            ObjTraslado.Costo = Convert.ToSingle(TxBoxCosto.Text);


            ObjMedioTransporte.TipoTransporte = DropDownMedioTransporte.SelectedItem.ToString();
            DataTable ids = ObjMedioTransporte.VerificarIDMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjTraslado.idMedioTransporte = Convert.ToInt32(ids.Rows[0][0].ToString());

            ObjCliente.Telefono = DropDownNumeroINSERTAR.SelectedValue;
            ids = ObjCliente.VerificarIDConTelefonoCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjClienteDireccion.idCliente = Convert.ToInt32(ids.Rows[0][0].ToString());

            ObjDirecciones.Direccion = DropDownDireccionINSERTAR.SelectedValue ;
            ids = ObjDirecciones.VerificarIDCONDireccionesNumero(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjClienteDireccion.idDireccion = Convert.ToInt32(ids.Rows[0][0].ToString());

            ids = ObjClienteDireccion.VerificarIDClienteDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjTraslado.idClienteDireccion = Convert.ToInt32(ids.Rows[0][0].ToString());

            ObjTraslado.Estatus = CheckBoxInsertarEstatus.Checked;
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
            GridViewRow fila = datatablesSimple.Rows[e.NewEditIndex];
            idtransporteTabla = (fila.FindControl("LabelidMedioTransporte") as Label).Text;
            NumeroTelefono = (fila.FindControl("LabelNumeroTelefono") as Label).Text;
            DirecionCliente = (fila.FindControl("LabelidClienteDireccion") as Label).Text;

            Guardar1.Text = NumeroTelefono;
            Guardar2.Text = DirecionCliente;

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


            ObjMedioTransporte.TipoTransporte = (fila.FindControl("DropDownTransporteTabla") as DropDownList).SelectedValue; 
            DataTable ids = ObjMedioTransporte.VerificarIDMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjTraslado.idMedioTransporte = Convert.ToInt32(ids.Rows[0][0].ToString());

            ObjCliente.Telefono = (fila.FindControl("DropDownNumeroTabla") as DropDownList).SelectedValue; 
            ids = ObjCliente.VerificarIDConTelefonoCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjClienteDireccion.idCliente = Convert.ToInt32(ids.Rows[0][0].ToString());

            ObjDirecciones.Direccion = (fila.FindControl("DropDownDireccionTabla") as DropDownList).SelectedValue;
            ids = ObjDirecciones.VerificarIDCONDireccionesNumero(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjClienteDireccion.idDireccion = Convert.ToInt32(ids.Rows[0][0].ToString());

            ids = ObjClienteDireccion.VerificarIDClienteDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjTraslado.idClienteDireccion = Convert.ToInt32(ids.Rows[0][0].ToString());

            ObjTraslado.Estatus = (fila.FindControl("CheckBoxEstatus") as CheckBox).Checked;

            //CLIENTE DIRECCION
            ObjCliente.Telefono = Guardar1.Text;
            ids = ObjCliente.VerificarIDConTelefonoCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjClienteDireccion.idClienteANTIGUO = Convert.ToInt32(ids.Rows[0][0].ToString());

            ObjDirecciones.Direccion = Guardar2.Text;
            ids = ObjDirecciones.VerificarIDCONDireccionesNumero(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjClienteDireccion.idDireccionANTIGUO = Convert.ToInt32(ids.Rows[0][0].ToString());
            //ACTUALIZAR
            ObjTraslado.ActualizarTraslado(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            ObjClienteDireccion.ActualizarTODOClienteDirecciones(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
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

                document.Add(new Paragraph(20, "Reporte Traslados", fontTitle) { Alignment = Element.ALIGN_CENTER });

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
                Response.AddHeader("content-disposition", "attachment;filename=ReporteTraslados" + ".pdf");
                HttpContext.Current.Response.Write(document);
                Response.Flush();
                Response.End();

            }
        }
        public void cargarDropDownPROVEDOR(DropDownList lista, string IDDrop)
        {

            if (IDDrop == "IDTransporte")
            {
                lista.DataSource = ObjMedioTransporte.VerificarTODOSMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                lista.DataTextField = "TipoTransporte";
            }
            if (IDDrop == "NumeroTelefono")
            {
                lista.DataSource = ObjCliente.VerificarTelefonoCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                lista.DataTextField = "Telefono";
            }
            if (IDDrop == "Direccion")
            {
                lista.DataSource = ObjDirecciones.VerificarDireccionesNumero(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                lista.DataTextField = "Direccion";
            }
            lista.DataBind();

        }

        protected void DropDownTransporteTabla_Load(object sender, EventArgs e)
        {
            if (idtransporteTabla != "" && idtransporteTabla != null)
            {
                DropDownList dropDownList = (DropDownList)sender;
                cargarDropDownPROVEDOR(dropDownList, "IDTransporte");
                dropDownList.SelectedValue = idtransporteTabla;

            }
        }

        protected void DropDownNumeroTabla_Load(object sender, EventArgs e)
        {
            if (NumeroTelefono != "" && NumeroTelefono != null)
            {
                DropDownList dropDownList = (DropDownList)sender;
                cargarDropDownPROVEDOR(dropDownList, "NumeroTelefono");
                dropDownList.SelectedValue = NumeroTelefono;
            }
        }

        protected void DropDownNumeroTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDownNumero = (DropDownList)sender;
            ObjDirecciones.telelfono = dropDownNumero.SelectedValue;
            DropDownList dropDownDireccion = (DropDownList)dropDireccion;
            dropDownDireccion.Enabled = true;
            cargarDropDownPROVEDOR(dropDownDireccion, "Direccion");
            dropDownDireccion.SelectedValue = DirecionCliente;
        }
        protected void DropDownDireccionTabla_Load(object sender, EventArgs e)
        {
            DropDownList dropDowndireccion= (DropDownList)sender;
            dropDowndireccion.Items.Add(DirecionCliente);
            dropDowndireccion.SelectedValue = DirecionCliente;
            dropDireccion = sender;
        }

        protected void DropDownMedioTransporte_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownMedioTransporte.DataSource = ObjMedioTransporte.VerificarTODOSMedioTransporte(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                DropDownMedioTransporte.DataTextField = "TipoTransporte";
                DropDownMedioTransporte.DataBind();
            }
        }

        protected void DropDownNumeroINSERTAR_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownNumeroINSERTAR.DataSource = ObjCliente.VerificarTelefonoCliente(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
                DropDownNumeroINSERTAR.DataTextField = "Telefono";
                DropDownNumeroINSERTAR.DataBind();
            }
        }

        protected void DropDownDireccionINSERTAR_Load(object sender, EventArgs e)
        {
            dropDireccionINSERTAR = sender;
        }


        protected void DropDownNumeroINSERTAR_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList dropDownNumero = (DropDownList)dropDireccionINSERTAR;
            dropDownNumero.Enabled = true;
            ObjDirecciones.telelfono = DropDownNumeroINSERTAR.SelectedValue;
            dropDownNumero.DataSource = ObjDirecciones.VerificarDireccionesNumero(ConfigurationManager.ConnectionStrings["ConexionPrincipal"].ConnectionString);
            dropDownNumero.DataTextField = "Direccion";
            dropDownNumero.DataBind();


        }

        protected void CalendarInsertarFechaProgramada_Load(object sender, EventArgs e)
        {
            CalendarInsertarFechaProgramada.SelectedDate = DateTime.Today;
        }

        protected void CalendarInsertarFechaRealizado_Load(object sender, EventArgs e)
        {
            CalendarInsertarFechaRealizado.SelectedDate = DateTime.Today;
        }
    }
}
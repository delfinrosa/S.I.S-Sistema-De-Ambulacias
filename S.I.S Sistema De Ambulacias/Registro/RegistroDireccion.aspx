<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroDireccion.aspx.cs" Inherits="S.I.S_Sistema_De_Ambulacias.Registro.RegistroDirreccion" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SIS</title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/styles.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/simple-datatables@latest/dist/style.css" rel="stylesheet" />
    <link href="../css/estiloSIS.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>

</head>

<body class="sb-nav-fixed">
    <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
        <!-- Navbar Brand-->
        <a class="navbar-brand ps-3" href="../inicio.aspx">S.I.S. Ambulacias</a>
        <!-- Sidebar Toggle-->
        <!-- <button class="btn btn-link btn-sm order-5 order-lg-first me-4 me-lg-0  " id="sidebarToggle" href="#!"><i class="fas fa-bars"></i></button> -->
        <div class="d-flex justify-content-end w-100">
            <button class="btn btn-link btn-sm order-5 order-lg-first me-4 me-lg-0  " id="sidebarToggle" href="#!"><i class="fas fa-bars"></i></button>
        </div>
        <!-- Navbar Search-->

    </nav>
    <div id="layoutSidenav">
        <div id="layoutSidenav_nav">
            <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                <div class="sb-sidenav-menu">
                    <div class="nav">


                        <%--______Registros_____--%>
                        <div class="sb-sidenav-menu-heading m--5">Registros</div>
                        <a class="nav-link collapsed" href="#" data-bs-toggle="collapse" data-bs-target="#collapseLayouts" aria-expanded="false" aria-controls="collapseLayouts">
                            <div class="sb-nav-link-icon"><i class="fas fa-columns"></i></div>
                            Registrar
                                <div class="sb-sidenav-collapse-arrow"><i class="fas fa-angle-down"></i></div>
                        </a>
                        <div class="collapse" id="collapseLayouts" aria-labelledby="headingOne" data-bs-parent="#sidenavAccordion">
                            <nav class="sb-sidenav-menu-nested nav">
                                <a class="nav-link py-3" href="RegistroProvedor.aspx">Provedores</a>
                                <a class="nav-link py-3" href="RegistroArticulo.aspx">Articulo</a>
                                <a class="nav-link py-3" href="RegistroChofer.aspx">Chofer</a>
                                <a class="nav-link py-3" href="RegistroDesperfectoMecanico.aspx">Desperfecto Mecanico</a>
                                <a class="nav-link py-3" href="RegistroCliente.aspx">Cliente</a>
                                <a class="nav-link py-3" href="RegistroDireccion.aspx">Direccion</a>
                                <a class="nav-link py-3" href="RegistroClienteDirecciones.aspx">Cliente Direcciones</a>
                                <a class="nav-link py-3" href="RegistroMedioTransporte.aspx">Medio De Transporte</a>
                                <a class="nav-link py-3" href="RegistroTraslado.aspx">Traslado</a>
                                <a class="nav-link py-3" href="RegistroArticuloTransporte.aspx">Articulo Transporte</a>
                            </nav>
                        </div>
                        <%--___________--%>
                    </div>
                </div>
                <div class="sb-sidenav-footer">
                    <div class="small">Logged in as:</div>
                    Start Bootstrap
                </div>
            </nav>
        </div>

        <!-- INSERT -->

        <div id="layoutSidenav_content">
            <form action="" runat="server">
                <main>
                    <div class="container w-100">
                        <h1 class="text-dark text-center my-5">Direccion</h1>
                    </div>


                    <div class="card mb-4">
                        <div class="card-header ">
                            <i class="fas fa-table me-1"></i>
                            Cliente
                        <div class="card-body card-title">
                            &nbsp;<asp:GridView DataKeyNames="ID" ID="datatablesSimple" runat="server" OnLoad="datatablesSimple_Load" AutoGenerateColumns="false" OnRowCancelingEdit="datatablesSimple_RowCancelingEdit" OnRowDeleting="datatablesSimple_RowDeleting" OnRowEditing="datatablesSimple_RowEditing" OnRowUpdating="datatablesSimple_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelID" runat="server" Text='<%#Bind("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox CssClass="w-100 form-control" ID="txtID" runat="server" Text='<%#Bind("ID")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Direccion">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelDireccion" runat="server" Text='<%#Bind("Direccion")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox CssClass="w-100 form-control" ID="txtDireccion" runat="server" Text='<%#Bind("Direccion")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Codigo Postal">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelCodigoPostal" runat="server" Text='<%#Bind("CodigoPostal")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox CssClass="w-100 form-control" ID="txtCodigoPostal" runat="server" Text='<%#Bind("CodigoPostal")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                                <Columns>
                                    <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        </div>
                    </div>

                    <div class="container-fluid p-4">
                        <div class="d-block w100">
                            <div class="row">
                                <div class="col-12">
                                    <h2 class="text-center mb-4">Registro Del Direccion</h2>
                                </div>
                            </div>
                            <div class="row mb-2">

                                <div class="col-auto">
                                    <h2 class="text-end">
                                        <label for="TxBoxDireccion" class="form-label text-dark ">Direccion</label>
                                    </h2>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="TxBoxDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-2">

                                <div class="col-auto">
                                    <h2 class="text-end">
                                        <label for="TxBoxCodigoPostal" class="form-label text-dark ">Codigo Postal</label>
                                    </h2>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="TxBoxCodigoPostal" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">

                                <div class="col-auto">
                                    <h2 class="text-end">
                                        <label for="TxBoxIDliente" class="form-label text-dark ">ID Cliente</label>
                                    </h2>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="TxBoxIDliente" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="d-flex justify-content-end">
                                <asp:Button ID="BtnInsertarDireccion" runat="server" Text="Registrar" Style="color: #fff;" class=" btn border-dark border-2 w-50 bg-dark " OnClick="BtnInsertarDireccion_Click" />
                            </div>
                        </div>

                    </div>
                    <!-- !_______________________________________________________________________ -->

                </main>
            </form>
            <footer class="py-4 bg-light mt-auto">
                <div class="container-fluid px-4">
                    <div class="d-flex align-items-center justify-content-between small">
                        <div class="text-muted">Copyright &copy; Your Website 2022</div>
                        <div>
                            <a href="#">Privacy Policy</a>
                            &middot;
                                <a href="#">Terms &amp; Conditions</a>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="../js/scripts.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
    <script src="../assets/demo/chart-area-demo.js"></script>
    <script src="../assets/demo/chart-bar-demo.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/simple-datatables@latest" crossorigin="anonymous"></script>
    <script src="../js/datatables-simple-demo.js"></script>
</body>
</html>

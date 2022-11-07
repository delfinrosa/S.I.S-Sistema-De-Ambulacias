<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroArticuloTransporte.aspx.cs" Inherits="S.I.S_Sistema_De_Ambulacias.Registro.RegistroArticuloTransporte" %>

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
                                <div class="sb-sidenav-menu" >
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
                                <a class="nav-link py-3" href="RegistroMedioTransporte.aspx">Medio De Transporte</a>
                                <a class="nav-link py-3" href="RegistroTraslado.aspx">Traslado</a>
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
                        <h1 class="text-dark text-center my-5">Traslado</h1>
                    </div>
                    <div class="container-fluid p-4">
                        <div class="d-block w100">
                            <div class="row">
                                <div class="col-12">
                                    <h2 class="text-center mb-4">Registro de Traslado</h2>
                                </div>
                            </div>
                            <div class="row mb-2">

                                <div class="col-auto">
                                    <h2 class="text-end">
                                        <label for="TxBoxIDTransporte" class="form-label text-dark ">ID Transporte</label>
                                    </h2>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="TxBoxIDTransporte" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-2">

                                <div class="col-auto">
                                    <h2 class="text-end">
                                        <label for="TxBoxIDArticulo" class="form-label text-dark ">ID Articulo</label>
                                    </h2>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="TxBoxIDArticulo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="d-flex justify-content-end">
                                <asp:Button ID="BtnInsertarArticuloTransporte" runat="server" Text="Registrar" Style="color: #fff;" class=" btn border-dark border-2 w-50 bg-dark " OnClick="BtnInsertarArticuloTransporte_Click" />
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
<script src="../js/tabla.js"></script>    <script src="../js/datatables-simple-demo.js"></script>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="S.I.S_Sistema_De_Ambulacias.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SIS</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/main.css" rel="stylesheet" />
    <link href="css/styles.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/simple-datatables@latest/dist/style.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>

</head>


<body class="sb-nav-fixed">
    <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
        <!-- Navbar Brand-->
        <a class="navbar-brand ps-3" href="inicio.aspx">S.I.S. Ambulacias</a>
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
                <div class="sb-sidenav-menu m-1 ">
                    <div class="nav m-1">

                        <%--______Registros_____--%>
                        <div class="sb-sidenav-menu-heading bordeaa  m--5 ">Registros</div>
                        <a class="nav-link collapsed " href="#" data-bs-toggle="collapse" data-bs-target="#collapseNAV" aria-expanded="false" aria-controls="collapseLayouts">
                            <div class="sb-nav-link-icon "><i class="fas fa-columns"></i></div>
                            Registrar
                                <div class="sb-sidenav-collapse-arrow "><i class="fas fa-angle-down"></i></div>
                        </a>

                        <div class="collapse mb-2" id="collapseNAV" aria-labelledby="headingOne" data-bs-parent="#sidenavAccordion">
                            <nav class="sb-sidenav-menu-nested nav m-3 ">
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroProvedor.aspx">Provedores</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroArticulo.aspx">Articulo</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroChofer.aspx">Chofer</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroDesperfectoMecanico.aspx">Desperfecto Mecanico</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroCliente.aspx">Cliente</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroDireccion.aspx">Direccion</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroClienteDirecciones.aspx">Cliente Direcciones</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroMedioTransporte.aspx">Medio De Transporte</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroTraslado.aspx">Traslado</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroArticuloTransporte.aspx">Articulo Transporte</a>
                            </nav>
                        </div>
                        <%--___________--%>
           
                                                <%--______Registros_____--%>
                        <div class="sb-sidenav-menu-heading mt-5 m--5">Registros</div>
                        <a class="nav-link collapsed " href="#" data-bs-toggle="collapse" data-bs-target="#collapseNAV" aria-expanded="false" aria-controls="collapseLayouts">
                            <div class="sb-nav-link-icon "><i class="fas fa-columns"></i></div>
                            Registrar
                                <div class="sb-sidenav-collapse-arrow "><i class="fas fa-angle-down"></i></div>
                        </a>

                        <div class="collapse " id="collapseNAV" aria-labelledby="headingOne" data-bs-parent="#sidenavAccordion">
                            <nav class="sb-sidenav-menu-nested nav m-3 ">
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroProvedor.aspx">Provedores</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroArticulo.aspx">Articulo</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroChofer.aspx">Chofer</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroDesperfectoMecanico.aspx">Desperfecto Mecanico</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroCliente.aspx">Cliente</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroDireccion.aspx">Direccion</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroClienteDirecciones.aspx">Cliente Direcciones</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroMedioTransporte.aspx">Medio De Transporte</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroTraslado.aspx">Traslado</a>
                                <a class="nav-link p-2 my-2 d-flex" href="/Registro/RegistroArticuloTransporte.aspx">Articulo Transporte</a>
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

        <div id="layoutSidenav_content">
            <img src="../img/nose.jpg" />
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="js/scripts.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
    <script src="assets/demo/chart-area-demo.js"></script>
    <script src="assets/demo/chart-bar-demo.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/simple-datatables@latest" crossorigin="anonymous"></script>
    <script src="js/datatables-simple-demo.js"></script>
</body>
</html>

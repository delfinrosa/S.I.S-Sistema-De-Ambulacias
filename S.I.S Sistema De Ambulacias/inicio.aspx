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
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = google.visualization.arrayToDataTable(<%=graficaArea()%>);
            var options = { title: 'Cantidad De Traslados' };
            var chart = new google.visualization.PieChart(document.getElementById('myChart'));
            chart.draw(data, options);

            data = google.visualization.arrayToDataTable(<%=graficaBarras()%>);
            options = { title: 'Dinero' };
            chart = new google.visualization.BarChart(document.getElementById('GraficaBarras'));
            chart.draw(data, options);

            data = google.visualization.arrayToDataTable(<%=graficaAreaDespefecto()%>);
            options = { title: 'Desperfectos Mecanicos' };
            chart = new google.visualization.PieChart(document.getElementById('GraficaDespefecto'));
            chart.draw(data, options);
        }
    </script>


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
                                <a class="nav-link py-3" href="Registro/RegistroProvedor.aspx">Provedores</a>
                                <a class="nav-link py-3" href="Registro/RegistroArticulo.aspx">Articulo</a>
                                <a class="nav-link py-3" href="Registro/RegistroChofer.aspx">Chofer</a>
                                <a class="nav-link py-3" href="Registro/RegistroDesperfectoMecanico.aspx">Desperfecto Mecanico</a>
                                <a class="nav-link py-3" href="Registro/RegistroCliente.aspx">Cliente</a>
                                <a class="nav-link py-3" href="Registro/RegistroDireccion.aspx">Direccion</a>
                                <a class="nav-link py-3" href="Registro/RegistroMedioTransporte.aspx">Medio De Transporte</a>
                                <a class="nav-link py-3" href="Registro/RegistroTraslado.aspx">Traslado</a>
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
        <form runat="server" class="w-100 container-fluid">

            <div id="layoutSidenav_content">
                <div class="row w-100">

                    <div class="d-flex justify-content-center   col-6 ">
                        <div class="" style="max-width: 700px; height: 400px" id="myChart"></div>
                    </div>
                    <div class="d-flex justify-content-center  w-50 col-6">
                        <div class="" style="max-width: 700px; height: 400px" id="GraficaDespefecto"></div>
                    </div>
                </div>
                <div class="d-flex justify-content-center menos_margen_superior">
                    <asp:DropDownList AutoPostBack="true" ID="DropDownGraficaTraslados" CssClass="form-control w-25 m-auto" runat="server" OnLoad="DropDownGraficaTraslados_Load">
                        <asp:ListItem>Historico</asp:ListItem>
                        <asp:ListItem>Anual</asp:ListItem>
                        <asp:ListItem>Mensual</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList AutoPostBack="true" ID="DropDownGraficaDesperfectos" CssClass="form-control w-25 m-auto" runat="server" OnLoad="DropDownGraficaTraslados_Load">
                        <asp:ListItem>Historico</asp:ListItem>
                        <asp:ListItem>Anual</asp:ListItem>
                        <asp:ListItem>Mensual</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="d-flex justify-content-center my-2">
                    <div id="GraficaBarras" class="w-75 h-75 "></div>
                    <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="DropDownGraficaBarras_OnSelectedIndexChanged" ID="DropDownGraficaBarras" CssClass="form-control w-25 m-auto" runat="server" OnLoad="DropDownGraficaTraslados_Load">
                        <asp:ListItem>Historico</asp:ListItem>
                        <asp:ListItem>Anual</asp:ListItem>
                        <asp:ListItem>Mensual</asp:ListItem>
                    </asp:DropDownList>
                </div>


            </div>
        </form>
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

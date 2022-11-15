using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace LibSIS
{
    public class ObjSIS
    {
        public class Articulo
        {
            public string Descripcion;
            public decimal precioUnitario;
            public int stockActual;
            public int IdProveedor;
            public int stockMinimo;

            public int IDArticulo;

            public string InsertarArticulo(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_AgregarArticulo] '{Descripcion}', {precioUnitario}, {stockActual},{IdProveedor},{stockMinimo}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public DataTable VerificarArticulo(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[Articulo]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public DataTable VerificarArticuloTransporte(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[VWArticulo]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarArticulo(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarArticulo] {IDArticulo}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarArticulo(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarArticulo] {IDArticulo} , '{Descripcion}' , '{precioUnitario}','{stockActual}' ,'{IdProveedor}','{stockMinimo}'";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }

        }

        public class Proveedor
        {
            public int IDProvedor;
            public string razonSocial;
            public string Telefono;
            public string email;
            public string sitioWeb;


            public string InsertarProvedor(string strconexion)
            {
                string striSQL = $"EXECUTE [sp_AgregarProveedor] '{razonSocial}' , '{Telefono}' , '{email}' , '{sitioWeb}' ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public DataTable VerificarProveedor(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[Proveedor]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }

            public DataTable VerificarIDProveedor(string strconexion)
            {
                string striSQL = $"SELECT Proveedor.ID FROM [dbo].[Proveedor] WHERE razonSocial = '{razonSocial}'", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }

            public DataTable VerificarTODOSProveedor(string strconexion)
            {
                string striSQL = $"SELECT razonSocial FROM [dbo].[Proveedor]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }

            public string EliminarProveedor(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarProveedor]  {IDProvedor}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarProveedor(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarProveedor] {IDProvedor} , '{razonSocial}' , '{Telefono}','{email}' ,'{sitioWeb}'";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
        }

        public class Chofer
        {
            public string Nombre;
            public string Apellido;
            public string RFC;
            public decimal Salario;
            public int IDChofer;
            public string InsertarChofer(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_AgregarChofer] '{Nombre}', '{Apellido}', '{RFC}', '{Salario}' ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public DataTable VerificarChofer(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[Chofer]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public DataTable VerificarNombreChofer(string strconexion)
            {
                string striSQL = $"SELECT Nombre FROM [dbo].[Chofer]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public DataTable VerificaridNombreChofer(string strconexion)
            {
                string striSQL = $"SELECT ID FROM [dbo].[Chofer] WHERE Nombre='{Nombre}'", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarChofer(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarChofer]  {IDChofer}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarChofer(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarChofer] {IDChofer} , '{Nombre}' , '{Apellido}','{RFC}' ,'{Salario}'";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
        }

        public class DesperfectoMecanico
        {
            public int IDMedioTransporte;
            public string Fecha;
            public string Descripcion;
            public int IDDesperfectoMecanico;

            public string InsertarDesperfectoMecanico(string strconexion)
            {
                string[] Arefecha = Fecha.Split('/');
                string Fechabien = Arefecha[1] + "/" + Arefecha[0] + "/" + Arefecha[2];
                string striSQL = $"EXECUTE [dbo].[sp_AgregarDesperfectoMecanico] '{IDMedioTransporte}', '{Fechabien}', '{Descripcion}'";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }

            public DataTable VerificarDesperfectoMecanico(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[VWDesperfectoMecanico]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarDesperfectoMecanico(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarDesperfectoMecanico]  {IDDesperfectoMecanico}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarDesperfectoMecanico(string strconexion)
            {
                string[] Arefecha = Fecha.Split('/');
                string Fechabien = Arefecha[1] + "/" + Arefecha[0] + "/" + Arefecha[2];
                string striSQL = $"EXECUTE [dbo].[sp_EditarDesperfectoMecanico] {IDDesperfectoMecanico} , '{IDMedioTransporte}' , '{Fechabien}','{Descripcion}'";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
        }

        public class Cliente
        {

            public string Nombre;
            public string ApellidoPaterno;
            public string ApellidoMaterno;
            public string Telefono;
            public int IDCliente;
            public string InsertarCliente(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_AgregarCliente]  '{Nombre}', '{ApellidoPaterno}' , '{ApellidoMaterno}', '{Telefono}'";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public DataTable VerificarCliente(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[VWClienteDireccion]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }

            public DataTable VerificarTelefonoCliente(string strconexion)
            {
                string striSQL = $"SELECT Telefono FROM [dbo].[VWClienteDireccion] GROUP BY Telefono", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public DataTable VerificarIDConTelefonoCliente(string strconexion)
            {
                string striSQL = $"SELECT ID FROM Cliente WHERE Telefono = '{Telefono}'", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarCliente(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarCliente]  {IDCliente}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarCliente(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarCliente] {IDCliente} , '{Nombre}' , '{ApellidoPaterno}','{ApellidoMaterno}' ,'{Telefono}'";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
        }

        public class Direcciones
        {
            public int IDDireccion;
            public string Direccion;
            public string CodigoPostal;
            public string telelfono;

            public string InsertarDireccion(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_AgregarDireccion] '{Direccion}', '{CodigoPostal}' ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }


            public DataTable VerificarDirecciones(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[VWDireccion]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public DataTable VerificarDireccionesNumero(string strconexion)
            {
                string striSQL = $"SELECT DIR.Direccion FROM Direcciones DIR  " +
                    $"INNER JOIN ClienteDirecciones CLIDIR " +
                    $"ON CLIDIR.IdDireccion = DIR.ID " +
                    $"INNER JOIN CLIENTE AS CLI " +
                    $"ON CLI.ID = CLIDIR.IdCliente " +
                    $"WHERE CLI.Telefono = '{telelfono}'", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }

            public DataTable VerificarIDDireccionesNumero(string strconexion)
            {
                string striSQL = $"SELECT DIR.ID FROM Direcciones DIR  " +
                    $"INNER JOIN ClienteDirecciones CLIDIR " +
                    $"ON CLIDIR.IdDireccion = DIR.ID " +
                    $"INNER JOIN CLIENTE AS CLI " +
                    $"ON CLI.ID = CLIDIR.IdCliente " +
                    $"WHERE CLI.Telefono = '{telelfono}'", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public DataTable VerificarIDCONDireccionesNumero(string strconexion)
            {
                string striSQL = $"SELECT DIR.ID FROM Direcciones DIR WHERE DIR.Direccion = '{Direccion}'", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarDirecciones(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarTABLADireccion]  {IDDireccion}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarDireccion(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarDireccion] {IDDireccion} , '{Direccion}' , '{CodigoPostal}'";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
        }

        public class ClienteDirecciones
        {

            public int idCliente;
            public long idClienteANTIGUO;
            public long idDireccionANTIGUO;
            public int idDireccion;
            public int IDClienteDirecciones;
            public string InsertarClienteDirecciones(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_AgregarDireccion] {IDClienteDirecciones},{idCliente}, {idDireccion} ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string InsertarULTIMAClienteDirecciones(string strconexion)
            {
                string striSQL = $"insert into ClienteDirecciones values(CAST((SELECT IDENT_CURRENT('Cliente')) AS INT),CAST((SELECT IDENT_CURRENT('Direcciones')) AS INT))";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string InsertarClienteConOTraDirecciones(string strconexion)
            {
                string striSQL = $"insert into ClienteDirecciones values({idCliente},CAST((SELECT IDENT_CURRENT('Direcciones')) AS INT))";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public DataTable VerificarClienteDirecciones(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[ClienteDirecciones]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public DataTable VerificarIDClienteDirecciones(string strconexion)
            {
                string striSQL = $"SELECT ID FROM ClienteDirecciones AS CLIDIR WHERE CLIDIR.IdCliente = '{idCliente}' AND CLIDIR.IdDireccion = '{idDireccion}'  ", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarClienteDirecciones(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarDireccion] {idCliente},{idDireccion}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarClienteDirecciones(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarDireccion] {IDClienteDirecciones} , '{idCliente}' , '{idDireccion}' ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarTABLAClienteDirecciones(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarClienteDireccion] {idCliente} , {idDireccion} , {idClienteANTIGUO} ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarTODOClienteDirecciones(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarTODOClienteDireccion] {idCliente} , {idDireccion} , {idClienteANTIGUO} ,{idDireccionANTIGUO} ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
        }

        public class MedioTransporte
        {
            public int IDMedioTransporte;
            public string TipoCombustible;
            public string TipoTransporte;
            public int idChofer;
            public string InsertarMedioTransporte(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_AgregarMedioTransporte]  '{TipoCombustible}' , '{TipoTransporte}' , '{idChofer}' ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public DataTable VerificarIDMedioTransporte(string strconexion)
            {
                string striSQL = $"SELECT ID FROM [dbo].[MedioTransporte] WHERE TipoTransporte = '{TipoTransporte}'", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }

            public DataTable VerificarTODOSMedioTransporte(string strconexion)
            {
                string striSQL = $"SELECT TipoTransporte FROM [dbo].[MedioTransporte]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public DataTable VerificarMedioTransporte(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[VWMediotransporte]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarMedioTransporte(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarMedioTransporte]  {IDMedioTransporte}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarMedioTransporte(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarMedioTransporte] {IDMedioTransporte} , '{TipoCombustible}' , '{TipoTransporte}' , '{idChofer}'";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
        }

        public class Traslado
        {

            public string FechaRealizado;
            public string FechaProgramada;
            public float Costo;
            public int idMedioTransporte;
            public int idClienteDireccion;
            public bool Estatus;
            public int IDTraslado;

            public string InsertarTraslado(string strconexion)
            {
                string[] Arefecha = FechaProgramada.Split('/');
                string fechaprogramadabien = Arefecha[1] + "/" + Arefecha[0] + "/" + Arefecha[2];
                Arefecha = FechaRealizado.Split('/');
                string fecharealizadobien = Arefecha[1] + "/" + Arefecha[0] + "/" + Arefecha[2];
                string striSQL = $"EXECUTE [dbo].[sp_AgregarTraslado] '{fechaprogramadabien}' , '{fecharealizadobien}' , '{Costo}' , '{idMedioTransporte}' , '{idClienteDireccion}' , '{Estatus}' ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }

            public DataTable VerificarTraslado(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[VWTraslado]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarTraslado(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarTraslado]  {IDTraslado}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string ActualizarTraslado(string strconexion)
            {
                string[] Arefecha  = FechaProgramada.Split('/');
                string fechaprogramadabien = Arefecha[1]+"/"+Arefecha[0]+"/" + Arefecha[2];
                Arefecha = FechaRealizado.Split('/');
                string fecharealizadobien = Arefecha[1] + "/" + Arefecha[0] + "/" + Arefecha[2];
                string striSQL = $"EXECUTE [dbo].[sp_EditarTraslado] {IDTraslado} , '{fechaprogramadabien}' , '{fecharealizadobien}' , '{Costo}' , '{idMedioTransporte}' , '{idClienteDireccion}' , '{Estatus}' ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
        }

        public class ArticuloTransporte
        {

            public int idTransporte;
            public int idAntiguoTransporte;
            public int idarticulo;
            public string InsertarArticuloTransporte(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[ArticuloTransporte] ([idTransporte],[idArticulo]  )" +
                    $"VALUES( '{idTransporte}' , CAST((SELECT IDENT_CURRENT('Articulo')) AS INT)  )";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);

                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string EliminarArticuloTransporte(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarArticuloTransporte] {idarticulo}, {idTransporte} ";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }
            public string EditarArticuloTransporte(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EditarArticuloTransporte] {idarticulo}, {idTransporte} ,{idAntiguoTransporte}";
                string strError = "";
                int intRegistrosAfectados;
                intRegistrosAfectados = cslUtileriasBD.clsSQLServer.exeQuery(strconexion, striSQL, ref strError);
                if (strError == "")
                {
                    return "";
                }
                else
                {
                    return strError;
                }
            }

        }


    }

}


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
            public string EliminarArticulo(string strconexion)
            {
                string striSQL = $"DELETE [dbo].[sp_EliminarArticulo]  {IDArticulo}";
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
                string striSQL = $"EXECUTE [dbo].[sp_AgregarDesperfectoMecanico] '{IDMedioTransporte}', '{Fecha}', '{Descripcion}'";
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
                string striSQL = $"SELECT * FROM [dbo].[DesperfectoMecanico]", error = "";
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
                string striSQL = $"EXECUTE [dbo].[sp_EditarDesperfectoMecanico] {IDDesperfectoMecanico} , '{IDMedioTransporte}' , '{Fecha}','{Descripcion}'";
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
                string striSQL = $"SELECT * FROM [dbo].[Cliente]", error = "";
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
                string striSQL = $"SELECT * FROM [dbo].[Direcciones]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarDirecciones(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarDireccion]  {IDDireccion}";
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
            public DataTable VerificarClienteDirecciones(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[ClienteDirecciones]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }
            public string EliminarClienteDirecciones(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_EliminarDireccion]  {IDClienteDirecciones}";
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

            public DataTable VerificarMedioTransporte(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[MedioTransporte]", error = "";
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

            public string FechaProgramada;
            public string FechaRealizado;
            public float Costo;
            public int idMedioTransporte;
            public int idClienteDireccion;
            public int Estatus;
            public int IDTraslado;
            public string InsertarTraslado(string strconexion)
            {
                string striSQL = $"EXECUTE [dbo].[sp_AgregarTraslado] '{FechaProgramada}' , '{FechaRealizado}' , '{Costo}' , '{idMedioTransporte}' , '{idClienteDireccion}' , '{Estatus}' ";
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
                string striSQL = $"SELECT * FROM [dbo].[Traslado]", error = "";
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
                string striSQL = $"EXECUTE [dbo].[sp_EditarTraslado] {IDTraslado} , '{FechaProgramada}' , '{FechaRealizado}' , '{Costo}' , '{idMedioTransporte}' , '{idClienteDireccion}' , '{Estatus}' ";
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
            public int idArticulo;
            public string InsertarArticuloTransporte(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[ArticuloTransporte] ([idTransporte],[idArticulo]  )" +
                    $"VALUES( '{idTransporte}' , '{idArticulo}' )";
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


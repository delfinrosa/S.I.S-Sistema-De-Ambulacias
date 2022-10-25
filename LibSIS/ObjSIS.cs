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

            public int IDBusqueda;

            public string InsertarArticulo(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[Articulo] ([Descripcion],[precioUnitario],[stockActual] ,[IdProveedor] ,[stockMinimo] ) " +
                    $"VALUES ('{Descripcion}', {precioUnitario}, {stockActual},{IdProveedor},{stockMinimo})";
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
            public static DataTable VerificarArticulo(string strconexion)
            {
                string striSQL = $"SELECT * FROM [dbo].[Articulo]", error = "";
                DataTable tabla = cslUtileriasBD.clsSQLServer.getDatatable(strconexion, striSQL, ref error);
                return tabla;
            }

        }
        public class Proveedor
        {
            public string razonSocial;
            public string Telefono;
            public string email;
            public string sitioWeb;

            public string InsertarProvedor(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[Proveedor]([razonSocial],[Telefono],[email],[sitioWeb])" +
                    $"VALUES( '{razonSocial}', '{Telefono}', '{email}', '{sitioWeb}')";
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

            public string InsertarChofer(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[Chofer] ([Nombre],[Apellido],[RFC],[Salario])" +
                    $"VALUES( '{Nombre}', '{Apellido}', '{RFC}', '{Salario}')";
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

            public string InsertarDesperfectoMecanico(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[DesperfectoMecanico] ([IDMedioTransporte],[Fecha],[Descripcion])" +
                    $"VALUES( '{IDMedioTransporte}', '{Fecha}', '{Descripcion}')";
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

            public string InsertarCliente(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[Cliente] ([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Telefono])" +
                    $"VALUES( '{Nombre}', '{ApellidoPaterno}' , '{ApellidoMaterno}', '{Telefono}')";
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

            public string Direccion;
            public string CodigoPostal;

            public string InsertarDireccion(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[Direcciones] ([Direccion],[CodigoPostal])" +
                    $"VALUES( '{Direccion}', '{CodigoPostal}' )";
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
            public int ID;
            public string InsertarClienteDirecciones(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[ClienteDirecciones] ([ID],[idCliente],[idDireccion])" +
                    $"VALUES( {ID},{idCliente}, {idDireccion} )";
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

            public string TipoCombustible;
            public string TipoTransporte;
            public int idChofer;
            public string InsertarMedioTransporte(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[MedioTransporte] ([TipoCombustible],[TipoTransporte],[idChofer])" +
                    $"VALUES( '{TipoCombustible}' , '{TipoTransporte}' , '{idChofer}' )";
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
            public string InsertarTraslado(string strconexion)
            {
                string striSQL = $"INSERT INTO [dbo].[Traslado] ([FechaProgramada],[FechaRealizado] ,[Costo],[idMedioTransporte],[idClienteDireccion],[Estatus] )" +
                    $"VALUES( '{FechaProgramada}' , '{FechaRealizado}' , '{Costo}' , '{idMedioTransporte}' , '{idClienteDireccion}' , '{Estatus}' )";
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


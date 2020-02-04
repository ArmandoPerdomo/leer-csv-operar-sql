using LeerDeCsvYOperarSql.Models;
using System;
using System.Data.SqlClient;
using System.Text;
using TinyCsvParser;

namespace LeerDeCsvYOperarSql
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePathName = @"C:\CargaClienteGeneralCargo\0_carga_cliente_general_cargo.sql";
            string createTableSql = @"CREATE TABLE clientes_argelia(
                TipoCliente NVARCHAR(MAX),
                Numero NVARCHAR(MAX),
                Nombres NVARCHAR(MAX), 
                Apellidos NVARCHAR(MAX),
                PaisNacimiento INT,
                FechaNacimiento DATE,
                Genero INT,
                TipoIdentificacion INT,
                Identificacion NVARCHAR(MAX), 
                FechaExpId DATE,
                DireccionResidencia NVARCHAR(MAX),
                EstadoCivil INT,
                Email NVARCHAR(MAX), 
                TelefonoMovil NVARCHAR(MAX),
                TelefonoResidencia NVARCHAR(MAX),
                CodigoPostal NVARCHAR(MAX),
                Sector INT,
                OcupacionActual INT,
                NombreRepresentante NVARCHAR(MAX),
                ApellidoRepresentante NVARCHAR(MAX),
                EsProveedor BIT
                );";

            CsvParserOptions options = new CsvParserOptions(true, ';');
            CsvClienteMapping mapping = new CsvClienteMapping();
            CsvParser<Cliente> csvParser = new CsvParser<Cliente>(options, mapping);

            var result = csvParser
                .ReadFromFile(@"C:\CargaClienteGeneralCargo\Fuente.csv", Encoding.UTF8).GetEnumerator();
           

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathName, false, Encoding.UTF8))
            {
                file.WriteLine("USE HubQueryEngine;");
                file.WriteLine("GO");
                file.WriteLine(createTableSql);
                file.WriteLine("GO");
                file.WriteLine(@"INSERT INTO dbo.clientes_argelia (TipoCliente, Nombres, Apellidos, PaisNacimiento, FechaNacimiento, Genero, TipoIdentificacion, Identificacion, FechaExpId, DireccionResidencia, EstadoCivil, Email, TelefonoMovil, TelefonoResidencia, CodigoPostal, Sector, OcupacionActual, NombreRepresentante, ApellidoRepresentante, EsProveedor) VALUES");
                while (result.MoveNext())
                {
                    var c = result.Current.Result;
                    file.WriteLine(@"(N'"+ c.TipoCliente + "', N'" + c.Nombres.Replace("'", "''") +"', N'"+ c.Apellidos.Replace("'", "''") + "', " + GetValueOrNull(c.PaisNacimiento) + ", " + GetValueOrNull(c.FechaNacimiento) + ", " + GetValueOrNull(c.Genero) + ", " + GetValueOrNull(c.TipoIdentificacion) + ", " + GetValueOrNull(c.Identificacion) + ", " + GetValueOrNull(c.FechaExpId) + ", " + GetValueOrNull(c.DireccionResidencia) + ", " + GetValueOrNull(c.EstadoCivil) + ", " + GetValueOrNull(c.Email) + ", " + GetValueOrNull(c.TelefonoMovil) + ", " + GetValueOrNull(c.TelefonoResidencia) + ", " + GetValueOrNull(c.CodigoPostal) + ", " + GetValueOrNull(c.Sector) + ", " + GetValueOrNull(c.OcupacionActual) + ", " + GetValueOrNull(c.NombreRepresentante) + ", " + GetValueOrNull(c.ApellidoRepresentante) + ", "+ c.EsProveedor +"),");
                }
            }

            Console.WriteLine("Terminado, presione ENTER para continuar");
            Console.ReadLine();
        }

        public static string GetValueOrNull(string value)
        {
            return string.IsNullOrEmpty(value) ? "NULL" : "N'"+ value.Replace("'", "''") + "'";
        }

        public static string GetValueOrNull(int? value)
        {
            return !value.HasValue ? "NULL" : value.ToString();
        }

        public static string GetValueOrNull(DateTime? value)
        {
            return !value.HasValue ? "NULL" : "CONVERT(DATE, '"+value.Value.ToShortDateString()+"', 103)";
        }
    }
}

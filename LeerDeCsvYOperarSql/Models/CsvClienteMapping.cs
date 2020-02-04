using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace LeerDeCsvYOperarSql.Models
{
    class CsvClienteMapping: CsvMapping<Cliente>
    {
        public CsvClienteMapping(): base()
        {
            MapProperty(0, x => x.TipoCliente);
            MapProperty(1, x => x.Numero);
            MapProperty(2, x => x.Nombres);
            MapProperty(3, x => x.Apellidos);
            MapProperty(4, x => x.PaisNacimiento);
            MapProperty(5, x => x.FechaNacimiento);
            MapProperty(6, x => x.Genero);
            MapProperty(7, x => x.TipoIdentificacion);
            MapProperty(8, x => x.Identificacion);
            MapProperty(9, x => x.FechaExpId);
            MapProperty(10, x => x.DireccionResidencia);
            MapProperty(11, x => x.EstadoCivil);
            MapProperty(12, x => x.Email);
            MapProperty(13, x => x.TelefonoMovil);
            MapProperty(14, x => x.TelefonoResidencia);
            MapProperty(15, x => x.CodigoPostal);
            MapProperty(16, x => x.Sector);
            MapProperty(17, x => x.OcupacionActual);
            MapProperty(18, x => x.NombreRepresentante);
            MapProperty(19, x => x.ApellidoRepresentante);
            MapProperty(20, x => x.EsProveedor);
        }
    }
}

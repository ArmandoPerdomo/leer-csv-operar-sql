using System;

namespace LeerDeCsvYOperarSql
{
    class Cliente
    {
        public string TipoCliente { get; set; }
        public string Numero { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? PaisNacimiento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Genero { get; set; }
        public int? TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public DateTime? FechaExpId { get; set; }
        public string DireccionResidencia { get; set; }
        public int? EstadoCivil { get; set; }
        public string Email { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoResidencia { get; set; }
        public string CodigoPostal { get; set; }
        public int? Sector { get; set; }
        public int? OcupacionActual { get; set; }
        public string NombreRepresentante { get; set; }
        public string ApellidoRepresentante { get; set; }
        public int EsProveedor { get; set; }
    }
}

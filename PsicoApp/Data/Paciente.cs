using System;
using System.Collections.Generic;

namespace PsicoApp.Data
{
    public partial class Paciente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Dni { get; set; }
        public string? Departamento { get; set; }
        public string? Email { get; set; }
        public string? Tipo { get; set; }
        public string? Estatus { get; set; }
        public DateTime? Fecha { get; set; }
    }
}

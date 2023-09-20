using System;
using System.Collections.Generic;

namespace PsicoApp.Data
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Password { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Dni { get; set; }
    }
}

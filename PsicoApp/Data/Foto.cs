using System;
using System.Collections.Generic;

namespace PsicoApp.Data
{
    public partial class Foto
    {
        public int Id { get; set; }
        public byte[]? Imagenes { get; set; }
        public string? Dni { get; set; }
        public string? Usuario { get; set; }
    }
}

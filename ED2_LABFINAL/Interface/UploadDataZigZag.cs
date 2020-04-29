using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Interface
{
    public class UploadDataZigZag : IUploadDataZigZag<int>
    {
        public IFormFile files { get; set; }
        public int TamañoCarriles { get; set; }
        public string NuevoNombre { get; set; }
        public string Palabra { get; set; }
        public int Tamaño { get; set; }
        IFormFile IUploadDataZigZag<int>.ArchivoCargado { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Interface
{
    public class UploadDataCipher : IUploadDataChipher<int>
    {
        public IFormFile files { get; set; }
        public int p { get; set; }
        public int q { get; set; }
        public int Tamaño { get; set; }

    }
}

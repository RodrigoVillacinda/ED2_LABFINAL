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
        public IFormFile CipherKeyRSA { get; set; }
        public IFormFile CipherKeyDH { get; set; }
        public int p { get; set; }
        public int q { get; set; }
        public int Tamaño { get; set; }
        public int c { get; set; }
        public int d { get; set; }
        public int n { get; set; }


    }
}

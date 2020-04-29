using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Interface
{
    public interface IUploadDataChipher<T>
    {

        IFormFile files { get; set; }
        int p { get; set; }
        int q { get; set; }
        int Tamaño { get; set; }
    }
}

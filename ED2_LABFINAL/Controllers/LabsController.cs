using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using D2_LABFINAL.Models.Btree;
using ED2_LABFINAL.Implementation.Asymmetric;
using ED2_LABFINAL.Implementation.Ciphers;
using ED2_LABFINAL.Implementation.Compression;
using ED2_LABFINAL.Interface;
using ED2_LABFINAL.Models.List;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ED2_LABFINAL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class LabsController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public LabsController(IWebHostEnvironment environment)
        {
            _environment = environment;

        }
        public class FileUploadAPI
        {
            public IFormFile files { get; set; }

        }

        //Laboratorio 0----------------
        [HttpGet("list/peek/movie")]
        public IEnumerable<Movie> GetMovie()
        {
            if (Models.List.Data.Instance.movies.Count > 10)
            {
                Models.List.Data.Instance.movies.Reverse();
                return Models.List.Data.Instance.movies.GetRange(0, 10);
            }
            return Models.List.Data.Instance.movies;
        }

        [HttpPost("list/insert/movie")]
        public IEnumerable<Movie> PostMovie([FromBody] Movie movie)
        {
            Models.List.Data.Instance.movies.Add(movie);
            return Models.List.Data.Instance.movies;
        }
        //fin laboratorio0----------------

        //Laboratoio 1-------------------
        [HttpGet("btree/peek/drinks")]
        public IEnumerable<Bebidas> GetDrinks()
        {

            return D2_LABFINAL.Models.Btree.Data.Instance.arbol.Recorrido();
        }

        /// /{id?} 
        [HttpGet("btree/search/drinks")]
        public string GetDrinksId(int id)
        {
            return "value";
        }

        [HttpPost("btree/insert/drinks")]
        public IEnumerable<Bebidas> PostDrinks([FromBody] Bebidas bebida)
        {
            D2_LABFINAL.Models.Btree.Data.Instance.bebidas.Add(bebida);
            D2_LABFINAL.Models.Btree.Data.Instance.arbol.Insertar(D2_LABFINAL.Models.Btree.Data.Instance.bebidas);
            return D2_LABFINAL.Models.Btree.Data.Instance.bebidas;
        }
        //FinLaboratorio1----------------

        //Laboratorio4-------------------
        [HttpPost("compression/compress/lzw")]
        public async Task<string> post([FromForm]FileUploadAPI objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                        string temporal = objFile.files.FileName.ToString();
                        ImplementationLZW imp = new ImplementationLZW(fileStream.Name, s, temporal);
                        imp.Comprimir();


                        return "\\Upload\\" + objFile.files.FileName;

                    }

                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }

        [HttpPost("compression/decompress/lzw")]
        public async Task<string> decompress([FromForm]FileUploadAPI objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                        string temporal = objFile.files.FileName.ToString();
                        ImplementationLZW imp = new ImplementationLZW(fileStream.Name, s, temporal);
                        imp.Descomprimir();
                        return "\\Upload\\" + objFile.files.FileName;

                    }


                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }
        //FinLaboratorio4----------------

        //FinLaboratorio5----------------
        [HttpPost("cif/cipher/zigzag")]
        public async Task<string> postCipherZZ([FromForm]UploadDataZigZag objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                        //Implementacion imp = new Implementacion(fileStream.Name, s);
                        ImplementationZigZag.Cifrado(fileStream.Name, s, objFile.TamañoCarriles);

                        return "\\Upload\\" + objFile.files.FileName;

                    }


                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }

        [HttpPost("cif/decipher/zigzag")]
        public async Task<string> postDecipherZZ([FromForm]UploadDataZigZag objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;

                        ImplementationZigZag.Descifrado(fileStream.Name, s, objFile.TamañoCarriles);


                        return "\\Upload\\" + objFile.files.FileName;

                    }


                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }

        [HttpPost("cif/cipher/caesar")]
        public async Task<string> postCipherCaeser([FromForm]UploadDataZigZag objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                        //Implementacion imp = new Implementacion(fileStream.Name, s);
                        ImplementationCaesar.Cifrado(fileStream.Name, s, objFile.Palabra);

                        return "\\Upload\\" + objFile.files.FileName;

                    }
                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }

        [HttpPost("cif/decipher/caesar")]
        public async Task<string> postDecipherCaesar([FromForm]UploadDataZigZag objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;

                        ImplementationCaesar.Descifrado(fileStream.Name, s, objFile.Palabra);


                        return "\\Upload\\" + objFile.files.FileName;

                    }


                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }

        [HttpPost("cif/cipher/vertical")]
        public async Task<string> postCipherVertical([FromForm]UploadDataZigZag objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                        //Implementacion imp = new Implementacion(fileStream.Name, s);
                        ImplementationVertical.Cifrado(fileStream.Name, s, objFile.Tamaño);

                        return "\\Upload\\" + objFile.files.FileName;

                    }


                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }

        [HttpPost("cif/decipher/vertical")]
        public async Task<string> postDecipherVertical([FromForm]UploadDataZigZag objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;

                        ImplementationVertical.Descifrado(fileStream.Name, s, objFile.Tamaño);


                        return "\\Upload\\" + objFile.files.FileName;

                    }


                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }

        [HttpPost("cif/cipher/espiral")]
        public async Task<string> postCipherEspiral([FromForm]UploadDataZigZag objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                        //Implementacion imp = new Implementacion(fileStream.Name, s);
                        ImplementationEspiral.Cifrado(fileStream.Name, s, objFile.Tamaño);

                        return "\\Upload\\" + objFile.files.FileName;

                    }


                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }

        [HttpPost("cif/decipher/espiral")]
        public async Task<string> postDecipherEspiral([FromForm]UploadDataZigZag objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;

                        ImplementationEspiral.Descifrado(fileStream.Name, s, objFile.Tamaño);

                        return "\\Upload\\" + objFile.files.FileName;
                    }

                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        //FinLaboratorio5----------------

        //Laboratorio6------------------
        [HttpPost("asymmetric/cipher/keypublic")]
        public async Task<string> post([FromForm]UploadDataCipher objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                        ImplementationCaesar2.Cifrado(fileStream.Name, s, objFile.Tamaño, objFile.p, objFile.q);

                        return "\\Upload\\" + objFile.files.FileName;

                    }


                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }

        [HttpPost("asymmetric/cipher/caesar2")]
        public async Task<string> postCipher([FromForm]UploadDataCipher objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                        Models.Asymmetric.Data.Instance.p = objFile.p;
                        Models.Asymmetric.Data.Instance.q = objFile.q;
                        Models.Asymmetric.Data.Instance.tamaño = objFile.Tamaño;

                        ImplementationCaesar2.CifradoCaesar(fileStream.Name, s, Models.Asymmetric.Data.Instance.tamaño, Models.Asymmetric.Data.Instance.p, Models.Asymmetric.Data.Instance.q);

                        return "\\Upload\\" + objFile.files.FileName;

                    }


                }
                else
                {
                    return "Failed";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



        }
        //FinLaboratorio6---------------

    }
}
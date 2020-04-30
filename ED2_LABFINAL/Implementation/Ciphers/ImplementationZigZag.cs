using ED2_LABFINAL.Models.Ciphers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Implementation.Ciphers
{
    public static class ImplementationZigZag
    {
        public static void Cifrado(string path, string root, int niveles)
        {
            string descomprimido = "";
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\ZigZag\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\ZigZag\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            ZigZagEncoded cifrado = new ZigZagEncoded(niveles, texto);
            string txtcifrado = cifrado.Cifrado();

            List<char> bytecompress = new List<char>();


            root = root + @"\\Upload\\ZigZag\\cifrado.ZigZag";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }
            }
        }
        public static void Descifrado(string path, string root, int niveles)
        {
            string descomprimido = "";
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\ZigZag\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\ZigZag\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            ZigZagDecoded descifrado = new ZigZagDecoded(niveles, texto);
            string txtdescifrado = descifrado.Descifrado();
            txtdescifrado.Replace("ascii 197", "");

            root = root + @"\\Upload\\ZigZag\\descifradoZigZag.txt";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtdescifrado)
                {
                    outputFile.Write(caracter.ToString());

                }
            }
        }

    }
}

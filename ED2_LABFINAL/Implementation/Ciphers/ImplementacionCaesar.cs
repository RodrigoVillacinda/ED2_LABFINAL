using ED2_LABFINAL.Models.Ciphers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Implementation.Ciphers
{
    public class ImplementationCaesar
    {
        public static void Cifrado(string path, string root, string palabra)
        {
            string descomprimido = "";
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\Caesar\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Caesar\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            Caesar cifrado = new Caesar(palabra, texto);
            string txtcifrado = cifrado.Cifrado();

            root = root + @"\\Upload\\Caesar\\cifrado.Caesar";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }

            }
        }

        public static void Descifrado(string path, string root, string palabra)
        {
            string descomprimido = "";
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\Caesar\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Caesar\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            Caesar descifrado = new Caesar(palabra, texto);
            string txtdescifrado = descifrado.Descifrado();
            txtdescifrado.Replace("ascii 197", "");

            root = root + @"\\Upload\\Caesar\\descifradoCaesar.txt";
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

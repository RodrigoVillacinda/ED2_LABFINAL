using ED2_LABFINAL.Models.Ciphers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Implementation.Ciphers
{
    public class ImplementationVertical
    {
        public static void Cifrado(string path, string root, int tamaño)
        {
            string texto = System.IO.File.ReadAllText(@path);
            RutaVertical cifrado = new RutaVertical(texto, tamaño);
            string txtcifrado = cifrado.Cifrado();

            List<char> bytecompress = new List<char>();

            root = root + @"\\Upload\\cifrado.Vertical";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }

            }
        }

        public static void Descifrado(string path, string root, int tamaño)
        {
            string texto = System.IO.File.ReadAllText(@path);
            RutaVertical descifrado = new RutaVertical(texto, tamaño);
            string txtdescifrado = descifrado.Descifrado();
            txtdescifrado.Replace("ascii 197", "");

            root = root + @"\\Upload\\descifradoRuta.txt";
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

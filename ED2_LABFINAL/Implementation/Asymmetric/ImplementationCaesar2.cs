using ED2_LABFINAL.Models.Asymmetric;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Implementation.Asymmetric
{
    public class ImplementationCaesar2
    {
        public static void Cifrado(string path, string root, int tamaño, int p, int q)
        {
            string rootPrivate;
            string keyPrivate;
            rootPrivate = root + @"\\Upload\\Asymmetric\\KeyPrivates.txt";
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\Asymmetric\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Asymmetric\\");
            }
            DiffieHellman dh = new DiffieHellman(p, tamaño);
            RSA rsa = new RSA(p, q);
            string texto = System.IO.File.ReadAllText(@path);
            rsa.ObtenerFI();
            rsa.ObtenerE();

            string txtcifrado = "Cipher: RSA" + Environment.NewLine + "Clave pública: " + "( " + rsa.ObtenerN().ToString() + " , " + rsa.ObtenerD().ToString() + " )"
                + Environment.NewLine + " " + Environment.NewLine + "Cipher: Diffie-Hellman" + Environment.NewLine + "Clave pública: " +
             " ( " + dh.SetAlice() + " )";

            keyPrivate = "Clave privada: " + "( " + rsa.ObtenerN().ToString() + " , " + rsa.ObtenerE().ToString() + " )";
            File.WriteAllText(@rootPrivate, keyPrivate);
            root = root + @"\\Upload\\Asymmetric\\KeyPublics.txt";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }
            }
           

        }

        public static void CifradoCaesar(string path, string root, int tamaño, int p, int q)
        {
            string cifradoRSA = "";
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\Asymmetric\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Asymmetric\\");
            }
            DiffieHellman dh = new DiffieHellman(p, tamaño);
            RSA rsa = new RSA(p, q);
            string rootdh = root;
            string texto = System.IO.File.ReadAllText(@path);
            rsa.ObtenerFI();
            rsa.ObtenerE();
            rsa.ObtenerN();
            rsa.ObtenerD();
            int tamañocifrado = rsa.encriptar(tamaño);
            Caesar2 caesar = new Caesar2(tamaño, texto);
            string txtcifrado = caesar.Cifrado();
            cifradoRSA = root;
            
            root = root + @"\\Upload\\Asymmetric\\Caesar2.txt";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }
            }
            string txtcifradoDH;
            int tamañoDH = Int32.Parse(dh.SetSecretKey());
            Caesar2 caesar2 = new Caesar2(tamañoDH, texto);
            txtcifradoDH = caesar2.Cifrado();
            cifradoRSA = cifradoRSA + @"\\Upload\\Asymmetric\\LLaveCifrada.RSA";
            rootdh = rootdh + @"\\Upload\\Asymmetric\\LlaveCifrada.dh";
            File.WriteAllText(@cifradoRSA, tamañocifrado.ToString());
            using (StreamWriter outputFile = new StreamWriter(rootdh))
            {
                foreach (char caracter in tamañoDH.ToString())
                {
                    outputFile.Write(caracter.ToString());
                }
            }

        }

    }
}

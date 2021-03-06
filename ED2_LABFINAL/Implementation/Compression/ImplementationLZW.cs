﻿using ED2_LABFINAL.Models.Compression;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Implementation.Compression
{
    public class ImplementationLZW
    {
            private static string NombreTemporal;
            public double FactorCompresion;
            public double RazonCompresion;
            public double PorcentajeCompresion;
            public string path = "";
            public string root = ""; 
            
            public ImplementationLZW(string path, string root, string temporal)
            {
                this.path = path;
                this.root = root;
                NombreTemporal = temporal;
            }

            public void Comprimir()
            {
                string directorio;
                directorio = root + @"\\Upload\\";
                if (!Directory.Exists(directorio + "\\Compresion\\"))
                {
                    DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Compresion\\");
                }
                List<int> comprimido = new List<int>();
                string text = System.IO.File.ReadAllText(@path);
                comprimido = LZW.Compresion(text);
                List<char> bytecompress = new List<char>();

                foreach (int numero in comprimido)
                {
                    bytecompress.Add((char)numero);
                }
                NombreTemporal = NombreTemporal.Replace(".txt","");
                root = root + @"\\Upload\\Compresion\\" + NombreTemporal +"compresion" + ".lzw";
                
                using (StreamWriter outputFile = new StreamWriter(root))
                {
                    foreach (char caracter in bytecompress)
                    {
                        outputFile.Write(caracter.ToString());
                    }
                }
               
        }

            public void Descomprimir()
            {
                string descomprimido = "";
                string directorio;
                directorio = root + @"\\Upload\\";
                if (!Directory.Exists(directorio + "\\Compresion\\"))
                {
                    DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Compresion\\");
                }
                string comprimido = System.IO.File.ReadAllText(@path);
                const int bufferLength = 100;
                List<int> bytedecompress = new List<int>();

                var buffer = new char[bufferLength];
                using (var file = new FileStream(path, FileMode.Open))
                {
                    using (var reader = new BinaryReader(file))
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            buffer = reader.ReadChars(bufferLength);
                            foreach (var item in buffer)
                            {

                                bytedecompress.Add((int)Convert.ToChar(item));
                            }


                        }

                    }

                }

                descomprimido = LZW.Descompresion(bytedecompress);
                string rootRazonFactor = root;
                NombreTemporal = NombreTemporal.Replace(".lzw", "");
                root = root + @"\\Upload\\Compresion\\" + NombreTemporal + ".txt";
                File.WriteAllText(@root, descomprimido);
                FactorCompresion = Convert.ToDouble(comprimido.Length) / Convert.ToDouble(descomprimido.Length);
                RazonCompresion = Convert.ToDouble( descomprimido.Length) / Convert.ToDouble( comprimido.Length);
                PorcentajeCompresion = ((FactorCompresion / RazonCompresion)*100);
                double raz = Math.Round(RazonCompresion, 2);
                double fac = Math.Round(FactorCompresion, 2);
                double porcent = Math.Round(PorcentajeCompresion, 2);    
                rootRazonFactor = rootRazonFactor + @"\\Upload\\Compresion\\FactorRazon.txt";
                File.WriteAllText(@rootRazonFactor, "Razon de compresión: " + raz.ToString() + Environment.NewLine + "Factor de compresión: " + fac.ToString() + Environment.NewLine + "Porcentaje de compresión: " + porcent.ToString() + "%");
                

            }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Models.Ciphers
{
    public class RutaVertical
    {
        public int m;
        public int n;
        public string Texto;
        public List<char> ListCifrado = new List<char>();
        public char[,] MatrizCifrado;
        public List<char> ListaTexto = new List<char>();
        public RutaVertical(string texto, int tamaño)
        {
            Texto = texto;
            m = tamaño;
            n = (texto.Length) / (tamaño) + 1;
        }

        public string Cifrado()
        {
            string cifrado = "";
            MatrizCifrado = new char[n, m];
            ListaTexto = Texto.ToArray().ToList();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (ListaTexto.Count() != 0)
                    {
                        MatrizCifrado[j, i] = ListaTexto.ElementAt(0);
                        ListaTexto.RemoveAt(0);
                    }
                    else
                    {
                        MatrizCifrado[j, i] = '↔';
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ListCifrado.Add(MatrizCifrado[i, j]);
                }
            }
            cifrado = string.Join('┼', ListCifrado);
            cifrado = cifrado.Replace("┼", "");
            return cifrado;

        }

        public string Descifrado()
        {
            string descifrado = "";
            n = n - 1;
            MatrizCifrado = new char[n, m];
            ListaTexto = Texto.ToArray().ToList();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (ListaTexto.Count() != 0)
                    {
                        MatrizCifrado[i, j] = ListaTexto.ElementAt(0);
                        ListaTexto.RemoveAt(0);
                    }

                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ListCifrado.Add(MatrizCifrado[j, i]);
                }
            }
            descifrado = string.Join('┼', ListCifrado);
            descifrado = descifrado.Replace("┼", "");
            return descifrado;
        }

    }
}

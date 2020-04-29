using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Models.Ciphers
{
    public class RutaEspiral
    {

        public int m;
        public int n;
        public string Texto;
        public string TextoAux;
        public List<char> ListCifrado = new List<char>();
        public char[,] matriz;
        public List<char> ListaTexto = new List<char>();
        public RutaEspiral(string texto, int tamaño)
        {
            Texto = texto;
            m = tamaño;
            n = (texto.Length) / (tamaño) + 1;
        }

        public string Cifrado()
        {
            string cifrado = "";
            matriz = new char[m, m];
            ListaTexto = Texto.ToArray().ToList();

            llenarmatrizcaracol(matriz, m, m);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ListCifrado.Add(matriz[i, j]);
                }
            }
            cifrado = string.Join('┼', ListCifrado);
            cifrado = cifrado.Replace("┼", "");
            return cifrado;
        }
        public string Descifrado()
        {
            string descifrado = "";
            matriz = new char[m, m];
            char[,] matrizAux = new char[m, m]; 
            ListaTexto = Texto.ToArray().ToList();

           

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matriz[i, j] = ListaTexto.ElementAt(0);
                    ListaTexto.RemoveAt(0);
                    //ListCifrado.Add(matriz[j, i]);
                }
            }
            llenarmatrizcaracol(matrizAux, m, m);
            descifrado = string.Join('┼', ListCifrado);
            descifrado = descifrado.Replace("┼", "");
            return descifrado;

        }
        public void llenarmatrizcaracol(char[,] mat, int n, int m)
        {
            int fil, col, aux, cont, k;
            cont = 1;
            for (k = 0; k < m; k++)
            {
                col = k;
                for (fil = k; fil <= (m - 1 - k); fil++)
                {
                    if (ListaTexto.Count() != 0)
                    {
                        ListCifrado.Add( matriz[fil, col] );
                        
                    }
                    else
                    {
                        ListCifrado.Add(matriz[fil, col]);
                    }
                }
                fil = m - 1 - k;
                for (col = k + 1; col <= n - 1 - k; col++)
                {
                    if (ListaTexto.Count() != 0)
                    {
                        ListCifrado.Add(matriz[fil, col]);

                    }
                    else
                    {
                        ListCifrado.Add(matriz[fil, col]);
                    }
                }
                col = n - 1 - k;
                for (fil = m - 2 - k; fil >= k; fil--)
                {
                    if (ListaTexto.Count() != 0)
                    {
                        ListCifrado.Add(matriz[fil, col]);
                    }
                    else
                    {
                        ListCifrado.Add(matriz[fil, col]);
                    }
                }
                fil = k;
                for (col = n - 2 - k; col >= k + 1; col--)
                {
                    if (ListaTexto.Count() != 0)
                    {
                        ListCifrado.Add(matriz[fil, col]);
                    }
                    else
                    {
                        ListCifrado.Add(matriz[fil, col]);
                    }
                }
            }
            return;
        }
    }
}

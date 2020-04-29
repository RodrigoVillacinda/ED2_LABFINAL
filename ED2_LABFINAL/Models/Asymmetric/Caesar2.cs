using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Models.Asymmetric
{
    public class Caesar2
    {
        public string Palabra;
        public string Texto;
        public List<char> ListaPalabra;
        public List<char> Abecedario;
        public List<char> ListaTexto = new List<char>();
        public List<char> ListaCifrada = new List<char>();
        public Dictionary<char, char> DicccionarioCifrado = new Dictionary<char, char>();
        public Caesar2(int tamaño, string texto)
        {
            this.tamaño = tamaño;
            this.Texto = texto;
            Abecedario = "abcdefghijklmnñopqrstuvwxyz".ToArray().ToList();
            ListaTexto = Texto.ToArray().ToList();
            GenerarPalabra();
        }

        private int tamaño { get; set; }

        public string Cifrado()
        {
            int posicion = 0;
            string cifrado = "";
            PalabraAbecedario();
            for (int i = 0; i < ListaTexto.Count(); i++)
            {
                if (Abecedario.Contains(ListaTexto.ElementAt(i)))
                {
                    posicion = Abecedario.IndexOf(ListaTexto.ElementAt(i));
                    ListaCifrada.Add(ListaPalabra.ElementAt(posicion));
                }
                else
                {
                    ListaCifrada.Add(ListaTexto.ElementAt(i));
                }

            }
            cifrado = string.Join('↔', ListaCifrada);
            cifrado = cifrado.Replace("↔", "");
            return cifrado;
        }

        public void PalabraAbecedario()
        {
            int posicion = 0;
            ListaPalabra = Palabra.ToArray().ToList();
            ListaPalabra = ((from s in ListaPalabra select s).Distinct()).ToList();
            ListaPalabra = ListaPalabra.Union(Abecedario).ToList();

            ListaPalabra = ((from s in ListaPalabra select s).Distinct()).ToList();


        }

        public void GenerarPalabra()
        {
            List<char> palabra = new List<char>();
            Random rnd = new Random();
            char randomChar = ' ';


            for (int i = 0; i < tamaño; i++)
            {
                randomChar = (char)rnd.Next('a', 'z');

                if (!palabra.Contains(randomChar))
                {
                    palabra.Add(randomChar);
                }
                else
                {
                    tamaño = tamaño - 1;
                }
            }

            Palabra = string.Join('↔', palabra);
            Palabra = Palabra.Replace("↔", "");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Models.Btree
{
    class Arbol<T> where T : IComparable
    {
        public Arbol(int grado)
        {
            Grado = grado;
            this.Raiz = new Nodo<T>();
        }

        public int Grado { get; set; }
        public Nodo<T> Raiz { get; set; }
        private static bool Vacio { get; set; }
        private static bool Lleno { get; set; }
        List<T> Listado = new List<T>();

        public void Insertar(List<T> valores)
        {

            while (this.Raiz.Values.Count < Grado && valores.Count != 0)
            {
                this.InsercionNodoActivo(this.Raiz, valores.First());
                valores.RemoveAt(0);
            }

            if (valores.Count > 0)
            {
                Nodo<T> nodoAux = this.Raiz;
                this.Raiz = new Nodo<T>();
                this.Raiz.Children.Add(nodoAux);
                this.SepararNodo(this.Raiz, nodoAux, 0);

                for (int i = 0; i <= valores.Count; i++)
                {
                    this.InsercionNodoActivo(this.Raiz, valores.First());
                    valores.RemoveAt(0);
                    Insertar(valores);
                }
            }

        }

        public void InsercionNodoActivo(Nodo<T> nodo, T valor)
        {

            int puntero = nodo.Values.TakeWhile(x => valor.CompareTo(x) >= 0).Count();

            if (nodo.IsLeaf)
            {
                nodo.Values.Insert(puntero, valor);
                return;
            }

            Nodo<T> hijo = nodo.Children[puntero];
            if (hijo.Values.Count == Grado)
            {
                this.SepararNodo(nodo, hijo, puntero);
                if (valor.CompareTo(nodo.Values[puntero]) > 0)
                {
                    puntero++;
                }
            }

            this.InsercionNodoActivo(nodo.Children[puntero], valor);
        }

        public void SepararNodo(Nodo<T> padre, Nodo<T> hermano, int puntero)
        {
            var nuevoNodo = new Nodo<T>();

            padre.Values.Insert(puntero, hermano.Values[this.Grado - 2]);
            padre.Children.Insert(puntero + 1, nuevoNodo);

            nuevoNodo.Values.AddRange(hermano.Values.GetRange(this.Grado - 1, this.Grado - 2));

            hermano.Values.RemoveRange(Grado - 2, Grado - 1);

            if (!hermano.IsLeaf)
            {
                nuevoNodo.Children.AddRange(hermano.Children.GetRange(Grado - 1, Grado - 1));
                hermano.Children.RemoveRange(Grado - 1, Grado - 1);
            }

        }

        public List<T> Recorrido()
        {
            var lista = new List<T>();
            bool existe = true;
            int i = 0;

            for (int j = 0; j < this.Raiz.Children.Count; j++)
            {
                for (int x = 0; x < this.Raiz.Children[j].Values.Count; x++)
                {
                    lista.Add(this.Raiz.Children[j].Values[x]);

                }

                if (j < this.Raiz.Children.Count - 1)
                {
                    lista.Add(this.Raiz.Values[i]);
                    i++;

                }

            }

            return lista;
        }

        private void RecorridoInorder(Nodo<T> NodoArbol)
        {
           
            if (NodoArbol !=null && NodoArbol.Children.Count !=0)
            {
                RecorridoInorder(NodoArbol.Children[0]);
                for (int i = 1; i <NodoArbol.Children.Count(); i++)
                {

                    Listado.Add(NodoArbol.Values.ElementAt(i-1));
                    
                    RecorridoInorder(NodoArbol.Children[i]);
                }
            }
            else
            {
                Listado.Add(NodoArbol.Values.ElementAt(0));
            }
           
        }
        public List<T> ConvertirALista()
        {
           
            RecorridoInorder(Raiz);
            return Listado;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Models.Btree
{
    public class Nodo<T> : IEquatable<Nodo<T>>
    {


        public T Id { get; set; }
        public bool IsRoot { get; set; }

        public bool IsLeaf
        {
            get
            {
                return this.Children.Count == 0;
            }
        }
        private List<Nodo<T>> children = new List<Nodo<T>>();

        public List<Nodo<T>> Children { get { return this.children; } }

        private List<T> values = new List<T>();

        public List<T> Values { get { return this.values; } }

        public bool Equals(Nodo<T> other)
        {
            return this.Values.Equals(other.Values);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2_LABFINAL.Models.Btree
{
    public class Bebidas : IComparable
    {

        public string Nombre { get; set; }
        public string Sabor { get; set; }
        public int Volumen { get; set; }
        public float Precio { get; set; }
        public string Casa { get; set; }

        public int CompareTo(object obj)
        {
            //throw new NotImplementedException();
            return this.Nombre.CompareTo(((Bebidas)obj).Nombre);
        }

        public static Comparison<Bebidas> ComperByName = delegate (Bebidas m1, Bebidas m2)
        {
            return m1.CompareTo(m2);
        };

    }
}

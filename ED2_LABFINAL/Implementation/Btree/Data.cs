using ED2_LABFINAL.Models.Btree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2_LABFINAL.Models.Btree
{
    public class Data
    {

        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null) _instance = new Data();
                return _instance;
            }
        }

        internal Arbol<Bebidas> arbol = new Arbol<Bebidas>(3);
        public List<Bebidas> bebidas = new List<Bebidas>();



    }
}
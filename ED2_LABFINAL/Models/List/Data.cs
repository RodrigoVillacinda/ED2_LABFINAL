using ED2_LABFINAL.Models.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Models.List
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
        public string moviename;
        public int year;
        public string director;

        public List<Movie> movies = new List<Movie>();

    }

}
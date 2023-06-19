using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamenS3
{
    public class Udlån
    {
        public int Id { get; set; }

        public DateTime Dato { get; set; }
        public int Antal { get; set; }
        public Låner Låner { get; set; }
        public Bog Bog { get; set; }
    }
}

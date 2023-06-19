using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamenS3
{
    public class Bog
    {
        public int Id { get; set; }

        public string Forfatter { get; set; }
        public string Titel { get; set; }
        public string Udgiver { get; set; }
        public int UdgivelsesÅr { get; set; }
        public int Antal { get ; set; }
        public int ISBN { get; set; }
    }
}

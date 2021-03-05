using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  public class Urun
    {
        public int id { get; set; }
        public string Ad { get; set; }
        public double Fiyat { get; set; }
        public string Resim { get; set; }
    }
}

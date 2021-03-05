using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Satis
    {
        public int id { get; set; }
        public int urunİd { get; set; }
        public int musteriId { get; set; }
        public DateTime tarih { get; set; }
    }
}

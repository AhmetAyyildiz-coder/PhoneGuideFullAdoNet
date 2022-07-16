using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rehber
    {
        public Guid ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return Isim  + " " + Soyisim;
        }
    }
    
}

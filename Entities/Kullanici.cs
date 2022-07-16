using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kullanici
    {
        //buraya sql serverdaki kullanici alandaki propertyler yazilacak aynen 
        public Guid ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }


    }
}

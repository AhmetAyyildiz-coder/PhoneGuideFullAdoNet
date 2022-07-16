using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseLogicLayer;
using Entities;
namespace BuisnessLogicLayer
{
    public class BLL
    {
        DatabaseLogicLayer.DLL dll;
        public BLL()
        {
            dll = new DatabaseLogicLayer.DLL();
        }

        /// <summary>
        /// eger sonuc -1 donerse  hatali bir islem demektir.Eger 1 donerse islem basarili demektr
        /// </summary>
        /// <param name="Isim"></param>
        /// <param name="Soyisim"></param>
        /// <param name="TelefonNumarasi"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public int KayitEkle(string Isim, string Soyisim, string TelefonNumarasi, string Email)
        {
            if (!string.IsNullOrEmpty(Isim) && (!string.IsNullOrEmpty(Soyisim) && (!string.IsNullOrEmpty(TelefonNumarasi))))
            {
                int sonuc = dll.kayitEkle(new Rehber { ID = Guid.NewGuid(), Isim = Isim, Soyisim = Soyisim, TelefonNumarasi = TelefonNumarasi, Email = Email });
                return sonuc;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// bu fonksiyon gelen kullanici adi ve sifrenin sistemde kayitli olup olmadigini bize bildirecek. Kayitli ise return 10 olacaktir.
        /// Degil ise return 20 olacaktir
        /// </summary>
        /// <param name="KullaniciAdi"></param>
        /// <param name="Sifre"></param>
        /// <returns></returns>
        public int SistemKonrol(string KullaniciAdi, string Sifre)
        {
            int retrnvalue = 0;
            bool sonuc = stringBosKontrolu(KullaniciAdi, Sifre);
            if (!sonuc)
            {
                int bllreturn = dll.SistemKonrol(new Entities.Kullanici()
                {
                    KullaniciAdi = KullaniciAdi,
                    Sifre = Sifre
                });
                if (bllreturn == 1)
                {
                    retrnvalue= (int)Entities.Islemler.BasariliIslem;
                }
                else
                {
                    retrnvalue = (int)Entities.hatalar.EksikParametre;
                }
            }
            return retrnvalue;
            
        }

        /// <summary>
        /// bu fonksiyon bize gelen degerlerin bos bir string olup olmadigini dondurecektir. Gelen string dizisi kelimelerden
        /// bir tanesi bile bos olursa true degeri dondurecektir
        /// </summary>
        /// <param name="kelimeler"></param>
        /// <returns></returns>
        public bool stringBosKontrolu(params string[] kelimeler)
        {
            bool sonuc = true;
            foreach (var item in kelimeler)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    sonuc = false;
                }
            }

            return sonuc;
        }
        /// <summary>
        /// Kayit duzenledikten sonra eger islem basarili ise bu fonksiyon bize return 1 donecektir. Basarisiz ise eksik parametre = return 10 donecektir
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Isim"></param>
        /// <param name="Soyisim"></param>
        /// <param name="TelefonNumarasi"></param>
        /// <param name="EmailAdress"></param>
        /// <returns></returns>
        public int KayitDuzenle(Guid ID, string Isim, string Soyisim, string TelefonNumarasi, string EmailAdress)
        {
            if (ID != Guid.Empty)
            {
                return dll.KayitDuzenle(new() { ID = ID, Isim = Isim, Soyisim = Soyisim, Email = EmailAdress, TelefonNumarasi = TelefonNumarasi });
            }
            else
            {
                return (int)Entities.hatalar.EksikParametre;
            }
        }
        /// <summary>
        /// eger kayit silindi ise return 1 , silinmedi ise return 10 eksik parametre hatasi donecektir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         public int KayitSil(Guid id)
        {
            if (id != Guid.Empty)
            {
               return  dll.kayitSilRehber(id);
            }
            return (int)Entities.hatalar.EksikParametre;
        }

        public List<Rehber> KayitListeleRehber()
        {
            List<Rehber> kayitlarim = new List<Rehber>();
            
            try
            {
                SqlDataReader dataReader = dll.KayitListeRehber();
                while (dataReader.Read())
                {
                    //data.read metodu gelen sqldatareader icerisindeki bir foreach metodu olarak da dusunulebilir
                    //yani gelen butun datalari tek tek dolasicaktir.
                    //bizde bu tek tek data gezerken o datalari bir list icerisine ekleyebiliriz.
                    kayitlarim.Add(new()
                    {
                        ID = dataReader.IsDBNull(0) ? Guid.Empty : dataReader.GetGuid(0),
                        Isim = dataReader.IsDBNull(1)?string.Empty:dataReader.GetString(1),
                        Soyisim = dataReader.IsDBNull(2)? string.Empty:dataReader.GetString(2),
                        TelefonNumarasi = dataReader.IsDBNull(3)?string.Empty : dataReader.GetString(3),
                        Email = dataReader.IsDBNull(4) ? string.Empty: dataReader.GetString(4)

                        //burada yaptigmiz olay sudur while dongusu datareader icerisindeki butun datalari tek tek
                        //row olarak donmektedir. Bu rowlarin da indexine gore degerlerine ulasabiliyoruz/
                        //ve bu sayede her row geldiginde gelen degerler bos degilse listemize atiyoruz
                        //bos kontrolunu yapmak zorundayiz cunku database de olmayan verilerin yeri de gelebilir

                    });
                }
                dataReader.Close();
            }
            catch (Exception)
            {

                
            }
            finally
            {
                dll.BaglantiAyarla();
            }
            return kayitlarim;
        }


        public Rehber KayitListeleRehberID(Guid ID)
        {
            Rehber rehberkayit = new Rehber();

            try
            {
                SqlDataReader dataReader = dll.KayitListeleRehberTekil(ID);
                while (dataReader.Read())
                {
                    //data.read metodu gelen sqldatareader icerisindeki bir foreach metodu olarak da dusunulebilir
                    //yani gelen butun datalari tek tek dolasicaktir.
                    //bizde bu tek tek data gezerken o datalari bir list icerisine ekleyebiliriz.
                    rehberkayit = new Rehber()
                    {
                        ID = dataReader.IsDBNull(0) ? Guid.Empty : dataReader.GetGuid(0),
                        Isim = dataReader.IsDBNull(1) ? string.Empty : dataReader.GetString(1),
                        Soyisim = dataReader.IsDBNull(2) ? string.Empty : dataReader.GetString(2),
                        TelefonNumarasi = dataReader.IsDBNull(3) ? string.Empty : dataReader.GetString(3),
                        Email = dataReader.IsDBNull(4) ? string.Empty : dataReader.GetString(4)

                        //burada yaptigmiz olay sudur while dongusu datareader icerisindeki butun datalari tek tek
                        //row olarak donmektedir. Bu rowlarin da indexine gore degerlerine ulasabiliyoruz/
                        //ve bu sayede her row geldiginde gelen degerler bos degilse listemize atiyoruz
                        //bos kontrolunu yapmak zorundayiz cunku database de olmayan verilerin yeri de gelebilir

                    };
                }
                dataReader.Close();
            }
            catch (Exception)
            {


            }
            finally
            {
                dll.BaglantiAyarla();
            }
            return rehberkayit;
        }

    }
}

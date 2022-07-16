using Entities;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DatabaseLogicLayer
{
    public class DLL
    {
        //bu sinifin en onemli ozelligi database islemlerinin tamamini bu siniftan yapicak olmamiz



        SqlConnection connection; //bu isminden de anlasilacagi gibi sql baglantisini saglayan Nesnemizdir.
        //bu nesneleri ctor da ornekleriz.

        SqlCommand Command; // Bu nesnemiz de sql sorgularimizi sql servera iletmemizi saglar. Bu nesnenın uzantı fonksiyonlari ile 
                            //de sorgumuzu database e gonderip calistigini gorebiliriz calismadigi durumlari da gorebilmekteyiz.


        SqlDataReader DataReader; //bu nesnemiz de sql den gelen datayi c# tarafinda karsiliyor.Gelen Datayi okuyor yani
        
        public DLL()
        {
            connection = new("Server =(LocalDb)\\MSSQLLocalDB;" +
                "Database=PhoneGuide;Trusted_Connection=True;");
            //connection nesnesini burada ornekledik ama daha acmadik bunu.

        }
        #region Ortak Fonksiyonlar

        #endregion
        public void BaglantiAyarla()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                connection.Close();
            }
        }

        #region Rehber Fonksiyonlari
        public int KayitDuzenle(Rehber kisi)
        {
            int ReturnValues = 0;
            try
            {

                Command = new SqlCommand(@"update Rehber set Isim = @Isim , Soyisim = @Soyisim , 
                TelefonNumarasi = @TelefonNumarasi , EmailAdress = @EmailAdress
                where ID = @ID", connection);
                Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = kisi.ID;
                Command.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = kisi.Isim;
                Command.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = kisi.Soyisim;
                Command.Parameters.Add("@TelefonNumarasi", SqlDbType.NVarChar).Value = kisi.TelefonNumarasi;
                Command.Parameters.Add("@EmailAdress", SqlDbType.NVarChar).Value = kisi.Email;
                BaglantiAyarla();
                var baglantiDurumu = connection.State; 
                ReturnValues = Command.ExecuteNonQuery(); // non query ile hazirlamis oldugumuz sorgumuzu 
                //sql e gonderiyoruz ve etkilenen row sayisini bize int olarak donuyor
            }
            catch
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }
        /// <summary>
        /// Eger kayit silindi ise return 1 donecektir
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int kayitSilRehber(Guid ID)
        {
            int ReturnValues = 0;
            try
            {

                Command = new SqlCommand("Delete Rehber where ID = @ID", connection);
                Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;


                BaglantiAyarla();
                ReturnValues = Command.ExecuteNonQuery(); // non query ile hazirlamis oldugumuz sorgumuzu 
                //sql e gonderiyoruz ve etkilenen row sayisini bize int olarak donuyor
            }
            catch (Exception)
            {


            }
            finally
            {
                BaglantiAyarla();
            }

            return ReturnValues;
        }
        public int kayitEkle(Rehber kisi)
        {
            int ReturnValues = 0;

            try
            {


                Command = new SqlCommand("insert into Rehber (ID , Isim , Soyisim , TelefonNumarasi , EmailAdress) values" +
                    " (@ID , @Isim , @Soyisim , @TelefonNumarasi , @EmailAdress) ", connection);
                Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = kisi.ID;
                Command.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = kisi.Isim;
                Command.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = kisi.Soyisim;
                Command.Parameters.Add("@TelefonNumarasi", SqlDbType.NVarChar).Value = kisi.TelefonNumarasi;
                Command.Parameters.Add("@EmailAdress", SqlDbType.NVarChar).Value = kisi.Email;
                BaglantiAyarla();
                var baglantiDurumu = connection.State;
                ReturnValues = Command.ExecuteNonQuery(); // non query ile hazirlamis oldugumuz sorgumuzu 
                                                          //sql e gonderiyoruz ve etkilenen row sayisini bize int olarak donuyor

            }
            catch (Exception ex)
            {
                

            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

        public SqlDataReader KayitListeRehber()
        {
            Command = new SqlCommand("select * from Rehber", connection);
            BaglantiAyarla();
            return Command.ExecuteReader();
        }

        public SqlDataReader KayitListeleRehberTekil(Guid ID)
        {
            Command = new SqlCommand("select * from Rehber Where ID = @ID");
            Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            BaglantiAyarla();
            return Command.ExecuteReader();
        }
        #endregion

        #region Kullanici Fonksiyonlari
        public int kayitSilKullanici(Guid ID)
        {
            int ReturnValues = 0;
            try
            {
                Command = new SqlCommand("Delete Kullanici Where ID = @ID ");
                Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
                BaglantiAyarla();
                ReturnValues = Command.ExecuteNonQuery(); // Etkilenen kayit sayisini bize dondurecektir.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }
        public int kayitEkle(Kullanici k)
        {
            int ReturnValues = 0;
            try
            {
                Command = new SqlCommand("insert into Kullanici (ID , KullaniciAdi , Sifre ) values (@ID , @KullaniciAdi , @Sifre )", connection);
                Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = k.ID;
                Command.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = k.KullaniciAdi;
                Command.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = k.Sifre;

                BaglantiAyarla();
                ReturnValues = Command.ExecuteNonQuery(); // non query ile hazirlamis oldugumuz sorgumuzu 
                //sql e gonderiyoruz ve etkilenen row sayisini bize int olarak donuyor
            }
            catch
            {

            }
            finally
            {
                BaglantiAyarla();
            }

            return ReturnValues;

        }
        public int SistemKonrol(Kullanici k)
        {
            int ReturnValues = 0;

            try
            {
                Command = new SqlCommand("select count(*) from Kullanici where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre ", connection);
                BaglantiAyarla();
                Command.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = k.KullaniciAdi;
                Command.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = k.Sifre;
                ReturnValues = (int)Command.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

        #endregion
    }
}

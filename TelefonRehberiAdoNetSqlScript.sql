Create table Rehber (
 ID UniqueIdentifier not null,
 Isim varchar(50),
 Soyisim varchar(50),
 TelefonNumarasi varchar(11),
 Email varchar(30),
 PRIMARY KEY(ID)
);


Create table Kullanici (
 ID UniqueIdentifier not null,
 KullaniciAdi varchar(50),
 Sifre varchar(50),
 
 PRIMARY KEY(ID)
);
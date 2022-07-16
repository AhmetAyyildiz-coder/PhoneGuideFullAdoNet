using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuisnessLogicLayer;
using Entities;

namespace TelefonRehberi
{
    public partial class AnaForm : Form
    {
        List<Rehber> RehberKayitlari;
        BLL buisness; 
        public AnaForm()
        {
            InitializeComponent();
            buisness = new();

        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonKEYeniKayitOlustur_Click(object sender, EventArgs e)
        {
            BuisnessLogicLayer.BLL bLL = new BuisnessLogicLayer.BLL();
           int sonuc = bLL.KayitEkle(textBoxKEIsim.Text, textBoxKESoyisim.Text, textBoxKETelefon.Text, textBoxKEEmail.Text);
            if (sonuc == 1)
            {
                //islem basarili
                DialogResult result = MessageBox.Show("islem basarili", "Bilgi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    //burada geri kalan textboxlari temizle dicez.
                    textBoxKEEmail.Text = string.Empty;
                    textBoxKEIsim.Text = string.Empty;
                    textBoxKESoyisim.Text = string.Empty;
                    textBoxKETelefon.Text = string.Empty;
                    RehberKayitlari = buisness.KayitListeleRehber();
                    listBoxListe.DataSource = RehberKayitlari;
                }
            }
        }

        private void buttonListeGuncelle_Click(object sender, EventArgs e)
        {

            RehberKayitlari = buisness.KayitListeleRehber();
            listBoxListe.DataSource = RehberKayitlari;
        }

        private void listBoxListe_DoubleClick(object sender, EventArgs e)
        {
            ListBox box = (ListBox)sender;
            Rehber secilenKayit = (Rehber)box.SelectedItem;
            if (secilenKayit != null)
            {
                textBoxKGIsim.Text = secilenKayit.Isim;
                textBoxKGSoyisim.Text = secilenKayit.Soyisim;
                textBoxKGTelefon.Text = secilenKayit.TelefonNumarasi;
                textBoxKGEmail.Text = secilenKayit.Email;
            }
        }

        private void buttonKayitDuzenle_Click(object sender, EventArgs e)
        {
            Rehber temp = new Rehber();
            temp = (Rehber)listBoxListe.SelectedItem;

            Rehber yakalananKisi = new Rehber();
            yakalananKisi.ID = temp.ID;
            yakalananKisi.Isim = textBoxKGIsim.Text;
            yakalananKisi.Soyisim = textBoxKGSoyisim.Text;
            yakalananKisi.TelefonNumarasi = textBoxKGTelefon.Text;
            yakalananKisi.Email = textBoxKGEmail.Text;
            //Rehber rehberKayit = (Rehber)YakalananKisi;
           buisness.KayitDuzenle(yakalananKisi.ID, yakalananKisi.Isim, yakalananKisi.Soyisim, yakalananKisi.TelefonNumarasi, yakalananKisi.Email);


            RehberKayitlari = buisness.KayitListeleRehber();
            listBoxListe.DataSource = RehberKayitlari;
           DialogResult result = MessageBox.Show("Tebrikler Kaydiniz Guncellenmistir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                textBoxKGEmail.Text = string.Empty;
                textBoxKGIsim.Text = string.Empty;
                textBoxKGSoyisim.Text = string.Empty;
                textBoxKGTelefon.Text = string.Empty;
            }
        }

        private void buttonKayitSil_Click(object sender, EventArgs e)
        {
            Rehber temp = new Rehber();
            temp = (Rehber)listBoxListe.SelectedItem;
           int sonuc = buisness.KayitSil(temp.ID);
            if (sonuc == 1)
            {
              DialogResult result=  MessageBox.Show("Tebrikler Kaydiniz basarili bir sekilde silinmistir.", "Basarili ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result== DialogResult.OK)
                {
                    RehberKayitlari = buisness.KayitListeleRehber();
                    listBoxListe.DataSource = RehberKayitlari;
                    textBoxKGEmail.Text = string.Empty;
                    textBoxKGIsim.Text = string.Empty;
                    textBoxKGSoyisim.Text = string.Empty;
                    textBoxKGTelefon.Text = string.Empty;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BuisnessLogicLayer;

namespace TelefonRehberi
{
    
    public partial class GirisForm : Form
    {
        AnaForm anaForm = new();
        BuisnessLogicLayer.BLL buisness;
        public GirisForm()
        {
            InitializeComponent();
             buisness = new();
           
        }

        private void buttonSistemGiris_Click(object sender, EventArgs e)
        {
            var kullaniciAdi = textBoxKullaniciAdi.Text;
            var sifre = textBoxSifre.Text;
           int returnVal = buisness.SistemKonrol(kullaniciAdi, sifre);
            //sistemde kayitli ise return 10 degil ise return 20 olucaktir.
            if (returnVal == (int)Entities.Islemler.BasariliIslem)
            {
                //bilgiler dogru ise anaforma giris yapicaz ana formu orneklicez burda

                anaForm.Show() ;
                Application.OpenForms["GirisForm"].Visible = false; //ilk formumuzu kapattik giris ekranini fazlalik kaplamasin diye
                

            }
            else if (returnVal == (int)Entities.hatalar.EksikParametre)
            {
                //
                MessageBox.Show("Girdiginiz kullanici bilgileri bulunamadi.", "uyari" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            
        }

        private void groupBoxKullaniciGirisBilgileri_Enter(object sender, EventArgs e)
        {
            
        }

        
    }
}

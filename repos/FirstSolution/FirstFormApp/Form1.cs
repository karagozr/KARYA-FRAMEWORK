using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstFormApp
{
    public partial class Form1 : Form
    {
        Ogrenci ogrenci1 = new Ogrenci();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtIsim.Text == "" || txtBoy.Text=="" || txtYas.Text=="")
            {
                MessageBox.Show("hatalı giriş tüm alanlar doldurulmalıdır");
            }
            else
            {
                ogrenci1.isim = txtIsim.Text;
                ogrenci1.boy = Convert.ToDouble(txtBoy.Text);
                ogrenci1.yas = Convert.ToInt32(txtYas.Text);
                ogrenci1.vefat = chkVefat.Checked;

                MessageBox.Show("İşlem başarılı");

                txtIsim.Text = "";
                txtBoy.Text = "";
                txtYas.Text = "";
                chkVefat.Checked = false;
            }
            



            //veri tabanına yazma işlemi
        }

        private void btnBak_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ogrenci1.isim+" - "+ogrenci1.yas+" - "+ogrenci1.boy+" - "+ogrenci1.vefat);
        }
    }
}

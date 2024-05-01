using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProje
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.tblKategori.Count().ToString();
            label3.Text = db.tblUrun.Count().ToString();
            label5.Text = db.tblMusteri.Count(x => x.durum == true).ToString();
            label7.Text = db.tblMusteri.Count(x => x.durum == false).ToString();
            label13.Text = db.tblUrun.Sum(x => x.stok).ToString();
            label21.Text = db.tblSatis.Sum(x => x.fiyat).ToString() + " TL";
            label11.Text = (from x in db.tblUrun orderby x.fiyat descending select x.urunAd).FirstOrDefault();
            label9.Text = (from x in db.tblUrun orderby x.fiyat ascending select x.urunAd).FirstOrDefault();
            label15.Text = db.tblUrun.Count(x => x.kategori == 1).ToString();
            label17.Text = db.tblUrun.Count(x => x.urunAd == "Buzdolabi").ToString();
            label23.Text = (from x in db.tblMusteri select x.sehir).Distinct().Count().ToString();
            label19.Text = db.markaGetir().FirstOrDefault();
        }
    }
}

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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.tblUrun
                                        select new
                                        {
                                            x.urunID,
                                            x.urunAd,
                                            x.marka,
                                            x.stok,
                                            x.fiyat,
                                            x.tblKategori.Ad,
                                            x.durum
                                        }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            tblUrun t = new tblUrun();
            t.urunAd = txtUrunAdi.Text;
            t.marka = txtMarka.Text;
            t.stok = short.Parse(txtStok.Text);
            t.fiyat = decimal.Parse(txtFiyat.Text);
            t.durum = true;
            t.kategori = int.Parse(cmbKategori.SelectedValue.ToString());
            db.tblUrun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Urun Sisteme Kaydedildi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtID.Text);
            var urun = db.tblUrun.Find(x);
            db.tblUrun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Urun Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtID.Text);
            var urun = db.tblUrun.Find(x);
            urun.urunAd = txtUrunAdi.Text;
            urun.stok = short.Parse(txtStok.Text);
            urun.marka = txtMarka.Text;
            urun.fiyat = Convert.ToInt32(txtFiyat.Text);
            db.SaveChanges();
            MessageBox.Show("Urun Guncellendi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.tblKategori select new { x.ID, x.Ad }).ToList();
            cmbKategori.ValueMember = "ID";
            cmbKategori.DisplayMember = "Ad";
            cmbKategori.DataSource = kategoriler;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

        }
    }
}

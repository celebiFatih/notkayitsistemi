using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NoyKayitSistemi
{
    public partial class FrmOgrtDetay : Form
    {
        public FrmOgrtDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2HOS6DT\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True");
        private void FrmOgrtDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
            baglanti.Open();
            SqlCommand gecen = new SqlCommand("Select Count(DURUM) From TBLDERS where DURUM='True'",baglanti);
            SqlCommand kalan = new SqlCommand("Select Count(DURUM) From TBLDERS where DURUM='False'", baglanti);
            lblGecen.Text = (gecen.ExecuteScalar()).ToString();
            lblKalan.Text = (kalan.ExecuteScalar()).ToString();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA, OGRAD, OGRSOYAD) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1", mskNumara.Text);
            komut.Parameters.AddWithValue("@p2", txtAd.Text);
            komut.Parameters.AddWithValue("@p3", txtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci sisteme eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            mskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            lblOrt.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
        string durum;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            double ort, s1, s2, s3;
            
            s1 = Convert.ToDouble(txtSinav1.Text);
            s2 = Convert.ToDouble(txtSinav2.Text);
            s3 = Convert.ToDouble(txtSinav3.Text);

            ort = (s1 + s2 + s3) / 3;
            lblOrt.Text = ort.ToString();

            if (ort >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@p1,OGRS2=@p2,OGRS3=@p3,ORTALAM=@p4,DURUM=@p5 where OGRNUMARA=@p6", baglanti);
            komut.Parameters.AddWithValue("@p1", txtSinav1.Text);
            komut.Parameters.AddWithValue("@p2", txtSinav2.Text);
            komut.Parameters.AddWithValue("@p3", txtSinav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblOrt.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", mskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci notları güncellendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);

        }

        private void lblGecen_Click(object sender, EventArgs e)
        {

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand gecen = new SqlCommand("Select Count(DURUM) From TBLDERS where DURUM='True'", baglanti);
            SqlCommand kalan = new SqlCommand("Select Count(DURUM) From TBLDERS where DURUM='False'", baglanti);
            lblGecen.Text = (gecen.ExecuteScalar()).ToString();
            lblKalan.Text = (kalan.ExecuteScalar()).ToString();
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRAD=@p1,OGRSOYAD=@p2 where OGRNUMARA=@p3", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskNumara.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci bilgisi güncellendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
        }
    }
}

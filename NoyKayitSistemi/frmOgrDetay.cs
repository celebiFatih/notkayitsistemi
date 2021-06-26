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
    public partial class frmOgrDetay : Form
    {
        public frmOgrDetay()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2HOS6DT\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True");
        private void frmOgrDetay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select*From TBLDERS where OGRNUMARA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                lblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblS1.Text = dr[4].ToString();
                lblS2.Text = dr[5].ToString();
                lblS3.Text = dr[6].ToString();
                lblOrt.Text = dr[7].ToString();
                if (dr[8].ToString() == "True")
                {
                    lblDurum.Text = "Geçti";
                }
                else
                {
                    lblDurum.Text = "Kaldı";
                }

            }

            

            baglanti.Close();
        }
    }
}

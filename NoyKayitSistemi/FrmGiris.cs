using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoyKayitSistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (maskedTextBox1.Text == "")
            {
                MessageBox.Show("Öğrencinin numarasını giriniz!");
            }
            else
            {
                frmOgrDetay frm = new frmOgrDetay();
                frm.numara = maskedTextBox1.Text;
                frm.Show();
            }

        }


        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmOgrtDetay frm = new FrmOgrtDetay();
            frm.Show();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }
    }
}

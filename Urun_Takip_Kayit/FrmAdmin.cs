using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Kayit
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=DBurun;Integrated Security=True;TrustServerCertificate=True;");

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLADMIN where Kullanici =@p1 and Sifre = @p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtGiris.Text);
            komut.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                AnaSayfacs fr = new AnaSayfacs();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Sifre");
            }
            baglanti.Close();
        }
    }
}

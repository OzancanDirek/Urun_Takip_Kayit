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
    public partial class FrmIstatistikler : Form
    {
        public FrmIstatistikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=DBurun;Integrated Security=True;TrustServerCertificate=True;");

        private void Istatistikler_Load(object sender, EventArgs e)
        {
            this.Size = new Size(830, 390);
            //Toplam Kategori Sayısı
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select count(*) from TBLKATEGORİ",baglanti);
            SqlDataReader dr =komut.ExecuteReader();
            while (dr.Read())
            {
                lblToplamKategori.Text = dr[0].ToString();
            }
            baglanti.Close();


            //Toplam Urun sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from TBLURUNLER",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                lblToplamUrun.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Toplam beyaz eşya sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count(*) from TBLURUNLER where Kategori = (Select ID from TBLKATEGORİ where Ad = 'Beyaz Eşya')", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
               lblKucukEvAlet.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Toplam Kucuk Ev Aletleri Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(*) from TBLURUNLER where Kategori = (Select ID from TBLKATEGORİ where Ad = 'Küçük Ev Aletleri')", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblBeyazEsya.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //En Yuksek Stoklu Urun
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select * from TBLURUNLER where Stok = (select max(Stok)from TBLURUNLER)", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                label7.Text = dr5["UrunAd"].ToString();
            }
            baglanti.Close();

            // En Dusuk Stoklu Urun
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select * from TBLURUNLER where Stok = (select min(Stok)from TBLURUNLER)", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                label9.Text = dr6["UrunAd"].ToString();
            }
            baglanti.Close();


            //Laptop Toplam Kar
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select stok *(SatisFiyat-AlisFiyat) from TBLURUNLER where UrunAd = 'Laptop'", baglanti);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                label11.Text = dr7[0].ToString() + "₺";
            }
            baglanti.Close();

            //Beyaz Eşya Toplam Kar
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("select sum (stok*(SatisFiyat-AlisFiyat)) as 'Toplam Stokla Carpılan Sonuc' from TBLURUNLER\r\nwhere Kategori = (Select ID from TBLKATEGORİ where Ad='Beyaz Eşya')", baglanti);
            SqlDataReader dr8 = komut7.ExecuteReader();
            while (dr8.Read())
            {
                lblBeyazEsyaToplam.Text = dr8[0].ToString() + "₺";
            }
            baglanti.Close();

        }
    }
}

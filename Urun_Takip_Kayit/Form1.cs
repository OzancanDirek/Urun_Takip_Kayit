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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=DBurun;Integrated Security=True;TrustServerCertificate=True;");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=DBurun;Integrated Security=True;TrustServerCertificate=True;");
            SqlCommand komut = new SqlCommand("Select * from TBLKATEGORİ", baglanti);


            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Insert into TBLKATEGORİ (Ad) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1",TxtKategoriAd.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategoriniz Başarıyla Eklendi...");

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete from TBLKATEGORİ where ID = @p1",baglanti);
            komut3.Parameters.AddWithValue("@p1",TxtID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategoriniz Silindi...");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Update TBLKATEGORİ set Ad = @p1 WHERE ID = @p2", baglanti);
            komut4.Parameters.AddWithValue("@p1", TxtKategoriAd.Text);
            komut4.Parameters.AddWithValue("@p2", TxtID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Adı Güncellendi...");
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=DBurun;Integrated Security=True;TrustServerCertificate=True;");
            SqlCommand komut = new SqlCommand("Select * from TBLKATEGORİ where Ad = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKategoriAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKategoriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
//Data Source=LAPTOP-QD8VUNPD\\SQLEXPRESS;Initial Catalog=DBurun;Integrated Security=True;Trust Server Certificate=True

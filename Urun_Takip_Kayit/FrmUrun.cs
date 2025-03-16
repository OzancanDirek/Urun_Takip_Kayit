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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=DBurun;Integrated Security=True;TrustServerCertificate=True;");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select UrunId,UrunAd,Stok,AlisFiyat,SatisFiyat,Ad,Kategori from TBLURUNLER\r\ninner join TBLKATEGORİ\r\non TBLURUNLER.Kategori = TBLKATEGORİ.ID", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Kategori"].Visible = false;
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from TBLKATEGORİ",baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox1.DisplayMember = "Ad";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = dt2;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into TBLURUNLER (UrunAd, Stok, AlisFiyat, SatisFiyat,Kategori)" +
                "VALUES (@p1,@p2,@p3,@p4,@p5)",baglanti);
            komut3.Parameters.AddWithValue("@p1",TxtAD.Text);
            komut3.Parameters.AddWithValue("@p2", NudStok.Value);
            komut3.Parameters.AddWithValue("@p3", TxtAlisFiyat.Text);
            komut3.Parameters.AddWithValue("@p4", TxtSatisFiyat.Text);
            komut3.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" Urun başarıyla eklendi... ");

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Delete from TBLURUNLER where UrunId = @p1 ",baglanti);
            komut4.Parameters.AddWithValue("@p1",TxtID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" Istediğiniz ürün başarıyla silindi... ");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //e parametresi tıkladığımız yeri hafızaya atarken cells[-] değerleri
            //kaçıncı sütunu seçmemize yardımcı oluyor.
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAD.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            NudStok.Value =int.Parse( dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            TxtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
           
            SqlCommand komut5 = new SqlCommand("update TBLURUNLER set UrunAd = @p1 , Stok = @p2," +
                " AlisFiyat = @p3, SatisFiyat = @p4, Kategori = @p5 where UrunId = @p6", baglanti);
            komut5.Parameters.AddWithValue("@p1",TxtAD.Text);
            komut5.Parameters.AddWithValue("@p2", NudStok.Value);
            komut5.Parameters.AddWithValue("@p3", decimal.Parse(TxtAlisFiyat.Text));
            komut5.Parameters.AddWithValue("@p4", decimal.Parse(TxtSatisFiyat.Text));
            komut5.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komut5.Parameters.AddWithValue("@p6", TxtID.Text);
            komut5.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Urun Başarıyla Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

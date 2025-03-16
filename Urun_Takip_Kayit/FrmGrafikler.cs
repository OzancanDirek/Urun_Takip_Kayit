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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=DBurun;Integrated Security=True;TrustServerCertificate=True;");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Ad,Count(*) from TBLURUNLER inner join TBLKATEGORİ\r\non TBLURUNLER.Kategori = TBLKATEGORİ.ID\r\ngroup by Ad", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategori"].Points.AddXY(dr[0],dr[1]);


            }
            baglanti.Close();

        }
    }
}

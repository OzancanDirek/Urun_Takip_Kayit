using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Kayit
{
    public partial class AnaSayfacs : Form
    {
        public AnaSayfacs()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            FrmUrun fr = new FrmUrun();
            fr.Show();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            FrmIstatistikler fr = new FrmIstatistikler();
            fr.Show();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            FrmAdmin fr = new FrmAdmin();
            fr.Show();
        }
    }
}

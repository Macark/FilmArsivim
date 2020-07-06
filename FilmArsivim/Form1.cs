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

namespace FilmArsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Data Source=DESKTOP-BTHDCST;Initial Catalog=Db_FilmArsivim; Integrated Security=True
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BTHDCST;" +
            "Initial Catalog=FilmArsivim; Integrated Security=True");

        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLFİLMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFİLMLER (AD,KATEGORİ,LİNK) values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtFilm.Text);
            komut.Parameters.AddWithValue("@p2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@p3", TxtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film listenize eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            webBrowser1.Navigate(link);
        }

        private void BtnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Mehmet Ali Çark tarafından 28 Mart 2020'de kodlandı", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
                }

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnTamEkran_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            FrmTamEkran frm = new FrmTamEkran();
            frm.film = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            frm.Show();
                

        }
    }
}

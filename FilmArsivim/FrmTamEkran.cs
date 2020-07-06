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
    public partial class FrmTamEkran : Form
    {
        public FrmTamEkran()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BTHDCST;" +
            "Initial Catalog=FilmArsivim; Integrated Security=True");
        public string film;
        private void FrmTamEkran_Load(object sender, EventArgs e)
        {
            this.Text = film.ToString();
            this.WindowState = FormWindowState.Maximized;
            webBrowser1.Navigate(film);



        }
    }
}

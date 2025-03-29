using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EntityLayer;
using DataAccessLayer;
using LogicLayer;
using System.Data.SqlClient;

namespace OOP_Projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtGorev.Text = "";
            txtId.Text = "";
            txtMaas.Text = "";
            txtSehir.Text = "";
            txtSoyad.Text = "";

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> Perlist = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = Perlist;


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();

            ent.Ad1 = txtAd.Text;
            ent.Soyad1 = txtSoyad.Text;
            ent.Maas1 = short.Parse( txtMaas.Text);
            ent.Sehir1 = txtSehir.Text;
            ent.Gorev1 = txtGorev.Text;

            LogicPersonel.LLPersonelEkle(ent);


        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            EntityPersonel ent = new EntityPersonel();
            ent.Id1 = Convert.ToInt32(txtId.Text);
            LogicPersonel.LLPersonelSil(ent.Id1);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (txtId.Text == "")
            {
                MessageBox.Show("Id değeri girmeden güncelleme işlemi yapamazsınız, Güncellemek istediğiniz personelin üzerine tıklayın","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand komut = new SqlCommand("update Tbl_Bilgi set Personel_Ad=@p2, Personel_Soyad=@p3, Personel_Gorev=@p4, Personel_Sehir=@p5, Personel_Maas=@p6 where Personel_Id=@p1", Baglanti.bgl);
                
                komut.Parameters.AddWithValue("@p1", txtId.Text);
                komut.Parameters.AddWithValue("@p2", txtAd.Text);
                komut.Parameters.AddWithValue("@p3", txtSoyad.Text);
                komut.Parameters.AddWithValue("@p4", txtSehir.Text);
                komut.Parameters.AddWithValue("@p5", txtGorev.Text);
                komut.Parameters.AddWithValue("@p6", txtMaas.Text);

                komut.ExecuteNonQuery();

                MessageBox.Show("Personel güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtGorev.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtSehir.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            


        }
    }
}

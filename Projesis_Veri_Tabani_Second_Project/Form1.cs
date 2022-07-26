using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projesis_Veri_Tabani_Second_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        InternDal _internDal = new InternDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInterns();
        }

        private void ClearRows()
        {
            TbAdEkle.Clear();
            TbAdGuncelle.Clear();
            TbSoyadEkle.Clear();
            TbSoyadGuncelle.Clear();
            TbTelefonNumarasiEkle.Clear();
            TbTelefonNumarasiGuncelle.Clear();
            TbSehirEkle.Clear();
            TbSehirGuncelle.Clear();
        }

        private void LoadInterns()
        {
            DgvInterns.DataSource = _internDal.GetAll();
        }
        
        private void DgvInterns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TbAdGuncelle.Text = DgvInterns.CurrentRow.Cells[1].Value.ToString();
            TbSoyadGuncelle.Text = DgvInterns.CurrentRow.Cells[2].Value.ToString();
            TbTelefonNumarasiGuncelle.Text = DgvInterns.CurrentRow.Cells[3].Value.ToString();
            TbSehirGuncelle.Text = DgvInterns.CurrentRow.Cells[4].Value.ToString();
            CbOkuyorMuGuncelle.Text = DgvInterns.CurrentRow.Cells[5].Value.ToString();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
      
            _internDal.Add(new Intern
            {
                Ad = TbAdEkle.Text,
                Soyad = TbSoyadEkle.Text,
                TelefonNo = TbTelefonNumarasiEkle.Text,
                Sehir = TbSehirEkle.Text,
                OkuyorMu = CbOkuyorMuEkle.Text
            });

            ClearRows();
            LoadInterns();
            MessageBox.Show("Stajyer ekleme işlemi başarıyla gerçekleşti!");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            Intern intern = new Intern
            {
                Id = Convert.ToInt16(DgvInterns.CurrentRow.Cells[0].Value),
                Ad = TbAdGuncelle.Text,
                Soyad = TbSoyadGuncelle.Text,
                TelefonNo = TbTelefonNumarasiGuncelle.Text,
                Sehir = TbSehirGuncelle.Text,
                OkuyorMu = CbOkuyorMuGuncelle.Text
            };

            _internDal.Update(intern);
            ClearRows();
            LoadInterns();
            MessageBox.Show("Stajyer güncelleme işlemi başarıyla gerçekleşti!");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            Int16 Id = Convert.ToInt16(DgvInterns.CurrentRow.Cells[0].Value);
            _internDal.Delete(Id);
            ClearRows();
            LoadInterns();
            MessageBox.Show("Stajyer silme işlemi başarıyla gerçekleşti!");
        }     
    }
}

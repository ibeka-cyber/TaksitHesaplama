using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GP_AraSinav2
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Bisque;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Bu Alan Boş Geçilemez!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Bisque;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Bu Alan Boş Geçilemez!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.BackColor = Color.Bisque;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == null)
            {
                MessageBox.Show("Bu Alan Boş Geçilemez!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maskedTextBox1.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Apara;

            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                double odeme, faiz;
                Apara = Convert.ToDouble(textBox1.Text);
                //NAKİT
                if (radioButton1.Checked == true)
                {
                    if (radioButton6.Checked == true)
                    {
                        if (MessageBox.Show("Seçiminiz: " + radioButton1.Text + "\n" + "Taksit Sayısı:Tek Çekim " + "\n\n" + "Ödemeniz: " + Apara + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton1.Text + "\n" + "Tutar: " + Apara + "\n");


                        }
                    }
                    if (radioButton7.Checked == true)
                    {
                        odeme = Apara / 2;


                        if (MessageBox.Show("Seçiminiz: " + radioButton1.Text + "\nTaksit Sayısı: 2 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += (Environment.NewLine + "\n" + "Banka: " + radioButton1.Text + "\nTaksit Sayısı: 2 \n Tutar: " + odeme + "\n");

                        }
                    }
                    if (radioButton8.Checked == true)
                    {
                        odeme = Apara / 3;

                        if (MessageBox.Show("Seçiminiz: " + radioButton1.Text + "\nTaksit Sayısı: 3 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton1.Text + "\nTaksit Sayısı: 3 \n Tutar: " + odeme + "\n");
                        }
                    }
                    if (radioButton9.Checked == true)
                    {
                        odeme = Apara / 4;


                        if (MessageBox.Show("Seçiminiz: " + radioButton1.Text + "\nTaksit Sayısı: 4 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton1.Text + "\nTaksit Sayısı: 4 \n Tutar: " + odeme + "\n");
                        }

                    }
                }
                //HALKBANK
                if (radioButton2.Checked == true)
                {

                    if (radioButton6.Checked == true)
                    {

                        if (MessageBox.Show("Seçiminiz: " + radioButton2.Text + "\n" + "Taksit Sayısı: Tek Çekim " + "\n\n" + "Ödemeniz: " + Apara + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton2.Text + "\n" + "Tutar: " + Apara + "\n");
                        }
                    }
                    if (radioButton7.Checked == true)
                    {
                        odeme = Apara / 2;


                        if (MessageBox.Show("Seçiminiz: " + radioButton2.Text + "\n" + "Taksit Sayısı: 2 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton2.Text + "\n" + "Taksit Sayısı: 2 \n Tutar: " + odeme + "\n");
                        }
                    }
                    if (radioButton8.Checked == true)
                    {
                        faiz = (Apara * 2 * 3) / 1200;
                        Apara = Apara + faiz;
                        odeme = Apara / 3;


                        if (MessageBox.Show("seçiminiz: " + radioButton2.Text + "\nTaksit Sayısı: 3 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton2.Text + "\nTaksit Sayısı: 3 \n Tutar: " + odeme + "\n");
                        }
                    }
                    if (radioButton9.Checked == true)
                    {
                        faiz = (Apara * 2 * 4) / 1200;
                        Apara = Apara + faiz;

                        odeme = Apara / 4;


                        if (MessageBox.Show("Seçiminiz: " + radioButton2.Text + "\nTaksit Sayısı: 4 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton2.Text + "\nTaksit Sayısı: 4 \n Tutar: " + odeme + "\n");
                        }

                    }


                }
                //VAKIFBANK
                if (radioButton3.Checked == true)
                {

                    if (radioButton6.Checked == true)
                    {
                        if (MessageBox.Show("Seçiminiz: " + radioButton3.Text + "\n" + "Taksit Sayısı: Tek Çekim " + "\n\n" + "Ödemeniz: " + Apara + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton3.Text + "\nTutar: " + Apara + "\n");
                        }
                    }
                    if (radioButton7.Checked == true)
                    {
                        odeme = Apara / 2;

                        if (MessageBox.Show("Seçiminiz: " + radioButton3.Text + "\nTaksit Sayısı: 2 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton3.Text + "\nTaksit Sayısı: 2 \n Tutar: " + odeme + "\n");
                        }
                    }
                    if (radioButton8.Checked == true)
                    {
                        odeme = Apara / 3;

                        if (MessageBox.Show("Seçiminiz: " + radioButton3.Text + "\nTaksit Sayısı: 3 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton3.Text + "\nTaksit Sayısı: 3 \n Tutar: " + odeme + "\n");
                        }
                    }
                    if (radioButton9.Checked == true)
                    {
                        faiz = (Apara * 2 * 4) / 1200;
                        Apara = Apara + faiz;
                        odeme = Apara / 4;

                        if (MessageBox.Show("Seçiminiz: " + radioButton3.Text + "\nTaksit Sayısı: 4 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton3.Text + "\nTaksit Sayısı: 4 \n Tutar: " + odeme + "\n");
                        }
                    }
                }
                //ZİRAAT BANKASI
                if (radioButton4.Checked == true)
                {
                    if (radioButton6.Checked == true)
                    {
                        if (MessageBox.Show("Seçiminiz: " + radioButton4.Text + "\n" + "Taksit Sayısı: Tek Çekim " + "\n\n" + "Ödemeniz: " + Apara + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton4.Text + "\nTutar: " + Apara + "\n");
                        }
                    }
                    if (radioButton7.Checked == true)
                    {
                        odeme = Apara / 2;

                        if (MessageBox.Show("Seçiminiz: " + radioButton4.Text + "\nTaksit Sayısı: 2 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton4.Text + "\nTaksit Sayısı: 2 \n Tutar: " + odeme + "\n");
                        }
                    }
                    if (radioButton8.Checked == true)
                    {
                        odeme = Apara / 3;

                        if (MessageBox.Show("Seçiminiz: " + radioButton4.Text + "\nTaksit Sayısı: 3 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton4.Text + "\nTaksit Sayısı: 3 \n Tutar: " + odeme + "\n");
                        }
                    }
                    if (radioButton9.Checked == true)
                    {
                        odeme = Apara / 4;

                        if (MessageBox.Show("Seçiminiz: " + radioButton4.Text + "\nTaksit Sayısı: 4 " + "\n\n" + "Aylık Ödemeniz: " + odeme + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton4.Text + "\nTaksit Sayısı: 4 \n Tutar: " + odeme + "\n");
                        }
                    }
                }
                //DİĞER BANKA KARTLARI
                if (radioButton5.Checked == true)
                {

                    if (radioButton6.Checked == true)
                    {

                        if (MessageBox.Show("Firmamız diğer banka kartlarına taksit uygulamamaktadır.\n\n" + "Seçiminiz: " + radioButton5.Text + "\n" + "Taksit Sayısı: Tek Çekim " + "\n\n" + "Ödemeniz: " + Apara + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton5.Text + "\nTaksit Sayısı: Tek Çekim \n Tutar: " + Apara + "\n");
                        }
                    }
                    if (radioButton7.Checked == true)
                    {

                        if (MessageBox.Show("Firmamız diğer banka kartlarına taksit uygulamamaktadır.\n\n" + "Seçiminiz: " + radioButton5.Text + "\n" + "Taksit Sayısı: Tek Çekim " + "\n\n" + "Ödemeniz: " + Apara + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton5.Text + "\nTaksit Sayısı: Tek Çekim \n Tutar: " + Apara + "\n");
                        }
                    }
                    if (radioButton8.Checked == true)
                    {

                        if (MessageBox.Show("Firmamız diğer banka kartlarına taksit uygulamamaktadır.\n\n" + "Seçiminiz: " + radioButton5.Text + "\n" + "Taksit Sayısı: Tek Çekim " + "\n\n" + "Ödemeniz: " + Apara + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton5.Text + "\nTaksit Sayısı: Tek Çekim\n Tutar: " + Apara + "\n");
                        }
                    }
                    if (radioButton9.Checked == true)
                    {

                        if (MessageBox.Show("Firmamız diğer banka kartlarına taksit uygulamamaktadır.\n\n" + "Seçiminiz: " + radioButton5.Text + "\n" + "Taksit Sayısı: Tek Çekim " + "\n\n" + "Ödemeniz: " + Apara + " TL'dir") == DialogResult.OK)
                        {
                            richTextBox1.Text += ("\n" + "Banka: " + radioButton5.Text + "\nTaksit Sayısı: Tek Çekim \n Tutar: " + Apara + "\n");
                        }
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "TXT Dosyalar|*.txt";
            saveFileDialog1.Title = "Hesap Dökümanı Kaydı";
            saveFileDialog1.FileName = "HesapDokuman.txt";
            saveFileDialog1.ShowDialog();

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
            }

            maskedTextBox1.Clear();
            richTextBox1.Clear();
            if (radioButton1.Checked == true)
            { radioButton1.Checked = false; }
            if (radioButton2.Checked == true)
            { radioButton2.Checked = false; }
            if (radioButton3.Checked == true)
            { radioButton3.Checked = false; }
            if (radioButton4.Checked == true)
            { radioButton4.Checked = false; }
            if (radioButton5.Checked == true)
            { radioButton5.Checked = false; }
            if (radioButton6.Checked == true)
            { radioButton6.Checked = false; }
            if (radioButton7.Checked == true)
            { radioButton7.Checked = false; }
            if (radioButton8.Checked == true)
            { radioButton8.Checked = false; }
            if (radioButton9.Checked == true)
            { radioButton9.Checked = false; }
        }

        private void groupBox1_Leave(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false)
            {
                MessageBox.Show("Bu Alan Boş Geçilemez!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void groupBox2_Leave(object sender, EventArgs e)
        {
            if (radioButton6.Checked == false && radioButton7.Checked == false && radioButton8.Checked == false && radioButton9.Checked == false)
            {
                MessageBox.Show("Bu Alan Boş Geçilemez!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

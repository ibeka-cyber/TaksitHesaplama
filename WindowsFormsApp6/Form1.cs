using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToLongTimeString();
            ToolTip bilgilendirme = new ToolTip();
            bilgilendirme.SetToolTip(comboBox1, "1- Halkbank (3), Vakıfbank (4) ve Ziraatbank (5) taksit seçildiğinde peşin fiyatına taksitlendirme yapılır.\n" +
                                            "2 - Diğer taksit seçeneklerinde aylık % 2 faiz uygulanır.\n" +
                                           "3 - Diğer kartlar ile aylık % 2 faiz uygulanır.\n" +
                                            "4 - En fazla 6 taksit seçilebilir.\n" +
                                           "5 - Nakit ve tek çekimde ürün fiyatı uygulanır.");
            bilgilendirme.ToolTipTitle = "Bilgilendirme";
        }
        private void uyari()
        {
            MessageBox.Show("Bu alanı boş geçemezsiniz.", "UYARI");
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) == false) && (char.IsControl(e.KeyChar) == false))
                e.KeyChar = '\0';
        }
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                uyari();
                maskedTextBox1.Focus();
            }
            maskedTextBox1.BackColor = Color.White;
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.KeyChar = '\0';
        }
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.Red;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                uyari();
                textBox1.Focus();
            }
            textBox1.BackColor = Color.White;
        }
        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                uyari();
                comboBox1.Focus();
            }
            comboBox1.BackColor = Color.White;
        }
        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.KeyChar = '\0';
        }
        private void comboBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.BackColor = Color.Red;
        }
        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                uyari();
                comboBox2.Focus();
            }
            comboBox2.BackColor = Color.White;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = "0123456789";
            if (str.IndexOf(e.KeyChar) != -1)
                e.KeyChar = '\0';
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Red;
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                uyari();
                textBox2.Focus();
            }
            textBox2.BackColor = Color.White;
            textBox2.Text = textBox2.Text.ToUpper();
        }
        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskedTextBox1.BackColor = Color.Red;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "")
                MessageBox.Show("Formda boş bıraktığınız alanları doldurunuz.", "HATA");
            else if (comboBox2.Text == "Tek Çekim")
            {
                MessageBox.Show("Seçiminiz      : " + comboBox1.Text + "\n" + "Taksit Sayısı  : " + comboBox2.Text + "\n" + "Tek çekim yaptığınız için borcunuz : " + textBox1.Text + "\n\n" + "Tarih : " + dateTimePicker1.Text + "\n" + "Saat  : " + label6.Text);
            }
            else
            {
                if (comboBox1.Text == "Nakit")
                {
                    MessageBox.Show("Seçiminiz      : Nakit" + "\n" + "Taksit Sayısı : " + comboBox2.Text + "\n" + "Nakit şeçimini yaptığınız için borcunuz : " + textBox1.Text + "\n\n" + "Tarih : " + dateTimePicker1.Text + "\n" + "Saat  : " + label6.Text);

                }
                if (comboBox1.Text == "Halkbank" && int.Parse(comboBox2.Text) <= 3)
                {
                    MessageBox.Show("Seçiminiz      : Halkbank" + "\n" + "Taksit Sayısı  : " + comboBox2.Text + "\n" +
                        textBox1.Text + " tl olan borcunuz aylık " + double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) + " tl olarak ödeyebilirsiniz." + "\n\n" +
                        "Tarih : " + dateTimePicker1.Text + "\n" + "Saat  : " + label6.Text);                 
                }
                else if (comboBox1.Text == "Halkbank" && int.Parse(comboBox2.Text) > 3)
                {
                    MessageBox.Show("Seçiminiz      : Halkbank" + "\n" + "Taksit Sayısı  : " + comboBox2.Text + "\n" +
                        textBox1.Text + " tl olan borcunuz aylık " + (double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) + double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) * 0.02) + " tl olarak ödeyebilirsiniz." + "\n\n" +
                        "Tarih : " + dateTimePicker1.Text + "\n" + "Saat  : " + label6.Text);                
                }
                if (comboBox1.Text == "Vakıfbank" && int.Parse(comboBox2.Text) <= 4)
                {
                    MessageBox.Show("Seçiminiz      : Vakıfbank" + "\n" + "Taksit Sayısı  : " + comboBox2.Text + "\n" +
                        textBox1.Text + " tl olan borcunuz aylık " + double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) + " tl olarak ödeyebilirsiniz." + "\n\n" +
                        "Tarih : " + dateTimePicker1.Text + "\n" + "Saat  : " + label6.Text);                
                }
                else if (comboBox1.Text == "Vakıfbank" && int.Parse(comboBox2.Text) > 4)
                {
                    MessageBox.Show("Seçiminiz      : Vakıfbank" + "\n" + "Taksit Sayısı  : " + comboBox2.Text + "\n" +
                        textBox1.Text + " tl olan borcunuzu aylık " + (double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) + double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) * 0.02) + " tl olarak ödeyebilirsiniz." + "\n\n" +
                        "Tarih : " + dateTimePicker1.Text + "\n" + "Saat  : " + label6.Text);                  
                }
                if (comboBox1.Text == "Ziraatbank" && int.Parse(comboBox2.Text) <= 5)
                {
                    MessageBox.Show("Seçiminiz      : Ziraat Bankası" + "\n" + "Taksit Sayısı  : " + comboBox2.Text + "\n" +
                        textBox1.Text + " tl olan borcunuz aylık " + double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) + " tl olarak ödeyebilirsiniz." + "\n\n" +
                        "Tarih : " + dateTimePicker1.Text + "\n" + "Saat  : " + label6.Text);                 
                }
                else if (comboBox1.Text == "Ziraatbank" && int.Parse(comboBox2.Text) > 5)
                {
                    MessageBox.Show("Seçiminiz      : Ziraat Bankası" + "\n" + "Taksit Sayısı  : " + comboBox2.Text + "\n" +
                        textBox1.Text + " tl olan borcunuzu aylık " + (double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) + double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) * 0.02) + " tl olarak ödeyebilirsiniz." + "\n\n" +
                        "Tarih : " + dateTimePicker1.Text + "\n" + "Saat  : " + label6.Text);                
                }
                if (comboBox1.Text == "Diğer Kartlar")
                {
                    MessageBox.Show("Seçiminiz      : Diğer Kartlar" + "\n" + "Taksit Sayısı  : " + comboBox2.Text + "\n" +
                        textBox1.Text + " tl olan borcunuz aylık " + (double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) + double.Parse(textBox1.Text) / double.Parse(comboBox2.Text) * 0.02) + " tl olarak ödeyebilirsiniz." + "\n\n" +
                        "Tarih : " + dateTimePicker1.Text + "\n" + "Saat  : " + label6.Text);                
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBox1.Font = fontDialog1.Font;
                textBox1.ForeColor = fontDialog1.Color;
                textBox2.Font = fontDialog1.Font;
                textBox2.ForeColor = fontDialog1.Color;
                comboBox1.Font = fontDialog1.Font;
                comboBox1.ForeColor = fontDialog1.Color;
                comboBox2.Font = fontDialog1.Font;
                comboBox2.ForeColor = fontDialog1.Color;
                maskedTextBox1.Font = fontDialog1.Font;
                maskedTextBox1.ForeColor = fontDialog1.Color;
                dateTimePicker1.Font = fontDialog1.Font;
                dateTimePicker1.ForeColor = fontDialog1.Color;
                label6.Font = fontDialog1.Font;
                label6.ForeColor = fontDialog1.Color;
            }
            PrintDialog prd = new PrintDialog();
            {
                PrintDocument göster = new PrintDocument();
                DialogResult yazdirma;
                yazdirma = prd.ShowDialog();
                göster.PrintPage += Göster_PrintPage;

                if (yazdirma == DialogResult.OK)
                {
                    göster.Print();
                }
            }
        }
        private void Göster_PrintPage(object sender, PrintPageEventArgs e)
        {
            SolidBrush renk = new SolidBrush(fontDialog1.Color);
            e.Graphics.DrawString("Ürün fiyatı : " + textBox1.Text, textBox1.Font, renk, 200, 20);
            e.Graphics.DrawString("Ödeme : " + comboBox1.Text, comboBox1.Font, renk, 200, 60);
            e.Graphics.DrawString("Taksit : " + comboBox2.Text, comboBox2.Font, renk, 200, 100);
            e.Graphics.DrawString("Ad-Soyad : " + textBox2.Text, textBox2.Font, renk, 200, 140);
            e.Graphics.DrawString("Telefon : " + maskedTextBox1.Text, maskedTextBox1.Font, renk, 200, 180);
            e.Graphics.DrawString("Tarih : " + dateTimePicker1.Text, dateTimePicker1.Font, renk, 200, 220);
            e.Graphics.DrawString("Saat : " + label6.Text, label6.Font, renk, 200, 260);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Kayıt Yerinizi Seçiniz";
                saveFileDialog1.Filter = "(*.doc)|*.doc|(*.txt)|*.txt|Tüm dosyalar(*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.InitialDirectory = "C:\\";
                saveFileDialog1.ShowDialog();
                StreamWriter Kaydet = new StreamWriter(saveFileDialog1.FileName);
                Kaydet.WriteLine(textBox2.Text);
                Kaydet.Close();
                MessageBox.Show("Kaynak metin belgesine yazdırıldı.","BİLGİ");
            }
            catch
            {
                MessageBox.Show("Kaynak metin belgesine yazdırılmadı.","BİLGİ");
            }
        }
    }
}

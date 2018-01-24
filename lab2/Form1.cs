using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr4_katamaran
{
    public partial class Form1 : Form
    {
       Parking parking;
        public Form1()
        {
            InitializeComponent();

            parking = new Parking(5);

            for (int i = 1; i < 6; i++)
            {
                listBox1.Items.Add("Уровень " + i);
            }
            listBox1.SelectedIndex = parking.getCurrentLevel;
            Draw();
        }

        private void AddKatamaran(ITransport katamaran)
        {
            if (katamaran != null)
            {
                int place = parking.PutKatamaranInParking(katamaran);
                if (place > -1)
                {
                    Draw();
                    MessageBox.Show("Ваше место: " + place);
                }
                else
                {
                    MessageBox.Show("Катамаран не удалось поставить");
                }
            }
        }

        private void Draw()
        {
            if (listBox1.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                parking.Draw(gr, 1000, 200);
                pictureBox1.Image = bmp;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            parking.LevelDown();
            listBox1.SelectedIndex = parking.getCurrentLevel;
            Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parking.LevelUp();
            listBox1.SelectedIndex = parking.getCurrentLevel;
            Draw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                string level = listBox1.Items[listBox1.SelectedIndex].ToString();
                if (maskedTextBox1.Text != "")
                {
                    ITransport car = parking.GetKatamaranInParking(Convert.ToInt32(maskedTextBox1.Text));
                    if (car != null)
                    {
                        Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        car.SetPosition(30, 40);
                        car.drawKatamaran(gr);
                        pictureBox2.Image = bmp;
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Извинте, на этом месте нет тарантула");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var katamaran = new Katamaran(100, 4, 1000, dialog.Color);
                int place = parking.PutKatamaranInParking(katamaran);
                Draw();
                MessageBox.Show("Ваше место: " + place);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var Walk = new Walking(100, 4, 1000, dialog.Color, true, true, dialogDop.Color);
                    int place = parking.PutKatamaranInParking(Walk);
                    Draw();
                    MessageBox.Show("Ваше место: " + place);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr2_katamaran
{
    public partial class Form1 : Form
    {
        Color color;
        Color dopColor;
        int maxSpeed;
        int maxcountPassengers;
        int Weight;

        private ITransport inter;

        public Form1()
        {
            InitializeComponent();
            color = Color.Brown;
            dopColor =Color.Red;
            maxSpeed = 150;
            maxcountPassengers = 3;
            Weight = 1500;
            button1.BackColor = color;
            button2.BackColor = dopColor;
        }
        private bool checkFields()
        {

            if (!int.TryParse(textBox1.Text, out maxSpeed))
            {
                return false;
            }
            if (!int.TryParse(textBox2.Text, out Weight))
            {
                return false;
            }
            if (!int.TryParse(textBox3.Text, out maxcountPassengers))
            {
                return false;
            }
            return true;

        }

        private void Katamaran_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                inter = new Katamaran(maxSpeed,maxcountPassengers,Weight, color);
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                inter.drawKatamaran(gr);
                pictureBox1.Image = bmp;
            }

        }

        private void Walking_Click(object sender, EventArgs e)
        {

            if (checkFields())
            {
                inter = new Walking(maxSpeed, maxcountPassengers, Weight, color,
                    checkBox1.Checked, checkBox2.Checked, dopColor);
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                inter.drawKatamaran(gr);
                pictureBox1.Image = bmp;
            }

        }

        private void Dvig_Click(object sender, EventArgs e)
        {
            if (inter != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                inter.moveKatamaran(gr);
                pictureBox1.Image = bmp;
            }
        }

        private void Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                color = cd.Color;
                button1.BackColor = color;
            }
        }

        private void dopColor_Click(object sender, EventArgs e)
        {
        
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dopColor = cd.Color;
                button2.BackColor = dopColor;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

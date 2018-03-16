using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lr5_katamaran
{
    public partial class Form2 : Form
    {
        ITransport katamaran = null;

        public ITransport getKatamaran { get { return katamaran; } }

        private void DrawKatamaran()
        {
            if (katamaran != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gr = Graphics.FromImage(bmp);
                katamaran.SetPosition(30, 40);
                katamaran.drawKatamaran(gr);
                pictureBox1.Image = bmp;
            }
        }
        private event myDel eventAddKatamaran;

        public void AddEvent(myDel ev)
        {
            if (eventAddKatamaran == null)
            {
                eventAddKatamaran = new myDel(ev);
            }
            else
            {
                eventAddKatamaran += ev;
            }
        }

        public Form2()
        {
            InitializeComponent();
            Black.MouseDown += panelColor_MouseDown;
            White.MouseDown += panelColor_MouseDown;
            Red.MouseDown += panelColor_MouseDown;
            Blue.MouseDown += panelColor_MouseDown;
            Yellow.MouseDown += panelColor_MouseDown;
            Green.MouseDown += panelColor_MouseDown;
            Violet.MouseDown += panelColor_MouseDown;
            Greenish.MouseDown += panelColor_MouseDown;

            button2.Click += (object sender, EventArgs e) => { Close(); };
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor,
               DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void NormalKatamaran_MouseDown(object sender, MouseEventArgs e)
        {
            NormalKatamaran.DoDragDrop(NormalKatamaran.Text,
                DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void AddKatamaran_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный":
                    katamaran = new Katamaran(50, 5, 10, Color.Brown);
                    break;
                case "Прогулочный":
                    katamaran = new Walking(60, 7, 20, Color.Brown, true, true, Color.Red);
                    break;
            }
            DrawKatamaran();
        }

        private void AddKatamaran_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Walking_MouseDown(object sender, MouseEventArgs e)
        {
            Walking.DoDragDrop(Walking.Text,
                DragDropEffects.Move | DragDropEffects.Copy);
        }

       

        private void BaseColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void BaseColor_DragDrop(object sender, DragEventArgs e)
        {
            if (katamaran != null)
            {
                katamaran.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawKatamaran();
            }
        }

        private void DopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (katamaran != null)
            {
                if (katamaran is Walking)
                {
                    (katamaran as Walking).SetMainColor((Color)e.Data.GetData(typeof(Color)));
                    DrawKatamaran();
                }
            }
        }

        private void DopColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (eventAddKatamaran != null)
            {
                eventAddKatamaran(katamaran);
            }
            Close();
        }
    }
}

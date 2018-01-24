using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3_katamaran
{
    public class Walking : Katamaran
    {
        private Color dopcolor;
        private bool dopPassengers;
        private bool Lifebuoy;

        public Walking(int maxSpeed, int maxcountEaten, double weight,
            Color color, bool dopPassengers, bool Lifebuoy, Color dopcolor) :
            base(maxSpeed, maxcountEaten, weight, color)
        {
            this.dopPassengers = dopPassengers;
            this.Lifebuoy = Lifebuoy;
            this.dopcolor = dopcolor;
        }
        protected override void drawKatamaranNormal(Graphics g)
        {

            base.drawKatamaranNormal(g);
            Brush telo = new SolidBrush(ColorBody);
            g.FillRectangle(telo, startPosX - 10, startPosY - 20, 85, 60);
            Brush tel = new SolidBrush(Color.White);
            g.FillRectangle(tel, startPosX, startPosY - 10, 65, 40);
            Brush t = new SolidBrush(Color.Red);
            g.FillRectangle(t, startPosX + 10, startPosY - 5, 12, 12);
            g.FillRectangle(t, startPosX + 10, startPosY + 10, 12, 12);

            g.FillRectangle(t, startPosX + 30, startPosY - 5, 12, 12);
            g.FillRectangle(t, startPosX + 30, startPosY + 10, 12, 12);


            if (dopPassengers)
            {
                Brush t1 = new SolidBrush(dopcolor);
                g.FillRectangle(t1, startPosX + 50, startPosY - 5, 12, 12);
                g.FillRectangle(t1, startPosX + 50, startPosY + 10, 12, 12);

            }

            if (Lifebuoy)
            {
                Pen h = new Pen(Color.Orange, 4);
                g.DrawEllipse(h, startPosX - 10, startPosY, 12, 12);
            }

        }
    }
}

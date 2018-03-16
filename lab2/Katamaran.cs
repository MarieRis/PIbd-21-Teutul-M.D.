using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2_katamaran
{
    public class Katamaran:Lodka
    {
   

        public override int MaxSpeed
        {
            get
            {
                return base.MaxSpeed;
            }

            protected set
            {
                if (value > 0 && value < 200)
                {
                    base.MaxSpeed = value;
                }
                else
                {
                    base.MaxSpeed = 100;
                }

            }
        }

        public override int MaxcountPassengers
        {
            get
            {
                return base.MaxcountPassengers;
            }

            protected set
            {
                if (value > 0 && value < 3)
                {
                    base.MaxcountPassengers = value;
                }
                else
                {
                    base.MaxcountPassengers = 2;
                }

            }
        }
        public override double Weight
        {
            get
            {
                return base.Weight;
            }

            protected set
            {
                if (value > 10 && value < 90)
                {
                    base.Weight = value;
                }
                else
                {
                    base.Weight = 40;
                }
            }
        }

        public Katamaran(int maxSpeed, int maxcountPassengers, double weight, Color color)
        {
            this.MaxSpeed = maxSpeed;
            this.MaxcountPassengers = maxcountPassengers;
            this.Weight = weight;
            this.ColorBody = color;
            this.passengers = 0;
            Random rand = new Random();
            startPosX = rand.Next(10, 200);
            startPosY = rand.Next(10, 200);

        }

        public override void moveKatamaran(Graphics g)
        {
            startPosX += (MaxSpeed * 50 / (float)Weight);
            drawKatamaran(g);
        }

        public override void drawKatamaran(Graphics g)
        {
            drawKatamaranNormal(g);

        }
        protected virtual void drawKatamaranNormal(Graphics g)
        {
            Brush telo = new SolidBrush(ColorBody);
            g.FillRectangle(telo, startPosX, startPosY - 10, 65, 40);
            Brush tel = new SolidBrush(Color.White);
            g.FillRectangle(tel, startPosX+10, startPosY - 10, 45, 40);
            Brush te = new SolidBrush(ColorBody);
            g.FillRectangle(te, startPosX + 20, startPosY , 25, 20);
            
            Brush t = new SolidBrush(Color.Red);
            g.FillRectangle(t, startPosX + 30, startPosY, 8,8);
            g.FillRectangle(t, startPosX + 30, startPosY + 10, 8, 8);


        }
    }
}


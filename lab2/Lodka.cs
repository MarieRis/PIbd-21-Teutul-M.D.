using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr5_katamaran
{
    public abstract class Lodka : ITransport
    {
        protected int passengers;
        protected float startPosX;
        protected float startPosY;

        public virtual int MaxcountPassengers { protected set; get; }

        public virtual int MaxSpeed { protected set; get; }

        public Color ColorBody { protected set; get; }

        public virtual double Weight { protected set; get; }

        public abstract void moveKatamaran(Graphics g);

        public abstract void drawKatamaran(Graphics g);

        public void SetPosition(int x, int y)
        {
            startPosX = x;
            startPosY = y;
        }

        public void Passengers(int count)
        {
            if (passengers + count < MaxcountPassengers)
            {
                passengers += count;
            }
        }
        public int getPassengers()
        {
            int count = passengers;
            passengers = 0;
            return count;
        }

        public virtual void SetMainColor(Color color)
        {
            ColorBody = color;
        }
        public abstract string getInfo();
    }
}

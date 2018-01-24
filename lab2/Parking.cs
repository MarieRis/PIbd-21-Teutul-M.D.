using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3_katamaran
{
    class Parking
    {
        ClassArray<ITransport> parking;
        int countPlace = 10;
        int placeSizeWidht = 200;
        int placeSizeHeight = 100;

        public Parking()
        {
            parking = new ClassArray<ITransport>(countPlace, null);
        }

        public int PutKatamaranInParking(ITransport katamaran)
        {
            return parking + katamaran;
        }

        public ITransport GetKatamaranInParking(int ticket)
        {
            return parking - ticket;
        }
        public void Draw(Graphics g, int width, int heigth)
        {
            DrawMarking(g);
            for (int i = 0; i < countPlace; i++)
            {
                var katamaran = parking.getObject(i);
                if (katamaran != null)
                {
                    katamaran.SetPosition(5 + i / 5 * placeSizeWidht + 5, i % 5 * placeSizeHeight + 40);
                    katamaran.drawKatamaran(g);
                }
            }
        }
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawRectangle(pen, 0, 0, (countPlace / 5) * placeSizeWidht, 480);
            for (int i = 0; i < countPlace / 5; i++)
            {
                for (int j = 0; j < 6; ++j)
                {
                    g.DrawLine(pen, i * placeSizeWidht, j * placeSizeHeight,
                        i * placeSizeWidht + 110, j * placeSizeHeight);
                }
                g.DrawLine(pen, i * placeSizeWidht, 0, i * placeSizeWidht, 400);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr4_katamaran
{
    public class Parking
    {

        List<ClassArray<ITransport>> parkingStages;

        int countPlace = 10;
        int placeSizeWidht = 200;
        int placeSizeHeight = 100;

        int currentLevel;

        public int getCurrentLevel { get { return currentLevel; } }

        public void LevelUp()
        {
            if (currentLevel + 1 < parkingStages.Count)
            {
                currentLevel++;
            }
        }
        public void LevelDown()
        {
            if (currentLevel > 0)
            {
                currentLevel--;

            }
        }

        public Parking(int countStages)
        {
            parkingStages = new List<ClassArray<ITransport>>();
            for (int i = 0; i < countStages; i++)
            {
                parkingStages.Add(new ClassArray<ITransport>(countPlace, null));
            }
        }

        public int PutKatamaranInParking(ITransport katamaran)
        {
            return parkingStages[currentLevel] + katamaran;
        }

        public ITransport GetKatamaranInParking(int ticket)
        {
            return parkingStages[currentLevel] - ticket;
        }


        public void Draw(Graphics g, int width, int heigth)
        {
            DrawMarking(g);
            for (int i = 0; i < countPlace; i++)
            {
                var katamaran = parkingStages[currentLevel][i];
                if (katamaran != null)
                {
                    katamaran.SetPosition(5 + i / 5 * placeSizeWidht + 25, i % 5 * placeSizeHeight + 35);
                    katamaran.drawKatamaran(g);
                }
            }
        }



        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawString("L" + (currentLevel + 1), new Font("Arial", 30), new SolidBrush(Color.Blue),
                (countPlace / 5) * placeSizeWidht, 480);
            g.DrawRectangle(pen, 0, 0, (countPlace / 5) * placeSizeWidht, 480);
            for (int i = 0; i < countPlace / 5; i++)
            {
                for (int j = 0; j < 6; ++j)
                {
                    g.DrawLine(pen, i * placeSizeWidht, j * placeSizeHeight,
                        i * placeSizeWidht + 110, j * placeSizeHeight);
                    if (j < 5)
                    {
                        g.DrawString((i * 5 + j + 1).ToString(), new Font("Arial", 30), new SolidBrush(Color.Blue),
                            i * placeSizeWidht + 30, j * placeSizeHeight + 20);
                    }
                }
                g.DrawLine(pen, i * placeSizeWidht, 0, i * placeSizeWidht, 400);
            }
        }
    }
}

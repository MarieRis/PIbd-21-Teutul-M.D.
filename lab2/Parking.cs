using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr5_katamaran
{
    public class Parking
    {

        List<ClassArray<ITransport>> parkingStages;

        int countPlace = 10;
        int placeSizeWidht = 200;
        int placeSizeHeight = 100;

        int currentLevel;
       
    

        public bool SaveData(string filename)
        {

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {

                byte[] info = new UTF8Encoding(true).GetBytes("CountLeveles:" + parkingStages.Count + Environment.NewLine);
                fs.Write(info, 0, info.Length);
                foreach (var level in parkingStages)
                {

                    info = new UTF8Encoding(true).GetBytes("Level" + Environment.NewLine);
                    fs.Write(info, 0, info.Length);
                    for (int i=0; i < countPlace; i++)
                    {

                        var katamaran = level[i];
                        if(katamaran!=null)
                        {

                            if (katamaran.GetType().Name == "katamaran")
                            {

                                info = new UTF8Encoding(true).GetBytes("katamaran:");
                                fs.Write(info, 0, info.Length);
                            }
                            if (katamaran.GetType().Name == "walking")
                            {

                                info = new UTF8Encoding(true).GetBytes("walking:");
                                fs.Write(info, 0, info.Length);
                            }

                            info = new UTF8Encoding(true).GetBytes(katamaran.getInfo() + Environment.NewLine);
                            fs.Write(info, 0, info.Length);

                        }
                    } 
                }
            }
            return true;
        }

        public bool LoadData(string filename)
        {

            if (!File.Exists(filename))
            {
                return false;
            }

            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {

                string s = "";
                using (BufferedStream bs = new BufferedStream(fs))
                {

                    byte[] b = new byte[fs.Length];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (bs.Read(b, 0, b.Length) > 0)
                    {

                        s += temp.GetString(b);
                    }
                }

                s = s.Replace("\r", "");
                var strs = s.Split('\n');
                if (strs[0].Contains("CountLeveles"))
                {

                    int count = Convert.ToInt32(strs[0].Split(':')[1]);
                    if (parkingStages != null)
                    {

                        parkingStages.Clear();
                    }

                    parkingStages = new List<ClassArray<ITransport>>(count);
                }
                int counter = -1;
                for (int i = 1; i < strs.Length; i++)
                {
                    if (strs[i] == "level")
                    {

                        counter++;
                        parkingStages.Add(new ClassArray<ITransport>(countPlace, null));
                    }

                    if (strs[i].Split(':')[0] == "Katamaran")
                    {
                        ITransport katamaran = new Katamaran(strs[i].Split(':')[1]);
                        int number = parkingStages[counter] + katamaran;
                        if (number == -1)
                        {

                            return false;
                        }
                    }
                    else if (strs[i].Split(':')[0] == "Walking")
                    {
                        ITransport katamaran = new Walking(strs[i].Split(':')[1]);
                        int number = parkingStages[counter] + katamaran;
                        if (number == -1)
                        {


                            return false;
                        }
                    }

                }
                return true;
            }
        }



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

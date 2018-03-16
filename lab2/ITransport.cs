using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr5_katamaran
{
    public interface ITransport
    {
        void moveKatamaran(Graphics g);
        void drawKatamaran(Graphics g);
        void SetPosition(int x, int y);
        void Passengers(int count);
        int getPassengers();

        void SetMainColor(Color Color);

        string getInfo();
    }
}

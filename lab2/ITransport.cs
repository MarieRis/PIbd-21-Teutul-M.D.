using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2_katamaran
{
    interface ITransport
    {
        void moveKatamaran(Graphics g);
        void drawKatamaran(Graphics g);
        void SetPosition(int x, int y);
        void Passengers(int count);
        int getPassengers();

    }
}

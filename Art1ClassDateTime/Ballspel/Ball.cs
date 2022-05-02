using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballspel
{
    internal class Ball
    {
        public int GetX()
        { return x; }

        public int GetY()
        { return y; }
        private int x = 0;
            private int y = 0;
            protected int vx = 0;
            protected int vy = 0;
            protected char drawChar = 'O';
            protected ConsoleColor drawColor = ConsoleColor.Red;

            public Ball(int xin, int yin, int vxin, int vyin)
            {
                x = xin;
                y = yin;
                vx = vxin;
                vy = vyin;
            }

            public void Update()
            {
                x += vx;
                y += vy;
                if (x >= Console.WindowWidth || x < 0)
                {
                    vx *= -1;
                    x += vx;
                }
                if (y >= Console.WindowHeight || y < 0)
                {
                    vy *= -1;
                    y += vy;
                }
            }
            public void Draw()
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = drawColor;
                Console.Write(drawChar);
                Console.ResetColor();

            }

            static public bool CheckHit(Ball ball1, Ball ball2)
            {

                if (ball1.GetX() == ball2.GetX() && ball1.GetY() == ball2.GetY())
                    return true;

                return false;
            }
        
    }
}

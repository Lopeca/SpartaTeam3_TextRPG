using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class ConsoleCanvas
{
    public int height;
    public int width;

    char[,] buffer;
    ConsoleColor[,] colorBuffer;

    public ConsoleCanvas(int width, int height)
    {
        char[,] buffer = new char[width, height];
        ConsoleColor[,] colorBuffer = new ConsoleColor[width, height];
    }
    

    public void DrawTargetPos(char c, ConsoleColor color, int x, int y)
    {
        colorBuffer[y, x] = color;
        buffer[y, x] = c;
    }

    public void ShowBuffer()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = colorBuffer[y, x];
                Console.Write(buffer[y, x]);
            }
        }
    }
}


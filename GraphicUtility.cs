using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class GraphicUtility
{
    public static void DrawLine()
    {
        Console.WriteLine();
        Console.WriteLine("==============================================");
        Console.WriteLine();
    }

    public static void WriteRainbowText(string text)
    {
        char[] chars = text.ToCharArray();


        for(int i=0; i<chars.Length; i++)
        {
            switch (i % 6)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }
            Console.Write(chars[i]);
        }
        Console.ResetColor();
    }

    internal static void DrawByStringList(List<string> stringList, ConsoleColor color, int startX, int startY)
    {
        Console.ForegroundColor = color;
        int cursorY = startY;

        foreach (string str in stringList)
        {
            Console.SetCursorPosition(startX, cursorY);
            Console.Write(str);
            cursorY++;
        }

        Console.ResetColor();
    }
    public static void DrawRect(char c, int width, int height)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    if (x % 2 == 0)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(c);
                    }
                }
            }
        }
        Console.ResetColor();
    }
}


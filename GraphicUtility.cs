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

    public static void WriteColor(string str, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(str);
        Console.ResetColor();
    }
    // 문장을 쓰면 한 글자마다 색이 바뀌는 요란한 연출입니다. 캔버스씬을 로드하면 확인할 수 있어요
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

    // 참조를 타고 넘어가서 어떤식으로 쓰이는지 직접 보는 것이 사용하기 좋을 것 같습니다.
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
                    if (x % 2 == 0) // 2칸을 쓰는 문자를 위한 조건문입니다. 다른 방식이 필요하다면 함수를 복사해서 이부분 바꾸거나 이 함수를 커스텀해주세요
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


using System;

public class StartScreen
{
    public static string playerName; // 닉네임 입력한걸 저장
    public static void Show()
    {
        Console.WriteLine("Sparta Rpg Adventure에 오신 모험가님! 환영합니다~!");
        Console.WriteLine("원하시는 닉네임을 입력해 주세요");
        Console.WriteLine();
        playerName = Console.ReadLine(); // 닉네임 입력하면 저장할 수 있음

        Console.WriteLine();
        Console.WriteLine($"반갑습니다, {playerName} 님!");
        Console.WriteLine();
        Console.WriteLine("1. 게임 시작");
        Console.WriteLine("2. 종료");
        Console.WriteLine();
        Console.Write("메뉴를 선택하세요: ");

        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                JobSelectionScreen.Show(); // 직업 선택 화면 보여주기
                break;
            case "2":
                Console.WriteLine("게임을 종료합니다.");
                Environment.Exit(0); // 프로그램 종료
                break;
            default:
                Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                Console.ReadKey();
                Show(); // 다시 시작 화면
                break;
        }
    }
}

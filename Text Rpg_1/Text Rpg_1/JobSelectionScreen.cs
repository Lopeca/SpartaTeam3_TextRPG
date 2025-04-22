using System;

public class JobSelectionScreen
{
    public static void Show()
    {
        Console.Clear();        
        Console.WriteLine("직업을 선택하세요");
        Console.WriteLine();
        Console.WriteLine("1. 전사 - 거대한 대검과 갑옷으로 최전선에서 싸우는 상남자!");
        Console.WriteLine("2. 마법사 - 광범위한 공격이 특기인 화려하고 무자비한 클래스! ");
        Console.WriteLine("3. 도적 - 누구보다 속도가 빠른 직업. 빠른 연속 공격과 회피가 특기! ");
        Console.WriteLine("4. 연금술사 - 수상하게 생긴 물약과 마법 도구로 아군을 지원해주는 클래스!");
        Console.WriteLine("5. 프리스트 - 아군을 치유하고 보호해주는 든든한 버팀목!");
        Console.WriteLine();
        Console.Write("선택: ");

        string input = Console.ReadLine();
        Console.WriteLine();

        switch (input)
        {
            case "1":
                Console.WriteLine("전사를 선택하셨습니다!");
                break;
            case "2":
                Console.WriteLine("마법사를 선택하셨습니다!");
                break;
            case "3":
                Console.WriteLine("도적을 선택하셨습니다!");
                break;
            case "4":
                Console.WriteLine("연금술사를 선택하셨습니다!");
                break;
            case "5":
                Console.WriteLine("프리스트를 선택하셨습니다!");
                break;
            default:
                Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                Console.ReadKey();
                Show(); // 다시 선택 화면으로 돌아감
                return;
        }


        Console.WriteLine("아무 키나 누르면 계속합니다.");
        Console.ReadKey(); // 결과 보기 위해 잠깐 멈춤

        // 상점 페이지로 이동
        ShopScreen.Show();
    }
}

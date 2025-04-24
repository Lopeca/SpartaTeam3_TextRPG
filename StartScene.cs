using System;
using System.Collections.Generic;

public class Start : SceneBase
{
    public override void AddSelections()
    {
        selections.Add(new Menu("게임 시작", () =>
        {
            Console.WriteLine();
            Console.WriteLine("닉네임을 입력해주세요: ");
            Console.Write(">> ");
            string? name = Console.ReadLine();
            
            Game.Instance.player = new Player();
            Game.Instance.player.Name = name ?? "이름 없음";

            Console.WriteLine();
            Console.WriteLine($"반갑습니다, {name} 님!");
            Console.WriteLine("아무 키나 누르면 계속...");
            Console.ReadKey();

            Game.Instance.ChangeScene(new JobSelectionScene());
        }));

        selections.Add(new Menu("게임 종료", () =>
        {
            Console.WriteLine("\n게임을 종료합니다.");
            Environment.Exit(0);
        }));
    }

    public override void RenderCustomArea()
    {
        Console.WriteLine("========================================");
        Console.WriteLine(" Sparta RPG Adventure에 오신 것을 환영합니다!");
        Console.WriteLine("========================================");
    }
}

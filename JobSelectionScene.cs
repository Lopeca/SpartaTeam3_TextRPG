using System;

public class JobSelectionScene : SceneBase
{
    public override void AddSelections()
    {
        selections.Add(new Menu("전사 - 거대한 대검과 갑옷으로 최전선에서 싸우는 상남자!", () =>
        {
            Game.Instance.player.InitByClass(CharacterClass.Warrior);
            Console.WriteLine("전사를 선택하셨습니다!");
            Game.Instance.ChangeScene(new ShopScene());
        }));

        selections.Add(new Menu("마법사 - 광범위한 공격이 특기인 화려하고 무자비한 클래스!", () =>
        {
            Game.Instance.player.InitByClass(CharacterClass.Mage);
            Console.WriteLine("마법사를 선택하셨습니다!");
            Game.Instance.ChangeScene(new ShopScene());
        }));

        selections.Add(new Menu("궁수 - 정확한 사격과 기동력으로 적을 공략!", () =>
        {
            Game.Instance.player.InitByClass(CharacterClass.Archer);
            Console.WriteLine("궁수를 선택하셨습니다!");
            Game.Instance.ChangeScene(new ShopScene());
        }));

        selections.Add(new Menu("도적 - 빠른 연속 공격과 회피가 특기!", () =>
        {
            Game.Instance.player.InitByClass(CharacterClass.Assassin);
            Console.WriteLine("도적을 선택하셨습니다!");
            Game.Instance.ChangeScene(new ShopScene());
        }));
    }

    public override void RenderCustomArea()
    {
        Console.WriteLine("직업을 선택하세요:");
    }
}

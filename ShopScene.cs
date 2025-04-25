using System;

public class ShopScene : SceneBase
{
    public override void AddSelections()
    {
        selections.Add(new Menu("낡은 철 검 / 공격력 +9 / 초보자용 검", () =>
        {
            Console.WriteLine("낡은 철 검을 구매하셨습니다!");
        }));

        selections.Add(new Menu("덜그럭 거리는 마법 오브 / 주문력 +10", () =>
        {
            Console.WriteLine("마법 오브를 구매하셨습니다!");
        }));

        selections.Add(new Menu("녹슨 단검 / 공격력 +7", () =>
        {
            Console.WriteLine("녹슨 단검을 구매하셨습니다!");
        }));

        selections.Add(new Menu("소나무로 만든 활 / 공격력 +10", () =>
        {
            Console.WriteLine("소나무로 만든 활을 구매하셨습니다!");
        }));

    }

    public override void RenderCustomArea()
    {
        Console.WriteLine("어서오세요 모험가분들~ 없는 것 빼곤 다 있습니다~!");
        Console.WriteLine("이곳에서는 물품을 구매할 수 있습니다.\n");
    }
}

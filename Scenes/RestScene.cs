using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RestScene : SceneBase
{
    Player player = Game.Instance.player;
    public override void AddSelections()
    {
        selections.Add(new Menu("휴식하기 (50 G)", Rest));
    }

  

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        GraphicUtility.WriteTitle("여관");

        GraphicUtility.DrawLine();
        GraphicUtility.WriteWithColor("[여관 주인 시이]", ConsoleColor.DarkYellow);
        Console.WriteLine();
        Console.WriteLine(" \"어서오세요. 고양이는 좋아하시나요?\"");
        GraphicUtility.DrawLine();
        ShowSelections();
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들면 됩니다


    // 이건 예시, 상태 보기 씬을 만들 때
   
    private void Rest()
    {
        Console.WriteLine();
        Console.WriteLine("체력과 마나가 회복되었습니다. (엔터로 넘어갑니다)");

        player.CurrentHp = player.BaseHp;
        player.CurrentMp = player.BaseMp;

        Console.ReadLine();
        Init();

    }
}


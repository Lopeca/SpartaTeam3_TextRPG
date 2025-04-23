using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

public class IntroScene : SceneBase
{
    // 부모 SceneBase의 멤버변수 selections : 인터페이스 ISelectable의 리스트 
    public override void AddSelections()
    {
        selections.Add(new Menu("시작", () => Game.Instance.LoadScene(new ChooseCharacterScene())));
    }

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
       GraphicUtility.DrawRect('■', 79, 16);
        DrawTitleText();

        Console.WriteLine();
        GraphicUtility.DrawLine();

        ShowSelections();
    }

    private void DrawTitleText()
    {
        List<string> stringList =
        [
            "□□□  □□□  □  □  □□□",
            "  □    □      □  □    □  ",
            "  □    □□□    □      □  ",
            "  □    □      □  □    □  ",
            "  □    □□□  □  □    □  ",
        ];

        GraphicUtility.DrawByStringList(stringList, ConsoleColor.White, 10, 5);

        stringList =
            [
            "□□□ ",
            "□  □ ",
            "□□   ",
            "□  □ ",
            "□  □ ",
        ];

        GraphicUtility.DrawByStringList(stringList, ConsoleColor.Red, 44, 5);

        stringList =
           [
            "□□□ ",
            "□  □ ",
            "□□□ ",
            "□   ",
            "□   ",
        ];

        GraphicUtility.DrawByStringList(stringList, ConsoleColor.Blue, 52, 5);

        stringList =
          [
            "□□□ ",
            "□     ",
            "□  □ ",
            "□  □ ",
            "□□□",
        ];

        GraphicUtility.DrawByStringList(stringList, ConsoleColor.Green, 60, 5);

        Console.SetCursorPosition(34, 12);
        Console.Write("Team 3연벙");

        Console.SetCursorPosition(0, 17);
    }
   

}


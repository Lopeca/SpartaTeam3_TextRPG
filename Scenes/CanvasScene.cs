using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CanvasScene : SceneBase
{
    // 부모 SceneBase의 멤버변수 selections : 인터페이스 ISelectable의 리스트 
    public override void AddSelections()
    {

    }

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        Console.WriteLine("캔버스 씬입니다.\n");

        GraphicUtility.WriteRainbowText("그래픽 테스트\n Graphic Test\n");

        // ShowSelections();
    }

}


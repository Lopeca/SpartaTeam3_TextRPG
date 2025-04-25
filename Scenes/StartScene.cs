using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class StartScene : SceneBase
{

    
    public override void AddSelections()
    {
        Console.WriteLine($"현재 {BattleStartScene.CurrentFloor}층");

        selections.Add(new Menu("상태 보기", () => Game.Instance.LoadScene(new PlayerStatusScene())));
        selections.Add(new Menu("전투 시작", () => Game.Instance.LoadScene(new BattleStartScene())));
        selections.Add(new Menu("저장하기", () => Save()));

    }

    private void Save()
    {
        Game.Instance.Save();
        Game.Instance.messageLog = "저장되었습니다.";
        RenderScene();
    }

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {

        Console.WriteLine("========================================");
        Console.WriteLine(" Sparta RPG Adventure에 오신 것을 환영합니다!");
        Console.WriteLine("========================================");
        

        ShowSelections();
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들면 됩니다
}


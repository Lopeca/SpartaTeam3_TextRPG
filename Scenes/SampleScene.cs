﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SampleScene : SceneBase
{
    // 부모 SceneBase의 멤버변수 selections : 인터페이스 ISelectable의 리스트 

    public override void Init()
    {
        

    }
    public override void AddSelections()
    {
        selections.Add(new Menu("상태 보기", LoadStatusScene));

    }

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        Console.WriteLine("시작 씬입니다.\n");

        ShowSelections();
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들면 됩니다


    // 이건 예시, 상태 보기 씬을 만들 때
    public void LoadStatusScene()
    {
        // 상태 보기씬 만들어서 Game.Instance.LoadScene(new 만든 씬); 하면 됩니다
        // 그 외 커스텀 씬 만들 때 이런 느낌인 점 참고
        Console.WriteLine("상태 보기 대신에 출력되는 문장");
    }

    public void LoadBattleScene()
    {
        Console.WriteLine("전투 씬 대신에 출력되는 문장");
    }
}


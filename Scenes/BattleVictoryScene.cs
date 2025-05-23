﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3TextRPG.Scenes;
using Team3TextRPG;
using System.Security.Cryptography.X509Certificates;
public class BattleVictoryScene : SceneBase
{

    private List<Monster> defeatedMonsters;
    private int totalExp = 0;
    private int totalGold = 0;
    Player player = Game.Instance.player;
    bool hasLevelUp;

    public BattleVictoryScene(List<Monster> monsters)
    {
        
        player.CurrentDungeonFloor++;

        this.defeatedMonsters = monsters;
        hasLevelUp = false;
        CalculateRewards(); // 보상 계산
        ApplyRewards(); // 보상 적용
    }

    private void CalculateRewards()
    {
        totalExp = 0;
        totalGold = 0;

        foreach ( var monster in defeatedMonsters )
        {
            if (monster.IsDead)
            {
                totalExp += monster.Exp;
                totalGold += monster.DropGold;
            }
        }

    }

    private void ApplyRewards()
    {
        int prevLevel = player.Level;
        player.GainExp(totalExp);
        if (prevLevel != player.Level) hasLevelUp = true;
        player.Gold += totalGold;

    }


    // 부모 SceneBase의 멤버변수 selections : 인터페이스 ISelectable의 리스트 
    public override void AddSelections()
    {
        selections.Add(new Menu("다음 층 도전", () => Game.Instance.ChangeScene(new BattleStartScene())));
    }

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        Console.WriteLine("승리했습니다!");
        Console.WriteLine();
        Console.WriteLine("몬스터를 처치하여 보상을 획득했습니다.");
        Console.WriteLine();
        Console.WriteLine("[획득한 보상]");
        Console.Write($"경험치: {totalExp} ");
        if (hasLevelUp) GraphicUtility.WriteWithColor($"[ 레벨 업 ! (현재 레벨 : {player.Level}]", ConsoleColor.Magenta);
        Console.WriteLine();
        Console.WriteLine($"골드: {totalGold}G");
        Console.WriteLine();
        Console.WriteLine($"현재 {Game.Instance.player.CurrentDungeonFloor}층에 도달했습니다");
        Console.WriteLine();

        ShowSelections();
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들면 됩니다
}


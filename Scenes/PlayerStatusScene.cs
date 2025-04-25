using System;
using System.ComponentModel;
using System.Data.Common;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class PlayerStatusScene : SceneBase
{
    Player player => Game.Instance.player;
   
    public override void AddSelections() { }

    public override void RenderCustomArea()
    {
        GraphicUtility.WriteTitle("상태 보기");
        Console.WriteLine("\n캐릭터의 정보가 표시됩니다.");

        GraphicUtility.DrawLine();
        Console.WriteLine($"Lv. {player.Level}");
        Console.WriteLine($"{player.Name} ( {CharacterClassStr.GetClassString(player.CharacterClass)} )");
        Console.WriteLine();
        Console.WriteLine($"공격력 : {player.Atk}");
        Console.WriteLine($"방어력 : {player.Def}");
        Console.WriteLine($"체  력 : {player.CurrentHp} / {player.MaxHP}");
        Console.WriteLine($"경험치 : {player.currentExp} / {player.BaseExp}");
        Console.WriteLine($"Gold   : {player.Gold} G");
        GraphicUtility.DrawLine();
        Console.WriteLine();
    }
}
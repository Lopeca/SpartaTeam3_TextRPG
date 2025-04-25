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
   
    public override void AddSelections() {
        selections.Add(new Menu("장비", () => Game.Instance.LoadScene(new EquipInventoryScene())));
    }

    public override void RenderCustomArea()
    {
        GraphicUtility.WriteTitle("상태 보기");
        Console.WriteLine("\n캐릭터의 정보가 표시됩니다.");

        GraphicUtility.DrawLine();
        Console.WriteLine($"Lv. {player.Level}");
        Console.WriteLine($"{player.Name} ( {CharacterClassStr.GetKRString(player.CharacterClass)} )");
        Console.WriteLine();
        Console.Write($"공격력 : {player.Atk} ");
        if (player.BonusAtk != 0) GraphicUtility.WriteWithColor($" (+ {player.BonusAtk})", ConsoleColor.Green);
        Console.WriteLine();                                                                           
        Console.Write($"방어력 : {player.Def}");                                                       
        if (player.BonusDef != 0) GraphicUtility.WriteWithColor($" (+ {player.BonusDef})", ConsoleColor.Green);
        Console.WriteLine();
        Console.WriteLine($"체  력 : {player.CurrentHp} / {player.MaxHP}");
        Console.WriteLine($"마  나 : {player.CurrentMp} / {player.MaxMP}");
        Console.WriteLine($"경험치 : {player.CurrentExp} / {player.RequiredExp}");
        Console.WriteLine($"Gold   : {player.Gold} G");
        GraphicUtility.DrawLine();
        Console.WriteLine();

        ShowSelections();
    }
}
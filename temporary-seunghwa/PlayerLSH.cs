using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

public static class ChadStr
{
    public static readonly Dictionary<Chad, string> Map = new()
    {
        {Chad.Warrior, "전사" },
        { Chad.Mage, "마법사" },
        { Chad.Archer, "궁수" },
        { Chad.Assassin, "도적" }
    };

    public static string GetChadString(Chad chad)   // ChadStr.GetChadString(Chad chad)로 직업으로부터 문자열 얻을 수 있음
    {
        Map.TryGetValue(chad, out var result);
        return result;
    }
} 
public enum Chad
{
    Warrior,
    Mage,
    Archer,
    Assassin
}

[Serializable]
public class PlayerLSH
{
    public string Name { get; set; }

    public int level;
    public Chad chad;
    public int atk;
    public int def;
    public int hp;
    public int gold;

    public PlayerLSH()
    {
        Name = "";
        level = 1;
        gold = 1000;
    }

    
}


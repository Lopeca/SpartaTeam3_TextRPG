using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class CharacterClassStr
{
    public static readonly Dictionary<CharacterClass, string> Map = new()
    {
        {CharacterClass.Warrior, "전사" },
        { CharacterClass.Mage, "마법사" },
        { CharacterClass.Archer, "궁수" },
        { CharacterClass.Assassin, "도적" }
    };

    public static string GetClassString(CharacterClass cClass)   // ChadStr.GetChadString(Chad chad)로 직업으로부터 문자열 얻을 수 있음
    {
        Map.TryGetValue(cClass, out var result);
        return result;
    }
}
public enum CharacterClass
{
    Warrior,
    Mage,
    Archer,
    Assassin
}

[Serializable]
public class Player
{
    public string Name { get; set; }

    public int Level { get; set; }
    public CharacterClass CharacterClass { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int Gold { get; set; }

    public Player()
    {
        Name = "";
        Level = 1;
        Gold = 1000;
    }

    public void InitByClass(CharacterClass chClass)
    {
        CharacterClass = chClass;
        switch (chClass)
        {
            case CharacterClass.Warrior:
                Atk = 5;
                Def = 5;
                Hp = 150;
                break;
            default:
                Atk = 3;
                Def = 3;
                Hp = 100;
                break;
        }
    }
}


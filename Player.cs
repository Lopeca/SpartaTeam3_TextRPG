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

    public static string GetCharacterClassString(CharacterClass c)   
    // 오류때문에 ChadStr.GetChadString(Chad chad)를  GetCharacterClassString(CharacterClass c)로 수정
    {
        Map.TryGetValue(c, out var result);
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
public class Player
{
    public string Name { get; set; }

    public int level;
    public CharacterClass characterClass;
    public int atk;
    public int def;
    public int hp;
    public int gold;

    public Player()
    {
        Name = "";
        level = 1;
        gold = 1000;
    }

    public void InitByClass(CharacterClass chClass)
    {
        characterClass = chClass;

        switch (chClass)
        {
            case CharacterClass.Warrior:
                atk = 5;
                def = 5;
                hp = 150;
                break;

            case CharacterClass.Mage:
                atk = 10;
                def = 2;
                hp = 80;
                break;

            case CharacterClass.Archer:
                atk = 7;
                def = 4;
                hp = 100;
                break;

            case CharacterClass.Assassin:
                atk = 8;
                def = 3;
                hp = 90;
                break;

        }
    }
}


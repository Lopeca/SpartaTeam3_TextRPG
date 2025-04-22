using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class CharacterClassStr
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
        switch (chClass)
        {
            case CharacterClass.Warrior:    // 예시. 직업별 초기화를 어떻게 할지는 기획적인 영역으로
                atk = 5;
                def = 5;
                hp = 150;
                break;
        }
    }

}


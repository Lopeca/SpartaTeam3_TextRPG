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

// 세이브 기능을 위해서 모든 멤버변수(필드)가 이런 프로퍼티 형태로 될 필요가 있습니다
// 사실 뉴톤소프트라는 라이브러리를 설치하는 다른 방법도 있는데, 기본 C# 콘솔 프로젝트에서는 이런 이슈가 있다는 걸 한 번 부딪히는 것도 좋을 것 같습니다
// 유니티에서는 JsonUtility 라고 일반 public 직렬화도 잘 해주는 시스템을 주니까 원래 이런 문제가 있구나 하고 넘어가면 될 것 같아요
[Serializable]
public class Player
{
    public string Name { get; set; }

    public int Level { get; set; }
    public CharacterClass CharacterClass { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int BaseHp { get; set; }
    public int CurrentHp { get; set; }
    public int Gold { get; set; }

    public int Exp { get; set; }

    public List<int> ItemId { get; set; }

    // bonusHP는 나중에 아이템 추가 제거할 때 실시간 계산해서 넣을 변수입니다
    // 최대 체력 계산할 때마다 위의 아이템 리스트에서 꺼내오는 방법도 있지만 매번 연산해야할 게 많아지니까
    // 체력 옵션 붙은 아이템 추가/제거할 때나 처음 게임 로드할 때 실시간으로 계산해서 들고 있을 일종의 캐싱 목적 변수입니다
    private int bonusHP; 

    public int MaxHP => BaseHp + bonusHP;
    public Player()
    {
        Name = "";
        Level = 1;
        Gold = 1000;
        ItemId = [];
    }

    public void InitByClass(CharacterClass chClass)
    {
        CharacterClass = chClass;
        switch (chClass)
        {
            case CharacterClass.Warrior:
                Atk = 5;
                Def = 5;
                BaseHp = 150;
                CurrentHp = BaseHp;
                break;
            default:
                Atk = 3;
                Def = 3;
                BaseHp = 100;
                CurrentHp = BaseHp;
                break;
        }
    }
}


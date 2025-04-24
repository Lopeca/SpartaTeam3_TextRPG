using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3TextRPG;

public enum SkillTargetType
{
    Self,
    Enemy,
    AllEnemies      // '두 명을 공격한다' 같은 인구수 지정이 있으면 타입을 더 추가해서 쓰면 됩니다
}   
public abstract class Skill
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }

    public int Cost { get; protected set; }
    public SkillTargetType Type { get; protected set; } // 스킬 타입이 AllEnemies인지 조건 검사를 배틀씬에서, 조건이 맞으면 모든 몬스터에게 반복문 돌면서 Use 함수 호출하는 느낌으로

    public Skill(string name, string description, int cost, SkillTargetType type)
    {
        Name = name;
        Description = description;
        Cost = cost;
        Type = type;
    }

    public abstract void Use(Player player, Monster? mob = null);
}


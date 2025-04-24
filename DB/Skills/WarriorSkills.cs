using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3TextRPG;

public class Bonk : Skill
{
    // 타겟 지정 
    public Bonk(string name, string description, int cost) : base("통", "약간 더 집중한 일격", 10, SkillTargetType.Enemy)
    {
    }
    public override void Use(Player player, Monster? mob)
    {
        mob.CurrentHP -= 10;    // Monster에 TakeDamge함수를 만들거나, 이벤트 기반 시스템에 도전해보셔도 좋을 것 같습니다
                                // 적어도 여기서 방어력 계산을 하면 모든 스킬에 똑같은 방어력 계산 코드가 들어가서 그건 비추천합니다
    }
}

public class WaterSurfaceSlash : Skill
{
    // 타겟 지정 
    public WaterSurfaceSlash(string name, string description, int cost) : base("수면 베기", "물의 호흡 제 1형", 20, SkillTargetType.AllEnemies)
    {
    }
    public override void Use(Player player, Monster? mob)
    {
        mob.CurrentHP -= 10;
    }
}


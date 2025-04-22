using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_TEAM_P_TXT_2
{
    public class Monster
    {
        private MonsterData data;

        public string Name => data.name;
        public int Level => data.level;
        public int Atk => data.atk;
        public int Def => data.def;
        public int DropGold => data.dropGold;
        public int Exp => data.exp;

        public int CurrentHP { get; set; }
        public bool IsDead => CurrentHP <= 0;

        public Monster(MonsterData data)
        {
            this.data = data;
            this.CurrentHP = data.hp;
        }

        public override string ToString()
        {
            return $"Lv.{Level} {Name} HP {CurrentHP}/{data.hp}";
        }
    }

}

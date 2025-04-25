using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3TextRPG
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

        public void TakeDamage(int damage)
        {
            int resultDamage = damage - Def;
            CurrentHP -= resultDamage;
            if(CurrentHP < 0) CurrentHP = 0;
        }
        public override string ToString()
        {   
            return $"Lv.{Level} {Name} HP {CurrentHP}/{data.hp}";
        }
    }

}

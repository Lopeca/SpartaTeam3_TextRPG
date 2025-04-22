using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RG_TEAM_P_TXT_2;

namespace RG_TEAM_P_TXT_2.Scenes
{
    public class BattleScene : SceneBase
    {
        PlayerLSH player => Game.Instance.player;
        List<Monster> monsters = new List<Monster>();
        bool monstersGenerated = false; //몬스터가 최초 1회만 생성되게하는 코드의 일부.


        //어떤 선택지가 있는가
        public override void AddSelections()
        { 
            Game.Instance.messageLog = null; //기존의 메세지 초기화(캐릭터 생성됨 문구가 뜨길래요)여기보다 좋은 위치가 있다면 옮기겠습니다
            MonsterDB.MonsterInit(); //**매우 중요. 몬스터db의 비어있는 상태일 리스트를 작동해서 채우기.
            GenerateMonsters(); //전투 시작시 몬스터 등장
                                //실질 선택지는 아래부터
            selections.Clear();//혹시 남아있을지 모르는 다른 구문 치워버리기 
            selections.Add(new Menu("나가기", () => Game.Instance.LoadScene(new StartScene()))); 
            selections.Add(new Menu("공격", AttackPhase));
            
        }

        //씬에 실제로 출력되는 함수
        public override void RenderCustomArea()
        {

        ShowMonsterStatus();

            ShowPlayerStatus();
            {
                Console.WriteLine("\n[내정보]");//이거는 PlayerLSH cs 파일에서 아래의 정보들이 있게끔 조금 수정했습니다.
                Console.WriteLine($"Lv. {player.level} {player.Name} ({player.Job})");
                Console.WriteLine($"HP {player.currenthp} / {player.hp}");
            }
            Console.WriteLine();
            ShowSelections();
        }
        //몬스터생성
        void GenerateMonsters()
        {
            //monsters.Clear(); // 기존 몬스터 초기화

            if (monstersGenerated)
                return;

            monstersGenerated = true; // 최초 1회만 발동

            if (MonsterDB.monsterList.Count == 0)
            {
                Console.WriteLine("[ERROR] 몬스터 데이터가 비어 있습니다!");
                Console.ReadLine(); // 잠깐 멈춰서 확인
                return;
            }

            Random rand = new Random();
            int count = rand.Next(1, 5); // 1~4마리


            for (int i = 0; i < count; i++)
            {
                // MonsterDB에서 랜덤한 몬스터 데이터 하나 선택
                int index = rand.Next(0, MonsterDB.monsterList.Count);
                MonsterData data = MonsterDB.monsterList[index];

                // 그 데이터를 바탕으로 Monster 인스턴스 생성
                Monster monster = new Monster(data);

                monsters.Add(monster);
            }
        }
        void AttackPhase()
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();

            // 1. 몬스터 목록 다시 출력
            for (int i = 0; i < monsters.Count; i++)
            {
                string status = monsters[i].ToString();
                Console.WriteLine($"{i + 1}. {status}");
            }

            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv. {player.level} {player.Name} ({player.chad})");
            Console.WriteLine($"HP {player.hp}");

            Console.WriteLine();
            Console.WriteLine("0. 취소");
            Console.WriteLine();
            Console.WriteLine("대상을 선택해주세요.");

            // 2. 입력 받기
            while (true)
            {
                Console.Write(">> ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int index))
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                    continue;
                }

                if (index == 0)
                {
                    Game.Instance.CloseScene();
                    return;
                }

                if (index < 1 || index > monsters.Count)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }

                Monster target = monsters[index - 1];

                if (target.IsDead)
                {
                    Console.WriteLine("이미 죽은 몬스터입니다.");
                    continue;
                }

                // 3. 공격 처리
                int baseDamage = player.atk;
                double variation = baseDamage * 0.1;
                int min = (int)Math.Ceiling(baseDamage - variation);
                int max = (int)Math.Floor(baseDamage + variation + 1);

                Random rand = new Random();
                int finalDamage = rand.Next(min, max);

                target.CurrentHP -= finalDamage;

                Console.WriteLine();
                Console.WriteLine($"Chad의 공격!");
                Console.WriteLine($"Lv.{target.Level} {target.Name} 을(를) 맞췄습니다. [데미지 : {finalDamage}]");

                if (target.IsDead)
                {
                    Console.WriteLine($"\nLv.{target.Level} {target.Name}\nHP {target.CurrentHP + finalDamage} → Dead");
                }
                else
                {
                    Console.WriteLine($"\nLv.{target.Level} {target.Name}\nHP {target.CurrentHP + finalDamage} → {target.CurrentHP}");
                }

                Console.WriteLine();
                Console.WriteLine("0. 다음");
                Console.ReadLine();

                break;
            }

            EnemyPhase();


        }
        void EnemyPhase()
        {
            Console.Clear();
            Console.WriteLine("Enemy Phase\n");

            foreach (var monster in monsters)
            {
                if (monster.IsDead) continue;

                int damage = monster.Level * 2;
                player.hp -= damage;

                Console.WriteLine($"Lv.{monster.Level} {monster.Name}의 공격!");
                Console.WriteLine($"{player.Name}을(를) 맞췄습니다. [데미지 : {damage}]");
                Console.WriteLine($"현재 HP : {player.hp}\n");

                if (player.hp <= 0)
                {
                    player.hp = 0;
                    break;
                }

                Console.WriteLine("0. 다음");
                Console.ReadLine();
            }

            CheckGameEnd();
            // 승패가 결정되지 않았다면 → 다음 턴: 다시 플레이어의 선택 유도
            {
                if (player.hp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You Lose!");
                    Console.ReadLine();
                    Game.Instance.LoadScene(new StartScene());
                    return;
                }

                bool allDead = true;
                foreach (var m in monsters)
                {
                    if (!m.IsDead)
                    {
                        allDead = false;
                        break;
                    }
                }

                if (allDead)
                {
                    Console.Clear();
                    Console.WriteLine("Victory!");
                    Console.ReadLine();
                    Game.Instance.LoadScene(new StartScene());
                    return;
                }
                selections.Clear();
                AddSelections();     // 메뉴 재설정
                RenderScene();       // 전투씬 다시 그리기
            }
        }

        //몬스터 목록을 출력
        void ShowMonsterStatus()
        {
            Console.WriteLine("Battle!!\n");

            for (int i = 0; i < monsters.Count; i++)
            {
                string status = monsters[i].ToString();
                Console.WriteLine($"{i + 1}. {status}");
            }
        }



       
        void ShowPlayerStatus() { }
        //void AttackPhase() {  }
        //
        //void EnemyPhase() {  }
        void CheckGameEnd() {  }
    }



}

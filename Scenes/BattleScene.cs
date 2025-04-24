using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Team3TextRPG;

namespace Team3TextRPG.Scenes
{
    public class BattleScene : SceneBase
    {
        List<Monster> monsters;

        public BattleScene(List<Monster> monsters)
        {
            this.monsters = monsters;
        }

        Player player => Game.Instance.player; //아직은 여기서 임시로 플레이어 정보를 가져옴


        void ShowPlayerStatus()
        {
            Console.WriteLine("\n[내정보]");
            PrintPlayerStatus();
        }

        void PrintPlayerStatus()//이거는 PlayerLSH cs 파일에서 아래의 정보들이 있게끔 조금 수정했습니다.
        {
            Console.WriteLine($"Lv. {player.Level} {player.Name} ({player.CharacterClass})");
            Console.WriteLine($"HP {player.CurrentHp} / {player.BaseHp}");
        }
        // 기존 GenerateMonsters()는 더 이상 호출하지 않음
        // Init() 또는 AddSelections()에서 받은 monsters만 사용
        //어떤 선택지가 있는가
        public override void AddSelections()
        { 
            Game.Instance.messageLog = null; //기존의 메세지 초기화(캐릭터 생성됨 문구가 뜨길래요)여기보다 좋은 위치가 있다면 옮기겠습니다
            selections.Clear();//혹시 남아있을지 모르는 다른 구문 치워버리기 
            selections.Add(new Menu("도망친다", () =>
            {
                Game.Instance.ResetToStart();
                //Game.Instance.ChangeScene(new StartScene());
            }));
            //배틀 스타트씬으로 돌아가는 것마저 스킵하면서(실제론 거쳐가는 느낌) 시작화면으로 돌아가기 위한 수정
            selections.Add(new Menu("공격", AttackPhase));
            
        }

        //씬에 실제로 적용되는 함수
        public override void RenderCustomArea()
        {
            ShowMonsterStatus();
            ShowPlayerStatus();
            Console.WriteLine();
            ShowSelections();
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
            Console.WriteLine($"Lv. {player.Level} {player.Name} ({player.CharacterClass})");
            Console.WriteLine($"HP {player.CurrentHp} / {player.BaseHp}");
            Console.WriteLine();

            Console.WriteLine("0. 취소");
            Console.WriteLine("대상을 선택해주세요.");

            // 2. 입력 받기
            while (true)
            {
                Console.Write(">> ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int index)) 
                {
                    Console.WriteLine("잘못된 입력, 숫자를 입력해주세요.");
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
                int baseDamage = player.Atk;
                double variation = baseDamage * 0.1; //실제 공격에는 10%의 피해 증감량이 있음
                int min = (int)Math.Ceiling(baseDamage - variation);
                int max = (int)Math.Floor(baseDamage + variation + 1);
                int finalDamage = new Random().Next(min, max);

                target.CurrentHP -= finalDamage;

                Console.WriteLine();
                Console.WriteLine($"Chad의 공격!");
                Console.WriteLine($"Lv.{target.Level} {target.Name} 을(를) 맞췄습니다. [데미지 : {finalDamage}]");

                if (target.IsDead)//타겟이 죽으면 사망처리
                {
                    Console.WriteLine($"\nLv.{target.Level} {target.Name}\nHP {target.CurrentHP + finalDamage} → Dead");
                }
                else //타겟이 살면 현제 피통 감소량 반영
                {
                    Console.WriteLine($"\nLv.{target.Level} {target.Name}\nHP {target.CurrentHP + finalDamage} → {target.CurrentHP}");
                }

                Console.WriteLine();
                Console.WriteLine("0. 다음");
                Console.ReadLine();

                break;
            }

            EnemyPhase(); //상대 턴으로 넘어가기


        }
        void EnemyPhase() //몬스터의 공격
        {
            Console.Clear();
            Console.WriteLine("Enemy Phase\n");

            foreach (var monster in monsters)
            {
                if (monster.IsDead) continue;

                int damage = monster.Level * 2;
                player.CurrentHp -= damage;

                Console.WriteLine($"Lv.{monster.Level} {monster.Name}의 공격!");
                Console.WriteLine($"{player.Name}을(를) 맞췄습니다. [데미지 : {damage}]");
                Console.WriteLine($"현재 HP : {player.CurrentHp}\n");

                if (player.CurrentHp <= 0) //플레이어의 체력이 0이하로 내려갔는지 아닌지 체크
                {
                    player.CurrentHp = 0; // 플레이어 체력을 수치적으로 0으로 고정
                    break; //즉시 전투 루프종료. 그러면 패배페이즈로.
                }

                Console.WriteLine("0. 다음"); //살았으면 전투 속행
                Console.ReadLine();
            }

            CheckGameEnd();
            // 승패가 결정되지 않았다면 → 다음 턴: 다시 플레이어의 선택 유도
            {
                if (player.CurrentHp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("당신은 차디찬 던전에서 삶을 마감했다!");
                    Console.ReadLine();
                    Game.Instance.LoadScene(new StartScene()); //처음으로 돌아갑니다. 사실상 재시작이나 다름없습니다
                    return;
                }

                bool allDead = true; //모든 몬스터를 죽였는지 살펴 보기
                foreach (var m in monsters)
                {
                    if (!m.IsDead)
                    {
                        allDead = false; //하나라도 살아있으면 몬스터 '올 데드'는 거짓입니다
                        break;
                    }
                }

                if (allDead) //몬스터를 모두 죽였으면 발생
                {
                    Console.Clear();
                    Console.WriteLine("전투 승리!");
                    Console.ReadLine();
                    Game.Instance.LoadScene(new StartScene()); //처음으로 돌아갑니다. 깎인 체력은 유지됩니다!!!
                    
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



       
        //void ShowPlayerStatus() { }
        //void AttackPhase() {  }
        //
        //void EnemyPhase() {  }
        void CheckGameEnd() {  }
    }



}

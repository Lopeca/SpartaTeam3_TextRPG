using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Team3TextRPG;
using static System.Net.Mime.MediaTypeNames;

namespace Team3TextRPG.Scenes
{
    public class BattleScene : SceneBase
    {
        List<Monster> monsters;
        Player player => Game.Instance.player; //아직은 여기서 임시로 플레이어 정보를 가져옴

        public BattleScene(List<Monster> monsters)
        {
            this.monsters = monsters;
        }

        void ShowPlayerStatus()
        {
            Console.WriteLine("\n[내정보]");
            PrintPlayerStatus();
        }

        void PrintPlayerStatus()
        {
            Console.WriteLine($"Lv. {player.Level} {player.Name} ({CharacterClassStr.GetKRString(player.CharacterClass)})");
            Console.WriteLine($"HP {player.CurrentHp} / {player.BaseHp}");
        }
        // Init() 또는 AddSelections()에서 받은 monsters만 사용
        //어떤 선택지가 있는가
        public override void AddSelections()
        {
            //배틀 스타트씬으로 돌아가는 것마저 스킵하면서(실제론 거쳐가는 느낌) 시작화면으로 돌아가기 위한 수정
            selections.Add(new Menu("공격", AttackPhase));
            if (selections[0] is Menu quitMenu)
            {
                quitMenu.ChangeName("도망친다");
            }            
            //selections.Add(new Menu("도망친다", () =>
            //{
            //    Game.Instance.CloseScene();
            //    //Game.Instance.ChangeScene(new StartScene());
            //}));           
        }

        //씬에 실제로 적용되는 함수
        public override void RenderCustomArea()
        {
            GraphicUtility.WriteTitle("전투");
            ShowMonsterStatus();
            ShowPlayerStatus();
            Console.WriteLine();
            ShowSelections();
        }
        
        void AttackPhase()
        {

            Console.Clear();
            GraphicUtility.WriteTitle("전투 - 공격");

            GraphicUtility.DrawLine();
            // 1. 몬스터 목록 다시 출력
            for (int i = 0; i < monsters.Count; i++)
            {
                string status = monsters[i].ToString();
                GraphicUtility.WriteWithColor($"{i + 1}. ", ConsoleColor.Green);
                GraphicUtility.WriteWithColor(status, monsters[i].IsDead ? ConsoleColor.DarkGray : ConsoleColor.White);
                Console.WriteLine();
            }

            GraphicUtility.DrawLine();

           
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv. {player.Level} {player.Name} ({CharacterClassStr.GetKRString(player.CharacterClass)})");
            Console.WriteLine($"HP {player.CurrentHp} / {player.BaseHp}");
            Console.WriteLine();

            GraphicUtility.WriteWithColor("0. ", ConsoleColor.Red);
            Console.WriteLine("취소\n");
            Console.WriteLine("대상을 선택해주세요.");

            // 입력 받기
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
                    RefreshSelections();
                    AddSelections();     // 메뉴 재설정
                    RenderScene();       // 전투씬 다시 그리기
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

                // 공격 처리
                Random random = new Random();
                bool Gamnabit = random.Next(0, 100) < 10;       // 10% 확률로 회피
                bool isCritical = !Gamnabit && random.Next(0, 100) < 15; // 회피가 아닐 때 15% 확률로 치명타

                int baseDamage = player.Atk;
                double variation = baseDamage * 0.1; //실제 공격에는 10%의 피해 증감량이 있음
                int min = (int)Math.Ceiling(baseDamage - variation);
                int max = (int)Math.Floor(baseDamage + variation + 1);
                int finalDamage = new Random().Next(min, max + 1);

                if (Gamnabit)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{player.Name}의 공격!");
                    Console.WriteLine($"Lv.{target.Level} {target.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.\n");
                    Console.WriteLine("<<아무 키나 눌러 계속>>");
                    Console.ReadLine();

                    EnemyPhase(); // 회피 후 바로 상대에게 턴을 넘긴다
                    return; // 회피 발생 시 이후 공격 로직 중단
                }
                
                if (isCritical)
                {
                    finalDamage = (int)Math.Ceiling(finalDamage * 1.6); // 치명타는 160% 데미지
                }

                int targetPrevHp = target.CurrentHP;
                target.TakeDamage(finalDamage);
                int appliedDamage = finalDamage - target.Def;
               
                Console.Clear();
                Console.WriteLine($"{Game.Instance.player.Name}의 공격!");
                Console.Write($"Lv.{target.Level} {target.Name} 을(를) 맞췄습니다. ");
                GraphicUtility.WriteWithColor($"[대미지 : {finalDamage}]{(isCritical ? " - 치명타 공격!!" : "")}\n", ConsoleColor.Red);

                if (target.IsDead)//타겟이 죽으면 사망처리
                {
                    Console.WriteLine($"\nLv.{target.Level} {target.Name}\nHP {targetPrevHp} → Dead");
                }
                else //타겟이 살면 현제 피통 감소량 반영
                {
                    Console.WriteLine($"\nLv.{target.Level} {target.Name}\nHP {targetPrevHp} → {target.CurrentHP}");
                }

                Console.WriteLine();
                Console.WriteLine("(엔터) 다음");
                Console.ReadLine();
                break;
            }
            EnemyPhase(); //상대 턴으로 넘어가기

        }
        void EnemyPhase() //몬스터의 공격
        {
            
            Console.Clear();
            GraphicUtility.WriteTitle("전투 - 상대 턴");

            foreach (var monster in monsters)
            {
                if (monster.IsDead) continue;

                int damage = monster.Atk;

                int prevHp = player.CurrentHp;
                player.TakeDamage(damage);

                Console.WriteLine($"Lv.{monster.Level} {monster.Name}의 공격!");
                Console.Write($"{player.Name}을(를) 맞췄습니다. ");
                GraphicUtility.WriteWithColor($"[대미지 : {prevHp - player.CurrentHp}]\n", ConsoleColor.Red);
                Console.WriteLine($"현재 HP : {player.CurrentHp}\n");

                if (player.CurrentHp <= 0) //플레이어의 체력이 0이하로 내려갔는지 아닌지 체크
                {
                    player.CurrentHp = 0; // 플레이어 체력을 수치적으로 0으로 고정
                    Console.WriteLine($"현재 HP : 0 (사망)\n"); //사망했음을 고지
                    Console.WriteLine("<<아무 키나 눌러 계속>>");//사망 문구 스킵이 안되게끔 배치
                    Console.ReadLine();
                    break; //즉시 전투 로직 종료. 그러면 패배페이즈로.
                }

                Console.WriteLine("(엔터) 다음"); //살았으면 전투 속행
                Console.ReadLine();
            }

        void CheckGameEnd() { }
            CheckGameEnd();
            // 승패가 결정되지 않았다면 → 다음 턴: 다시 플레이어의 선택 유도
            {
                if (player.CurrentHp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("당신은 차디찬 던전에서 삶을 마감했다!");
                    Console.ReadLine();
                    Game.Instance.CloseScene(); //처음으로 돌아갑니다. 사실상 재시작이나 다름없습니다
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
                    //Console.Clear();
                    //Console.WriteLine("전투 승리!");
                    //Console.ReadLine();
                    Game.Instance.ChangeScene(new BattleVictoryScene(monsters)); //처음으로 돌아갑니다. 깎인 체력은 유지됩니다!!!
                    
                    return;
                }
                RefreshSelections();
                AddSelections();     // 메뉴 재설정
                RenderScene();       // 전투씬 다시 그리기
            }
        }

        //몬스터 목록을 출력
        void ShowMonsterStatus()
        {
            
            //Console.WriteLine("[ Battle!! ]\n");
            GraphicUtility.DrawLine();
            for (int i = 0; i < monsters.Count; i++)
            {
                string status = monsters[i].ToString();
                GraphicUtility.WriteWithColor(status + "\n", monsters[i].IsDead ? ConsoleColor.DarkGray : ConsoleColor.White);
            }
            GraphicUtility.DrawLine();
        }
    }
}

using Team3TextRPG.Scenes;
using Team3TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

public class BattleStartScene : SceneBase
{
    Player player => Game.Instance.player;
    public static int CurrentFloor = 1; // 현재 층
    List<MonsterData> selectedMonsters = new List<MonsterData>();//류건)위치를 RenderCustomArea()에서 밖으로 뺐습니다. 이 씬에서 생성된 몹 정보를 배틀씬에서 받아가기 위해
    public override void AddSelections() //류건)배틀씬으로 가기 위한 코드들을 넣었습니다
    {
        
        selections.Add(new Menu("전투 시작", () =>
        {
            // MonsterData → Monster 로 변환해서 BattleScene에 넘김
            List<Monster> monsters = selectedMonsters
                .Select(md => new Monster(md))
                .ToList();

            Game.Instance.ChangeScene(new BattleScene(monsters));
        }));
        
        /*selections.Add(new Menu("공격", LoadBattleAttackScene));*/ // 공격 씬 호출
    }

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        MonsterDB.MonsterInit();
        GraphicUtility.WriteTitle($"현재 {CurrentFloor}층");

        Console.WriteLine("\n몬스터가 나타났다!\n");
        Random random = new Random();
        int monsterCount = random.Next(1, 4+CurrentFloor);
        selectedMonsters.Clear(); // 류건)'배틀 스타트 씬'이 열릴때마다 몬스터를 매번 새로 생성
        //List<MonsterData> selectedMonsters = new List<MonsterData>(); 류건)맨 위로 빼갔습니다.이건 변경사항 착오 없으시기 위해 잔흔으로 주석화했습니다.


        for (int i = 0; i < monsterCount; i++) //몬스터 선택
        {
            int maxMonsterLv = Math.Min((int)(2 + ((1.5) * CurrentFloor)), MonsterDB.monsterList.Count);
            int minMonsterLv = Math.Min((int)(((1.5) * CurrentFloor) - 1),MonsterDB.monsterList.Count);
           
            
                int randomIndex = random.Next(minMonsterLv, maxMonsterLv);

                selectedMonsters.Add(MonsterDB.monsterList[randomIndex]);
            

        }

        //랜덤 선택된 몬스터 출력
        for (int i = 0; i < selectedMonsters.Count; i++)
        {
            Console.WriteLine($"Lv.{selectedMonsters[i].level} {selectedMonsters[i].name} Hp {selectedMonsters[i].hp}");
        }

        Console.WriteLine();
        Console.WriteLine();

        ////내정보 출력 (레벨,이름,직업, 체력)
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv. {player.Level} {player.Name} ({player.CharacterClass})");
        Console.WriteLine($"HP {player.CurrentHp} / {player.BaseHp} ");
        Console.WriteLine();
        ShowSelections();
    }
}


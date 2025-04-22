using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BattleStart : SceneBase
{
    public override void AddSelections()
    {

        selections.Add(new Menu("공격", LoadBattleAttackScene)); // 공격 씬 호출
    }

    // 씬에 실제로 출력되는 함수는 여기, SceneBase에서 이 함수 후에 종료 버튼과 입력을 알아서 묻습니다.
    public override void RenderCustomArea()
    {
        Console.WriteLine("Battle Start!!\n");
        Random random = new Random();
        int monsterCount = random.Next(1, 5);
        List<MonsterData> selectedMonsters = new List<MonsterData>();


        for (int i = 0; i < monsterCount; i++) //몬스터 선택
        {
            int randomIndex = random.Next(0, MonsterDB.monsterList.Count);
            selectedMonsters.Add(MonsterDB.monsterList[randomIndex]);
        }

        //랜덤 선택된 몬스터 출력
        for (int i = 0; i < selectedMonsters.Count; i++)
        {
            Console.WriteLine($"{selectedMonsters[i].monsterLv} {selectedMonsters[i].name} {selectedMonsters[i].monsterHP}");
        }

        Console.WriteLine();
        Console.WriteLine();

        //내정보 출력 (레벨,이름,직업, 체력)
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{player.Lv} {player.Name} ({player.playerClass");
        Console.WriteLine($"{player.playerHp}/{player.playerMaxhp}");

        ShowSelections();
    }

    // 씬 안에서 쓰는 메서드를 밑에 자유롭게 만들 됩니다


        // 이건 예시, 상태 보기 씬을 만들 때
    public void LoadStatusScene()
    {
        // 상태 보기씬 만들어서 Game.Instance.LoadScene(new 만든 씬); 하면 됩니다
        // 그 외 커스텀 씬 만들 때 이런 느낌인 점 참고
        Console.WriteLine("상태 보기 대신에 출력되는 문장");
    }

    public void LoadBattleScene()
    {
        Console.WriteLine("전투 씬 대신에 출력되는 문장");
    }
}

